using Ads.Core.Entities.Abstract;

namespace Ads.Business.Dtos.Users;

public class EmailEditDto : IDto
{
	public string CurrentEmail { get; set; }
	public string NewEmail { get; set; }
}
