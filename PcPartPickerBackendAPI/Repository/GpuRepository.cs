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
    public class GpuRepository : BaseRepository, IRepository<Gpu>
    {
        public GpuRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Gpu entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Gpu> GetAll()
        {
            List<Gpu> GpuList = Connection.Query<Gpu>("pc.GetAllGpus", commandType: StoredProcedure).ToList();
            return GpuList;
        }

        public Gpu GetById(int id)
        {
            string query = @"SELECT
		part.[name],
		part.partname,
		part.manufacturer,
		gpu.*
	FROM
		pc.gpu
		inner join pc.part
		on pc.gpu.id = pc.part.id
Where gpu.id = @id;";
            Gpu gpu = Connection.QuerySingle<Gpu>(query, new {id});
            return gpu;
        }

        public bool Update(Gpu entity)
        {
            throw new NotImplementedException();
        }
    }
}
