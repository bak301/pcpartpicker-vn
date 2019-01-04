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
    public class PccaseRepository : BaseRepository, IRepository<Pccase>
    {
        public PccaseRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Pccase entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pccase> GetAll()
        {
            List<Pccase> PccaseList = Connection.Query<Pccase>("pc.GetAllPccases", commandType: StoredProcedure).ToList();
            return PccaseList;
        }

        public Pccase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pccase entity)
        {
            throw new NotImplementedException();
        }
    }
}
