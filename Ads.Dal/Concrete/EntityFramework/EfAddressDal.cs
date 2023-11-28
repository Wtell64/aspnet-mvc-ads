using Ads.Core.Dal.Concrete.EntityFramework;
using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework.Context;
using Ads.Entities.Concrete;

namespace Ads.Dal.Concrete.EntityFramework
{
  public class EfAddressDal : EfEntityRepositoryBase<Address, DataContext>, IAddressDal
  {
    private DataContext _dbContext;
    public EfAddressDal(DataContext context) : base(context)
    {
      _dbContext = context;
    }
  }
}
