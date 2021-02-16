using ClienteCrudOriontek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCrudOriontek.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetClientes();

        Task<Cliente> GetCliente(int? clienteid);

        Task<int> AddCliente(Cliente cliente);

        Task<int> DeleteCliente(int? clienteid);

        Task UpdatCliente(Cliente cliente);
    }
}
