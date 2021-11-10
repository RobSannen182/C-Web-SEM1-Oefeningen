using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSportStore.Data.Tables
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(8,2)")]// kolom wordt voorzien voor 6 cijfers voor en 2 na de komma
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
