using CalculadoraIR.Controllers;
using Core.Data;
using Core.UnidadeDeTrabalho;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// Valida se conseguiu inserir um novo Registro
        /// </summary>
        [Test]
        public void Inserir()
        {
            PreencheParametros();
            bool sucesso = _unitOfWork.Contribuintes.Inserir(new Core.Model.Contribuinte()
            {
                CPF = "000000000",
                Dependentes = 2,
                Nome = "Gustavo Rosauro",
                RendaBruta = 85
            });
            Assert.AreEqual(true, sucesso);
        }
        /// <summary>
        /// Valida se conseguiu retorna mais de um item
        /// </summary>
        [Test]
        public void ValidaContribuintes()
        {
            PreencheParametros();
            var lista = _unitOfWork.Contribuintes.RetornaContribuintes();
            Assert.AreEqual(true, lista.ToList().Count > 0);
        }
    }
}
