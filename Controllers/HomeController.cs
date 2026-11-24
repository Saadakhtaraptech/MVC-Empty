
using Microsoft.AspNetCore.Mvc;
using Saad.Models;
using Saad.Models.Entity;
using WebApplication_Empty.Data;
using System.Diagnostics;

namespace Saad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _Context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _Context = context;
        }

        public IActionResult Index()
        {
            var users = _Context.users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _Context.users.Add(user);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = _Context.users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _Context.users.Update(user);
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var FindUser = _Context.users.Find(id);

            if (FindUser == null)
            {
                return NotFound();
            }

            return View(FindUser);
        }

        [HttpPost]
        public IActionResult Delete(int id, User user)
        {
            var FindUser = _Context.users.Find(id);

            if (FindUser != null)
            {
                _Context.users.Remove(FindUser);
                _Context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
