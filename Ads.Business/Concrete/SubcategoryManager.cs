using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Dal.Abstract;
using Ads.Entities.Concrete;
using App.Core.Utilities.Results;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Concrete
{
	public class SubcategoryManager : ISubcategoryService
	{
		private readonly ISubcategoryDal _subcategoryDal;
		private readonly IMapper _mapper;
		private readonly IValidator<Subcategory> _validator;

		public SubcategoryManager(ISubcategoryDal subcategoryDal, IMapper mapper, IValidator<Subcategory> validator)
		{
			_subcategoryDal = subcategoryDal;
			_mapper = mapper;
			_validator = validator;
		}


		public IDataResult<TDto> Add<TDto>(TDto dto)
		{
			try
			{
				var entity = _mapper.Map<Subcategory>(dto);

				var validationResult = _validator.Validate(entity);
				if (!validationResult.IsValid)
				{
					return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
				}

				_subcategoryDal.Add(entity);


				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryAdded);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public async Task<IDataResult<TDto>> AddAsync<TDto>(TDto dto)
		{
			try
			{
				var entity = _mapper.Map<Subcategory>(dto);

				var validationResult = await _validator.ValidateAsync(entity);
				if (!validationResult.IsValid)
				{
					return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
				}

				await _subcategoryDal.AddAsync(entity);


				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryAdded);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public IResult Any(Expression<Func<Subcategory, bool>> filter)
		{
			try
			{
				var anyResult = _subcategoryDal.Equals(filter);

				if (anyResult)
				{
					return new SuccessResult(Messages.SubcategoryFound);
				}

				else
				{
					return new ErrorResult(Messages.SubcategoryNotFound);
				}
			}
			catch (Exception ex)
			{

				return new ErrorResult(ex.Message);
			}
		}

		public IDataResult<int> CountWhere(Expression<Func<Subcategory, bool>> filter)
		{
			try
			{
				var count = _subcategoryDal.CountWhere(filter);

				return new SuccessDataResult<int>(count, Messages.CountFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<int>(ex.Message);
			}
		}

		public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<Subcategory, bool>> filter)
		{
			try
			{
				var count = await _subcategoryDal.CountWhereAsync(filter);

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
				var entity = _mapper.Map<Subcategory>(dto);

				var validationResult = _validator.Validate(entity);
				if (!validationResult.IsValid)
				{
					return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
				}

				_subcategoryDal.Delete(entity);
				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryDeleted);
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
				var entity = _subcategoryDal.FindById(id);



				_subcategoryDal.Delete(entity);
				return new SuccessDataResult<Subcategory>(entity, Messages.SubcategoryDeleted);
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
				var entity = _subcategoryDal.FindById(id);

				var dto = _mapper.Map<Subcategory, TDto>(entity);
				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryFound);
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
				var entity = await _subcategoryDal.FindByIdAsync(id);

				var dto = _mapper.Map<Subcategory, TDto>(entity);
				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public IDataResult<TDto> Get<TDto>(Expression<Func<Subcategory, bool>> filter, string includeProperties = "")
		{
			try
			{
				var entity = _subcategoryDal.Get(filter, includeProperties);

				var dto = _mapper.Map<Subcategory, TDto>(entity);

				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Subcategory, bool>> filter, string includeProperties = "")
		{
			try
			{
				var entity = await _subcategoryDal.GetAsync(filter, includeProperties);

				var dto = _mapper.Map<Subcategory, TDto>(entity);

				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryFound);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<TDto>(ex.Message);
			}
		}

		public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Subcategory, bool>> filter = null, Func<IQueryable<Subcategory>, IOrderedQueryable<Subcategory>> orderBy = null, string includeProperties = "")
		{
			try
			{
				var entities = _subcategoryDal.GetList(filter, orderBy, includeProperties);

				var dtos = _mapper.Map<IEnumerable<Subcategory>, IEnumerable<TDto>>(entities);

				return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.SubcategoryListed);
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<IEnumerable<TDto>>(ex.Message);
			}
		}

		public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Subcategory, bool>> filter = null, Func<IQueryable<Subcategory>, IOrderedQueryable<Subcategory>> orderBy = null, string includeProperties = "")
		{
			try
			{
				var entities = await _subcategoryDal.GetListAsync(filter, orderBy, includeProperties);

				var dtos = _mapper.Map<IEnumerable<Subcategory>, IEnumerable<TDto>>(entities);

				return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.SubcategoryListed);
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
				var result = _subcategoryDal.Save();
				if (result != 0)
				{
					return new SuccessResult(Messages.SaveSuccess);
				}

				return new ErrorResult(Messages.SaveFailed);
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
				var result = await _subcategoryDal.SaveAsync();
				if (result != 0)
				{
					return new SuccessResult(Messages.SaveSuccess);
				}

				return new ErrorResult(Messages.SaveFailed);
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
				var entity = _mapper.Map<TDto, Subcategory>(dto);

				//var validationResult = _validator.Validate(entity);

				//if (!validationResult.IsValid)
				//{
				//	return new ErrorResult(Messages.ValidationResultNull);
				//}

				_subcategoryDal.Update(entity);

				return new SuccessDataResult<TDto>(dto, Messages.SubcategoryUpdated);
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
				var entity = _mapper.Map<Subcategory>(dto);

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
