using Ads.Business.Abstract;
using Ads.Business.Dtos.Users;
using Ads.Business.Extentions;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ads.Web.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles ="Admin,Superadmin")]
public class UserController : Controller
{
	private readonly UserManager<AppUser> _userManager;
	private readonly IAdvertCommentService _advertCommentService;
	private readonly IAdvertService _advertService;
	private readonly ICityService _cityService;
	private readonly IDistrictService _districtService;
	private readonly IAddressService _addressService;

	public UserController(UserManager<AppUser> userManager, IAdvertCommentService advertCommentService, IAdvertService advertService, ICityService cityService, IDistrictService districtService, IAddressService addressService)
	{
		_userManager = userManager;
		_advertCommentService = advertCommentService;
		_advertService = advertService;
		_cityService = cityService;
		_districtService = districtService;
		_addressService = addressService;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var userList = await _userManager.GetUsersInRoleAsync("user");
		var adminList = await _userManager.GetUsersInRoleAsync("admin");

		List<UserViewDto> users = new List<UserViewDto>();

		var userViewModelList = userList.Select(uvd => new UserViewDto()
		{
			Id = uvd.Id,
			FirstName = uvd.FirstName,
			LastName = uvd.LastName,
			Email = uvd.Email,
			CreatedDate = uvd.CreatedDate,
			Role = "User"
		});

		var adminViewModelList = adminList.Select(uvd => new UserViewDto()
		{
			Id = uvd.Id,
			FirstName = uvd.FirstName,
			LastName = uvd.LastName,
			Email = uvd.Email,
			CreatedDate = uvd.CreatedDate,
			Role = "Admin"
		});

		users.AddRange(userViewModelList);
		users.AddRange(adminViewModelList);

		return View(users.ToList());
	}

	[HttpPost]
	[Authorize(Roles = "Superadmin")]
  public async Task<IActionResult> Delete(int userId)
	{
		if (userId.Equals(0))
			return RedirectToAction("Index");

		var adverts = await _advertCommentService.GetListAsync<AdvertComment>(x => x.UserId.Equals(userId));

		foreach (var advert in adverts.Data)
		{
			_advertCommentService.DeleteById(advert.Id);
		}

		await _advertCommentService.SaveAsync();

		var user = await _userManager.FindByIdAsync(userId.ToString());
		await _userManager.DeleteAsync(user);

		return RedirectToAction("Index");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int userId)
	{
		var hasUser = await _userManager.FindByIdAsync(userId.ToString());
		var role = await _userManager.GetRolesAsync(hasUser);


		if (hasUser is null)
			return RedirectToAction("Index");

		UserViewDto userViewDto = new()
		{
			Id = hasUser.Id,
			FirstName = hasUser.FirstName,
			LastName = hasUser.LastName,
			Email = hasUser.Email,
			Role = role.FirstOrDefault(),
		};

		return View(userViewDto);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int userId, UserViewDto userViewDto)
	{
		var hasUser = await _userManager.FindByIdAsync(userId.ToString());
		var role = await _userManager.GetRolesAsync(hasUser);

		if (hasUser is null)
			return RedirectToAction("Index");

		await _userManager.RemoveFromRoleAsync(hasUser, role.FirstOrDefault());
		await _userManager.AddToRoleAsync(hasUser, userViewDto.Role);

		return RedirectToAction("Index");
	}

	[HttpGet]
	public async Task<IActionResult> Create()
	{
		var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
		var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));

		ViewBag.City = new SelectList(cities.Data, "Id", "Name");
		ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(RegisterDto request)
	{
		request.TermAndCondition = true;
		if (!ModelState.IsValid)
		{
			var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
			var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));

			ViewBag.City = new SelectList(cities.Data, "Id", "Name");
			ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");
			return View(request);
		}

		var newUser = new AppUser()
		{
			UserName = request.Email,
			NormalizedUserName = request.Email.ToUpper().Replace("İ", "I"),
			Email = request.Email,
			NormalizedEmail = request.Email.ToUpper().Replace("İ", "I"),
			FirstName = request.FirstName,
			LastName = request.LastName,
			SecurityStamp = Guid.NewGuid().ToString(),
			ImagePath = "deneme",
			EmailConfirmed = true,
			LockoutEnabled = false,
			Address = new Address
			{
				PostCode = _addressService.FindById<Address>(request.CityId).Data.PostCode,
				Country = "Türkiye",
				City = _cityService.FindById<City>(request.CityId).Data,
				District = _districtService.FindById<District>(request.DistrictId).Data,
				DetailedAddress = request.DetailedAddress,
				UserId = _userManager.Users.Count() + 1,
				CityId = request.CityId,
				DistrictId = request.DistrictId,
			},

		};
		var identityResult = await _userManager.CreateAsync(newUser, request.PasswordConfirm);

		await _userManager.AddToRoleAsync(newUser, "user");

		ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());

		return View();
	}

	[HttpGet]
	public JsonResult GetDistrictsByCityId(int cityId)
	{
		return Json(_districtService.GetList<District>(d => d.CityId.Equals(cityId)).Data);
	}
}