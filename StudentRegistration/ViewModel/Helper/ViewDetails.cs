using StudentData;
using StudentDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentRegistration.ViewModel.Helper
{
    internal static class ViewDetails
    {
        public static List<Student> GetAllStudentsDetails()
        {
            List<Student> students= new List<Student>();
            try
            {
                students = StudentContext.Instance.Students.ToList();
            }
            catch
            {
                throw;
            }
            return students;
        }
        public static List<Student> GetStudentDetails(int rollNo)
        {
            List<Student> students= new List<Student>();
            try
            {
                students = StudentContext.Instance.Students.Where(s => s.RollNo == rollNo).ToList();
            }
            catch
            {
                throw;
            }
            return students;
        }
    }
}
