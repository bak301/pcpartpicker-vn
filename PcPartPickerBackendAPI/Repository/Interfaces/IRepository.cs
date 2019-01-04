using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartPickerBackendAPI.Repository.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        bool Add(T entityOne);
        bool Delete(int id);
        bool Update(T entity);
    }
}
