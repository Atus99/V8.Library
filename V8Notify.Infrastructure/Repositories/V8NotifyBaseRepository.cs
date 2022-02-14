using System;
using System.Collections.Generic;
using System.Text;
using V8Notify.Infrastructure.Contexts;

namespace V8Notify.Infrastructure.Repositories
{
    public class V8NotifyBaseRepository<T> : BaseRepository<T> where T : class
    {
        protected V8NotifyContext V8NotifyContext { get; set; }

        public V8NotifyBaseRepository(V8NotifyContext repositoryContext) : base(repositoryContext)
        {
            V8NotifyContext = (V8NotifyContext)base.Context;
        }
    }
}
