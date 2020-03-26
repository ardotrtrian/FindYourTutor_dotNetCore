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
    public class ReservedCoursesController : Controller
    {
        private readonly IReservedCourseBusinessRules<ReservedCourse> _bRules;

        public ReservedCoursesController(IReservedCourseBusinessRules<ReservedCourse> bRules)
        {
            _bRules = bRules;
        }

        // GET: User/ReservedCourses
        public IActionResult Index()
        {
            int? id = TempData["UserId"] as int?;
            TempData["_userId"] = id;
            var reservedCourses = _bRules.GetAll(id.Value);
            return View(reservedCourses.ToList());
        }

        // GET: User/ReservedCourses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reservedCourse = new Tuple<ReservedCourse,Course, IEnumerable<Comment>>(_bRules.GetById(id.Value), _bRules.GetCourse(id.Value), _bRules.GetComments(_bRules.GetCourse(id.Value).Id));
            if (reservedCourse == null)
            {
                return NotFound();
            }

            return View(reservedCourse);
        }

        // GET: User/ReservedCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Name");
            ViewData["StudentId"] = new SelectList(_bRules.GetUsers(), "Id", "UserName");            
            return View();
        }

        // POST: User/ReservedCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CourseId,StudentId,Status,Id")] ReservedCourse reservedCourse)
        {
            if (ModelState.IsValid)
            {
                int? idC = TempData["CourseId"] as int?;
                int? idU = TempData["userId"] as int?;
                TempData["UserId"] = idU;
                
                
                if(_bRules.GetAll().Where(u => u.StudentId == idU.Value).Where(c => c.CourseId == idC.Value) == null)
                {
                    reservedCourse.CourseId = idC.Value;
                    reservedCourse.StudentId = idU.Value;
                    reservedCourse.Status = Status.Requested;
                    _bRules.Create(reservedCourse);
                }                
                return RedirectToAction("Index", "Courses");
            }
            //IEnumerable<SelectListItem> statuses = from Status status in Enum.GetValues(typeof(Status))
            //                                    select new SelectListItem
            //                                    {
            //                                        Text = status.ToString(),
            //                                        Value = Convert.ToInt32(status).ToString()
            //                                    };
            //ViewData["Status"] = new SelectList(statuses, "Value", "Text", reservedCourse.Status);
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Description", reservedCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_bRules.GetUsers(), "Id", "Email", reservedCourse.StudentId);
            return View(reservedCourse);
        }

        // GET: User/ReservedCourses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedCourse = _bRules.GetById(id.Value);
            if (reservedCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Description", reservedCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_bRules.GetUsers(), "Id", "Email", reservedCourse.StudentId);
            return View(reservedCourse);
        }

        // POST: User/ReservedCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseId,StudentId,Status,Id")] ReservedCourse reservedCourse)
        {
            if (id != reservedCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bRules.Update(reservedCourse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservedCourseExists(reservedCourse.Id))
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
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Description", reservedCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_bRules.GetUsers(), "Id", "Email", reservedCourse.StudentId);
            return View(reservedCourse);
        }

        // GET: User/ReservedCourses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservedCourse = _bRules.GetById(id.Value);
            if (reservedCourse == null)
            {
                return NotFound();
            }

            return View(reservedCourse);
        }

        // POST: User/ReservedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bRules.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ReservedCourseExists(int id)
        {
            return _bRules.GetAll().Any(e => e.Id == id);
        }
    }
}
