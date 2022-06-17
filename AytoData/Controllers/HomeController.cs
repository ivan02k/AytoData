
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AytoData.Controllers
{
    public class HomeController : Controller
    {
        public readonly AutoDataContext _context;
        public HomeController(AutoDataContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var listofData = _context.Brands.ToList();
            return View(listofData);
        }

        public async Task<IActionResult> Models(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listofBrandModels = _context.BrandModels.ToList();
            foreach (var item in listofBrandModels)
            {
                if (item.BrandId == id)
                {
                    item.Brand = _context.Brands.FirstOrDefault(p => p.Id == item.BrandId);
                }
                else
                {
                    item.BrandId = null;
                }
            }
            return View(listofBrandModels);
        }

        public async Task<IActionResult> Generations(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listofGenerations = _context.Generations.ToList();
            foreach (var item in listofGenerations)
            {
                if (item.BrandModelId == id)
                {
                    item.BrandModel = _context.BrandModels.FirstOrDefault(v => v.Id == item.BrandModelId);
                    Brand brand = _context.Brands.FirstOrDefault(v => v.Id == item.BrandModel.BrandId);
                    ViewBag.Brand = brand.Name;
                }
                else
                {
                    item.BrandModelId = null;
                }
            }
            return View(listofGenerations);
        }

        public async Task<IActionResult> Modifications(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listofModifications = _context.Modifications.ToList();
            foreach (var item in listofModifications)
            {
                if (item.GenerationId == id)
                {
                    item.Generation = _context.Generations.FirstOrDefault(v => v.Id == item.GenerationId);
                    item.BodyType = _context.BodyTypes.FirstOrDefault(v => v.Id == item.BodyTypeId);
                    item.EngineModel = _context.EngineModels.FirstOrDefault(v => v.Id == item.EngineModelId);
                    item.GearBoxType = _context.GearsBoxTypes.FirstOrDefault(v => v.Id == item.GearBoxTypeId);
                    BrandModel brandModel = _context.BrandModels.FirstOrDefault(v => v.Id == item.Generation.BrandModelId);
                    Brand brand = _context.Brands.FirstOrDefault(v => v.Id == brandModel.BrandId);
                    ViewBag.Brand = brand.Name;
                    ViewBag.BrandModel = brandModel.Name;
                }
                else
                {
                    item.GenerationId = null;
                }
            }
            return View(listofModifications);
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

            project.Generation = _context.Generations.FirstOrDefault(v => v.Id == project.GenerationId);

            project.BodyType = _context.BodyTypes.FirstOrDefault(v => v.Id == project.BodyTypeId);

            project.EngineModel = _context.EngineModels.FirstOrDefault(v => v.Id == project.EngineModelId);

            project.GearBoxType = _context.GearsBoxTypes.FirstOrDefault(v => v.Id == project.GearBoxTypeId);

            BrandModel brandModel = _context.BrandModels.FirstOrDefault(v => v.Id == project.Generation.BrandModelId);
            Brand brand = _context.Brands.FirstOrDefault(v => v.Id == brandModel.BrandId);
            ViewBag.Brand = brand.Name;
            ViewBag.BrandModel = brandModel.Name;

            return View(project);
        }
    }
}
