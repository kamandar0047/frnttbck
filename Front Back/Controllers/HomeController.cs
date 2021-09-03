using Front_Back.DAL;
using Front_Back.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Front_Back.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context { get; }
        public HomeController (AppDbContext context)
        {
            _context = context;
        }
            public  async Task<IActionResult> Index()
        {
            HomeVm homeVM = new HomeVm
            {
                Slides = await _context.Slides.ToListAsync(),
                Introduction = await _context.Introduction.FirstOrDefaultAsync(),
               Categories =await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync(),
               
            };
          //  HttpContext.Session.SetString("name", "Kamandar");
          //  //Response.Cookies.Append("surname", "Muradali");
          //  List<BasketProduct> baskets = new List<BasketProduct>
          // {
          //      new BasketProduct{Id=1,Count=2},
          //       new BasketProduct{Id=2,Count=3},
          //       new BasketProduct{Id=3,Count=4},
          //         new BasketProduct{Id=4,Count=5}
          // };
          //Response.Cookies.Append("basket", JsonSerializer.Serialize(baskets));
            return View(homeVM);
        
        }
        public IActionResult AddBasket(int? id)
        {

            //string sessionData = HttpContext.Session.GetString("name");
            //string cookieData = Request.Cookies["qwwq"];
            //List<BasketProduct> cookieData =
            //  JsonSerializer.Deserialize<List<BasketProduct>>(Request.Cookies["basket"]);
            //return Content($"session:{sessionData},\n cookie:{cookieData}");
            return RedirectToAction(nameof(Index));

        }
    }
}
