using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Core
{
    public interface IBaseRepository<TEntity, Tkey> : IDisposable
        where TEntity : class
    {
        void Create (TEntity entity);
        void Update (TEntity entity);
        void Delete (TEntity entity);

        List<TEntity> GetAll();
        TEntity GetByCodigo(Tkey codigo);
    }
}
