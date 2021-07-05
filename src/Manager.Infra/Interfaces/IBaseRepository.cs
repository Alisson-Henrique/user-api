using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Infra.Interfaces{


    public interface IBaseRepository<T> where T : Base{

        Task<T> Create(T obj);
        
        Task Update(T obj);

        Task Remove(long id);

        Task<T> Get(long id);

        Task<List<T>> GetAll();
    }


}