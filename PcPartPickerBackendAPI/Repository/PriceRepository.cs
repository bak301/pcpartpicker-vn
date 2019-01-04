using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.Repository.Interfaces;

namespace PcPartPickerBackendAPI.Repository
{
    public class PriceRepository : BaseRepository, IRepository<Price>, IPriceRepository
    {
        public PriceRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Price entityOne)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Price> GetAll()
        {
            throw new NotImplementedException();
        }

        public Price GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Price entity)
        {
            throw new NotImplementedException();
        }

        public List<Price> GetPricesByPartId(int partId)
        {
            string query = @"SELECT price.*, link.[url] AS [Url]
FROM pc.price LEFT JOIN pc.link 
ON price.partid = link.partid 
AND price.merchant = link.merchant
WHERE price.partid = @partId;";
            return Connection.Query<Price>(query, new { partId = partId }).ToList();
        }
    }
}
