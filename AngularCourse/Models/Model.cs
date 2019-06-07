using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCourse.Models
{
    public class Model
    {
        public int  Id { get; set; }
        public string  Name { get; set; }
        public Make Makes { get; set; }
        [ForeignKey("Make")]
        public int MakeId { get; set; }
    }
}
