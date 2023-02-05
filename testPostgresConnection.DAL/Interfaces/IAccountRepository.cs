using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPostgresConnection.Domain.Entities;

namespace testPostgresConnection.DAL.Interfaces
{
    public interface IAccountRepository: IBaseRepository<Account>
    {
    }
}
