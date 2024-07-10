using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.ServicesData.RepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.ServicesData
{
    public interface IUserOptionRepositorio : IRepositorioBase<UserOption>
    {

        Task<List<Option>> getOptionByUser(int userId);
    }
}
