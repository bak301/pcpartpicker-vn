using System;
using System.Collections.Generic;
using System.Linq;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.Models;
using Dapper;
using static System.Data.CommandType;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace PcPartPickerBackendAPI.Repository
{
    public class BuildRepository : BaseRepository, IRepository<Build>, IBuildRepository
    {
        public BuildRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Build build)
        {
            try
            {
                Connection.Query<Build>("pc.CreateBuild", new { build.Cpu, build.Motherboard, build.Memory, build.Gpu, build.Storage, build.Powersupply, build.Pccase, build.Buildname }, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddWithGetId(Build build)
        {
            int id = 0;
            try
            {
                var p = new DynamicParameters();
                p.Add("@BuildName", build.Buildname, DbType.AnsiString);
                p.Add("@Cpu", build.Cpu, DbType.Int32);
                p.Add("@Motherboard", build.Motherboard, DbType.Int32);
                p.Add("@Memory", build.Memory, DbType.Int32);
                p.Add("@Gpu", build.Gpu, DbType.Int32);
                p.Add("@Storage", build.Storage, DbType.Int32);
                p.Add("@Powersupply", build.Powersupply, DbType.Int32);
                p.Add("@Pccase", build.Pccase, DbType.Int32);
                p.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);
                Connection.Execute("pc.CreateBuild", p, commandType: StoredProcedure);

                id = p.Get<int>("@Id");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public bool Delete(int id)
        {
            try
            {
                Connection.Query<Build>("pc.DeleteBuild", new { id }, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Build> GetAll()
        {
            List<Build> buildList = Connection.Query<Build>("pc.GetAllBuilds", commandType: StoredProcedure).ToList();
            return buildList;
        }

        public Build GetById(int id)
        {
            try
            {
                Build build = Connection.Query<Build>("pc.GetBuildById", new { id } , commandType: StoredProcedure).First();
                return build;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Build build)
        {
            try
            {
                Connection.Query<Build>("pc.UpdateBuild", new { build }, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
