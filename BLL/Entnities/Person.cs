using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Person
    {
        private string Name, Surname, Patronymic;
        private int Id;
        public Person(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
        public int GetId()
        {
            return Id;
        }
        public string[] GetPersInfo()
        {
            return new string[] { Name, Surname, Patronymic };
        }
        public void ChangePersInfo(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
