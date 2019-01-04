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
    public class PowersupplyRepository : BaseRepository, IRepository<Powersupply>
    {
        public PowersupplyRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Powersupply entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Powersupply> GetAll()
        {
            List<Powersupply> PowerSuppliesList = Connection.Query<Powersupply>("pc.GetAllPowerSupplies", commandType: StoredProcedure).ToList();
            return PowerSuppliesList;
        }

        public Powersupply GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Powersupply entity)
        {
            throw new NotImplementedException();
        }
    }
}
