using Microsoft.EntityFrameworkCore;
using Entrevistas.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entrevistas.DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Entrevista> Entrevistas { get; set; }
    }
}
