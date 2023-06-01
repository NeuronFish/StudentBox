using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Teacher : Person
    {
        private string Position;
        private Facult Facult;
        public Teacher(string name, string surname, string patronymic, string position, Facult facult) : base(name, surname, patronymic)
        {
            Position = position;
            Facult = facult;
        }
        public string GetPosition()
        {
            return Position;
        }
        public Facult GetFacult()
        {
            return Facult;
        }
    }
}
