using Ads.Core.Dal.Concrete.EntityFramework;
using Ads.Dal.Abstract;
using Ads.Dal.Concrete.EntityFramework.Context;
using Ads.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Dal.Concrete.EntityFramework
{
  public class EfSettingDal : EfEntityRepositoryBase<Setting, DataContext>, ISettingDal
  {
    private DataContext _dbContext;
    public EfSettingDal(DataContext context) : base(context)
    {
      _dbContext = context;
    }
  }
}
