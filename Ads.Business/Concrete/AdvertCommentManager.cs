using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Dal.Abstract;
using Ads.Entities.Concrete;
using App.Core.Utilities.Results;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace Ads.Business.Concrete
{
	public class AdvertCommentManager : IAdvertCommentService
	{
		private readonly IMapper _mapper;
		private readonly IValidator<AdvertComment> _validator;
		private readonly IAdvertDal _advertDal;
		private readonly IAdvertCommentDal _advertCommentDal;

		public AdvertCommentManager(IAdvertDal advertDal, IAdvertCommentDal advertCommentDal, IMapper mapper, IValidator<AdvertComment> validator)
		{
			_advertDal = advertDal;
			_mapper = mapper;
			_validator = validator;
			_advertCommentDal = advertCommentDal;
		}

		public IDataResult<TDto> Add<TDto>(TDto dto)
		{
			try
			{
				var entity = _mapper.Map<AdvertComment>(dto);

				var validationResult = _validator.Validate(entity);
				if (!validationResult.IsValid)
				{
					return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
				}
				_advertCommentDal.Add(entity);

				return new SuccessDataResult<TDto>(dto, Messages.AdvertAdded);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(dto, ex.Message);
			}
		}

		public async Task<IDataResult<TDto>> AddAsync<TDto>(TDto dto)
		{
			try
			{
				var entity = _mapper.Map<AdvertComment>(dto);

				var validationResult = await _validator.ValidateAsync(entity);
				if (!validationResult.IsValid)
				{
					return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
				}
				_advertCommentDal.Add(entity);

				return new SuccessDataResult<TDto>(dto, Messages.AdvertAdded);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(dto, ex.Message);
			}
		}

		public IResult Any(Expression<Func<AdvertComment, bool>> filter)
		{
			try
			{
				var anyResult = _advertCommentDal.Equals(filter);

				if (anyResult)
				{
					return new SuccessResult(Messages.AdvertCommentFound);
				}

				else
				{
					return new ErrorResult(Messages.AdvertCommentNotFound);
				}
			}
			catch (Exception ex)
			{

				return new ErrorResult(ex.Message);
			}
		}

		public IDataResult<int> CountWhere(Expression<Func<AdvertComment, bool>> filter)
		{
			try
			{
				var count = _advertCommentDal.CountWhere(filter);

				return new SuccessDataResult<int>(count, Messages.CountFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<int>(ex.Message);
			}
		}

		public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<AdvertComment, bool>> filter)
		{
			try
			{
				var count = await _advertCommentDal.CountWhereAsync(filter);

				return new SuccessDataResult<int>(count, Messages.CountFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<int>(ex.Message);
			}
		}

		public IResult Delete<TDto>(TDto dto)
		{
			try
			{
				var entity = _mapper.Map<AdvertComment>(dto);

				var validationResult = _validator.Validate(entity);
				if (!validationResult.IsValid)
				{
					return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
				}

				_advertCommentDal.Delete(entity);
				return new SuccessDataResult<TDto>(dto, Messages.AdvertCommentDeleted);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(dto, ex.Message);
			}
		}



		public IResult DeleteById(int id)
		{
			try
			{

				var entity = _advertCommentDal.FindById(id);

				_advertCommentDal.Delete(entity);

				return new SuccessDataResult<AdvertComment>(entity, Messages.AdvertCommentDeleted);
			}
			catch (Exception ex)
			{

				return new ErrorResult(ex.Message);
			}
		}

		public IDataResult<TDto> FindById<TDto>(int id)
		{
			try
			{
				var entity = _advertCommentDal.FindById(id);

				var dto = _mapper.Map<AdvertComment, TDto>(entity);
				return new SuccessDataResult<TDto>(dto, Messages.AdvertCommentFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public async Task<IDataResult<TDto>> FindByIdAsync<TDto>(int id)
		{
			try
			{
				var entity = await _advertCommentDal.FindByIdAsync(id);

				var dto = _mapper.Map<AdvertComment, TDto>(entity);
				return new SuccessDataResult<TDto>(dto, Messages.AdvertCommentFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public IDataResult<TDto> Get<TDto>(Expression<Func<AdvertComment, bool>> filter, string includeProperties = "")
		{
			try
			{
				var entity = _advertCommentDal.Get(filter, includeProperties);

				var dto = _mapper.Map<AdvertComment, TDto>(entity);

				return new SuccessDataResult<TDto>(dto, Messages.AdvertCommentFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<AdvertComment, bool>> filter, string includeProperties = "")
		{
			try
			{
				var entity = await _advertCommentDal.GetAsync(filter, includeProperties);

				var dto = _mapper.Map<AdvertComment, TDto>(entity);

				return new SuccessDataResult<TDto>(dto, Messages.AdvertCommentFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<AdvertComment, bool>> filter = null, Func<IQueryable<AdvertComment>, IOrderedQueryable<AdvertComment>> orderBy = null, string includeProperties = "")
		{
			try
			{
				var entities = _advertCommentDal.GetList(filter, orderBy, includeProperties);

				var dtos = _mapper.Map<IEnumerable<AdvertComment>, IEnumerable<TDto>>(entities);

				return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.AdvertCommentFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<IEnumerable<TDto>>(ex.Message);
			}
		}

		public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<AdvertComment, bool>> filter = null, Func<IQueryable<AdvertComment>, IOrderedQueryable<AdvertComment>> orderBy = null, string includeProperties = "")
		{
			try
			{
				var entities = await _advertCommentDal.GetListAsync(filter, orderBy, includeProperties);

				var dtos = _mapper.Map<IEnumerable<AdvertComment>, IEnumerable<TDto>>(entities);

				return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.AdvertCommentFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<IEnumerable<TDto>>(ex.Message);
			}
		}

		public IResult Save()
		{
			try
			{
				var result = _advertCommentDal.Save();
				if (result != 0)
				{
					return new SuccessResult(Messages.AdvertCommentSaved);
				}

				return new ErrorResult(Messages.AdvertCommentNotSaved);
			}
			catch (Exception ex)
			{
				return new ErrorResult(ex.Message);

			}
		}

		public async Task<IResult> SaveAsync()
		{
			try
			{
				var result = await _advertCommentDal.SaveAsync();
				if (result != 0)
				{
					return new SuccessResult(Messages.AdvertCommentSaved);
				}

				return new ErrorResult(Messages.AdvertCommentNotSaved);
			}
			catch (Exception ex)
			{
				return new ErrorResult(ex.Message);

			}
		}

		public IResult Update<TDto>(TDto dto)
		{
			try
			{
				var entity = _mapper.Map<TDto, AdvertComment>(dto);

				var validationResult = _validator.Validate(entity);

				if (!validationResult.IsValid)
				{
					return new ErrorResult(Messages.ValidationResultNull);
				}

				_advertCommentDal.Update(entity);

				return new SuccessDataResult<TDto>(dto, Messages.AdvertCommentUpdated);
			}
			catch (Exception ex)
			{

				return new ErrorResult(ex.Message);
			}
		}

		public IDataResult<ValidationResult> Validate<TDto>(TDto dto)
		{
			try
			{
				var entity = _mapper.Map<AdvertComment>(dto);

				var validationResult = _validator.Validate(entity);

				if (validationResult == null)
					return new ErrorDataResult<ValidationResult>(Messages.ValidationResultNull);

				return new SuccessDataResult<ValidationResult>(validationResult);

			}
			catch (Exception e)
			{
				return new ErrorDataResult<ValidationResult>(e.Message);
			}
		}
	}
}
