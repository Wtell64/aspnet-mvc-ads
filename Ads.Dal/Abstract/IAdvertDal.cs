﻿using Ads.Core.Dal.Abstract;
using Ads.Core.Entities.Abstract;
using Ads.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Dal.Abstract
{
  public interface IAdvertDal : IEntityRepository<Advert>
  {
    Advert GetLastAddedEntity();
  }
}
