using System.Linq.Expressions;
using testPostgresConnection.Domain.Entities;
using testPostgresConnection.Domain.SpecificationPattern.Base;

namespace testPostgresConnection.Domain.SpecificationPattern.CustomSpecification
{
    public class MultipleChosenId : Specification<Account>
    {
        private readonly int _multipleNum;
        public MultipleChosenId(int multipleNum)
        {
            _multipleNum = multipleNum;
            expression = account => account.accountId % _multipleNum == 0;
        }

        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }

}
