using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartPickerBackendAPI.Repository.Interfaces
{
    public interface ICreateRepository<T, Y> 
        where T: class
        where Y: class
    {
        bool Create(T entityOne, Y entityTwo);
    }
}
