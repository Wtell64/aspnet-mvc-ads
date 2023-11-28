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
  public class AddressManager : IAddressService
  {
    private readonly IAddressDal _addressDal;
    private readonly IMapper _mapper;
    private readonly IValidator<Address> _validator;

    public AddressManager(IAddressDal addressDal, IMapper mapper, IValidator<Address> validator)
    {
      _addressDal = addressDal;
      _mapper = mapper;
      _validator = validator;
    }
    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, Address>(dto);

        _addressDal.Add(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AddressAdded);
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
        var entity = _mapper.Map<TDto, Address>(dto);

        await _addressDal.AddAsync(entity);
        return new SuccessDataResult<TDto>(dto, Messages.AddressAdded);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IResult Any(Expression<Func<Address, bool>> filter)
    {
      try
      {
        var any = _addressDal.Any(filter);

        if (any == true)
          return new SuccessResult(Messages.NoAddress);

        return new ErrorResult();
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<Address, bool>> filter)
    {
      try
      {
        var count = _addressDal.CountWhere(filter);
        return new SuccessDataResult<int>(count);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<int>(e.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<Address, bool>> filter)
    {
      try
      {
        var count = await _addressDal.CountWhereAsync(filter);
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
        var entity = _mapper.Map<TDto, Address>(dto);
        _addressDal.Delete(entity);
        return new SuccessDataResult<Address>(Messages.AddressDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<Address>(e.Message);
      }
    }

    public IResult DeleteById(int id)
    {
      try
      {
        _addressDal.DeleteById(id);
        return new SuccessDataResult<Address>(Messages.AddressDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<Address>(e.Message);
      }
    }

    public IDataResult<TDto> FindById<TDto>(int id)
    {
      try
      {
        return new SuccessDataResult<TDto>(_mapper.Map<Address, TDto>(_addressDal.FindById(id)));
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
        var page = await _addressDal.FindByIdAsync(id);
        var pageDto = _mapper.Map<Address, TDto>(page);
        return new SuccessDataResult<TDto>(pageDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<Address, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = _addressDal.Get(filter, includeProperties);
        var pagetDto = _mapper.Map<Address, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.AddressNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Address, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = await _addressDal.GetAsync(filter, includeProperties);
        var pagetDto = _mapper.Map<Address, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.AddressNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Address, bool>> filter = null, Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = _addressDal.GetList(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<Address, TDto>(e)).ToList();
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

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Address, bool>> filter = null, Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = await _addressDal.GetListAsync(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<Address, TDto>(e)).ToList();
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
        _addressDal.Save();
        return new SuccessResult(Messages.AddressAdded);
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
        await _addressDal.SaveAsync();
        return new SuccessResult(Messages.AddressAdded);
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
        var entity = _mapper.Map<TDto, Address>(dto);

        _addressDal.Update(entity);
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
        var entity = _mapper.Map<Address>(dto);

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
