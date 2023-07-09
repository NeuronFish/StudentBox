using System;
using DAL.Repositories;
using DAL.Entnities;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyDBContext DBContext = new MyDBContext();
        private StudentRepository StudRepos;
        private TeacherRepository TeachRepos;
        private GroupRepository GroupRepos;
        private FacultRepository FacultRepos;

        public IRepository<Student> Students()
        {
            if (StudRepos == null)
                StudRepos = new StudentRepository(DBContext);
            return StudRepos;
        }
        public IRepository<Teacher> Teachers()
        {
            if (TeachRepos == null)
                TeachRepos = new TeacherRepository(DBContext);
            return TeachRepos;
        }
        public IRepository<Group> Groups()
        {
            if (GroupRepos == null)
                GroupRepos = new GroupRepository(DBContext);
            return GroupRepos;
        }
        public IRepository<Facult> Facults()
        {
            if (FacultRepos == null)
                FacultRepos = new FacultRepository(DBContext);
            return FacultRepos;
        }
        public void Save()
        {
            DBContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DBContext.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
