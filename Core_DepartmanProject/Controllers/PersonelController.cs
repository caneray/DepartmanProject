using Core_DepartmanProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core_DepartmanProject.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
		[Authorize]
		public IActionResult Index()
        {
            var result = c.Personels.Include(x=>x.Birim).ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=x.BirimAd,
                                                 Value = x.BirimID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var result = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = result;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelSil(int id)
        {
            var result = c.Personels.Find(id);
            c.Personels.Remove(result);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
