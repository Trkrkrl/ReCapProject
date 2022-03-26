using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>//bu ksımda nugeet install entitiy: buradaki kodların içerisini nasıl dolduracağına  Ders örneğinden baktım
        where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context=new TContext())//using (bu normal using değil)içerisindeki nesneler işi bitince garbage collector atar  -bu performasn sağlarr
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
            
            }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                //tabi burada product yazdık -bu standart diğer elemmntler için de
                //bu yüzden ilerde generic yapacaz onu

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {//filtre-varsa veya yoksa
                // set diyorki db setlerden product a bağlanıyorum
                //benim product uma yerleş ve oradaki tüm datayı liste çevir
                //eğer değilse
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();


            }
        }
        //--cardmanager için
        public bool Any(Expression<Func<TEntity, bool>> exp)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Any(exp);
            }
        }

    }
}
