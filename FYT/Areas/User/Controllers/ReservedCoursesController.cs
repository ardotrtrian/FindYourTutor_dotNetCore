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
using Microsoft.Extensions.Caching.Memory;

namespace FYT.Areas.User.Controllers
{
    [Area("User")]
    public class ReservedCoursesController : Controller
    {
        private readonly IReservedCourseBusinessRules<ReservedCourse> _bRules;

        public ReservedCoursesController(IReservedCourseBusinessRules<ReservedCourse> bRules)
        {
            _bRules = bRules;
        }

        // GET: User/ReservedCourses
        public async Task<IActionResult> Index()
        {
            int? id = TempData["UserId"] as int?;
            TempData["UserId"] = id;
            return View(await _bRules.GetAllAsync(id.Value));
        }

        // GET: User/ReservedCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reservedCourse = new Tuple<ReservedCourse,Course, IEnumerable<Comment>>
                (await _bRules.GetAsync(id.Value), await _bRules.GetCourseAsync((await _bRules.GetAsync(id.Value)).CourseId),
                await _bRules.GetCommentsAsync((await _bRules.GetCourseAsync((await _bRules.GetAsync(id.Value)).CourseId)).Id));
            if (reservedCourse == null)
            {
                return NotFound();
            }

            return View(reservedCourse);
        }

        // GET: User/ReservedCourses/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Name");
            ViewData["StudentId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "UserName");            
            return View();
        }

        // POST: User/ReservedCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,StudentId,Status,Id")] ReservedCourse reservedCourse)
        {
            if (ModelState.IsValid)
            {
                int? idC = TempData["CourseId"] as int?;
                int? idU = TempData["userId"] as int?;
                TempData["UserId"] = idU;
                
                if((await _bRules.GetAllAsync()).Where(u => u.StudentId == idU.Value).Where(c => c.CourseId == idC.Value).FirstOrDefault() == null)
                {
                    reservedCourse.CourseId = idC.Value;
                    reservedCourse.StudentId = idU.Value;
                    reservedCourse.Status = Status.Requested;
                    await _bRules.CreateAsync(reservedCourse);
                }                
                return RedirectToAction("Index", "Courses");
            }

            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Description", reservedCourse.CourseId);
            ViewData["StudentId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "Email", reservedCourse.StudentId);
            return View(reservedCourse);
        }

        // GET: User/ReservedCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedCourse = await _bRules.GetAsync(id.Value);
            if (reservedCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Description", reservedCourse.CourseId);
            ViewData["StudentId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "Email", reservedCourse.StudentId);
            return View(reservedCourse);
        }

        // POST: User/ReservedCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,StudentId,Status,Id")] ReservedCourse reservedCourse)
        {
            if (id != reservedCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bRules.UpdateAsync(reservedCourse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservedCourseExists(reservedCourse.Id).Result)
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
            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Description", reservedCourse.CourseId);
            ViewData["StudentId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "Email", reservedCourse.StudentId);
            return View(reservedCourse);
        }

        // GET: User/ReservedCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedCourse = await _bRules.GetAsync(id.Value);
            if (reservedCourse == null)
            {
                return NotFound();
            }

            return View(reservedCourse);
        }

        // POST: User/ReservedCourses/Delete/5
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

        public async Task<IActionResult> CreateComment(int? id)
        {
            TempData["CourseId"] = (await _bRules.GetAsync(id.Value)).CourseId;
            return RedirectToAction("Create", "Comments");
        }

        private async Task<bool> ReservedCourseExists(int id)
        {
            return (await _bRules.GetAllAsync()).Any(e => e.Id == id);
        }
    }
}
