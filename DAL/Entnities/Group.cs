using System.Collections.Generic;

namespace DAL.Entnities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int? FacultId { get; set; }
        // Староста групи
        public int? StudId { get; set; }
        // Куратор групи
        public int? TeachId { get; set; }
        public virtual Facult Facult { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
