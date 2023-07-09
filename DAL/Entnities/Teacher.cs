
namespace DAL.Entnities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Position { get; set; }
        // Група в якої викладач є куратором
        public int? GroupId { get; set; }
        public int? FacultId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Facult Facult { get; set; }
    }
}
