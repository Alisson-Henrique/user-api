using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Infra.Interfaces{


    public class IBaseRepository<T> where T : Base{

        Task<T> Create(T obj);
        
        Task<T> Update(T obj);

        Task Remove(long id);

        Task<T> Get(long id);

        Task<List<T>> GetAll();
    }


}