using mobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mobile.DataTransactions
{
    public class DBTrans
    {
        public string dbPath;
        private SQLiteConnection conn;

        public DBTrans(string _dbPath)
        {
            this.dbPath = _dbPath;
            Init();
        }

        public void Init()
        {
            if (conn == null)
            {
                conn = new SQLiteConnection(this.dbPath);
                conn.CreateTable<StudentClass>();
                conn.CreateTable<CourseClass>();
                conn.CreateTable<EnrollClass>();
            }
        }

        public List<StudentClass> GetAllStudents()
        {
            return conn.Table<StudentClass>().ToList();
        }

        public List<CourseClass> GetAllCourses()
        {
            return conn.Table<CourseClass>().ToList();
        }

        public List<EnrollClass> GetEnrollList()
        {
            return conn.Table<EnrollClass>().ToList();
        }

        public void Add(StudentClass student)
        {
            conn.Insert(student);
        }

        public void Delete(int student_ID)
        {
            var remove_student = conn.Table<StudentClass>().FirstOrDefault(e => e.ID == student_ID);
            if (remove_student != null)
            {
                conn.Delete(remove_student);
            }
        }

        public void Add(CourseClass course)
        {
            conn.Insert(course);
        }

        public void Deletee(int course_id)
        {
            var remove_course = conn.Table<CourseClass>().FirstOrDefault(e => e.course_Id == course_id);
            if (remove_course != null)
            {
                conn.Delete(remove_course);
            }
        }

        public bool StudentExists(int studentId)
        {
            return conn.Table<StudentClass>().Any(s => s.ID == studentId);
        }

        public bool Add(EnrollClass enroll)
        {
            if (StudentExists(enroll.Stu_ID))
            {
                conn.Insert(enroll);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteEnrollment(int studentId, string courseCode)
        {
            var enrollment = conn.Table<EnrollClass>().FirstOrDefault(e => e.Stu_ID == studentId && e.course_code == courseCode);
            if (enrollment != null)
            {
                conn.Delete(enrollment);
            }
        }
    }
}
