using CRUD.DTOs;
using CRUD.Models;

namespace CRUD.Service
{
    public interface ICRUDService
    {
        //Task<List<Order>> GetAllData();
        Task<List<OrderDTOs>> GetAllData(
            int pageNumber,
            int pageSize);

    }
}
