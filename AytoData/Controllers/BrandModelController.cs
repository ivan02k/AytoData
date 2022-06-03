using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AutoData.Controllers
{
    public class BrandModelController : Controller
    {
        public readonly AutoDataContext _context;

        public BrandModelController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: BrandModelController
        public ActionResult Index()
        {
            var listofData = _context.BrandModels.ToList();
            foreach(var item in listofData)
            {
                item.Brand = _context.Brands.FirstOrDefault(p => p.Id == item.BrandId);
            }
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }

        // POST: BrandModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandModel model)
        {
            _context.BrandModels.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", model.BrandId);
            return View();
        }

        // GET: BrandModelController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.BrandModels.Where(x => x.Id == id).FirstOrDefault();
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(BrandModel Model)
        {
            var data = _context.BrandModels.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = Model.Name;
                data.BrandId = Model.Id;
                _context.SaveChanges();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", Model.BrandId);

            return RedirectToAction("index");
        }


        // POST: BrandModelController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.BrandModels.Where(x => x.Id == id).FirstOrDefault();
            _context.BrandModels.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.BrandModels.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
