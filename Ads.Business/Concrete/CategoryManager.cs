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
  public class CategoryManager : ICategoryService
  {
    private readonly ICategoryDal _categoryDal; //category verileri çekmek için eklendi.
    private readonly IMapper _mapper;
    private readonly IValidator<Category> _validator;
    public CategoryManager(ICategoryDal categoryDal, IMapper mapper, IValidator<Category> validator)
    {
      _categoryDal = categoryDal;
      _mapper = mapper;
      _validator = validator;
    }

    public IDataResult<TDto> Add<TDto>(TDto dto)
    {
      try
      {
        var entity = _mapper.Map<TDto, Category>(dto);

        _categoryDal.Add(entity);
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
        var entity = _mapper.Map<TDto, Category>(dto);
        await _categoryDal.AddAsync(entity);
        return new SuccessDataResult<TDto>(dto, Messages.CategoryAdded);
      }
      catch (Exception e)
      {

        return new ErrorDataResult<TDto>(e.Message);
      }

    }

    public IResult Any(Expression<Func<Category, bool>> filter)
    {
      try
      {
        var anyCategory = _categoryDal.Any(filter);
        if (anyCategory == true)
        {
          return new SuccessResult(Messages.CategoryFound);
        }
        return new ErrorResult();
      }
      catch (Exception e)
      {
        return new ErrorResult(e.Message);
      }
    }

    public IDataResult<int> CountWhere(Expression<Func<Category, bool>> filter)
    {
      try
      {
        var count = _categoryDal.CountWhere(filter);
        return new SuccessDataResult<int>(count);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<int>(e.Message);
      }
    }

    public async Task<IDataResult<int>> CountWhereAsync(Expression<Func<Category, bool>> filter)
    {
      try
      {
        var count = await _categoryDal.CountWhereAsync(filter);
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
        var entity = _mapper.Map<TDto, Category>(dto);
        _categoryDal.Delete(entity);
        return new SuccessDataResult<Category>(Messages.CategoryDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<Category>(e.Message);
      }
    }

    public IResult DeleteById(int id)
    {
      try
      {
        _categoryDal.DeleteById(id);
        return new SuccessDataResult<Category>(Messages.CategoryDeleted);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<Category>(e.Message);
      }
    }

    public IDataResult<TDto> FindById<TDto>(int id)
    {
      try
      {
        var entity = _mapper.Map<Category, TDto>(_categoryDal.FindById(id));
        return new SuccessDataResult<TDto>(entity, Messages.CategoryFound);
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
        var entity = await _categoryDal.FindByIdAsync(id);
        if (entity == null)
          return new SuccessDataResult<TDto>(Messages.CategoryFound);

        var categorydto = _mapper.Map<Category, TDto>(entity);
        return new SuccessDataResult<TDto>(categorydto, Messages.CategoryFound);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<Category, bool>> filter, string includeProperties = "")
    {
      try
      {
        var category = _categoryDal.Get(filter, includeProperties);
        var categoryDto = _mapper.Map<Category, TDto>(category);

        if (categoryDto == null)
        {
          return new ErrorDataResult<TDto>(Messages.CategoryNotFound);
        }
        return new SuccessDataResult<TDto>(categoryDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public async Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Category, bool>> filter, string includeProperties = "")
    {
      try
      {
        var category = await _categoryDal.GetAsync(filter, includeProperties);
        var categoryDto = _mapper.Map<Category, TDto>(category);

        if (categoryDto == null)
        { return new ErrorDataResult<TDto>(Messages.CategoryNotFound); }

        return new SuccessDataResult<TDto>(categoryDto);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<TDto>(e.Message);
      }
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = "")
    {
      try
      {
        IQueryable<Category> categoryList = _categoryDal.GetList(filter, orderBy, includeProperties).AsQueryable();
        if (categoryList == null || !categoryList.Any())
        {
          return new ErrorDataResult<IEnumerable<TDto>>(Messages.ListEmpty);
        }
        var categoryDtoList = categoryList.Select(e => _mapper.Map<Category, TDto>(e));
        return new SuccessDataResult<IEnumerable<TDto>>(categoryDtoList, Messages.CategoryListed);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<IEnumerable<TDto>>(e.Message);
      }
    }

    public async Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = "")
    {
      try
      {
        var categoryList = await _categoryDal.GetListAsync(filter, orderBy, includeProperties);
        if (categoryList == null || !categoryList.Any())
        {
          return new ErrorDataResult<IEnumerable<TDto>>(Messages.ListEmpty);
        }
        var categoryDtoList = categoryList.Select(e => _mapper.Map<Category, TDto>(e));
        return new SuccessDataResult<IEnumerable<TDto>>(categoryDtoList, Messages.CategoryListed);
      }
      catch (Exception e)
      {
        return new ErrorDataResult<IEnumerable<TDto>>(e.Message);
      }
    }

    public IResult Save()
    {
      try
      {
        _categoryDal.Save();
        return new SuccessResult(Messages.CategoryAdded);
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
        int result = await _categoryDal.SaveAsync();

        if (result > 0)
        {
          return new SuccessResult(Messages.SaveSuccess);
        }
        else
        {
          return new ErrorResult(Messages.SaveFailed);
        }
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
        var entity = _mapper.Map<TDto, Category>(dto);
        _categoryDal.Update(entity);
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
        var entity = _mapper.Map<Category>(dto);

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
