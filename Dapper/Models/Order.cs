namespace Dapper.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public int UserId { get; set; }

    }
}
