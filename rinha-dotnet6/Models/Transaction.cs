using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rinha_dotnet6.Models
{
    public enum TipoTransacao
    {
        Deposito = 'd',
        Credito = 'c'
    }
    public class Transaction
    {
        public String Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        
        [StringLength(10, ErrorMessage ="A descrição deve ter no máximo 10 caracteres")]
        public String Descricao { get; set; }
        public DateTime ? Data { get; set; }
    }
}