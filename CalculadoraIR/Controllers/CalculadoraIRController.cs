using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Model;
using Core.UnidadeDeTrabalho;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraIR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraIRController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public CalculadoraIRController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Inserir(Contribuintes c)
        {
            _unitOfWork.Contribuintes.Inserir(c);
            _unitOfWork.Commit();
            return true;
        }
    }
}