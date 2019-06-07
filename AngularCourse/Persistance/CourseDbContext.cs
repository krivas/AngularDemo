using AngularCourse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCourse.Persistance
{
    public class CourseDbContext : DbContext 
    {
        public  DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
        public CourseDbContext(DbContextOptions options)
            : base(options)
        {

        }

     
    }
}
