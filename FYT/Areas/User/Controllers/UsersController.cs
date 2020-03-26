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
        public IActionResult Index()
        {
            var users = _bRules.GetAll();
            return View(users.ToList());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([Bind("Email,Password")] Models.User user)
        {
            var _user = _bRules.GetAll()
                .Where(u => u.Email == user.Email)
                .Where(u => u.Password == user.Password).FirstOrDefault();
            if(_user != null)
            {
                return RedirectToAction("Details", "Users", new { id = _user.Id });
            }
            return RedirectToAction("Create", "Users");
        }

        // GET: User/Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _bRules.GetById(id.Value);
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
            //ViewData["Role"] = new SelectList(Enum.GetNames(typeof(Role)));            
            return View();
        }

        // POST: User/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserName,Email,Password,Role,Image,BirthDate,Id")] Models.User user)
        {
            if (ModelState.IsValid)
            {
                _bRules.Create(user);
                return RedirectToAction("Details", "Users", new { id = user.Id });
            }
            IEnumerable<SelectListItem> roles = from Role role in Enum.GetValues(typeof(Role))
                                                 select new SelectListItem
                                                 {
                                                     Text = role.ToString(),
                                                     Value = Convert.ToInt32(role).ToString()
                                                 };
            ViewData["Role"] = new SelectList(roles, "Value", "Text", user.Role);
            //ViewData["Role"] = new SelectList(Enum.GetNames(typeof(Role)), user.Role);
            return View(user);
        }

        // GET: User/Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _bRules.GetById(id.Value);
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
        public IActionResult Edit(int id, [Bind("UserName,Email,Password,Role,Image,BirthDate,Id")] Models.User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bRules.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _bRules.GetById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bRules.Delete(id);
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

        private bool UserExists(int id)
        {
            return _bRules.GetAll().Any(e => e.Id == id);
        }
    }
}
