using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expence
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense")]
        [Required]
        public string Item { get; set; }

        [DisplayName("Amount")]
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage ="Minimum amount is 0,1")]
        public double Price { get; set; }

        [DisplayName("Expense type")]
        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }


    }
}
