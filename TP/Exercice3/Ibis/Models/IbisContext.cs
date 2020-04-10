using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IbisAPI.Models
{
        public class IbisContext : DbContext
        {
            public IbisContext(DbContextOptions<IbisContext> options)
                : base(options)
            {
            
            }

            public Hotel Ibis { get; set; }
            public DbSet<Chambre> Chambres { get; set; }

            public DbSet<ClientPrincipal> Clients { get; set; }

            public DbSet<Reservation> Reservations { get; set; }

            public DbSet<Partenariat> Partenariats { get; set; }

    }

}
