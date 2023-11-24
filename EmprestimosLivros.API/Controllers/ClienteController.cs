using EmprestimosLivros.API.Interfaces;
using EmprestimosLivros.API.Models;
using EmprestimosLivros.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok(await _clienteRepository.SelecionarTodos());
        }
    }
}
