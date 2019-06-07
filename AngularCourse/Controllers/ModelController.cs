using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCourse.Models;
using AngularCourse.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private CourseDbContext _courseDbContext { get; set; }
        public ModelController(CourseDbContext courseDbContext)
        {
            _courseDbContext = courseDbContext;
        }
        [HttpGet]
        public IActionResult GetModels()
        {
            try
            {
                var models = _courseDbContext.Models.ToList();
                if (models.Count==0)
                    return StatusCode(StatusCodes.Status204NoContent, models);

                return StatusCode(StatusCodes.Status200OK,models);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            
        }
        [HttpPost]
        public IActionResult PostModel(Model model )
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var models = _courseDbContext.Models.Add(model);
                _courseDbContext.SaveChanges();
                
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
    }
}