﻿using System.Linq;
using CommandQueryExample.Common.Queries;
using CommandQuerySample.Domain;

namespace CommandQueryExample.Core
{
    public class GetPeopleByFirstNameQuery : QueryBase<Person>
    {
        public GetPeopleByFirstNameQuery(string firstName)
        {
            _query = s => s.Where(x => x.FirstName == firstName).ToList();
        }
    }
}