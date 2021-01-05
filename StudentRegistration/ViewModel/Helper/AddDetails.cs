using StudentData;
using StudentDomain;

namespace StudentRegistration.ViewModel.Helper
{
    internal static class AddDetails
    {
        public static bool AddStudentDetails(Student student)
        {
            bool isAdded = false;
            try
            {
                StudentContext.Instance.Add(student);
                StudentContext.Instance.SaveChanges();
                isAdded = true;
            }
            catch
            {
                isAdded = false;
                throw;
            }
            return isAdded;
        }
    }
}
