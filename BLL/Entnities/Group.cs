using System.Collections.Generic;

namespace BLL
{
    public class Group
    {
        private string Name;
        private int Course;
        private int Id;
        private Facult _Facult;
        private List<Student> Students;
        private Student Headman;
        private Teacher Curator;

        public Group(int id, string name, int course, List<Student> students, Student headman, Teacher curator, Facult facult)
        {
            Id = id;
            Name = name;
            Course = course;
            Students = students;
            Headman = headman;
            Curator = curator;
            _Facult = facult;
        }
        public int GetId()
        {
            return Id;
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
            return _Facult;
        }
        public Teacher GetCurator()
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
        public void ChangeName(string name)
        {
            Name = name;
        }
        public void ChangeCourse(int course)
        {
            Course = course;
        }
        public void ChangeFacult(Facult facult)
        {
            _Facult = facult;
        }
        public void ChangeCurator(Teacher curator)
        {
            Curator = curator;
        }
        public void ChangeHeadman(Student student)
        {
            Headman = student;
        }
    }
}
