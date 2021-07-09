using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Manager.Domain.Entities;
using System.Threading.Tasks;
using Manager.Infra.Interfaces;
using Manager.Infra.Context;


namespace Manager.Infra.Repository{


    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj){
            _context.Add(obj);

            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj){
            _context.Entry(obj).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            
            return obj;
        }

        public virtual async Task Remove(long id){
            var obj = await Get(id);

            if(obj != null)
            {
                _context.Remove(id);
                await _context.SaveChangesAsync();

            }
        }

        public virtual async Task<T> Get(long id){
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();
            
            return obj.FirstOrDefault();

        }
        public virtual async Task<List<T>> GetAll(){
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();


        }



    }
}