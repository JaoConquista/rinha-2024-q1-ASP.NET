using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rinha_dotnet6.Models;

namespace rinha_dotnet6.Controller
{
    [ApiController]
    public class Transacoes : ControllerBase
    {
        [HttpPost]
        [Route("/clientes/{id}/transacoes")]
        public IActionResult createTransaction(Cliente cliente)
        {
            return Ok();
        }
    }
}