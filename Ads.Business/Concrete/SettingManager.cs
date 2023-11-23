using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework;
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
  public class SettingManager : ISettingService
  {
    private readonly ISettingDal _settingDal;
    private readonly IMapper _mapper;
    private readonly IValidator<Setting> _validator;

    public SettingManager(ISettingDal settingDal, IMapper mapper, IValidator<Setting> validator)
    {
      _settingDal = settingDal;
      _mapper = mapper;
      _validator = validator;
    }

    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, Setting>(dto);
        _settingDal.Add(entity);
        return new SuccessDataResult<TDto>(dto, Messages.CategoryAdded);
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
        var entity = _mapper.Map<TDto, Setting>(dto);
        await _settingDal.AddAsync(entity);
        return new SuccessDataResult<TDto>(dto, Messages.CategoryAdded);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IResult Any(Expression<Func<Setting, bool>> filter)
    {
      try
      {
        var any = _settingDal.Any(filter);

        if (any == true)
          return new SuccessResult("");

        return new ErrorResult();
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<Setting, bool>> filter)
    {
      try
      {
        var count = _settingDal.CountWhere(filter);
        return new SuccessDataResult<int>(count);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<int>(e.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<Setting, bool>> filter)
    {
      try
      {
        var count = await _settingDal.CountWhereAsync(filter);
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
        var entity = _mapper.Map<Setting>(dto);
        _settingDal.Delete(entity);
        return new SuccessDataResult<TDto>(dto, Messages.SettingDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IResult DeleteById(int id)
    {
      try
      {       
        var entity = _settingDal.FindById(id);
        if (entity == null)
        {
          return new ErrorResult(Messages.SettingNotFound);
        }
        _settingDal.Delete(entity);
        return new SuccessResult(Messages.SettingDeleted);
        
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IDataResult<TDto> FindById<TDto>(int id)
    {
      try
      {
        var entity = _settingDal.FindById(id);

        if (entity == null)
        {
          return new ErrorDataResult<TDto>("Kayıt bulunamadı");
        }

        var dto = _mapper.Map<Setting, TDto>(entity);

        return new SuccessDataResult<TDto>(dto, "Kayıt bulundu");
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
        var entity = await _settingDal.FindByIdAsync(id);

        if (entity == null)
        {
          return new ErrorDataResult<TDto>("Kayıt bulunamadı");
        }

        var dto = _mapper.Map<Setting, TDto>(entity);

        return new SuccessDataResult<TDto>(dto, "Kayıt bulundu");
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<Setting, bool>> filter, string includeProperties = "")
    {
      try
      {
        var setting = _settingDal.Get(filter, includeProperties);
        var settingDto = _mapper.Map<Setting, TDto>(setting);
        if (settingDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.SettingNotFound);
        }
        return new SuccessDataResult<TDto>(settingDto);
      }
      catch(Exception e) 
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }
    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Setting, bool>> filter, string includeProperties = "")
    {
      try
      {
        var setting = await _settingDal.GetAsync(filter, includeProperties);
        var settingDto = _mapper.Map<Setting, TDto>(setting);
        if (settingDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.SettingNotFound);
        }
        return new SuccessDataResult<TDto>(settingDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Setting, bool>> filter = null, Func<IQueryable<Setting>, IOrderedQueryable<Setting>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var settingList = _settingDal.GetList(filter, orderBy, includeProperties);
        var dto = settingList.Select(e => _mapper.Map<Setting, TDto>(e)).ToList();
        if (dto == null)
        {
          return new ErrorDataResult<IEnumerable<TDto>>("Gösterilecek birşey yok");
        }
        return new SuccessDataResult<IEnumerable<TDto>>(dto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<IEnumerable<TDto>>(e.Message.ToString());
      }
    }

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Setting, bool>> filter = null, Func<IQueryable<Setting>, IOrderedQueryable<Setting>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var settingList = await _settingDal.GetListAsync(filter, orderBy, includeProperties);
        var dto = settingList.Select(e => _mapper.Map<Setting, TDto>(e)).ToList();
        if (dto == null)
        {
          return new ErrorDataResult<IEnumerable<TDto>>("Gösterilecek birşey yok.");
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
        _settingDal.Save();
        return new SuccessResult(Messages.SuccessfullySaved);
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
        await _settingDal.SaveAsync();
        return new SuccessResult(Messages.SuccessfullySaved);
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
        var entity = _mapper.Map<Setting>(dto);
        _settingDal.Update(entity);
        return new SuccessDataResult<TDto>(dto, Messages.SettingUpdated);
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
        var entity = _mapper.Map<Setting>(dto);

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
