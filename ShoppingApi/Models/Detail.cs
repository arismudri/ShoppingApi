using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingApi
{
    public class Detail
    {
        [Key, ForeignKey("Item")]
        public int Id { get; set; }
        public int Weight { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        //public int ItemId { get; set; }


        //[NotMapped]
        public virtual Item Item { get; set; }
    }
}