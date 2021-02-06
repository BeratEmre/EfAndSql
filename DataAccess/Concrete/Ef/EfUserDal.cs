using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Ef
{
    public class EfUserDal : IUserDal
    {
        public void Add(User entity)
        {
            using (EfContext context=new EfContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (EfContext context = new EfContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (EfContext context=new EfContext())
            {
                return filter == null ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();

            }
        }

        public User GetId(Expression<Func<User, bool>> filter )
        {
            using (EfContext context = new EfContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
            
        }

        public void Update(User entity)
        {
            using (EfContext context = new EfContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
