﻿using Ads.Entities.Concrete;
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
  public interface IAdvertImageService
  {
    IDataResult<ValidationResult> Validate<TDto>(TDto dto);
    IDataResult<TDto> FindById<TDto>(int id);
    IDataResult<TDto> Get<TDto>(Expression<Func<AdvertImage, bool>> filter, string includeProperties = "");
    IDataResult<IEnumerable<TDto>> GetList<TDto>(Expression<Func<AdvertImage, bool>> filter = null,
    Func<IQueryable<AdvertImage>, IOrderedQueryable<AdvertImage>> orderBy = null, string includeProperties = "");
    IDataResult<TDto> Add<TDto>(TDto dto);
    IResult Update<TDto>(TDto dto);
    IResult Delete<TDto>(TDto dto);
    IResult DeleteById(int id);
    IResult Any(Expression<Func<AdvertImage, bool>> filter);
    IResult Save();
    IDataResult<int> CountWhere(Expression<Func<AdvertImage, bool>> filter);

    //Asnyc
    Task<IDataResult<TDto>> FindByIdAsync<TDto>(int id);
    Task<IDataResult<TDto>> GetAsync<TDto>(Expression<Func<AdvertImage, bool>> filter, string includeProperties = "");
    Task<IDataResult<IEnumerable<TDto>>> GetListAsync<TDto>(Expression<Func<AdvertImage, bool>> filter = null, Func<IQueryable<AdvertImage>, IOrderedQueryable<AdvertImage>> orderBy = null, string includeProperties = "");

    Task<IDataResult<TDto>> AddAsync<TDto>(TDto dto);
    Task<IResult> SaveAsync();
    Task<IDataResult<int>> CountWhereAsync(Expression<Func<AdvertImage, bool>> filter);
  }
}
