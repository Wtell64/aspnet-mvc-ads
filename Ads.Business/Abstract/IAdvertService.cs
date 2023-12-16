using Ads.Entities.Concrete;
using App.Core.Utilities.Results;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Abstract
{
  public interface IAdvertService
  {
    IDataResult<ValidationResult> Validate<TDto>(TDto dto);
    IDataResult<TDto> FindById<TDto>(int id);
    IDataResult<TDto> Get<TDto>(Expression<Func<Advert, bool>> filter, string includeProperties = "");
    IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<Advert, bool>> filter = null,
    Func<IQueryable<Advert>, IOrderedQueryable<Advert>> orderBy = null, string includeProperties = "");
    IDataResult<TDto> Add<TDto>(TDto dto);
    IResult Update<TDto>(TDto dto);
    IResult Delete<TDto>(TDto dto);
    IResult DeleteById(int id);
    IResult Any(Expression<Func<Advert, bool>> filter);
    IResult Save();
    IDataResult<int> CountWhere(Expression<Func<Advert, bool>> filter);

    IDataResult<TDto> AddAndSave<TDto>(TDto dto);

    IDataResult<TDto> AddAdvertSubcategory<TDto>(TDto dto);

    IDataResult<TDto> DeleteAdvertSubcategory<TDto>(TDto dto);

    IResult DeleteSubcategory<TDto>(TDto dto);
    //Asnyc
    Task<IDataResult<TDto>> FindByIdAsync<TDto>(int id);
    Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<Advert, bool>> filter, string includeProperties = "");
    Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<Advert, bool>> filter = null, Func<IQueryable<Advert>, IOrderedQueryable<Advert>> orderBy = null, string includeProperties = "");

    Task<IDataResult<TDto>> AddAsync<TDto>(TDto dto);
    Task<IResult> SaveAsync();
    Task<IDataResult<int>> CountWhereAsync(Expression<Func<Advert, bool>> filter);

    Task<IDataResult<TDto>> AddAndSaveAsync<TDto>(TDto dto);

    Task<IDataResult<TDto>> AddAdvertSubcategoryAsync<TDto>(TDto dto);

    Task<IDataResult<IEnumerable<TDto>>> GetSubcategoryListAsync<TDto>(Expression<Func<SubcategoryAdvert, bool>> filter = null, Func<IQueryable<SubcategoryAdvert>, IOrderedQueryable<SubcategoryAdvert>> orderBy = null, string includeProperties = "");
  }
}
