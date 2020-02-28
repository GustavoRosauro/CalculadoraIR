using Core.Data;
using Core.Model;
using Core.UnidadeDeTrabalho.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.UnidadeDeTrabalho.Repositorios
{
    public class ContribuentesRepository:IContribuintesRepository
    {
        private CalculadorIRContext _calculadoraIr;

        public ContribuentesRepository(CalculadorIRContext calculadoraIr)
        {
            _calculadoraIr = calculadoraIr;
        }
        /// <summary>
        /// Inserir um novo Contribuinte
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool Inserir(Contribuinte c)
        {
            _calculadoraIr.Contribuintes.Add(c);
            return true;
        }
        /// <summary>
        /// Retrna Nossos Contribuintes ordenados por Renda e nome
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contribuinte> RetornaContribuintes()
        {
           return _calculadoraIr.Contribuintes;
        }
    }
}
