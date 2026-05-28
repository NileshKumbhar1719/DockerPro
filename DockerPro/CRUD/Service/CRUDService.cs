using CRUD.DTOs;
using CRUD.Models;
using CRUD.Repository;

namespace CRUD.Service
{
    public class CRUDService : ICRUDService
    {
        private readonly ICRUDRepository _repo;

        public CRUDService(ICRUDRepository repository) 
        {
            _repo = repository;
        
        }
        //public async Task<List<Order>> GetAllData()
        //{
        //    return  await _repo.GetAllOrders();
        //}
        public async Task<List<OrderDTOs>> GetAllData(
           int pageNumber,
           int pageSize)
        {
            return await _repo
                .GetAllData(pageNumber, pageSize);
        }
    }
}
