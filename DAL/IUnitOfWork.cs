using System;
using DAL.Repositories;
using DAL.Entnities;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students();
        IRepository<Teacher> Teachers();
        IRepository<Group> Groups();
        IRepository<Facult> Facults();
        void Save();
    }
}
