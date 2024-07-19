using Microsoft.AspNetCore.Mvc;
using soft.Models;
using System.Diagnostics;
using System.Collections;
using soft.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace soft.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db=db;
        }

        public IActionResult Index()
        {
            var Name = HttpContext.Session.GetString("Name");
            if (String.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Singup()
        {

            return View(new userData());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Singup(userData userData)
        {
            if (ModelState.IsValid)
            {
                _db.usersData.Add(userData);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(userData);
            }

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new Login());
        }
        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                var datauser = _db.usersData.FirstOrDefault(U => U.Password==user.Password);
                var dataAdmin = _db.Admins.FirstOrDefault(U => U.Password==user.Password);
                if (datauser!=null&& datauser.Password==user.Password&& datauser.Username==user.UserName)
                {
                    TempData["AdminOrNot"]=0;
                    HttpContext.Session.SetString("Name", datauser.Name);
                    return RedirectToAction("Index", "Home");
                }
                else if (dataAdmin!=null&& dataAdmin.Password==user.Password&& dataAdmin.UserName==user.UserName)
                {
                    TempData["AdminOrNot"]=1;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or password");
                }
                
            }
            else { 
            TempData["AdminOrNot"]=0;
             }
            return View(user);
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult checkout()
        {
            List<CartItems> cart = HttpContext.Session.Get<List<CartItems>>("cart")??new List<CartItems>();

            return View(cart);
        }
        public IActionResult main()
        {
            return View();
        }

        public IActionResult shopcart()
        {
            List<CartItems> cart = HttpContext.Session.Get<List<CartItems>>("cart")??new List<CartItems>();

            return View(cart);
        }
        public IActionResult shop(products product_Id)
        {
            List<products> Myproducts = _db.products1.ToList();
            return View(Myproducts);
        }
        public IActionResult productdetails(int? id)
        {
            if (id.HasValue) {

                products Myproduct = _db.products1.FirstOrDefault(U => U.product_Id==id);
                if (Myproduct!=null && Myproduct.product_Id==id) {

                    Categories Categorie = _db.Categories1.FirstOrDefault(U => U.category_Id==Myproduct.category_Id);

                    TempData["product_name"]=Myproduct.product_name;
                    TempData["product_Id"]=Myproduct.product_Id;
                    TempData["product_pic"]=Myproduct.product_pic;
                    TempData["product_price"]=Myproduct.product_price;
                    TempData["product_state"]=Myproduct.product_state;

                    TempData["Size"]=Myproduct.Size;
                    TempData["description"]=Myproduct.description;
                    TempData["quantity"]=Myproduct.quantity;
                    TempData["category_Name"]=Categorie.category_Name;

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Action");
                }
            }
            else{
                TempData["product_name"]=null;
            }
            return View();
        } 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Addtocart(int id)
        {
            List<CartItems> cart = HttpContext.Session.Get<List<CartItems>>("cart")??new List<CartItems>();
            CartItems item1 = cart.FirstOrDefault(i => i.product_Id==id);
            if (item1!=null)
            {

            }
            else
            {
                products c1 = _db.products1.FirstOrDefault(i => i.product_Id==id);
                CartItems newitems = new CartItems
                {
                    product_Id=c1.product_Id,
                    product_name=c1.product_name,
                    product_price=c1.product_price
                };
                cart.Add(newitems);
            }
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction("shopcart", "Home");
        }
        public IActionResult RemoveFromCart(int id)
        {
            List<CartItems> cart = HttpContext.Session.Get<List<CartItems>>("cart")??new List<CartItems>();
            CartItems item1 = cart.FirstOrDefault(i => i.product_Id==id);
                cart.Remove(item1);
          
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction("shopcart");
        }
    }
}
