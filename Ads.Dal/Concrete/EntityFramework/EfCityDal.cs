using Ads.Core.Dal.Concrete.EntityFramework;
using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework.Context;
using Ads.Entities.Concrete;

namespace Ads.Dal.Concrete.EntityFramework
{
  public class EfCityDal : EfEntityRepositoryBase<City, DataContext>, ICityDal
  {
    private DataContext _dbContext;
    public EfCityDal(DataContext context) : base(context)
    {
      _dbContext = context;
    }
  }
}
