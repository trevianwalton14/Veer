using Microsoft.AspNetCore.Mvc;
using Veer.Data;
using Veer.Models;

namespace Veer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        //Create Get Action Method
        public IActionResult Create()
        {
            return View();
        }

        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product Type has been saved succesfully";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);
        }


        //Create Get Edit Method
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producType = _db.ProductTypes.Find(id);
            if (producType == null)
            {
                return NotFound();
            }
            return View(producType);
        }

        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product Type has been Updated";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);
        }


        //Create Get Details Method
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producType = _db.ProductTypes.Find(id);
            if (producType == null)
            {
                return NotFound();
            }
            return View(producType);
        }

        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductTypes productTypes)
        {

            return RedirectToAction(actionName: nameof(Index));
        }

        //Create Get Delete Method
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producType = _db.ProductTypes.Find(id);
            if (producType == null)
            {
                return NotFound();
            }
            return View(producType);
        }

        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != productTypes.Id)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product Type has been Deleted";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);
        }
    }
}
