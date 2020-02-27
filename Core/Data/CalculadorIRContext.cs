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
        public DbSet<Contribuintes> Contribuintes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Nossa coluna CPF não aceitará valores duplicados 
            modelBuilder.Entity<Contribuintes>
                 ().HasIndex(x => x.CPF).IsUnique();
        }
    }
}
