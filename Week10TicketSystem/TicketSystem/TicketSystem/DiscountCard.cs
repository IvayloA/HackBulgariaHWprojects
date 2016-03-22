using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class DiscountCard
    {
        public DiscountCard()
        {

        }

        [Key]
        public string DiscountCardNumber { get; set; }
        [Required]  
        public DiscountCardType CardType { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        public SeatClassType AppliesToFirstClass { get; set; }


    }

    public enum DiscountCardType { Student, ISIC}
}
