using System;
using System.Linq;
using System.Linq.Expressions;
using CommandQueryExample.Common.Extensions;

namespace CommandQueryExample.Common.Queries
{
    public class FirstOrDefaultQuery<T> : ScalarQueryBase<T> where T : class
    {
        public FirstOrDefaultQuery(Expression<Func<T, bool>> where = null)
        {
            if (where.IsNull())
            {
                _query = s => s.FirstOrDefault();
                return;
            }
            _query = s => s.FirstOrDefault(where);
        }
    }
}