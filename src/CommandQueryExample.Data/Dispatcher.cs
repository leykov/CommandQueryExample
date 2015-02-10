﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CommandQueryExample.Common;
using CommandQueryExample.Common.Commands;
using CommandQueryExample.Common.Queries;

namespace CommandQueryExample.Data
{
    public class Dispatcher : IDispatcher
    {
        static DbContext Context
        {
            get
            {
                var currentContext = DataContextFactory.CurrentContext;
                return ((DataContext) currentContext).Context;
            }
        }

        public IEnumerable<T> Get<T>(QueryBase<T> query) where T : class
        {
            return query.Call(Context.Set<T>());
        }

        public async Task<IEnumerable<T>> GetAsync<T>(AsyncQueryBase<T> query) where T : class
        {
            return await query.CallAsync(Context.Set<T>());
        }

        public T Find<T>(ScalarQueryBase<T> query) where T : class
        {
            return query.Call(Context.Set<T>());
        }

        public async Task<T> FindAsync<T>(AsyncScalarQueryBase<T> query) where T : class
        {
            return await query.CallAsync(Context.Set<T>());
        }

        public void QueueCommand<T>(CommandBase<T> command) where T : class
        {
            command.AttachIfNeeded = AttachIfNeeded;
            command.MarkAsModified = MarkAsModified;

            command.Execute(Context.Set<T>());

            command.AttachIfNeeded = x => x;
            command.MarkAsModified = x => x;
        }

        static T AttachIfNeeded<T>(T entity) where T : class
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                Context.Set<T>().Attach(entity);
            return entity;
        }

        static T MarkAsModified<T>(T entity) where T : class
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}