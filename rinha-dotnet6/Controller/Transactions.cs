using Microsoft.AspNetCore.Mvc;
using rinha_dotnet6.Entities;

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