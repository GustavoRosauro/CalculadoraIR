using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraIR.ViewModel;
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
        /// <summary>
        /// Metodo responsável por inserir nosso Contribuinte na Base
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public bool Inserir([FromBody] Contribuinte c)
        {
            _unitOfWork.Contribuintes.Inserir(c);
            _unitOfWork.Commit();
            return true;
        }
        /// <summary>
        /// RetornaTodos os Contribuintes
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<ContrubuinteViewModel> RetornaContribuintes([FromQuery]double salario)
        {
            InserirSalario(salario);
            var lista = from c in _unitOfWork.Contribuintes.RetornaContribuintes()
                        select new ContrubuinteViewModel
                        {
                            Nome = c.Nome,
                            IR = CalculaIr(c.RendaBruta,c.Dependentes)
                        };
            return lista.OrderBy(x => x.IR).ThenBy(x => x.Nome);
        }
        /// <summary>
        /// Seta salário minimo
        /// </summary>
        /// <param name="salario"></param>
        private void InserirSalario([FromBody] double salario)
        {
            SalarioMinimo.Valor = salario;
        }
        /// <summary>
        /// Calcula Imposto de renda
        /// </summary>
        /// <param name="c"></param>
        private double CalculaIr(double rendaBruta,double dependentes)
        {
            double RendaLiquida = rendaBruta - (rendaBruta * ((dependentes * 5)/100));
            var resultado =  RendaLiquida / SalarioMinimo.Valor;
            if (resultado < 2)
            {
                return 0;
            }
            else if (resultado > 2 && resultado < 4)
            {
                return RendaLiquida *(7.5/100);
            }
            else if (resultado > 4 && resultado < 5)
            {
                return RendaLiquida *(15/100);
            }
            else if (resultado > 5 && resultado < 7)
            {
                return RendaLiquida *(22.5/100);
            }
            else
            {
                return RendaLiquida * (27.5/100);
            }
        }
    }
}