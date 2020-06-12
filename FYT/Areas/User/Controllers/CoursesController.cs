using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FYT.BusinessLogic.BusinessRules;
using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data;
using FYT.DataAccess.Data.Repository;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FYT.Areas.User.Controllers
{
    [Area("User")]
    public class CoursesController : Controller
    {        
        private readonly ICourseBusinessRules<Course> _bRules;

        public CoursesController(ICourseBusinessRules<Course> bRules)
        {
            _bRules = bRules;
        }

        // GET: User/Courses
        
        public IActionResult Index(string searchString)
        {
            //int? id = TempData["UserId"] as int?;
            //TempData["userId"] = id;
            //var courses = _bRules.GetAll().Where(c => c.TutorId != id.Value);
            //return View(courses.ToList());   



            int? id = TempData["UserId"] as int?;
            TempData["UserId"] = id;
            var courses = _bRules.GetAll().Where(c => c.TutorId != id.Value);

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.Name.Contains(searchString));         
            }
            return View(courses.ToList());

        }

        //[HttpGet]
        //public IActionResult Search(string searchString)
        //{
        //    if (searchString == null)
        //    {
        //        return NotFound();
        //    }
            
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(course);

        //}

        //public IActionResult Index(string searchString)
        //{
        //    ViewData["CategoryID"] = new SelectList(_bRules.GetCategories(), "Id", "Name");

        //    // ViewModel

        //    var items = _bRules.GetAll();


        //    // Search

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //         items = items.Where(i => i.CategoryId)
        //    }

        //    if (!String.IsNullOrEmpty(Request["CategoryID"]))
        //    {
        //        var strDDLValue = Convert.ToInt32(Request["CategoryID"]);

        //        if (strDDLValue >= 1)
        //        {
        //            searchString = searchString.ToUpper();
        //            items = items.Where(r => r.SubCateogory.CategoryID == strDDLValue && r.Title.ToUpper().Contains(searchString));
        //        }
        //    }

        //    return View(items);
        //}

        // GET: User/Courses/Details/5
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = new Tuple<Course, IEnumerable<Comment>>( _bRules.GetById(id.Value), _bRules.GetComments(id.Value));
            if (course == null)
            {
                return NotFound();
            }
            
            return View(course);
        }

        // GET: User/Courses/Create
        
        public IActionResult Create()
        {
              
            ViewData["CategoryId"] = new SelectList(_bRules.GetCategories(), "Id", "Name");
            ViewData["TutorId"] = new SelectList(_bRules.GetTutors(), "Id", "UserName");
            return View();
        }

        // POST: User/Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,TutorId,CategoryId,StartDate,EndDate,Description,Price,Id")] Course course)
        {
            if (ModelState.IsValid)
            {                
                _bRules.Create(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_bRules.GetCategories(), "Id", "Name", course.CategoryId);
            ViewData["TutorId"] = new SelectList(_bRules.GetTutors(), "Id", "Email", course.TutorId);
            return View(course);
        }

        // GET: User/Courses/Edit/5
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _bRules.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_bRules.GetCategories(), "Id", "Name", course.CategoryId);
            ViewData["TutorId"] = new SelectList(_bRules.GetTutors(), "Id", "Email", course.TutorId);
            return View(course);
        }

        // POST: User/Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,TutorId,CategoryId,StartDate,EndDate,Description,Price,Id")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bRules.Update(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["CategoryId"] = new SelectList(_bRules.GetCategories(), "Id", "Name", course.CategoryId);
            ViewData["TutorId"] = new SelectList(_bRules.GetTutors(), "Id", "Name", course.TutorId);
            return View(course);
        }

        // GET: User/Courses/Delete/5
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _bRules.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: User/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _bRules.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult CreateComment(int? id)
        {
            TempData["CourseId"] = id;
            return RedirectToAction("Create", "Comments");
        }

       
        public IActionResult ReserveCourse(int? id)
        {
            //int? idU = TempData["userId"] as int?;
            //TempData["_userId"] = idU;
            TempData["CourseId"] = id;
            return RedirectToAction("Create", "ReservedCourses");
        }

        public IActionResult GoToMyPage()
        {
            int? Id = TempData["UserId"] as int?;
            //TempData["UserId"] = Id;
            return RedirectToAction("Details", "Users", new { id = Id.Value });
        }

        private bool CourseExists(int id)
        {
            return _bRules.GetAll().Any(e => e.Id == id);
        }
    }
}