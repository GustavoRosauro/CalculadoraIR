using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraIR.ViewModel
{
    /// <summary>
    /// ViewModel que será mostrado na tabela dos contribuintes
    /// </summary>
    public class ContrubuinteViewModel
    {
        /// <summary>
        /// Chabe da Estrutura
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do contribuinte
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Imposto de renda do contribuinte
        /// </summary>
        public double IR { get; set; }
    }
}
