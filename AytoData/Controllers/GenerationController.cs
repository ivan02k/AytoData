using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AutoData.Controllers
{
    public class GenerationController : Controller
    {
        public readonly AutoDataContext _context;

        public GenerationController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: GenerationController
        public ActionResult Index()
        {
            var listofData = _context.Generations.ToList();
            foreach(var item in listofData)
            {
                item.BrandModel = _context.BrandModels.FirstOrDefault(v => v.Id == item.BrandModelId);
            }
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Generation model)
        {
            _context.Generations.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name", model.BrandModelId);
            return View();
        }

        // GET: GenerationController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Generations.Where(x => x.Id == id).FirstOrDefault();
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Generation Model)
        {
            var data = _context.Generations.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = Model.Name;
                data.BrandModelId = Model.BrandModelId;
                data.YearFactury = Model.YearFactury;
                _context.SaveChanges();
            }
            ViewData["BrandModelId"] = new SelectList(_context.BrandModels, "Id", "Name", Model.BrandModelId);

            return RedirectToAction("index");
        }

        // GET: GenerationController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Generations.Where(x => x.Id == id).FirstOrDefault();
            _context.Generations.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Generations.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
