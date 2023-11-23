using Ads.Core.Dal.Concrete.EntityFramework;
using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework.Context;
using Ads.Entities.Concrete;

namespace Ads.Dal.Concrete.EntityFramework
{
  public class EfPageDal : EfEntityRepositoryBase<Page, DataContext>, IPageDal
  {
    private DataContext _dbContext;
    public EfPageDal(DataContext context) : base(context)
    {
      _dbContext = context;
    }
  }
}
