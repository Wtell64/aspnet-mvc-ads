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
  public class CityManager : ICityService
  {
    private readonly ICityDal _cityDal;
    private readonly IMapper _mapper;
    private readonly IValidator<City> _validator;

    public CityManager(ICityDal cityDal, IMapper mapper, IValidator<City> validator)
    {
      _cityDal = cityDal;
      _mapper = mapper;
      _validator = validator;
    }
    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, City>(dto);

        _cityDal.Add(entity);
        return new SuccessDataResult<TDto>(dto, Messages.CityAdded);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public async Task<IDataResult<TDto>> AddAsync<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, City>(dto);

        await _cityDal.AddAsync(entity);
        return new SuccessDataResult<TDto>(dto, Messages.CityAdded);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IResult Any(Expression<Func<City, bool>> filter)
    {
      try
      {
        var any = _cityDal.Any(filter);

        if (any == true)
          return new SuccessResult(Messages.NoCity);

        return new ErrorResult();
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<City, bool>> filter)
    {
      try
      {
        var count = _cityDal.CountWhere(filter);
        return new SuccessDataResult<int>(count);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<int>(e.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<City, bool>> filter)
    {
      try
      {
        var count = await _cityDal.CountWhereAsync(filter);
        return new SuccessDataResult<int>(count);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<int>(e.Message);
      }
    }

    public IResult Delete<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, City>(dto);
        _cityDal.Delete(entity);
        return new SuccessDataResult<City>(Messages.CityDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<City>(e.Message);
      }
    }

    public IResult DeleteById(int id)
    {
      try
      {
        _cityDal.DeleteById(id);
        return new SuccessDataResult<City>(Messages.CityDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<City>(e.Message);
      }
    }

    public IDataResult<TDto> FindById<TDto>(int id)
    {
      try
      {
        return new SuccessDataResult<TDto>(_mapper.Map<City, TDto>(_cityDal.FindById(id)));
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public async Task<IDataResult<TDto>> FindByIdAsync<TDto>(int id)
    {
      try
      {
        var page = await _cityDal.FindByIdAsync(id);
        var pageDto = _mapper.Map<City, TDto>(page);
        return new SuccessDataResult<TDto>(pageDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<City, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = _cityDal.Get(filter, includeProperties);
        var pagetDto = _mapper.Map<City, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.CityNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<City, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = await _cityDal.GetAsync(filter, includeProperties);
        var pagetDto = _mapper.Map<City, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.CityNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<City, bool>> filter = null, Func<IQueryable<City>, IOrderedQueryable<City>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = _cityDal.GetList(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<City, TDto>(e)).ToList();
        if (dto == null)
        {
          return new ErrorDataResult<IEnumerable<TDto>>(Messages.ListEmpty);
        }
        return new SuccessDataResult<IEnumerable<TDto>>(dto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<IEnumerable<TDto>>(e.Message.ToString());
      }
    }

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<City, bool>> filter = null, Func<IQueryable<City>, IOrderedQueryable<City>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = await _cityDal.GetListAsync(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<City, TDto>(e)).ToList();
        if (dto == null)
        {
          return new ErrorDataResult<IEnumerable<TDto>>(Messages.ListEmpty);
        }
        return new SuccessDataResult<IEnumerable<TDto>>(dto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<IEnumerable<TDto>>(e.Message.ToString());
      }
    }

    public IResult Save()
    {
      try
      {
        _cityDal.Save();
        return new SuccessResult(Messages.CityAdded);
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public async Task<IResult> SaveAsync()
    {
      try
      {
        await _cityDal.SaveAsync();
        return new SuccessResult(Messages.CityAdded);
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IResult Update<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, City>(dto);

        _cityDal.Update(entity);
        return new SuccessDataResult<TDto>(dto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<ValidationResult> Validate<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<City>(dto);

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

