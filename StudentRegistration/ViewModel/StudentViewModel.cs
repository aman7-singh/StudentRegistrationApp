using StudentRegistration.Command;
using StudentRegistration.ViewModel.Helper;
using System;
using System.Windows.Input;
using StudentRegistration.Logger;
using StudentDomain;
using StudentData;
using System.Collections.Generic;
using System.Linq;

namespace StudentRegistration.ViewModel
{
    public class StudentViewModel: BindableBase
    {
        #region Fields
        private int _id;
        private int _rollNo;
        private string _studentname;
        private string _branchName;
        private LogMessage logmsg;
        private int _registrationId;
        private string _errorMessage;
        private string _warningMessage;
        private string _infoMessage;
        private List<Student> _students = new List<Student>();
        #endregion 

        #region Proerties
        public string InfoMessage
        {
            get { return _infoMessage; }
            set
            {
                _infoMessage = value;
                OnPropertyRaised(nameof(InfoMessage));
            }
        }
        public string WarningMessage
        {
            get { return _warningMessage; }
            set {
                _warningMessage = value;
                OnPropertyRaised(nameof(WarningMessage));
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value;
                OnPropertyRaised(nameof(ErrorMessage));
            }
        }
        public List<Student> Students
        {
            get 
            { 
                return _students; 
            }
            set 
            {
                _students = value;
                OnPropertyRaised(nameof(Students));
            }
        }
        public int RegistrationID
        {
            get { return _registrationId; }
            set
            { 
                _registrationId = value; 
                OnPropertyRaised(nameof(RegistrationID));
            }
        }
        public string BranchName
        {
            get { return _branchName; }
            set 
            {
                _branchName = value;
                OnPropertyRaised(nameof(BranchName));
            }
        }
        public string StudentName
        {
            get { return _studentname; }
            set 
            {
                _studentname = value;
                OnPropertyRaised(nameof(StudentName));
            }
        }
        public int RollNo
        {
            get { return _rollNo; }
            set 
            { 
                _rollNo = value; 
                OnPropertyRaised(nameof(RollNo));
            }
        }
        public int ID
        {
            get { return _id; }
            
        }
        #endregion

        #region ICommands
        public ICommand AddDetailsCommand { get; set; }
        public ICommand UpdateDetailsCommand { get; set; }
        public ICommand RemoveDetailsCommand { get; set; }
        public ICommand ViewAllStudentsDetailsCommand { get; set; }
        public ICommand ViewStudentDetailsCommand { get; set; }
        #endregion

        #region Constructor
        public StudentViewModel()
        {
            logmsg = LogMessage.LoggerInstance;
            StudentContext.Instance.Database.EnsureCreated();
            AddDetailsCommand = new RelayCommand<string>(c => Add(), c => true);
            UpdateDetailsCommand = new RelayCommand<string>(c => Update(), c => true);
            RemoveDetailsCommand = new RelayCommand<string>(c => Remove(), c => true);
            ViewAllStudentsDetailsCommand = new RelayCommand<string>(c => GetAllStudents(), c => true);
            ViewStudentDetailsCommand = new RelayCommand<string>(c => GetStudent(), c => true);
        }
        #endregion

        #region Private Methods
        private void Add()
        {
            try
            {
                ErrorMessage = WarningMessage = InfoMessage = string.Empty;
                var studentObj = new Student
                { 
                    RollNo=_rollNo,
                    StudentName =  _studentname,
                    BranchName = _branchName,
                    RegistrationID = _registrationId
                };
                if (AddDetails.AddStudentDetails(studentObj))
                {
                    InfoMessage = studentObj.ToString();
                    GetAllStudents();
                }
                else
                {
                    WarningMessage = "Not able to add student details.";
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message.ToString();
                logmsg.Log(LogMessage.LogType.Error, e.ToString());
            }
        }
        private void Update()
        {
            try
            {
                ErrorMessage = WarningMessage = InfoMessage = string.Empty;
                var studentObj = new Student
                {
                    RollNo = _rollNo,
                    StudentName = _studentname,
                    BranchName = _branchName,
                    RegistrationID = _registrationId
                };
                if (UpdateDetails.UpdateStudentDetails(studentObj))
                {
                    InfoMessage = studentObj.ToString();
                    GetAllStudents();
                }
                else
                {
                    WarningMessage = "Not able to update student details.";
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message.ToString();
                logmsg.Log(LogMessage.LogType.Error, e.ToString());
            }
        }
        private void Remove()
        {
            try
            {
                ErrorMessage = WarningMessage = InfoMessage = string.Empty;
                var studentObj = new Student
                {
                    RollNo = _rollNo,
                    StudentName = _studentname,
                    BranchName = _branchName,
                    RegistrationID = _registrationId
                };
                var Student = ViewDetails.GetStudentDetails(RollNo).FirstOrDefault();
                if (RemoveDetails.RemoveStudentDetails(Student))
                {
                    InfoMessage = studentObj.ToString();
                    GetAllStudents();
                }
                else
                {
                    WarningMessage = "Data is already removed from database.";
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message.ToString();
                logmsg.Log(LogMessage.LogType.Error, e.ToString());
            }
        }
        private void GetAllStudents()
        {
            try
            {
                ErrorMessage = WarningMessage = InfoMessage = string.Empty;
                Students = ViewDetails.GetAllStudentsDetails();
                if (Students.Count < 1)
                {
                    WarningMessage = "No data found.";
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message.ToString();
                logmsg.Log(Logger.LogMessage.LogType.Error, e.ToString());
            }
        }
        private void GetStudent()
        {
            try
            {
                ErrorMessage = WarningMessage = InfoMessage = string.Empty;
                Students = ViewDetails.GetStudentDetails(RollNo);
                if (Students.Count < 1)
                {
                    WarningMessage = "No data found with selected roll number.";
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message.ToString();
                logmsg.Log(LogMessage.LogType.Error, e.ToString());
            }
        }
        #endregion 
    }
}
