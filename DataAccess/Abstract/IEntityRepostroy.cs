using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepostroy<T> where T : class
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
    }
}
