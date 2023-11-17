using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Core.Dal.Abstract
{

  public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
  {
    TEntity FindById(int id);
    TEntity Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
    IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteById(int id);
    bool Any(Expression<Func<TEntity, bool>> filter);
    int Save();
    int CountWhere(Expression<Func<TEntity, bool>> filter);

    //Asnyc
    Task<TEntity> FindByIdAsync(int id);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
    Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    Task AddAsync(TEntity entity);
    Task<int> SaveAsync();
    Task<int> CountWhereAsync(Expression<Func<TEntity, bool>> filter);
  }
}

