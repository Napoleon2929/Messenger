using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Messenger.Persistence.Abstractions
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }

        bool AsNoTracking { get; }

        Func<IQueryable<T>, IIncludableQueryable<T, object>>[] Includes { get; }
    }
}
