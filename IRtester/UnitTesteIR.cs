using CalculadoraIR.Controllers;
using Core.Data;
using Core.UnidadeDeTrabalho;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IRtester
{
    public class UnitTesteIR
    {
        private IUnitOfWork _unitOfWork;
        private DbContextOptionsBuilder<CalculadorIRContext> optionsSql = new DbContextOptionsBuilder<CalculadorIRContext>();
        private void PreencheParametros()
        {
             optionsSql.UseSqlServer(@"Data Source=DESKTOP-T0GRJLM;Initial Catalog=IRCALCULATOR;Integrated Security=True");
            _unitOfWork = new UnitOfWork(new CalculadorIRContext(optionsSql.Options));
        }
        [Test]
        public void Inserir()
        {
           PreencheParametros();
           var sucesso = new CalculadoraIRController(_unitOfWork).Inserir(new Core.Model.Contribuintes()
           { 
                CPF = "000000000",
                Dependentes = 2,
                Nome = "Gustavo Rosauro",
                RendeBruta = 85
           });
            Assert.AreEqual(true,sucesso);
        }
    }
}
