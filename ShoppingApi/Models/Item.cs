using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingApi
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<CustomerItem> CustomerItems { get; set; }


        //[NotMapped]
        //public ICollection<Customer> Customers { get; set; }


        public virtual Detail Detail { get; set; }
        public virtual Category Category { get; set; }
    }
}