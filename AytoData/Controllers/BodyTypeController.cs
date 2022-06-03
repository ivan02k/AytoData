using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoData.Controllers
{
    public class BodyTypeController : Controller
    {
        public readonly AutoDataContext _context;

        public BodyTypeController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: BodyTypeController
        public ActionResult Index()
        {
            var listofData = _context.BodyTypes.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BodyTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BodyType model)
        {
            _context.BodyTypes.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        // GET: BodyTypeController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.BodyTypes.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(BodyType Model)
        {
            var data = _context.BodyTypes.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = Model.Name;
                data.Doors = Model.Doors;
                data.Seats = Model.Seats;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: BodyTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.BodyTypes.Where(x => x.Id == id).FirstOrDefault();
            _context.BodyTypes.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.BodyTypes.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
