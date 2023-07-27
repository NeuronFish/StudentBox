using System.ComponentModel.DataAnnotations;

namespace DAL.Entnities
{
    public class Teacher
    {
        [Key]
        public int TeachId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Position { get; set; }
        // Група в якої викладач є куратором
        public virtual Group OwnGroup { get; set; }
        public int? FacultId { get; set; }
        public virtual Facult Facult { get; set; }
    }
}
