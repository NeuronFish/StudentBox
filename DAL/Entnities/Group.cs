using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entnities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int? FacultId { get; set; }
        public virtual Facult Facult { get; set; }
        // Староста групи
        public virtual Student Headman { get; set; }
        // Куратор групи
        public virtual Teacher Curator { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
