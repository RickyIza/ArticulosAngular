using AutoMapper;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.ServicesData;
using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public class ClienteApp : IClienteApp
    {
        private readonly ICustomerRepositorio customerRepositorio;
        private readonly IMapper mapper;

        public ClienteApp(ICustomerRepositorio customerRepositorio, IMapper mapper)
        {
            this.customerRepositorio = customerRepositorio;
            this.mapper = mapper;
        }
        public async Task<Cliente> Add(Cliente cliente)
        {
            Customer c = mapper.Map<Customer>(cliente);

            var res = await customerRepositorio.AddAsync(c);

            return mapper.Map<Cliente>(res);
        }

        public async Task<bool> Delete(int IdCliente)
        {
            //Add error manage
            await customerRepositorio.DeleteByIdAsync(IdCliente);
            return true;
        }

        public async Task<List<ClienteLista>> GetAll()
        {
            List<Customer> res = await customerRepositorio.GetAllRepositorio();
            List<ClienteLista> clientes = mapper.Map<List<ClienteLista>>(res);
            return clientes;
        }

        public async Task<Cliente> GetById(int id)
        {

            Customer res = await customerRepositorio.GetByIdAsync(id);
            Cliente cliente = null;

            if (res != null)
            {
                cliente = mapper.Map<Cliente>(res);

            }
            return cliente;

        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            Customer p = mapper.Map<Customer>(cliente);
            await customerRepositorio.UpdateAsync(p);

            return cliente;
        }
    }
}
