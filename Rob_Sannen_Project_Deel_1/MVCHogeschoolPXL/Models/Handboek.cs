using MVCHogeschoolPXL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHogeschoolPXL.Models
{
    public class Handboek
    {
        [DisplayName("Handboek id")]
        public int HandboekId { get; set; }

        [Required]
        public string Titel { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Kostprijs{ get; set; }

        [DateValidation(ErrorMessage = "Datum moet tussen 1/1/1980 en 1/10/huidig jaar liggen!")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyy}")]
        [DisplayName("Uitgiftedatum")]
        [Required]
        public DateTime UitgifteDatum { get; set; }
        public string Afbeelding { get; set; }
    }
}
