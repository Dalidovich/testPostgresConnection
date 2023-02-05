using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPostgresConnection.Domain.Entities;
using testPostgresConnection.Domain.Response.Base;

namespace testPostgresConnection.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IBaseResponse<Account>> GetOne(string login);
        Task<IBaseResponse<IEnumerable<Account>>> GetAll();
    }
}
