using Ads.Business.Abstract;
using Ads.Business.Constants;
using Ads.Business.Dtos;
using Ads.Business.Dtos.AdressDtos;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Superadmin")]
	public class AddressController : Controller
	{
		private readonly IAddressService _addressService;
		private readonly ICityService _cityService;
		private readonly IDistrictService _districtService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IToastNotification _toastNotification;
		public AddressController(IAddressService addressService, ICityService cityService, IDistrictService districtService, UserManager<AppUser> userManager, IToastNotification toastNotification)
		{
			_addressService = addressService;
			_cityService = cityService;
			_districtService = districtService;
			_userManager = userManager;
			_toastNotification = toastNotification;
		}
		[HttpGet]
		public async Task<IActionResult> Index(int userId)
		{
			var address = await _addressService.GetAsync<Address>(a => a.UserId == userId, includeProperties: "User,City,District");
			ViewBag.UserId = userId;
			return View(address.Data);
		}
		#region Add
		[HttpGet]
		public async Task<IActionResult> Add(int userId)
		{
			var address = await _addressService.GetAsync<Address>(a => a.UserId == userId);
			if (address.Data != null) 
			{
				_toastNotification.AddErrorToastMessage("Kullanıcının bir adresi zaten mevcut");
				return RedirectToAction("Index","Address",new {userId=userId});
			}
			AddressCRUDDto dto = new AddressCRUDDto()
			{
				UserId = userId
			};
			var (cities, districts, userName) = await PrepareSelectListsAndUserName(userId);

			ViewBag.Cities = cities;
			ViewBag.Districts = districts;
			ViewBag.UserName = userName;

			return View(dto);
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddressCRUDDto dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _addressService.AddAsync(dto);
					await _addressService.SaveAsync();
					_toastNotification.AddSuccessToastMessage(Messages.AddressAdded);
					return RedirectToAction("Index", "Address", new { userId = dto.UserId });
				}
			}
			catch (Exception)
			{
				ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
				TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
			}

			int userId = dto.UserId;
			var (cities, districts, userName) = await PrepareSelectListsAndUserName(userId);

			ViewBag.Cities = cities;
			ViewBag.Districts = districts;
			ViewBag.UserName = userName;

			return View(dto);
		}
		#endregion
		#region Edit
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var address = await _addressService.GetAsync<Address>(i => i.Id == id);
			int userId = address.Data.UserId;
			var (cities, districts, userName) = await PrepareSelectListsAndUserName(userId);

			ViewBag.Cities = cities;
			ViewBag.Districts = districts;
			ViewBag.UserName = userName;

			AddressCRUDDto dto = new AddressCRUDDto()
			{
				Id = id,
				UserId = address.Data.UserId,
				Country = address.Data.Country,
				CityId = address.Data.CityId,
				DistrictId = address.Data.DistrictId,
				DetailedAddress = address.Data.DetailedAddress,
				PostCode = address.Data.PostCode,
			};
			return View(dto);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(AddressCRUDDto dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_addressService.Update(dto);
					await _addressService.SaveAsync();
					_toastNotification.AddWarningToastMessage(Messages.AddressUpdated);
					return RedirectToAction("Index","Address",new {userId=dto.UserId});
				}
			}
			catch (Exception)
			{
				ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
				TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
			}
			int userId = dto.UserId;
			var (cities, districts, userName) = await PrepareSelectListsAndUserName(userId);

			ViewBag.Cities = cities;
			ViewBag.Districts = districts;
			ViewBag.UserName = userName;

			return View(dto);
		}
		#endregion
		#region Delete
		[HttpGet]
		[Authorize(Roles = "Superadmin")]
		public async Task<IActionResult> Delete(int id)
		{
			var address = await _addressService.GetAsync<Address>(i => i.Id == id);
			int userId = address.Data.UserId;
			var (cities, districts, userName) = await PrepareSelectListsAndUserName(userId);

			ViewBag.Cities = cities;
			ViewBag.Districts = districts;
			ViewBag.UserName = userName;

			return View(address.Data);
		}

		[HttpPost]
		[Authorize(Roles = "Superadmin")]
		public async Task<IActionResult> Delete(Address address)
		{
			_addressService.Delete(address);
			await _addressService.SaveAsync();
			_toastNotification.AddErrorToastMessage(Messages.AddressDeleted);
			return RedirectToAction("Index", "User", new { area = "Admin" });
		}
		#endregion

		[HttpGet]
		public JsonResult GetDistrictsByCityId(int cityId)
		{
			return Json(_districtService.GetList<District>(d => d.CityId.Equals(cityId)).Data);
		}

		private async Task<(SelectList cities, SelectList districts, string userName)> PrepareSelectListsAndUserName(int userId)
		{
			var cities = new SelectList(_cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name)).Data, "Id", "Name");
			var districts = new SelectList(_districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name)).Data, "Id", "Name");
			var user = await _userManager.FindByIdAsync(userId.ToString());

			return (cities, districts, $"{user.FirstName} {user.LastName}");
		}
	}
}
