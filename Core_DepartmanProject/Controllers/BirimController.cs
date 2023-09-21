using Core_DepartmanProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_DepartmanProject.Controllers
{
    public class BirimController : Controller
    {
        Context c = new Context();
		
		public IActionResult Index()
        {
            var result = c.Birims.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var result = c.Birims.Find(id);
            c.Birims.Remove(result);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var result = c.Birims.Find(id);
            return View("BirimGetir", result);
        }
        public IActionResult BirimGuncelle(Birim d)
        {
            var result = c.Birims.Find(d.BirimID);
            result.BirimID = d.BirimID;
            result.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.BirimID == id).ToList();
            var brmad = c.Birims.Where(x=>x.BirimID == id).Select(y=>y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);
        }
    }
}
