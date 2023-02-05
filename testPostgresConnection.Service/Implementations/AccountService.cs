using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPostgresConnection.DAL.Interfaces;
using testPostgresConnection.Domain.Entities;
using testPostgresConnection.Domain.Enums;
using testPostgresConnection.Domain.Response.Base;
using testPostgresConnection.Domain.SpecificationPattern.CompositeSpecification;
using testPostgresConnection.Domain.SpecificationPattern.CustomSpecification;
using testPostgresConnection.Service.Interfaces;

namespace testPostgresConnection.Service.Implementations
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IAccountRepository accountRepository, ILogger<AccountService> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<IBaseResponse<Account>> GetOne(string login)
        {
            try
            {
                var account = await _accountRepository.GetAll().FirstOrDefaultAsync(x=>x.login==login);
                if (account == null)
                {
                    return new BaseResponse<Account>()
                    {
                        Description = "account not found"
                    };
                }
                return new BaseResponse<Account>()
                {
                    Data = account,
                    StatusCode = StatusCode.AccountRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetOne] : {ex.Message}");
                return new BaseResponse<Account>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public async Task<IBaseResponse<IEnumerable<Account>>> GetAll()
        {
            try
            {
                PasswordLengthMoreThenLimit passwordContainDigit = new PasswordLengthMoreThenLimit(2);
                MultipleChosenId oddId = new MultipleChosenId(2);
                AndSpecification<Account> and = new AndSpecification<Account>(passwordContainDigit,oddId);

                //use specification
                //var contents = await _accountRepository.GetAll().Where(and.ToExpression()).ToListAsync();

                var contents = await _accountRepository.GetAll().ToListAsync();
                if (contents == null)
                {
                    return new BaseResponse<IEnumerable<Account>>()
                    {
                        Description = "code not found"
                    };
                }
                return new BaseResponse<IEnumerable<Account>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.AccountRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetContent] : {ex.Message}");
                return new BaseResponse<IEnumerable<Account>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
