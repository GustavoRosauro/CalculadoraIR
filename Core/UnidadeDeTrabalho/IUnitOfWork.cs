using Core.UnidadeDeTrabalho.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UnidadeDeTrabalho
{
    public interface IUnitOfWork
    {
        IContribuintesRepository Contribuintes { get; }
        void Commit();
    }
}
