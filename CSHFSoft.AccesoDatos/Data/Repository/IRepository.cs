using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data.Repository
{
    //Repositorio generico que se puede usar en todas las clases.
    
    //Crearemos los metodos comunes. 
    public interface IRepository<T> where T : class //puede ser una clase de diferente implementacion T = Tipo Generico
    {
        //Metodo Get 
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = null
        );
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null

        );

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);

    
    }
}
