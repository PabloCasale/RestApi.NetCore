﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.NetCore.Contracts
{
    public class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = Root + "/" + Version;

        public static class Posts
        {
            public const string GetAll = Base + "/posts";
            public const string Get = Base + "/posts/{postId}";
            public const string Update = Base + "/posts/{postId}";
            public const string Delete = Base + "/posts/{postId}";
            public const string Create = Base + "/posts";
            //public static readonly string Create = $"{Base}/posts";
            //public static readonly string Get = $"{Base}/posts/{postID}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string Refresh = Base + "/identity/refresh";
        }
    }
}
