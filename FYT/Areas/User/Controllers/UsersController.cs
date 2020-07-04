using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FYT.DataAccess.Data;
using FYT.Models;
using FYT.BusinessLogic.IBusinessRules;

namespace FYT.Areas.User.Controllers
{
    [Area("User")]
    public class UsersController : Controller
    {
        private readonly IUserBusinessRules<Models.User> _bRules;

        public UsersController(IUserBusinessRules<Models.User> bRules)
        {
            _bRules = bRules;
        }

        // GET: User/Users
        public async Task<IActionResult> Index()
        {
            return View(await _bRules.GetAllAsync());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] Models.User user)
        {
            var _user = (await _bRules.GetAllAsync())
                .Where(u => u.Email == user.Email)
                .Where(u => u.Password == user.Password).AsQueryable().FirstOrDefault();
            if(_user != null)
            {
                return RedirectToAction("Details", "Users", new { id = _user.Id });
            }
            return RedirectToAction("Create", "Users");
        }

        // GET: User/Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _bRules.GetAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Users/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> roles = from Role role in Enum.GetValues(typeof(Role))
                                                select new SelectListItem
                                                {
                                                    Text = role.ToString(),
                                                    Value = Convert.ToInt32(role).ToString()
                                                };
            ViewData["Role"] = new SelectList(roles, "Value", "Text");           
            return View();
        }

        // POST: User/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,Password,Role,Image,BirthDate,Id")] Models.User user)
        {
            if (ModelState.IsValid)
            {
                await _bRules.CreateAsync(user);
                return RedirectToAction("Details", "Users", new { id = user.Id });
            }
            IEnumerable<SelectListItem> roles = from Role role in Enum.GetValues(typeof(Role))
                                                 select new SelectListItem
                                                 {
                                                     Text = role.ToString(),
                                                     Value = Convert.ToInt32(role).ToString()
                                                 };
            ViewData["Role"] = new SelectList(roles, "Value", "Text", user.Role);
            return View(user);
        }

        // GET: User/Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _bRules.GetAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserName,Email,Password,Role,Image,BirthDate,Id")] Models.User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bRules.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id).Result)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Users", new { id = user.Id }); ;
            }
            return View(user);
        }

        // GET: User/Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _bRules.GetAsync(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bRules.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetMyCourses(int? id)
        {
            TempData["UserId"] = id;
            return RedirectToAction("Index", "MyCourses");
        }

        public IActionResult GetMyReservedCourses(int? id)
        {
            TempData["UserId"] = id;
            return RedirectToAction("Index", "ReservedCourses");
        }

        public IActionResult GetCourses(int? id)
        {
            TempData["UserId"] = id;
            return RedirectToAction("Index", "Courses");
        }

        private async Task<bool> UserExists(int id)
        {
            return (await _bRules.GetAllAsync()).Any(e => e.Id == id);
        }
    }
}
