﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TripAdvasorAPI.Models
{
    public class TripAdvasorContext : DbContext
    {
        public TripAdvasorContext(DbContextOptions<TripAdvasorContext> options)
            : base(options)
        {

        }

        public Agence TripAdvasor { get; set; }

        public DbSet<ClientPrincipal> Clients { get; set; }

        public DbSet<Partenariat> Partenariats { get; set; }

    }
}
