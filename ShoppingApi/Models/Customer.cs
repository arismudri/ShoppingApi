using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApi
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<CustomerItem> CustomerItems { get; set; }

    }
}