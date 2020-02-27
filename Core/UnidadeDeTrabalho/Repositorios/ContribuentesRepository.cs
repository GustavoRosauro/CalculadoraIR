using Core.Data;
using Core.Model;
using Core.UnidadeDeTrabalho.Interfaces;
using System;
using System.Collections.Generic;
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
        public bool Inserir(Contribuintes c)
        {
            _calculadoraIr.Contribuintes.Add(c);
            return true;
        }
    }
}
