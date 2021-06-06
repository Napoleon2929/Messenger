using Messenger.Persistence.Abstractions.Enums;
using System;
using System.Linq.Expressions;

namespace Messenger.Persistence.Abstractions
{
    public interface ISorting<T>
    {
        Expression<Func<T, object>> Selector { get; }

        SortingType SortingType { get; }
    }
}
