using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;

namespace Messenger.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Includes an array of navigation properties for the specified query.
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="query">The query to include navigation properties for that</param>
        /// <param name="includes">The array of navigation properties to include</param>
        /// <returns></returns>
        public static IQueryable<T> Include<T>(this IQueryable<T> query,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
            where T : class
        {
            if (includes == null)
            {
                return query;
            }

            foreach (var include in includes)
            {
                query = include(query);
            }

            return query;
        }
    }
}
