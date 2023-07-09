using System.Data.Entity;
using DAL.Entnities;

namespace DAL
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("DbConnectionString")
        {        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Facult> Facults { get; set; }
    }
}
