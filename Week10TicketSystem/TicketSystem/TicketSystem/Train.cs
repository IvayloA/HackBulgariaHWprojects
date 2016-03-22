using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class Train
    {
        public Train()
        {
        }

        [Key]
        public int TrainID { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool isDeleted { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
