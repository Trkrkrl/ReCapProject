using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//ürün isminde şunlar geçenleri, getir
        //t vericem dönüş türü bool vereceksin, kullanıcı isterse filtre vermyeebilri filtre vermeze hepsini getir

        T Get(Expression<Func<T, bool>> filter);//BUNDA İSE NULL GEÇEMESEİN

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
