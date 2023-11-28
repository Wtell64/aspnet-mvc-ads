using Ads.Core.Dal.Concrete.EntityFramework;
using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework.Context;
using Ads.Entities.Concrete;

namespace Ads.Dal.Concrete.EntityFramework
{
  public class EfDisctrictDal : EfEntityRepositoryBase<District, DataContext>, IDistrictDal
  {
    private DataContext _dbContext;
    public EfDisctrictDal(DataContext context) : base(context)
    {
      _dbContext = context;
    }
  }
}
