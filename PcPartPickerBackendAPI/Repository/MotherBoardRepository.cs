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
    public class MotherboardRepository : BaseRepository, IRepository<Motherboard>
    {
        public MotherboardRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Motherboard entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Motherboard> GetAll()
        {
            List<Motherboard> MotherboardList = Connection.Query<Motherboard>("pc.GetAllMotherboards", commandType: StoredProcedure).ToList();
            return MotherboardList;
        }

        public Motherboard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Motherboard entity)
        {
            throw new NotImplementedException();
        }

        List<Motherboard> IRepository<Motherboard>.GetAll()
        {
            throw new NotImplementedException();
        }

        Motherboard IRepository<Motherboard>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
