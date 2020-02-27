using Core.Data;
using Core.UnidadeDeTrabalho.Interfaces;
using Core.UnidadeDeTrabalho.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UnidadeDeTrabalho
{
    public class UnitOfWork:IUnitOfWork
    {
        private IContribuintesRepository _contribuinteRepository;
        private CalculadorIRContext _calculadoraIr;
        public UnitOfWork(CalculadorIRContext calculadorIr)
        {
            _calculadoraIr = calculadorIr;
        }
        public IContribuintesRepository Contribuintes
        {
            get
            {
                _contribuinteRepository = new ContribuentesRepository(_calculadoraIr);
                return _contribuinteRepository;
            }
        }
        public void Commit()
        {
            _calculadoraIr.SaveChanges();
        }
    }
}
