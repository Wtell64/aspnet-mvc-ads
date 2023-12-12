

using Ads.Business.Dtos.Advert;
using Ads.Business.Dtos.AdvertComment;
using Ads.Business.Dtos.AdvertImage;
using Ads.Business.Dtos.Category;
using Ads.Business.Dtos.Setting;
using Ads.Business.Dtos.Subcategory;
using Ads.Entities.Concrete;
using AutoMapper;

namespace Ads.Business.Mapping
{

  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Category, CategoryViewDto>().ReverseMap();

      CreateMap<Setting, SettingViewDto>().ReverseMap();
      
      CreateMap<Advert, AdvertViewDto>().ReverseMap();
      CreateMap<Advert, AdvertSearchDto>().ReverseMap();
      CreateMap<AdvertComment, AdvertCommentViewDto>().ReverseMap();
      CreateMap<AdvertImage, AdvertImageViewDto>().ReverseMap();

      CreateMap<Advert, AdvertAddDto>().ReverseMap();
      CreateMap<AdvertImage, AdvertAddDto>().ReverseMap();

      CreateMap<SubcategoryAdvert, SubcategoryAdvertViewDto>().ReverseMap();

			CreateMap<Subcategory, SubcategoryViewDto>().ReverseMap();
		}
	}
}
