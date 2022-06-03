using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AutoData.Controllers
{
    public class BrandController : Controller
    {
        public readonly AutoDataContext _context;

        public BrandController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: BrandController
        public ActionResult Index()
        {
            var listofData = _context.Brands.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand model)
        {
            _context.Brands.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";           
            return View();
        }

        // POST: BrandController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Brands.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Brand Model)
        {
            var data = _context.Brands.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = Model.Name;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: BrandController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Brands.Where(x => x.Id == id).FirstOrDefault();
            _context.Brands.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Brands.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
