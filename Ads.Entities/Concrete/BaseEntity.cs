﻿using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete
{
  public class BaseEntity : IEntity 
  {
    
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; } = true;

  }
}
