using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcPartPickerBackendAPI.Models;

namespace PcPartPickerBackendAPI.Repository.Interfaces
{
    public interface IBuildRepository
    {
        int AddWithGetId(Build build);
    }
}
