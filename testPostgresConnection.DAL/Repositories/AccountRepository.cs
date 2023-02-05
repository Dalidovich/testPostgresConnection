using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPostgresConnection.DAL.Interfaces;
using testPostgresConnection.Domain.Entities;

namespace testPostgresConnection.DAL.Repositories
{
    public class AccountRepository : IBaseRepository<Account>
    {
        private readonly AppDBContext _db;

        public AccountRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<bool> createAsync(Account entity)
        {
            await _db.Accounts.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteAsync(Account entity)
        {
            _db.Accounts.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Account> GetAll()
        {
            return _db.Accounts;
        }
    }
}
