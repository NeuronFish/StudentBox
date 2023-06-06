using System;
using System.Collections.Generic;

namespace BLL
{
    public class MainLogic
    {
        private List<Student> Students = new List<Student>();
        private List<Teacher> Teachers = new List<Teacher>();
        private List<Group> Groups = new List<Group>();
        private List<Facult> Facults = new List<Facult>();

        public MainLogic()
        {
            AddDefault();
        }
        private void AddDefault()
        {
            Facults.Add(new Facult(1, "ФККПІ", null, new List<Group>(), new List<Teacher>()));
            Facults.Add(new Facult(2, "ФЕБА", null, new List<Group>(), new List<Teacher>()));
            Teachers.Add(new Teacher(1, "Артем", "Лабза", "Павлович", "ст. викладач", Facults[0], null));
            Teachers.Add(new Teacher(2, "Павло", "Зібров", "Ігорович", "лектор", Facults[0], null));
            Teachers.Add(new Teacher(3, "Олена", "Любов", "Олексіївна", "ст. викладач", Facults[1], null));
            Teachers.Add(new Teacher(4, "Мексон", "Стренглер", "Євгенович", "лектор", Facults[1], null));
            Facults[0].ChangeDean(Teachers[0]);
            Facults[0].AddTeacher(Teachers[0]);
            Facults[0].AddTeacher(Teachers[1]);
            Facults[1].ChangeDean(Teachers[2]);
            Facults[1].AddTeacher(Teachers[2]);
            Facults[1].AddTeacher(Teachers[3]);
            Groups.Add(new Group(1, "ПІ-324", 3, new List<Student>(), null, Teachers[1], Facults[0]));
            Groups.Add(new Group(2, "ІО-145", 1, new List<Student>(), null, Teachers[2], Facults[1]));
            Facults[0].AddGroup(Groups[0]);
            Facults[1].AddGroup(Groups[1]);
            Teachers[1].ChangeCuratorGroup(Groups[0]);
            Teachers[2].ChangeCuratorGroup(Groups[1]);
            Students.Add(new Student(1, "Анатолій", "Круговий", "Олександрович", Groups[0]));
            Students.Add(new Student(2, "Андрій", "Кузякін", "Юрієвич", Groups[0]));
            Students.Add(new Student(3, "Олександр", "Воронін", "Андрійович", Groups[0]));
            Students.Add(new Student(4, "Юля", "Сковорода", "Іванівна", Groups[1]));
            Students.Add(new Student(5, "Людмила", "Розина", "Васильовна", Groups[1]));
            Students.Add(new Student(6, "Платон", "Кулібякін", "Борисович", Groups[1]));
            Groups[0].AddStudent(Students[0]);
            Groups[0].ChangeHeadman(Students[0]);
            Groups[0].AddStudent(Students[1]);
            Groups[0].AddStudent(Students[2]);
            Groups[1].AddStudent(Students[3]);
            Groups[1].ChangeHeadman(Students[3]);
            Groups[1].AddStudent(Students[4]);
            Groups[1].AddStudent(Students[5]);
        }
        public List<Student> GetStudentList()
        {
            return Students;
        }
        public List<Teacher> GetTeacherList()
        {
            return Teachers;
        }
        public List<Group> GetGroupList()
        {
            return Groups;
        }
        public List<Facult> GetFacultList()
        {
            return Facults;
        }
    }
}
