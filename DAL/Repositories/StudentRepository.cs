using System.Collections.Generic;
using System.Linq;
using DAL.Entnities;

namespace DAL.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private MyDBContext DB;

        public StudentRepository(MyDBContext context)
        {
            DB = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return DB.Students.ToArray();
        }
        public Student Get(int id)
        {
            return DB.Students.Find(id);
        }
        public void Create(Student stud)
        {
            DB.Students.Add(stud);
        }
        public void Update(Student stud)
        {
            DB.Entry(stud).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(Student stud)
        {
            DB.Students.Remove(stud);
        }
    }
}
