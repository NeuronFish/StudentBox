using System.Collections.Generic;

namespace DAL.Entnities
{
    public class Facult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Декан факультету
        public int? TeachId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
