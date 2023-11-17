using Ads.Business.Dtos.Category;
using Ads.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Business.Mapping
{
  public class MappingProfile : Profile
  {
        public MappingProfile()
        {
            CreateMap<Category,CategoryViewDto>().ReverseMap();
        }
    }
}
