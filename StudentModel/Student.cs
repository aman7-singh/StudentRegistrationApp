using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentDomain
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public int RollNo { get; set; }
        public int RegistrationID { get; set; }
        public string StudentName { get; set; }
        public string BranchName { get; set; }

        public override string ToString()
        {

            return $"Student info {RollNo} {RegistrationID} {StudentName} {BranchName}";
        }

    }
}
