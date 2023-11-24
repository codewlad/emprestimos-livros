using EmprestimosLivros.API.Interfaces;
using EmprestimosLivros.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosLivros.API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ControleEmprestimoLivroContext _context;

        public ClienteRepository(ControleEmprestimoLivroContext context)
        {
            _context = context;
        }

        public void Alterar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        public void Excluir(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public void Incluir(Cliente cliente)
        {
            _context.Clientes.Add(cliente)
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Cliente> SelecionarByPk(int id)
        {
            return await _context.Clientes.Where(x => x.Id ==  id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodos()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
