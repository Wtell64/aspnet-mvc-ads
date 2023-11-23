using Ads.Business.Dtos.Advert;
using Ads.Business.Dtos.AdvertComment;
using Ads.Business.Dtos.AdvertImage;
using Ads.Business.Dtos.Category;
using Ads.Entities.Concrete;
using AutoMapper;

namespace Ads.Business.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Category, CategoryViewDto>().ReverseMap();
      CreateMap<Advert, AdvertViewDto>().ReverseMap();
      CreateMap<AdvertComment, AdvertCommentViewDto>().ReverseMap();
      CreateMap<AdvertImage, AdvertImageViewDto>().ReverseMap();
    }
  }
}
