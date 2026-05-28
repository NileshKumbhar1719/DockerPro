namespace CRUD.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Status { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
