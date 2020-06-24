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
        public async Task<IActionResult> Index()
        {
            return View(await _bRules.GetAllAsync());
        }

        // GET: User/Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comment = await _bRules.GetAsync(id.Value);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: User/Comments/Create
        public async Task<IActionResult> Create()
        {            
            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Name");
            ViewData["UserId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "UserName");
            return View();
        }

        // POST: User/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,UserId,Description,CreationDateTime,Id")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreationDateTime = DateTime.Now;
                int? idC = TempData["CourseId"] as int?;
                int? idU = TempData["userId"] as int?;
                comment.CourseId = idC.Value;
                comment.UserId = idU.Value;
                await _bRules.CreateAsync(comment);
                return RedirectToAction("Details", "Courses", new { Id = comment.CourseId });
            }
            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Name", comment.CourseId);
            ViewData["UserId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "UserName", comment.UserId);
            return View(comment);
            
        }

        // GET: User/Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _bRules.GetAsync(id.Value);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Name", comment.CourseId);
            ViewData["UserId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "UserName", comment.UserId);
            return View(comment);
            
        }

        // POST: User/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,UserId,Description,CreationDateTime,Id")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bRules.UpdateAsync(comment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id).Result)
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
            ViewData["CourseId"] = new SelectList(await _bRules.GetCoursesAsync(), "Id", "Name", comment.CourseId);
            ViewData["UserId"] = new SelectList(await _bRules.GetUsersAsync(), "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // GET: User/Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _bRules.GetAsync(id.Value);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: User/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bRules.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CommentExists(int id)
        {
            return (await _bRules.GetAllAsync()).Any(e => e.Id == id);
        }

        public IActionResult GoToMyPage()
        {
            int? Id = TempData["UserId"] as int?;
            return RedirectToAction("Details", "Users", new { id = Id.Value });
        }
    }
}
