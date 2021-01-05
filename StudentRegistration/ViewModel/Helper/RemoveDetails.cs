using StudentData;
using StudentDomain;
using System;

namespace StudentRegistration.ViewModel.Helper
{
    internal static class RemoveDetails
    {
        public static bool RemoveStudentDetails(Student student)
        {
            bool isRemoved = false;
            try
            {
                StudentContext.Instance.Remove(student);
                StudentContext.Instance.SaveChanges();

                isRemoved = true;
            }
            catch
            {
                isRemoved = false;
                throw;
            }
            return isRemoved;
        }
    }
}
