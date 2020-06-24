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
    public class MyCoursesController : Controller
    {
        private readonly ICourseBusinessRules<Course> _bRules;

        public MyCoursesController(ICourseBusinessRules<Course> bRules)
        {
            _bRules = bRules;
        }

        // GET: User/Courses
        public async Task<IActionResult> Index()
        {
            int? id = TempData["UserId"] as int?;
            TempData["UserId"] = id;
            return View(await _bRules.GetAllAsync(id.Value));
        }

        // GET: User/Courses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = new Tuple<Course, IEnumerable<Comment>>(await _bRules.GetAsync(id.Value), await _bRules.GetCommentsAsync(id.Value));
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: User/Courses/Create
        public async Task<IActionResult> Create()
        {

            ViewData["CategoryId"] = new SelectList(await _bRules.GetCategoriesAsync(), "Id", "Name");
            ViewData["TutorId"] = new SelectList(await _bRules.GetTutorsAsync(), "Id", "UserName");
            return View();
        }

        // POST: User/Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,TutorId,CategoryId,StartDate,EndDate,Description,Price,Id")] Course course)
        {
            if (ModelState.IsValid)
            {
                int? id = TempData["UserId"] as int?;
                course.TutorId = id.Value;
                await _bRules.CreateAsync(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _bRules.GetCategoriesAsync(), "Id", "Name", course.CategoryId);
            ViewData["TutorId"] = new SelectList(await _bRules.GetTutorsAsync(), "Id", "Email", course.TutorId);
            return View(course);
        }

        // GET: User/Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _bRules.GetAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _bRules.GetCategoriesAsync(), "Id", "Name", course.CategoryId);
            ViewData["TutorId"] = new SelectList(await _bRules.GetTutorsAsync(), "Id", "Email", course.TutorId);
            return View(course);
        }

        // POST: User/Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,TutorId,CategoryId,StartDate,EndDate,Description,Price,Id")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bRules.UpdateAsync(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id).Result)
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
            ViewData["CategoryId"] = new SelectList(await _bRules.GetCategoriesAsync(), "Id", "Name", course.CategoryId);
            ViewData["TutorId"] = new SelectList(await _bRules.GetTutorsAsync(), "Id", "Name", course.TutorId);
            return View(course);
        }

        // GET: User/Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _bRules.GetAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: User/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _bRules.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GoToMyPage()
        {
            int? Id = TempData["UserId"] as int?;
            return RedirectToAction("Details", "Users", new { id = Id.Value });
        }

        public IActionResult CreateComment(int? id)
        {
            TempData["courseid"] = id;
            return RedirectToAction("Create", "Comments");
        }
        private async Task<bool> CourseExists(int id)
        {
            return (await _bRules.GetAllAsync()).Any(e => e.Id == id);
        }
    }
}
