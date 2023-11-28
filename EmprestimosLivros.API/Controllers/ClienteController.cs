using AutoMapper;
using EmprestimosLivros.API.DTOs;
using EmprestimosLivros.API.Interfaces;
using EmprestimosLivros.API.Models;
using EmprestimosLivros.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EmprestimosLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.SelecionarTodos();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Incluir(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o cliente.");
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCliente(ClienteDTO clienteDTO)
        {
            if (clienteDTO.Id <= 0)
            {
                return BadRequest("O ID do cliente deve ser maior que zero.");
            }

            var clienteExiste = await _clienteRepository.SelecionarByPk(clienteDTO.Id);
            if (clienteExiste == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _mapper.Map(clienteDTO, clienteExiste);

            _clienteRepository.Alterar(clienteExiste);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o cliente.");
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);

            if(cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _clienteRepository.Excluir(cliente);

            if(await _clienteRepository.SaveAllAsync()){
                return Ok("Cliente excluído com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao excluir o cliente");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);

            if( cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return Ok(clienteDTO);
        }
    }
}
