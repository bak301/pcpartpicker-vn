using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using static System.Data.CommandType;


namespace PcPartPickerBackendAPI.Repository
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool Add(Order order)
        {
            try
            {
                Connection.Query("pc.CreateOrder", new { order.CustomerName, order.PhoneNumber, order.Address, order.OrderStatus, order.BuildId }, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            try
            {
                string sql = 
                    $@"SELECT 
                         customerName,
                         phoneNumber,
                         address,
                         orderStatus,
                         buildId
                        FROM
                         [pc].[order]";
                var orderList = Connection.Query<Order>(sql).ToList();
                return orderList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Order GetById(int id)
        {
            try
            {
                string sql =
                    $@"SELECT
                        customerName,
                        phoneNumber,
                        orderStatus,
                        buildId
                       FROM
                        pc.[order]
                       WHERE
                        id = @id";
                var order = Connection.Query<Order>(sql, new { id }).FirstOrDefault();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
