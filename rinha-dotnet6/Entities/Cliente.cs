using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rinha_dotnet6.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Limite { get; set; }
        public int Saldo { get; set; }

    }
}