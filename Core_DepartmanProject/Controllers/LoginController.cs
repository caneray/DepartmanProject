using Core_DepartmanProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Core_DepartmanProject.Controllers
{
	public class LoginController : Controller
	{
		Context c = new Context();
		[HttpGet]
		public IActionResult GirisYap()
		{
			return View();
		}
		public async Task<IActionResult> GirisYap(Admin p)
		{
			var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && 
			x.Sifre == p.Sifre);
			if (bilgiler != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.Kullanici)
				};
				var userIdentity = new ClaimsIdentity(claims,"Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index","Personel");
			}
			return View();
		}
	}
}
