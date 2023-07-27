using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entnities
{
    public class Facult
    {
        [Key]
        public int FacultId { get; set; }
        public string Name { get; set; }
        // Декан факультету
        public virtual Teacher Dean { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
