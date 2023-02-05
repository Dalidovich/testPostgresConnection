using System.Linq.Expressions;
using testPostgresConnection.Domain.Entities;
using testPostgresConnection.Domain.SpecificationPattern.Base;

namespace testPostgresConnection.Domain.SpecificationPattern.CustomSpecification
{
    public class PasswordLengthMoreThenLimit : Specification<Account>
    {
        private readonly int _lengthLimit;
        public PasswordLengthMoreThenLimit(int lengthLimit)
        {
            _lengthLimit = lengthLimit;
            expression = account => account.password.Length > _lengthLimit;
        }

        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }

}
