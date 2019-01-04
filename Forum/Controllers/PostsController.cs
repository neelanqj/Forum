using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Forum.Controllers { 
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        protected UserManager<User> _userManager;

        public PostsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.posts
                .Include(p => p.Topic)
                .Include(u => u.User);

            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        [Route("/Posts/{category}/{topic}")]
        public async Task<IActionResult> Index(string category, string topic)
        {
            List<Post> posts = await _context.posts
                .Include(u=>u.User)
                .Include(t=> t.Topic)
                .Include(c => c.Topic.Category)
                .Where(p => p.Topic.Name == topic && p.Topic.Category.Name == category)
                .ToListAsync();
            ViewData["Topic"] = topic; 

            return View(posts);
        }
        

        // GET: posts/Details/5
        [HttpGet]
        [Route("/Posts/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .Include(u=>u.User)
                .Include(p => p.Topic)
                .ThenInclude(c=>c.Category)
                .Include(c => c.Comments)
                .ThenInclude(uc=>uc.User)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: posts/Create
        [Authorize]
        [Route("/Posts/Create")]
        public IActionResult Create()
        {
            ViewData["TopicId"] = new SelectList(_context.topics, "TopicId", "Name");
            return View();
        }

        [Authorize]
        [HttpGet]
        [Route("/Posts/Create/{topic}")]
        public IActionResult Create(string topic)
        {
            Topic item = _context.topics.Where(t => t.Name == topic).FirstOrDefault();
            ViewData["CurrentTopic"] = item.TopicId;
            ViewData["TopicId"] = new SelectList(_context.topics, "TopicId", "Name", item);
            
            return View();
        }

        // POST: posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("/Posts/Create")]

        public async Task<IActionResult> Create([Bind("PostId,Details,TopicId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.User = await _userManager.GetUserAsync(HttpContext.User); 
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TopicId"] = new SelectList(_context.topics, "TopicId", "TopicId", post.TopicId);
            return View(post);
        }

        // GET: posts/Edit/5    
        [Authorize]
        [Route("/Posts/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["TopicId"] = new SelectList(_context.topics, "TopicId", "TopicId", post.TopicId);
            return View(post);
        }

        // POST: posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("/Posts/Edit/{id}")]

        public async Task<IActionResult> Edit(int id, [Bind("PostId,Details,TopicId")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            ViewData["TopicId"] = new SelectList(_context.topics, "TopicId", "TopicId", post.TopicId);
            return View(post);
        }

        // GET: posts/Delete/5
        [Authorize]
        [Route("/Posts/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .Include(p => p.Topic)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.posts.FindAsync(id);
            _context.posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.posts.Any(e => e.PostId == id);
        }
    }
}
