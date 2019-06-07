using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCourse.Models;
using AngularCourse.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private CourseDbContext _courseDbContext { get; set; }
        public MakeController(CourseDbContext courseDbContext)
        {
            _courseDbContext = courseDbContext;
        }
        [HttpGet]
        public IActionResult GetMakes()
        {
            try
            {
                var makes = _courseDbContext.Makes.Include(m => m.Models).ToList();
                if (makes.Count == 0)
                    return StatusCode(StatusCodes.Status204NoContent, makes);

                return StatusCode(StatusCodes.Status200OK, makes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
        [HttpPost]
        public IActionResult PostMakes(Make make)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var models = _courseDbContext.Makes.Add(make);
                _courseDbContext.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
        [HttpPut]
        public IActionResult PutMakes(Make make)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var models = _courseDbContext.Makes.Update(make);
                _courseDbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }

        [HttpDelete]
        public IActionResult DeleteMakes(Make make)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var models = _courseDbContext.Makes.Remove(make);
                
                _courseDbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }

    }
}