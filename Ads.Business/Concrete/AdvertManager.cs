using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Dal.Abstract;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using App.Core.Utilities.Results;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Ads.Business.Concrete
{
  public class AdvertManager : IAdvertService
  {
    private readonly IMapper _mapper;
    private readonly IValidator<Advert> _validator;
    private readonly IAdvertDal _advertDal;
    private readonly ISubcategoryAdvertDal _subcategoryAdvertDal;
    private readonly UserManager<AppUser> _userManager;

    public AdvertManager(IAdvertDal advertDal, IMapper mapper, IValidator<Advert> validator, ISubcategoryAdvertDal categoryAdvertDal, UserManager<AppUser> userManager)
    {
      _advertDal = advertDal;
      _mapper = mapper;
      _validator = validator;
			_subcategoryAdvertDal = categoryAdvertDal;
      _userManager = userManager;
    }
    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<Advert>(dto);



        var validationResult = _validator.Validate(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }

        _advertDal.Add(entity);



        return new SuccessDataResult<TDto>(dto, Messages.AdvertAdded);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public IDataResult<TDto> AddAdvertSubcategory<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<SubcategoryAdvert>(dto);

				_subcategoryAdvertDal.Add(entity);

        return new SuccessDataResult<TDto>(dto, Messages.SubcategoryAdvertAdded);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public async Task<IDataResult<TDto>> AddAdvertSubcategoryAsync<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<SubcategoryAdvert>(dto);

        await _subcategoryAdvertDal.AddAsync(entity);

        return new SuccessDataResult<TDto>(dto, Messages.SubcategoryAdvertAdded);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public  IDataResult<TDto> DeleteAdvertSubcategory<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<SubcategoryAdvert>(dto);

        _subcategoryAdvertDal.Delete(entity);

        return new SuccessDataResult<TDto>(dto, Messages.SubcategoryAdvertAdded);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public IDataResult<TDto> AddAndSave<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<Advert>(dto);




        var validationResult = _validator.Validate(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }

        _advertDal.Add(entity);
        _advertDal.Save();
        Advert advert = _advertDal.GetLastAddedEntity();

        var newAdded = _mapper.Map<TDto>(advert);

        return new SuccessDataResult<TDto>(newAdded, Messages.AdvertAdded);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public async Task<IDataResult<TDto>> AddAndSaveAsync<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<Advert>(dto);


        
        var validationResult = await _validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }

        _advertDal.Add(entity);
        _advertDal.Save();
        Advert advert = _advertDal.GetLastAddedEntity();

        var newAdded = _mapper.Map<TDto>(advert);

        return new SuccessDataResult<TDto>(newAdded, Messages.AdvertAdded);
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
        var entity = _mapper.Map<Advert>(dto);



        var validationResult = await _validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }

        _advertDal.Add(entity);


        return new SuccessDataResult<TDto>(dto, Messages.AdvertAdded);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public IResult Any(Expression<Func<Advert, bool>> filter)
    {
      try
      {
        var anyResult = _advertDal.Equals(filter);

        if (anyResult)
        {
          return new SuccessResult(Messages.AdvertFound);
        }

        else
        {
          return new ErrorResult(Messages.AdvertNotFound);
        }
      }
      catch (Exception ex)
      {

        return new ErrorResult(ex.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<Advert, bool>> filter)
    {
      try
      {
        var count = _advertDal.CountWhere(filter);

        return new SuccessDataResult<int>(count, Messages.CountFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<int>(ex.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<Advert, bool>> filter)
    {
      try
      {
        var count = await _advertDal.CountWhereAsync(filter);

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
        var entity = _mapper.Map<Advert>(dto);

        var validationResult = _validator.Validate(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }

        _advertDal.Delete(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AdvertDeleted);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(dto, ex.Message);
      }
    }

    public IResult DeleteSubcategory<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<SubcategoryAdvert>(dto);

        _subcategoryAdvertDal.Delete(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertDeleted);
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
        var entity = _advertDal.FindById(id);



        _advertDal.Delete(entity);
        return new SuccessDataResult<Advert>(entity, Messages.AdvertDeleted);
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
        var entity = _advertDal.FindById(id);

        var dto = _mapper.Map<Advert, TDto>(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AdvertFound);
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
        var entity = await _advertDal.FindByIdAsync(id);

        var dto = _mapper.Map<Advert, TDto>(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AdvertFound);
      }
      catch (Exception ex)
      {
        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<Advert, bool>> filter, string includeProperties = "")
    {
      try
      {
        var entity = _advertDal.Get(filter, includeProperties);

        var dto = _mapper.Map<Advert, TDto>(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Advert, bool>> filter, string includeProperties = "")
    {
      try
      {
        var entity = await _advertDal.GetAsync(filter, includeProperties);

        var dto = _mapper.Map<Advert, TDto>(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Advert, bool>> filter = null, Func<IQueryable<Advert>, IOrderedQueryable<Advert>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var entities = _advertDal.GetList(filter, orderBy, includeProperties);

        var dtos = _mapper.Map<IEnumerable<Advert>, IEnumerable<TDto>>(entities);

        return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.AdvertFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<IEnumerable<TDto>>(ex.Message);
      }
    }

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Advert, bool>> filter = null, Func<IQueryable<Advert>, IOrderedQueryable<Advert>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var entities = await _advertDal.GetListAsync(filter, orderBy, includeProperties);

        var dtos = _mapper.Map<IEnumerable<Advert>, IEnumerable<TDto>>(entities);

        return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.AdvertFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<IEnumerable<TDto>>(ex.Message);
      }
    }

    public async Task<IDataResult<IEnumerable<TDto>>> GetSubcategoryListAsync<TDto>(Expression<Func<SubcategoryAdvert, bool>> filter = null, Func<IQueryable<SubcategoryAdvert>, IOrderedQueryable<SubcategoryAdvert>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var entities = await _subcategoryAdvertDal.GetListAsync(filter, orderBy, includeProperties);

        var dtos = _mapper.Map<IEnumerable<SubcategoryAdvert>, IEnumerable<TDto>>(entities);

        return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.AdvertFound);
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
        var result = _advertDal.Save();
        if (result != 0)
        {
          return new SuccessResult(Messages.AdvertSaved);
        }

        return new ErrorResult(Messages.AdvertNotSaved);
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
        var result = await _advertDal.SaveAsync();
        if (result != 0)
        {
          return new SuccessResult(Messages.AdvertSaved);
        }

        return new ErrorResult(Messages.AdvertNotSaved);
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
        var entity = _mapper.Map<TDto, Advert>(dto);

        var validationResult = _validator.Validate(entity);

        if (!validationResult.IsValid)
        {
          return new ErrorResult(Messages.ValidationResultNull);
        }

        _advertDal.Update(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertUpdated);
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
        var entity = _mapper.Map<Advert>(dto);

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
