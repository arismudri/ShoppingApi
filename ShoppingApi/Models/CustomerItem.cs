using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApi
{
    public class CustomerItem
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }


        public Customer Customer { get; set; }
        public Item Item { get; set; }
    }
}