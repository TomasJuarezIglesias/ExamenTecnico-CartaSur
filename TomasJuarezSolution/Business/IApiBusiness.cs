using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IApiBusiness<T> where T : Entity
    {
        public Task<IEnumerable<T>?> GetColection();
        public Task<HttpResponseMessage> PostEntity(T entity);
    }
}
