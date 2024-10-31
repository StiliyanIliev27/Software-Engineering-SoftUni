using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private int studentId = 1;
        private int subjectId = 1;
        private int universityId = 1;       
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {         
            if(students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }

            IStudent student = new Student(studentId, firstName, lastName);
            students.AddModel(student);
           
            studentId++;

            return $"Student {firstName} {lastName} is added to the {students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            var supportedSubjects = new List<string>
            {
                nameof(SubjectType.EconomicalSubject),
                nameof(SubjectType.TechnicalSubject),
                nameof(SubjectType.HumanitySubject)
            };

            if(!supportedSubjects.Any(s => s == subjectType))
            {
                return $"Subject type {subjectType} is not available in the application!";
            }

            if(subjects.Models.Any(s => s.Name == subjectName))
            {
                return $"{subjectName} is already added in the repository.";
            }

            _ = Enum.TryParse(subjectType, out SubjectType type);
           
            Subject subject = type switch
            {
                SubjectType.TechnicalSubject => new TechnicalSubject(subjectId, subjectName),
                SubjectType.EconomicalSubject => new EconomicalSubject(subjectId, subjectName),
                SubjectType.HumanitySubject => new HumanitySubject(subjectId, subjectName),
                _ => null
            };

            subjects.AddModel(subject);
            subjectId++;

            return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity,
            List<string> requiredSubjects)
        {
            if(universities.FindByName(universityName) != null)
            {
                return $"{universityName} is already added in the repository.";
            }

            List<int> requiredIds = new();

            foreach(var subject  in subjects.Models)
            {
                requiredIds.Add(subject.Id);
            }

            IUniversity university = new University(universityId, universityName, category, capacity, requiredIds);
            universities.AddModel(university);
            universityId++;

            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);
           
            string[] nameSplitted = studentName.Split();
            
            string firstName = nameSplitted[0];
            string lastName = nameSplitted[1];

            string result = string.Empty;

            if (student == null)
            {
                result = string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            else if (university == null)
            {
                result = string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))
            {
                result = string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            else if (student.University != null && student.University.Name == universityName)
            {
                result = string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }
            else
            {
                student.JoinUniversity(university);
                result = string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
            }

            return result.TrimEnd();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if(students.FindById(studentId) == null)
            {
                return "Invalid student ID!";
            }

            if(subjects.FindById(subjectId) == null)
            {
                return "Invalid subject ID!";
            }

            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if(student.CoveredExams.Any(e => e == subjectId))
            {               
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";
            }

            student.CoverExam(subject);

            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId); 

            List<IStudent> universityStudents = new List<IStudent>();

            foreach(var student in students.Models)
            {
                if(student.University != null)
                {
                    if(student.University.Id == universityId)
                    {
                        universityStudents.Add(student);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {universityStudents.Count}");
            sb.AppendLine($"University vacancy: {university.Capacity - universityStudents.Count}");

            return sb.ToString().TrimEnd();
        }
    }

}
