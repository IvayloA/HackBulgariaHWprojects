using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    class TicketSystemDBEntities : DbContext
    {
        public TicketSystemDBEntities () : base("TicketSystemDB")
        {
            Database.SetInitializer<TicketSystemDBEntities> (null);
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }


    }
}
