
namespace DAL.Entnities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
