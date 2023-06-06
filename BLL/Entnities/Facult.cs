using System.Collections.Generic;

namespace BLL
{
    public class Facult
    {
        private string Name;
        private int Id;
        private Person Dean;
        private List<Group> Groups;
        private List<Teacher> Teachers;
        public Facult(int id, string name, Person dean, List<Group> groups, List<Teacher> teachers)
        {
            Id = id;
            Name = name;
            Dean = dean;
            Groups = groups;
            Teachers = teachers;
        }
        public int GetId()
        {
            return Id;
        }
        public string GetName()
        {
            return Name;
        }
        public Person GetDean()
        {
            return Dean;
        }
        public List<Group> GetGroups()
        {
            return Groups;
        }
        public List<Teacher> GetTeachers()
        {
            return Teachers;
        }
        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }
        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        public void ChangeDean(Person dean)
        {
            Dean = dean;
        }
        public void RemoveGroup(Group group)
        {
            Groups.Remove(group);
        }
        public void RemoveTeacher(Teacher teacher)
        {
            Teachers.Remove(teacher);
        }
    }
}
