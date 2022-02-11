
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constarint
    //class: referans tip
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //bu aşağıdaki satır benim filtreler yazabilmemi sağlıyor.
        List<T> GetAll(Expression<Func<T,bool>>? filter =null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

       
    }
}
