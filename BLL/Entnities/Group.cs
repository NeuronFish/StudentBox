using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Group
    {
        private string Name;
        private int Course;
        private int Id;
        private Facult Facult;
        private List<Student> Students;
        private Student Headman;
        private Person Curator;
        public Group(string name, int course, List<Student> students, Student headman, Person curator, Facult facult)
        {
            Name = name;
            Course = course;
            Students = students;
            Headman = headman;
            Curator = curator;
            Facult = facult;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetCourse()
        {
            return Course;
        }
        public List<Student> GetStudentList()
        {
            return Students;
        }
        public Student GetHeadman()
        {
            return Headman;
        }
        public Facult GetFacult()
        {
            return Facult;
        }
        public Person GetCurator()
        {
            return Curator;
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        public void ChangeCurator(Person curator)
        {
            Curator = curator;
        }
        public void ChangeHeadman(Student student)
        {
            Headman = student;
        }
    }
}
