using System.Collections.Generic;
using DAL.Entnities;

namespace DAL.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private MyDBContext DB;

        public TeacherRepository(MyDBContext context)
        {
            DB = context;
        }
        public IEnumerable<Teacher> GetAll()
        {
            return DB.Teachers;
        }
        public Teacher Get(int id)
        {
            return DB.Teachers.Find(id);
        }
        public void Create(Teacher teach)
        {
            DB.Teachers.Add(teach);
        }
        public void Update(Teacher teach)
        {
            DB.Entry(teach).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(Teacher teach)
        {
            DB.Teachers.Remove(teach);
        }
    }
}
