using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoData.Controllers
{
    public class GearBoxTypeController : Controller
    {
        public readonly AutoDataContext _context;

        public GearBoxTypeController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: GearBoxTypeController
        public ActionResult Index()
        {
            var listofData = _context.GearsBoxTypes.ToList();
            return View(listofData);
        }

        // GET: GearBoxTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GearBoxTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GearBoxType model)
        {
            _context.GearsBoxTypes.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        // GET: GearBoxTypeController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.GearsBoxTypes.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(GearBoxType Model)
        {
            var data = _context.GearsBoxTypes.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = Model.Name;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: GearBoxTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.GearsBoxTypes.Where(x => x.Id == id).FirstOrDefault();
            _context.GearsBoxTypes.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.GearsBoxTypes.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
