using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class Seat
    {
        public Seat()
        {
        
        }

        [Key]
        public int SeatID { get; set; }
        [Required]
        public SeatClassType SeatClass { get; set; }
        
        public bool SeatTaken { get; set; }
        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public bool isDeleted { get; set; }

        [ForeignKey("Train")]
        public int TrainID { get; set; }
        public virtual Train Train { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
    public enum  SeatClassType { First, Second}
}
