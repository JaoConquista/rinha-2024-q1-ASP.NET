using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace rinha_dotnet6.Entities
{
    public class Transaction
    {
        [JsonIgnore] //não é a melhor abordagem, mas para fins de teste, está ok
        public int Id { get; set; }
        public int Valor { get; set; }
        public string Tipo { get; set; }
        
        [StringLength(10, ErrorMessage ="A descrição deve ter no máximo 10 caracteres")]
        public string Descricao { get; set; }
        
        [JsonIgnore]
        public DateTime ? Data { get; set; }


    }
}