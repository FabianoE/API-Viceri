using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Base
{
    public interface IRepositoryBase<T> where T : class, IEntity
    {
        public Task Add(T item);
        public Task Update(T item);
        public Task Delete(T item);
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
    }
}
