﻿using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Setting
{
  public class SettingViewDto : IDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    
  }
}
