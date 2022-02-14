using System;
using System.Collections.Generic;
using System.Text;
using V8.Infrastructure.Contexts;

namespace V8.Infrastructure.Repositories.V8Notify
{
    public class V8NotifyBaseRepository<T> : BaseRepository<T> where T : class
    {
        protected V8NotifyContext v8NotifyContext { get; set; }

        public V8NotifyBaseRepository(V8NotifyContext repositoryContext) : base(repositoryContext)
        {
            v8NotifyContext = (V8NotifyContext)base.Context;
        }
    }
}
