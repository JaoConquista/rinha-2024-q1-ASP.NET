using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rinha_dotnet6.Models
{
    public class Extrato
    {
        public int Saldo { 
            get{
                return Saldo;
                } 
            set{
                if(value < Limite){
                    throw new Exception("Total não pode ser menor que o Limite");
                }
            } 
        }

        public DateTime Data { get; set;}
        public int Limite { get; set;}
    }
}