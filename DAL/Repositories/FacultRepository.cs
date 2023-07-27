using System.Collections.Generic;
using System.Linq;
using DAL.Entnities;

namespace DAL.Repositories
{
    public class FacultRepository : IRepository<Facult>
    {
        private MyDBContext DB;

        public FacultRepository(MyDBContext context)
        {
            DB = context;
        }
        public IEnumerable<Facult> GetAll()
        {
            return DB.Facults.ToArray();
        }
        public Facult Get(int id)
        {
            return DB.Facults.Find(id);
        }
        public void Create(Facult facult)
        {
            DB.Facults.Add(facult);
        }
        public void Update(Facult facult)
        {
            DB.Entry(facult).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(Facult facult)
        {
            DB.Facults.Remove(facult);
        }
    }
}
