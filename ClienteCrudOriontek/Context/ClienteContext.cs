using ClienteCrudOriontek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCrudOriontek.Context
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Direccion> direcciones { get; set; }

        public ClienteContext()
        {

        }
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
   
        }
    }
}
