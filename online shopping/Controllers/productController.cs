using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using soft.Data;
using soft.Models;
using Microsoft.Extensions.Hosting;

namespace soft.Controllers
{
 
    public class productController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public productController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment=environment;
        }

        // GET: product
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.products1.Include(p => p.Categories);
            return View(await appDbContext.ToListAsync());
        }

        // GET: product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.products1 == null)
            {
                return NotFound();
            }

            var products = await _context.products1.Include(p => p.Categories).FirstOrDefaultAsync(m => m.product_Id == id);
            //List<Course> courses = _context.Courses.Where(m => m.DepartmentCode == id).ToList();
            //List<Student> students = _context.Students.Where(m => m.dept_id == id).ToList();

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: product/Create
        public IActionResult Create()
        {
            ViewData["category_Id"] = new SelectList(_context.Categories1, "category_Id", "category_Name");
            return View();
        }

        // POST: product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_Id,product_name,product_price,quantity,description,product_pic,Size,category_Id")] products Myproduct,IFormFile img_file)
        {
            string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }
                Myproduct.product_pic= img_file.FileName;
            }
            else
            {
                Myproduct.product_pic = "default.jpeg"; // to save the default image path in database.
            }
            try
            {
                _context.Add(Myproduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex) { ViewBag.exc = ex.Message; }

            return View(Myproduct);
   }


    

    // GET: product/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.products1 == null)
            {
                return NotFound();
            }

            var products = await _context.products1.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["category_Id"] = new SelectList(_context.Categories1, "category_Id", "category_Name", products.category_Id);
            return View(products);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("product_Id,product_name,product_price,quantity,description,product_pic,Size,category_Id")] products Myproduct,IFormFile img_file)
        {
            if (id != Myproduct.product_Id)
            {
                return NotFound();
            }

            string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
            
                Myproduct.product_pic= img_file.FileName;
            }
            else
            {
                Myproduct.product_pic = "discount.jpg"; // to save the default image path in database.
            }
                try
                {
                    _context.Update(Myproduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productsExists(Myproduct.product_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        // GET: product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products1 == null)
            {
                return NotFound();
            }

            var products = await _context.products1
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.product_Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products1 == null)
            {
                return Problem("Entity set 'AppDbContext.products1'  is null.");
            }
            var products = await _context.products1.FindAsync(id);
            if (products != null)
            {
                _context.products1.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool productsExists(int id)
        {
          return (_context.products1?.Any(e => e.product_Id == id)).GetValueOrDefault();
        }
    }
}
