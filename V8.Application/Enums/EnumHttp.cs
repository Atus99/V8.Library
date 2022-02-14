using System;
using System.Collections.Generic;
using System.Text;

namespace V8.Application.Enums
{
    public static class EnumHttp
    {
        public enum HttpClientMethod
        {
            GET = 0,
            POST = 1,
            PUT = 2,
            DELETE = 3,
            HEAD = 4,
            OPTIONS = 5,
            PATCH = 6,
            MERGE = 7,
            COPY = 8
        }

        public enum AccessTokenType
        {
            None = 0,
            Bearer = 1,
            Basic = 2
        }
    }
}
