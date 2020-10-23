using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.ModelsView
{
    public class JoinCustomerDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<CustomerItemDTO> CustomerItems { get; set; }
    }
}
