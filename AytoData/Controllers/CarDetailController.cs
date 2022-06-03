using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoData.Controllers
{
    public class CarDetailController : Controller
    {
        public readonly AutoDataContext _context;

        public CarDetailController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: CarDetailController
        public ActionResult Index()
        {
            var listofData = _context.CarDetails.ToList();
            return View(listofData);
        }

        // GET: CarDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarDetail model)
        {
            _context.CarDetails.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        // GET: CarDetailController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.CarDetails.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(CarDetail Model)
        {
            var data = _context.CarDetails.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.ModificationId = Model.Id;
                data.Acceleration = Model.Acceleration;
                data.FuelConsumption = Model.FuelConsumption;

                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: CarDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.CarDetails.Where(x => x.Id == id).FirstOrDefault();
            _context.CarDetails.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.CarDetails.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
