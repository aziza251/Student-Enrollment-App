using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile.Models
{
    public class CourseClass
    {
        [PrimaryKey, AutoIncrement]
        public int course_Id { get; set; }
        public string course_code { get; set; }

        public string course_name { get; set;}
    }
}
