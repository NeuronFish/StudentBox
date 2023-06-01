using System;

namespace BLL
{
    public class Student : Person
    {
        private Group Group;
        public Student(string name, string surname, string patronymic, Group group) : base (name, surname, patronymic)
        {
            Group = group;
        }
        public Group GetGroup()
        {
            return Group;
        }
    }
}
