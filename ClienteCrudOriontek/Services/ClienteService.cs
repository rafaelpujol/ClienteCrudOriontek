using ClienteCrudOriontek.Context;
using ClienteCrudOriontek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCrudOriontek.Services
{
    public class ClienteService : IClienteService
    {
        ClienteContext _context;
        public ClienteService(ClienteContext context)
        {
            _context = context;
        }
        public async Task<int> AddCliente(Cliente cliente)
        {
            if (_context != null)
            {
               await _context.clientes.AddAsync(cliente);
               
                await _context.SaveChangesAsync();
                return cliente.id;
            }
            return 0;
            
        }

        public async Task<int> DeleteCliente(int? clienteid)
        {
            var result = 0;
            if(_context != null)
            {
                var cliente =  await _context.clientes.FirstOrDefaultAsync(x => x.id == clienteid);

                if(cliente != null)
                {
                    _context.Remove(cliente);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<Cliente> GetCliente(int? clienteid)
        {
            return  await _context.clientes.Include(x => x.direcciones).FirstOrDefaultAsync(x => x.id == clienteid);
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.clientes.Include(x => x.direcciones).ToListAsync();
        }

        public async Task UpdatCliente(Cliente cliente)
        {
            _context.Update(cliente);
            _context.UpdateRange(cliente.direcciones);
            await _context.SaveChangesAsync();
        }
    }
}
