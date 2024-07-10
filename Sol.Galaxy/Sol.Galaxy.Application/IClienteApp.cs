using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public interface IClienteApp
    {
        Task<List<ClienteLista>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> Add(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<bool> Delete(int IdCliente);
    }
}
