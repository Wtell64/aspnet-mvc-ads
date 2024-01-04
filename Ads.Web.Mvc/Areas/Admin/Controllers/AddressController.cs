using Ads.Business.Abstract;
using Ads.Business.Dtos;
using Ads.Business.Dtos.AdressDtos;
using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ads.Web.Mvc.Areas.Admin.Controllers
{
	//ToDo : Ask about UserId validation error message !!
	[Area("Admin")]
	[Authorize(Roles = "Admin,Superadmin")]
	public class AddressController : Controller
	{
		private readonly IAddressService _addressService;
		private readonly ICityService _cityService;
		private readonly IDistrictService _districtService;
		private readonly UserManager<AppUser> _userManager;

    public AddressController(IAddressService addressService, ICityService cityService, IDistrictService districtService, UserManager<AppUser> userManager)
    {
      _addressService = addressService;
      _cityService = cityService;
      _districtService = districtService;
      _userManager = userManager;
    }

    [HttpGet]
    public async Task <IActionResult> Index(int id)
		{
			var addresses = await _addressService.GetListAsync<Address>(a=>a.UserId==id,includeProperties: "User,City,District");
			return View(addresses.Data);
		}
		#region Add
		//[HttpGet]
		//public async Task<IActionResult> Add()
		//{
		//	var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
		//	var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));

		//	ViewBag.Cities = new SelectList(cities.Data, "Id", "Name");
		//	ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");

		//	return View();
		//  }
		//[HttpPost]
		//public async Task<IActionResult> Add (AddressCRUDDto dto)
		//{
		//    var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
		//    var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));

		//    ViewBag.Cities = new SelectList(cities.Data, "Id", "Name");
		//    ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");

		//    try
		//	{
		//		if (ModelState.IsValid)
		//		{
		//        await _addressService.AddAsync(dto);
		//        await _addressService.SaveAsync();
		//        TempData["SuccessMessage"] = "Ayarlar başarıyla keydedildi.";
		//      }
		//	}
		//	catch(Exception) 
		//	{
		//      ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
		//      TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
		//    }
		//	return  View();
		//}
		#endregion
		#region Edit
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
			var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));
			var address = await _addressService.GetAsync<Address>(i => i.Id == id);

			ViewBag.Cities = new SelectList(cities.Data, "Id", "Name");
			ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");

			var user = await _userManager.FindByIdAsync(address.Data.UserId.ToString());
			string userName = user.FirstName + " " + user.LastName;
			ViewBag.userName = userName;

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
			var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
			var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));

			ViewBag.Cities = new SelectList(cities.Data, "Id", "Name");
			ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");

			var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
			string userName = user.FirstName + " " + user.LastName;
			ViewBag.userName = userName;

			try
			{
				if (ModelState.IsValid)
				{
					_addressService.Update(dto);
					await _addressService.SaveAsync();
					TempData["SuccessMessage"] = "Adres başarıyla güncellendi.";
				}
			}
			catch (Exception)
			{
				ModelState.AddModelError("Error", "Kayıt sırasında bir hata oluştu");
				TempData["ErrorMessage"] = "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.";
			}
			return View(dto);
		}
		#endregion
		#region Delete
		//[HttpGet]
		//public async Task<IActionResult> Delete (int id)
		//{
		//    var cities = _cityService.GetList<City>(orderBy: q => q.OrderBy(x => x.Name));
		//    var districts = _districtService.GetList<District>(orderBy: q => q.OrderBy(x => x.Name));
		//    var address = await _addressService.GetAsync<Address>(i => i.Id == id);

		//    ViewBag.Cities = new SelectList(cities.Data, "Id", "Name");
		//    ViewBag.Districts = new SelectList(districts.Data, "Id", "Name");

		//    return View(address.Data);
		//  }
		//[HttpPost]
		//public async Task<IActionResult> Delete (Address address)
		//{
		//	_addressService.Delete(address);
		//	await _addressService.SaveAsync();
		//	return RedirectToAction("Index", "Address", new { area = "Admin" });
		//}
		#endregion


		[HttpGet]
		public JsonResult GetDistrictsByCityId(int cityId)
		{
			return Json(_districtService.GetList<District>(d => d.CityId.Equals(cityId)).Data);
		}
	}
}
