using ApiConductor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConductor.DBContext
{
    public class context : DbContext
    {
        //Constructor
        public context(DbContextOptions<context> options) :base (options)
        {

        }
        public virtual DbSet<Matricula> matricula { get; set; }
        public virtual DbSet<Conductor> conductor { get; set; }
        public virtual DbSet<Sanciones> sanciones { get; set; }

    }
}
