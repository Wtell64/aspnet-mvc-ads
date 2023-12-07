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
    internal class EfSubcategoryAdvertDal : EfEntityRepositoryBase<SubcategoryAdvert, DataContext>, ISubcategoryAdvertDal
  {
    private DataContext _dbContext;

    public EfSubcategoryAdvertDal(DataContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }
  }
}
