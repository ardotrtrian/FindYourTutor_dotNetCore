using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FYT.BusinessLogic.BusinessRules;
using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FYT.Areas.User.Controllers
{
    [Area("User")]
    public class CourseController : Controller
    {
        private readonly ICourseBusinessRule<Course> _br;

        public CourseController(ICourseBusinessRule<Course> br)
        {
            _br = br;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region API calls

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _br.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var success = _br.Delete(id);

            if (success == false)
            {
                return Json(new { success , message = "Error while deleting!" });
            }

            return Json(new { success , message = "Course deleted successfully!"  });
        }

        [HttpGet]
        public IActionResult Get(int TutorId)
        {
            return Json(new { data = _br.Get(TutorId) });
        }
        #endregion
    }
}