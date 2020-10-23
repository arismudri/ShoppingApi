using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApi.ModelsView
{
    public class CustomerItemDTO
    {
        [Display(Name = "Nama Item")]
        public string ItemName { get; set; }

        [Display(Name = "Harga Item")]
        public string ItemPrice { get; set; }
    }
}