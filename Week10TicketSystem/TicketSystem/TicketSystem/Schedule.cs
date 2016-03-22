using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class Schedule
    {
        public Schedule()
        {
           
        }
        [Key]
        public int ScheduleID { get; set; }
        [Required]
        public bool isDeleted { get; set; }

        [ForeignKey("StartingCity")]
        public int StartingCityID { get; set; }
        public virtual City StartingCity { get; set; }

        [ForeignKey("EndCity")]
        public int EndCityID { get; set; }
        public virtual City EndCity { get; set; }

        [Required]
        public DateTime TravelDate { get; set; }
        [Required]
        public TimeSpan TravelTime { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }

        [ForeignKey("Train")]
        public int TrainID { get; set; }
        public virtual Train Train { get; set; }
       
    }
}
