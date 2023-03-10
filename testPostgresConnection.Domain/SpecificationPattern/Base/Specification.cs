using System.Linq.Expressions;

namespace testPostgresConnection.Domain.SpecificationPattern.Base
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        protected Expression<Func<T, bool>> expression = null;

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }

}
