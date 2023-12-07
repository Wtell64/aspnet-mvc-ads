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
  public class AdvertImageManager : IAdvertImageService
  {
    private readonly IMapper _mapper;
    private readonly IValidator<AdvertImage> _validator;
    private readonly IAdvertImageDal _advertImageDal;


    public AdvertImageManager(IAdvertImageDal advertImageDal, IMapper mapper, IValidator<AdvertImage> validator)
    {
      _advertImageDal = advertImageDal;
      _mapper = mapper;
      _validator = validator;

    }

    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<AdvertImage>(dto);

        

        var validationResult = _validator.Validate(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }
        _advertImageDal.Add(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageAdded);
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
        var entity = _mapper.Map<AdvertImage>(dto);

        var validationResult = await _validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }
        _advertImageDal.Add(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageAdded);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(dto, ex.Message);
      }
    }

    public IResult Any(Expression<Func<AdvertImage, bool>> filter)
    {
      try
      {
        var anyResult = _advertImageDal.Equals(filter);

        if (anyResult)
        {
          return new SuccessResult(Messages.AdvertImageFound);
        }

        else
        {
          return new ErrorResult(Messages.AdvertImageNotFound);
        }
      }
      catch (Exception ex)
      {

        return new ErrorResult(ex.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<AdvertImage, bool>> filter)
    {
      try
      {
        var count = _advertImageDal.CountWhere(filter);

        return new SuccessDataResult<int>(count, Messages.CountFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<int>(ex.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<AdvertImage, bool>> filter)
    {
      try
      {
        var count = await _advertImageDal.CountWhereAsync(filter);

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
        var entity = _mapper.Map<AdvertImage>(dto);

        var validationResult = _validator.Validate(entity);
        if (!validationResult.IsValid)
        {
          return new ErrorDataResult<TDto>(dto, Messages.ValidationResultNull);
        }

        _advertImageDal.Delete(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageDeleted);
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
        var entity = _advertImageDal.FindById(id);

        _advertImageDal.Delete(entity);

        return new SuccessDataResult<AdvertImage>(entity, Messages.AdvertImageDeleted);
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
        var entity = _advertImageDal.FindById(id);

        var dto = _mapper.Map<AdvertImage, TDto>(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageFound);
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
        var entity = await _advertImageDal.FindByIdAsync(id);

        var dto = _mapper.Map<AdvertImage, TDto>(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<AdvertImage, bool>> filter, string includeProperties = "")
    {
      try
      {
        var entity = _advertImageDal.Get(filter, includeProperties);

        var dto = _mapper.Map<AdvertImage, TDto>(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<AdvertImage, bool>> filter, string includeProperties = "")
    {
      try
      {
        var entity = await _advertImageDal.GetAsync(filter, includeProperties);

        var dto = _mapper.Map<AdvertImage, TDto>(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<TDto>(ex.Message);
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<AdvertImage, bool>> filter = null, Func<IQueryable<AdvertImage>, IOrderedQueryable<AdvertImage>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var entities = _advertImageDal.GetList(filter, orderBy, includeProperties);

        var dtos = _mapper.Map<IEnumerable<AdvertImage>, IEnumerable<TDto>>(entities);

        return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.AdvertImageFound);
      }
      catch (Exception ex)
      {

        return new ErrorDataResult<IEnumerable<TDto>>(ex.Message);
      }
    }

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<AdvertImage, bool>> filter = null, Func<IQueryable<AdvertImage>, IOrderedQueryable<AdvertImage>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var entities = await _advertImageDal.GetListAsync(filter, orderBy, includeProperties);

        var dtos = _mapper.Map<IEnumerable<AdvertImage>, IEnumerable<TDto>>(entities);

        return new SuccessDataResult<IEnumerable<TDto>>(dtos, Messages.AdvertImageFound);
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
        var result = _advertImageDal.Save();
        if (result != 0)
        {
          return new SuccessResult(Messages.AdvertImageSaved);
        }

        return new ErrorResult(Messages.AdvertImageNotSaved);
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
        var result = await _advertImageDal.SaveAsync();
        if (result != 0)
        {
          return new SuccessResult(Messages.AdvertImageSaved);
        }

        return new ErrorResult(Messages.AdvertImageNotSaved);
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
        var entity = _mapper.Map<TDto, AdvertImage>(dto);

        var validationResult = _validator.Validate(entity);

        if (!validationResult.IsValid)
        {
          return new ErrorResult(Messages.ValidationResultNull);
        }

        _advertImageDal.Update(entity);

        return new SuccessDataResult<TDto>(dto, Messages.AdvertImageUpdated);
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
        var entity = _mapper.Map<AdvertImage>(dto);

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
