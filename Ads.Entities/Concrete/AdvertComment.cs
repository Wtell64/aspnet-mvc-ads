﻿using Ads.Entities.Concrete.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ads.Entities.Concrete
{
	public class AdvertComment : BaseEntity
	{
		public string Comment { get; set; }

		//Relationships

		public int AdvertId { get; set; }
		public Advert Advert { get; set; }
		
		public int UserId { get; set; }
		public AppUser User { get; set; }



	}
}
