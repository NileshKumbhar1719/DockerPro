using CRUD.Controllers;
using CRUD.DTOs;
using CRUD.Models;

namespace CRUD.Repository
{
    public interface ICRUDRepository
    {
        //Task<List<Order>> GetAllOrders();
        Task<List<OrderDTOs>> GetAllData(
           int pageNumber,
           int pageSize);

        Task<OrderDTOs?> orderById(int id);
    }
}
