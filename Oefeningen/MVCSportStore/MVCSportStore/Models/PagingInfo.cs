using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSportStore.Models
{
    public class PagingInfo
    {
        public int totalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int Totalpages => (int)Math.Ceiling((decimal)totalItems / ItemsPerPage);
    }
}
