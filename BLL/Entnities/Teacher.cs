using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Teacher : Person
    {
        private string Position;
        private Facult Facult;
        private Group CuratorGroup;
        public Teacher(int id, string name, string surname, string patronymic, string position, Facult facult,
            Group curatorGroup) : base(id, name, surname, patronymic)
        {
            Position = position;
            Facult = facult;
            CuratorGroup = curatorGroup;
        }
        public string GetPosition()
        {
            return Position;
        }
        public void ChangePosition(string position)
        {
            Position = position;
        }
        public Facult GetFacult()
        {
            return Facult;
        }
        public void ChangeFacult(Facult facult)
        {
            Facult = facult;
        }
        public Group GetCuratorGroup()
        {
            return CuratorGroup;
        }
        public void ChangeCuratorGroup(Group group)
        {
            CuratorGroup = group;
        }
    }
}
