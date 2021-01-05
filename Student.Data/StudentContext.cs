using Microsoft.EntityFrameworkCore;
using StudentDomain;

using System;

namespace StudentData
{
    public sealed class StudentContext : DbContext
    {
        const string  _dbConnectionString = "Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=StudentRegistrationData";
        public DbSet<StudentDomain.Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        static object lockObj = new object();
        private static StudentContext _studentContext;
        public static StudentContext Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (_studentContext == null)
                    {
                        _studentContext = new StudentContext();
                    }
                    return _studentContext;
                }
            }
        }
        private StudentContext() { }
    }
}
