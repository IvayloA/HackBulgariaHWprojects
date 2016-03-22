using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class Ticket
    {
        public Ticket()
        {

        }
        [Key]
        public int TicketID { get; set; }
        [Required]
        public DateTime TripDateAndTime { get; set; }
        [Required]
        public decimal OriginalPrice { get; set; }
        [Required]
        public decimal PriceSold { get; set; }
        [Required]
        public bool isDeleted { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [ForeignKey("Train")]
        public int TrainID { get; set; }
        public virtual Train  Train { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleID { get; set; }
        public virtual Schedule Schedule { get; set; }

      
       
    }
}
