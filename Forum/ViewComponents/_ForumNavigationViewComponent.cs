using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewComponents
{
    public class _ForumNavigationViewComponent: ViewComponent
    {
        public ApplicationDbContext _context { get; set; }
        public _ForumNavigationViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = _context.categories.Include(t => t.Topics).ToList();
            return View(categories);
        }
    }
}
