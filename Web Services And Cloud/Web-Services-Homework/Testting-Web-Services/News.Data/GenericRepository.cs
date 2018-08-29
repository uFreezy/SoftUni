using System.Data.Entity;
using System.Linq;

namespace News.Data
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        protected DbContext Context;
        protected DbSet<T> Set;

        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return Set.AsQueryable();
        }

        public T Find(object id)
        {
            return Set.Find(id);
        }

        public void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
            }

            entry.State = state;
        }
    }
}