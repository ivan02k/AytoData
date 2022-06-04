using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AutoData.Controllers
{
    public class ModificationController : Controller
    {
        public readonly AutoDataContext _context;

        public ModificationController(AutoDataContext context)
        {
            _context = context;
        }
        // GET: ModificationController
        public ActionResult Index()
        {
            var listofData = _context.Modifications.ToList();
            foreach (var item in listofData)
            {
                item.Generation = _context.Generations.FirstOrDefault(v => v.Id == item.GenerationId);
            }
            foreach (var item in listofData)
            {
                item.BodyType = _context.BodyTypes.FirstOrDefault(v => v.Id == item.BodyTypeId);
            }
            foreach (var item in listofData)
            {
                item.EngineModel = _context.EngineModels.FirstOrDefault(v => v.Id == item.EngineModelId);
            }
            foreach (var item in listofData)
            {
                item.GearBoxType = _context.GearsBoxTypes.FirstOrDefault(v => v.Id == item.GearBoxTypeId);
            }
            return View(listofData);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Modifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            var listofData = _context.Modifications.ToList();
            foreach (var item in listofData)
            {
                item.Generation = _context.Generations.FirstOrDefault(v => v.Id == item.GenerationId);
            }
            foreach (var item in listofData)
            {
                item.BodyType = _context.BodyTypes.FirstOrDefault(v => v.Id == item.BodyTypeId);
            }
            foreach (var item in listofData)
            {
                item.EngineModel = _context.EngineModels.FirstOrDefault(v => v.Id == item.EngineModelId);
            }
            foreach (var item in listofData)
            {
                item.GearBoxType = _context.GearsBoxTypes.FirstOrDefault(v => v.Id == item.GearBoxTypeId);
            }

            return View(project);
        }

        // GET: ModificationController/Create
        public ActionResult Create()
        {
            ViewData["GenerationId"] = new SelectList(_context.Generations, "Id", "Name");
            ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "Id", "Name");
            ViewData["EngineModelId"] = new SelectList(_context.EngineModels, "Id", "Name");
            ViewData["GearBoxTypeId"] = new SelectList(_context.GearsBoxTypes, "Id", "Name");
            return View();
        }

        // POST: ModificationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modification model)
        {
            _context.Modifications.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            ViewData["GenerationId"] = new SelectList(_context.Generations, "Id", "Name", model.GenerationId);
            ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "Id", "Name", model.BodyTypeId);
            ViewData["EngineModelId"] = new SelectList(_context.EngineModels, "Id", "Name", model.EngineModelId);
            ViewData["GearBoxTypeId"] = new SelectList(_context.GearsBoxTypes, "Id", "Name", model.GearBoxTypeId);
            return View();
        }

        // GET: ModificationController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Modifications.Where(x => x.Id == id).FirstOrDefault();
            ViewData["GenerationId"] = new SelectList(_context.Generations, "Id", "Name");
            ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "Id", "Name");
            ViewData["EngineModelId"] = new SelectList(_context.EngineModels, "Id", "Name");
            ViewData["GearBoxTypeId"] = new SelectList(_context.GearsBoxTypes, "Id", "Name");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Modification Model)
        {
            var data = _context.Modifications.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.GenerationId = Model.GenerationId;
                data.BodyTypeId = Model.BodyTypeId;
                data.EngineModelId = Model.EngineModelId;
                data.GearBoxTypeId = Model.GearBoxTypeId;
                data.Acceleration = Model.Acceleration;
                data.FuelConsumption = Model.FuelConsumption;

                _context.SaveChanges();
            }
            ViewData["GenerationId"] = new SelectList(_context.Generations, "Id", "Name", Model.GenerationId);
            ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "Id", "Name", Model.BodyTypeId);
            ViewData["EngineModelId"] = new SelectList(_context.EngineModels, "Id", "Name", Model.EngineModelId);
            ViewData["GearBoxTypeId"] = new SelectList(_context.GearsBoxTypes, "Id", "Name", Model.GearBoxTypeId);

            return RedirectToAction("index");
        }

        // GET: ModificationController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Modifications.Where(x => x.Id == id).FirstOrDefault();
            _context.Modifications.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Modifications.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
