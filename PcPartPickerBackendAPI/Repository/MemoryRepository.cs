using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.Models;
using Dapper;
using static System.Data.CommandType;
using Microsoft.Extensions.Configuration;

namespace PcPartPickerBackendAPI.Repository
{
    public class MemoryRepository : BaseRepository, IRepository<Memory>
    {
        public MemoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Memory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Memory> GetAll()
        {
            List<Memory> MemoryList = Connection.Query<Memory>("pc.GetAllMemoryDevices", commandType: StoredProcedure).ToList();
            return MemoryList;
        }

        public Memory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Memory entity)
        {
            throw new NotImplementedException();
        }
    }
}
