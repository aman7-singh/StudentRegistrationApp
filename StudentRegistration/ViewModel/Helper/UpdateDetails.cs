using StudentData;
using StudentDomain;

namespace StudentRegistration.ViewModel.Helper
{
    internal static class UpdateDetails
    {
        public static bool UpdateStudentDetails(Student student)
        {
            bool isUdated = false;
            try
            {
                StudentContext.Instance.Update(student);
                StudentContext.Instance.SaveChanges();

                isUdated = true;
            }
            catch
            {
                isUdated = false;
                throw;
            }
            return isUdated;
        }
    }
}
