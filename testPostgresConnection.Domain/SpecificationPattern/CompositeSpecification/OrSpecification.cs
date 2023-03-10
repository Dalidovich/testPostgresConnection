using System.Linq.Expressions;
using testPostgresConnection.Domain.SpecificationPattern.Base;

namespace testPostgresConnection.Domain.SpecificationPattern.CompositeSpecification
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec0;
        private readonly Specification<T> _spec1;

        public OrSpecification(Specification<T> spec0, Specification<T> spec1)
        {
            _spec0 = spec0;
            _spec1 = spec1;


            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(_spec0.ToExpression().Body, _spec1.ToExpression().Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);


            expression = finalExpr;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return expression;
        }
    }

}
