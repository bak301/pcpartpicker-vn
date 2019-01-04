using System.Collections.Generic;
using System.Linq;
using PcPartPickerBackendAPI.Models;
using Dapper;
using static System.Data.CommandType;
using PcPartPickerBackendAPI.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using PcPartPickerBackendAPI.ViewModels;

namespace PcPartPickerBackendAPI.Repository
{
    public class PartRepository : BaseRepository, IRepository<Part>, IPartRepository
    {
        public PartRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Part entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Part> GetAll()
        {
            List<Part> partList = Connection.Query<Part>("pc.GetAllParts", commandType: StoredProcedure).ToList();
            return partList;
        }

        public Part GetById(int id)
        {
            Part part = Connection.Query<Part>("pc.GetPartById", new { Id = id }, commandType: StoredProcedure).First();
            return part;
        }

        public bool SearchById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Part entity)
        {
            throw new System.NotImplementedException();
        }

        public List<PartViewModel> GetPartViewModels(
            string partType,
            KeyValuePair<string, string> filterOption,
            string sortProperty = "id",
            string direction = "asc",    
            int pageNumber = 1
        )
        {
            int offset = (pageNumber - 1) * 100;

            string filter = "";
            if (!string.IsNullOrEmpty(filterOption.Key))
            {
                switch (filterOption.Key)
                {
                    case "priceRange":
                        var range = filterOption.Value.Split(',');
                        filter = $"WHERE p.lowest BETWEEN {range[0]} AND {range[1]}";
                        break;
                    case "merchant":
                        filter = $"WHERE p.merc like '%{filterOption.Value}%'";
                        break;
                    case "price":
                        filter = $"WHERE p.lowest like '%{filterOption.Value}%'";
                        break;
                    default:
                        filter = $"WHERE {filterOption.Key} like '%{filterOption.Value}%'";
                        break;
                }
            }

            string query =
            $@"SELECT
		part.[name] as name,
        part.manufacturer as manufacturer,
		part.partname as partname,
		{partType}.id as id,
		stuff(
			(
			select ', ' + pc.image.imageUrl from 
			pc.image where pc.image.partid = {partType}.id
			for xml path('')
			)
		, 1, 2, '') as Images,
		p.lowest as price,
        p.merc as merchant,
        p.url as url
	FROM
		pc.{partType}
		inner join pc.part  
		on pc.{partType}.id = pc.part.id
		cross apply (
			select min(baseprice) as lowest, min(price.merchant) as merc, link.[url]
			from pc.price inner join pc.link 
            on price.partid = link.partid 
            and price.merchant = link.merchant
            where price.partid = {partType}.id
			group by price.partid, link.[url]
		) as p
    {filter}
    ORDER BY {sortProperty} {direction}
    OFFSET {offset} ROWS
    FETCH NEXT 100 ROWS ONLY";
            return Connection.Query<PartViewModel>(query).ToList();
        }
    }
}
