using System;

namespace BLL
{
    public class Student : Person
    {
        private Group Group;
        public Student(int id, string name, string surname, string patronymic, Group group) : base (id, name, surname, patronymic)
        {
            Group = group;
        }
        public Group GetGroup()
        {
            return Group;
        }
        public void ChangeGroup(Group group)
        {
            Group = group;
        }
    }
}
