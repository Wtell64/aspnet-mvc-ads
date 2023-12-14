﻿using Ads.Entities.Concrete.Enums;
using Ads.Entities.Concrete.Identity;
using Ads.Entities.Concrete;

namespace Ads.Web.Mvc.ViewModels
{
  public class AdvertViewDto
  {
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string Title { get; set; }
    public string Description { get; set; }
    public AdvertConditionEnum ConditionEnum { get; set; }
    public int Price { get; set; }
    public int? ClickCount { get; set; } = 0;

    //Relationship
    public virtual ICollection<SubcategoryAdvert> SubcategoryAdverts { get; set; }
    public virtual ICollection<AdvertImage> AdvertImages { get; set; }

    public virtual ICollection<AdvertComment> AdvertComments { get; set; }
    public AppUser User { get; set; }
    public int UserId { get; set; }
  }
}
