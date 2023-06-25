using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    // Interface solo utilizable para clases que hereden de entity
    public interface IApiBusiness<T> where T : Entity
    {
        public Task<IEnumerable<T>?> GetColection();
        public Task<HttpResponseMessage> PostEntity(T entity);
    }
}
