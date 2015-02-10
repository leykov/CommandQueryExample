using System;
using System.Linq.Expressions;
using CommandQueryExample.Common.Extensions;

namespace CommandQueryExample.Common.Queries
{
    public class SingleAsyncQuery<T> : AsyncScalarQueryBase<T> where T : class
    {
        public SingleAsyncQuery(Expression<Func<T, bool>> where)
        {
            _query = s => s.SingleAsync(where);
        }
    }
}