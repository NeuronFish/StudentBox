using System.ComponentModel.DataAnnotations;

namespace DAL.Entnities
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
