using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSaleApp.Models
{
    public class Sale
    {
        [Column("SaleId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int SaleId { get; set; }

        [Column("SaleName")]
        [Required]
        public string SaleName { get; set; }

        [Column("StartDate")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("EndDate")]
        [Required]
        public DateTime EndDate { get; set; }

        [Column("Price")]
        [Required]
        [Range(0.01,999999999)]
        public decimal Price { get; set; }

        [Column("Product")]
        [Required]
        public string Product { get; set; }
    }
}
