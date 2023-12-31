﻿using Ads.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Dtos.Category
{
  public class CategoryViewDto : IDto
  {
    public int Id { get; set; }
    [DisplayName("Kategori Adı")]
    public string Name { get; set; }
    public string IconClass { get; set; }

    public string Description { get; set; }
    public IEnumerable<Ads.Entities.Concrete.Category> Categories { get; set; }
  }
}
