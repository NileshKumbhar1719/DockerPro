using CRUD.Controllers;
using CRUD.Data;
using CRUD.DTOs;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository
{
    public class CRUDRepository : ICRUDRepository
    {
        private readonly AppDbContext _Context;

        public CRUDRepository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }

        //public async Task<List<Order>> GetAllOrders()
        //{
        //    var data = await _Context.Order
        //        .Select(x => new Order // Map the anonymous type to the Order model
        //        {
        //            Id = x.Id,
        //            Status = x.Status,
        //            TotalAmount = x.TotalAmount
        //        })
        //        .ToListAsync();

        //    return data;
        //}
        //public async Task<List<Order>> GetAllOrders()
        //{
        //    var data = await _Context.Order.FromSqlRaw("EXEC GetOrder")

        //        .ToListAsync();

        //    return data;
        //}
        public async Task<List<OrderDTOs>> GetAllData(
            int pageNumber,
            int pageSize)
        {
            var data = await _Context
                .Set<OrderDTOs>()
                .FromSqlInterpolated(
                    $"EXEC GetOrders {pageNumber}, {pageSize}")
                .AsNoTracking()
                .ToListAsync();

            return data;
        }
    }
}
