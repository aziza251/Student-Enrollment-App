using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile.Models
{
    public class EnrollClass
    {
        [PrimaryKey, AutoIncrement]
        public int Stu_ID { get; set; }
        public string Stu_Name { get; set; }
        public string course_code { get; set; }
    }
}
