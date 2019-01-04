using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.ViewModels;
using static System.Data.CommandType;

namespace PcPartPickerBackendAPI.Repository
{
    public class CpuRepository : BaseRepository, IRepository<Cpu>, IRepository<PartViewModel> 
    {
        public CpuRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(PartViewModel cpu)
        {
            try
            {
                Connection.Query("pc.CreateCpu", new { cpu }, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(Cpu entityOne)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cpu> GetAll()
        {
            List<Cpu> CpuList = Connection.Query<Cpu>("pc.GetAllCpus", commandType: StoredProcedure).ToList();
            return CpuList;
        }

        public Cpu GetById(int id)
        {
            string query = @"SELECT
		part.[name],
		part.partname,
		part.manufacturer,
		cpu.*
	FROM
		pc.cpu
		inner join pc.part
		on pc.cpu.id = pc.part.id
Where cpu.id = @id;";
            Cpu cpu = Connection.QuerySingle<Cpu>(query, new { id });
            return cpu;
        }

        public bool Update(Cpu entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PartViewModel entity)
        {
            throw new NotImplementedException();
        }

        List<PartViewModel> IRepository<PartViewModel>.GetAll()
        {
            List<PartViewModel> CpuList = Connection.Query<PartViewModel>("pc.GetAllCpus", commandType: StoredProcedure).ToList();
            return CpuList;
        }

        PartViewModel IRepository<PartViewModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
