using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class CalculadorIRContext:DbContext
    {
        /// <summary>
        /// Parâmetros via injeção de depêndencia
        /// </summary>
        /// <param name="options"></param>
        public CalculadorIRContext(DbContextOptions<CalculadorIRContext> options)
        :base(options)
        { }
        public DbSet<Contribuinte> Contribuintes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nossa coluna CPF não aceitará valores duplicados 
            modelBuilder.Entity<Contribuinte>
                 ().HasIndex(x => x.CPF).IsUnique();
        }
    }
}
