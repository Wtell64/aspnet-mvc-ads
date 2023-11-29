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
  public class DistrictManager : IDistrictService
  {
    private readonly IDistrictDal _districtDal;
    private readonly IMapper _mapper;
    private readonly IValidator<District> _validator;

    public DistrictManager(IDistrictDal districtDal, IMapper mapper, IValidator<District> validator)
    {
      _districtDal = districtDal;
      _mapper = mapper;
      _validator = validator;
    }
    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, District>(dto);

        _districtDal.Add(entity);
        return new SuccessDataResult<TDto>(dto, Messages.DistrictAdded);
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
        var entity = _mapper.Map<TDto, District>(dto);

        await _districtDal.AddAsync(entity);
        return new SuccessDataResult<TDto>(dto, Messages.DistrictAdded);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IResult Any(Expression<Func<District, bool>> filter)
    {
      try
      {
        var any = _districtDal.Any(filter);

        if (any == true)
          return new SuccessResult(Messages.NoDistrict);

        return new ErrorResult();
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<District, bool>> filter)
    {
      try
      {
        var count = _districtDal.CountWhere(filter);
        return new SuccessDataResult<int>(count);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<int>(e.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<District, bool>> filter)
    {
      try
      {
        var count = await _districtDal.CountWhereAsync(filter);
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
        var entity = _mapper.Map<TDto, District>(dto);
        _districtDal.Delete(entity);
        return new SuccessDataResult<District>(Messages.DistrictDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<District>(e.Message);
      }
    }

    public IResult DeleteById(int id)
    {
      try
      {
        _districtDal.DeleteById(id);
        return new SuccessDataResult<District>(Messages.DistrictDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<District>(e.Message);
      }
    }

    public IDataResult<TDto> FindById<TDto>(int id)
    {
      try
      {
        return new SuccessDataResult<TDto>(_mapper.Map<District, TDto>(_districtDal.FindById(id)));
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
        var page = await _districtDal.FindByIdAsync(id);
        var pageDto = _mapper.Map<District, TDto>(page);
        return new SuccessDataResult<TDto>(pageDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<District, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = _districtDal.Get(filter, includeProperties);
        var pagetDto = _mapper.Map<District, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.DistrictNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<District, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = await _districtDal.GetAsync(filter, includeProperties);
        var pagetDto = _mapper.Map<District, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.DistrictNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<District, bool>> filter = null, Func<IQueryable<District>, IOrderedQueryable<District>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = _districtDal.GetList(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<District, TDto>(e)).ToList();
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

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<District, bool>> filter = null, Func<IQueryable<District>, IOrderedQueryable<District>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = await _districtDal.GetListAsync(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<District, TDto>(e)).ToList();
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
        _districtDal.Save();
        return new SuccessResult(Messages.DistrictAdded);
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
        await _districtDal.SaveAsync();
        return new SuccessResult(Messages.DistrictAdded);
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
        var entity = _mapper.Map<TDto, District>(dto);

        _districtDal.Update(entity);
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
        var entity = _mapper.Map<District>(dto);

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
