using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.Repository.Interfaces;
using Dapper;
using static System.Data.CommandType;
using Microsoft.Extensions.Configuration;

namespace PcPartPickerBackendAPI.Repository
{
    public class StorageRepository : BaseRepository, IRepository<Storage>
    {
        public StorageRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Storage entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Storage> GetAll()
        {
            List<Storage> StorageList = Connection.Query<Storage>("pc.GetAllStorages", commandType: StoredProcedure).ToList();
            return StorageList;
        }

        public Storage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Storage entity)
        {
            throw new NotImplementedException();
        }
    }
}
