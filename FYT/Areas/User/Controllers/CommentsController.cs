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
    public class CommentsController : Controller
    {
        private readonly ICommentBusinessRules<Comment> _bRules;

        public CommentsController(ICommentBusinessRules<Comment> bRules)
        {
            _bRules = bRules;
        }

        // GET: User/Comments
        public IActionResult Index()
        {
            var comments = _bRules.GetAll();
            return View(comments.ToList());
        }

        // GET: User/Comments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comment = _bRules.GetById(id.Value);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: User/Comments/Create
        public IActionResult Create()
        {            
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Name");
            ViewData["UserId"] = new SelectList(_bRules.GetUsers(), "Id", "UserName");
            return View();
        }

        // POST: User/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CourseId,UserId,Description,CreationDateTime,Id")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreationDateTime = DateTime.Now;
                int? idC = TempData["CourseId"] as int?;
                int? idU = TempData["userId"] as int?;
                comment.CourseId = idC.Value;
                comment.UserId = idU.Value;
                _bRules.Create(comment);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Details", "Courses", new { Id = comment.CourseId });
            }
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Name", comment.CourseId);
            ViewData["UserId"] = new SelectList(_bRules.GetUsers(), "Id", "UserName", comment.UserId);
            return View(comment);
            
        }

        // GET: User/Comments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = _bRules.GetById(id.Value);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Name", comment.CourseId);
            ViewData["UserId"] = new SelectList(_bRules.GetUsers(), "Id", "UserName", comment.UserId);
            return View(comment);
            
        }

        // POST: User/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseId,UserId,Description,CreationDateTime,Id")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bRules.Update(comment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
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
            ViewData["CourseId"] = new SelectList(_bRules.GetCourses(), "Id", "Name", comment.CourseId);
            ViewData["UserId"] = new SelectList(_bRules.GetUsers(), "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: User/Comments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = _bRules.GetById(id.Value);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: User/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bRules.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _bRules.GetAll().Any(e => e.Id == id);
        }
    }
}
