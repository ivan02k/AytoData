using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoData.Controllers
{
    public class EngineModelController : Controller
    {
        public readonly AutoDataContext _context;

        public EngineModelController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: EngineModelController
        public ActionResult Index()
        {
            var listofData = _context.EngineModels.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EngineModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EngineModel model)
        {
            _context.EngineModels.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        // GET: EngineModelController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.EngineModels.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(EngineModel Model)
        {
            var data = _context.EngineModels.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = Model.Name;
                data.Power = Model.Power;
                data.NumberCylinders = Model.NumberCylinders;
                data.FuelType = Model.FuelType;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: EngineModelController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.EngineModels.Where(x => x.Id == id).FirstOrDefault();
            _context.EngineModels.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.EngineModels.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
