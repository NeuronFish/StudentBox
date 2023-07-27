using System.Data.Entity;
using DAL.Entnities;

namespace DAL
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("DbConnectionString")
        {        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOptional(x => x.Group)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GroupId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Teacher>()
                .HasOptional(x => x.OwnGroup)
                .WithOptionalDependent(x => x.Curator)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Teacher>()
                .HasOptional(x => x.Facult)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.FacultId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>()
                .HasOptional(x => x.Headman)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>()
                .HasOptional(x => x.Curator)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>()
                .HasOptional(x => x.Facult)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.FacultId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Facult>()
                .HasOptional(x => x.Dean)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Facult> Facults { get; set; }
    }
}
