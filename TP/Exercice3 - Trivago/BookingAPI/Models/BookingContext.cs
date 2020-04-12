using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {

        }

        public Agence Booking { get; set; }

        public DbSet<ClientPrincipal> Clients { get; set; }

        public DbSet<Partenariat> Partenariats { get; set; }

    }
}
