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
  public class CategoryManager : ICategoryService
  {
    private readonly ICategoryDal _categoryDal;
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

    public Task<IDataResult<TDto>> AddAsync<TDto>(TDto dto)
    {
      throw new NotImplementedException();
    }

    public IResult Any(Expression<Func<Category, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public IDataResult<int> CountWhere(Expression<Func<Category, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<int>> CountWhereAsync(Expression<Func<Category, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public IResult Delete<TDto>(TDto dto)
    {
      throw new NotImplementedException();
    }

    public IResult DeleteById(int id)
    {
      throw new NotImplementedException();
    }

    public IDataResult<TDto> FindById<TDto>(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<TDto>> FindByIdAsync<TDto>(int id)
    {
      throw new NotImplementedException();
    }

    public IDataResult<TDto> Get<TDto>(Expression<Func<Category, bool>> filter, string includeProperties = "")
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Category, bool>> filter, string includeProperties = "")
    {
      throw new NotImplementedException();
    }

    public IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = "")
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = "")
    {
      throw new NotImplementedException();
    }

    public IResult Save()
    {
      throw new NotImplementedException();
    }

    public Task<IResult> SaveAsync()
    {
      throw new NotImplementedException();
    }

    public IResult Update<TDto>(TDto dto)
    {
      throw new NotImplementedException();
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
