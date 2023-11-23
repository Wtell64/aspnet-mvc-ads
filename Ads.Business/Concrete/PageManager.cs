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
  public class PageManager : IPageService
  {
    private readonly IPageDal _pageDal;
    private readonly IMapper _mapper;
    private readonly IValidator<Page> _validator;

    public PageManager(IPageDal pageDal, IMapper mapper, IValidator<Page> validator)
    {
      _pageDal = pageDal;
      _mapper = mapper;
      _validator = validator;
    }

    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, Page>(dto);

        _pageDal.Add(entity);
        return new SuccessDataResult<TDto>(dto, Messages.PageAdded);
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
        var entity = _mapper.Map<TDto, Page>(dto);

        await _pageDal.AddAsync(entity);
        return new SuccessDataResult<TDto>(dto, Messages.PageAdded);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IResult Any(Expression<Func<Page, bool>> filter)
    {
      try
      {
        var any = _pageDal.Any(filter);

        if (any == true)
          return new SuccessResult(Messages.NoPage);

        return new ErrorResult();
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<Page, bool>> filter)
    {
      try
      {
        var count = _pageDal.CountWhere(filter);
        return new SuccessDataResult<int>(count);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<int>(e.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<Page, bool>> filter)
    {
      try
      {
        var count = await _pageDal.CountWhereAsync(filter);
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
        var entity = _mapper.Map<TDto, Page>(dto);
        _pageDal.Delete(entity);
        return new SuccessDataResult<Page>(Messages.PageDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<Page>(e.Message);
      }
    }

    public IResult DeleteById(int id)
    {
      try
      {
        _pageDal.DeleteById(id);
        return new SuccessDataResult<Page>(Messages.PageDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<Page>(e.Message);
      }
    }

    public IDataResult<TDto> FindById<TDto>(int id)
    {
      try
      {
        return new SuccessDataResult<TDto>(_mapper.Map<Page, TDto>(_pageDal.FindById(id)));
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
        var page = await _pageDal.FindByIdAsync(id);
        var pageDto = _mapper.Map<Page, TDto>(page);
        return new SuccessDataResult<TDto>(pageDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<Page, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = _pageDal.Get(filter, includeProperties);
        var pagetDto = _mapper.Map<Page, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.PageNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Page, bool>> filter, string includeProperties = "")
    {
      try
      {
        var page = await _pageDal.GetAsync(filter, includeProperties);
        var pagetDto = _mapper.Map<Page, TDto>(page);

        if (pagetDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.PageNotFound);
        }
        return new SuccessDataResult<TDto>(pagetDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message.ToString());
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Page, bool>> filter = null, Func<IQueryable<Page>, IOrderedQueryable<Page>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = _pageDal.GetList(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<Page, TDto>(e)).ToList();
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

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Page, bool>> filter = null, Func<IQueryable<Page>, IOrderedQueryable<Page>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var pageList = await _pageDal.GetListAsync(filter, orderBy, includeProperties);
        var dto = pageList.Select(e => _mapper.Map<Page, TDto>(e)).ToList();
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
        _pageDal.Save();
        return new SuccessResult(Messages.PageAdded);
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
        await _pageDal.SaveAsync();
        return new SuccessResult(Messages.PageAdded);
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
        var entity = _mapper.Map<TDto, Page>(dto);

        _pageDal.Update(entity);
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
        var entity = _mapper.Map<Page>(dto);

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
