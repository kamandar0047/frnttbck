using Front_Back.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_Back.ViewComponents
{
    public class FooterViewComponent :ViewComponent
        {
            public AppDbContext _context { get; }
            public FooterViewComponent(AppDbContext context)
            {
                _context = context;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {
                var model = _context.Products.Include(p => p.Images).Where(p => p.IsDeleted == false).OrderByDescending(p => p.Id).Take(12);

                return View(await Task.FromResult(model));
            }
        }
    }



