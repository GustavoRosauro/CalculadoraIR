using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    /// <summary>
    /// Estrutura dos Contribuentes
    /// </summary>
    [Table("Contribuintes")]
    public class Contribuinte
    {
        /// <summary>
        /// Chave responsável pelos dados na tabela
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome do Contribuente
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CPF Campo unico
        /// </summary>
        [MaxLength(11)]
        public string CPF { get; set; }
        /// <summary>
        ///Numero de dependentes
        /// </summary>
        public int Dependentes { get; set; }
        /// <summary>
        /// Renda Bruta Mensal
        /// </summary>
        public double RendaBruta { get; set; }
    }
}
