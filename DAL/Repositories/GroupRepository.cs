using System.Collections.Generic;
using DAL.Entnities;

namespace DAL.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private MyDBContext DB;

        public GroupRepository(MyDBContext context)
        {
            DB = context;
        }
        public IEnumerable<Group> GetAll()
        {
            return DB.Groups;
        }
        public Group Get(int id)
        {
            return DB.Groups.Find(id);
        }
        public void Create(Group group)
        {
            DB.Groups.Add(group);
        }
        public void Update(Group group)
        {
            DB.Entry(group).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(Group group)
        {
            DB.Groups.Remove(group);
        }
    }
}
