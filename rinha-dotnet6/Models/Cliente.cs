using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rinha_dotnet6.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        
        [StringLength(10, ErrorMessage ="A descrição deve ter no máximo 10 caracteres")]
        public string Descricao { get; set; }
    }
}