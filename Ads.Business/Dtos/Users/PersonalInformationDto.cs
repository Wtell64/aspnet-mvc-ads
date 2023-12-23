using Ads.Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Ads.Business.Dtos.Users;

public class PersonalInformationDto : IDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Image { get; set; }
	public IFormFile File { get; set; }
}
