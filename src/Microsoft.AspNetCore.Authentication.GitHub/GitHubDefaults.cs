// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Authentication.GitHub
{
    public static class GitHubDefaults
    {
        public const string AuthenticationScheme = "GitHub";

        public static readonly string AuthorizationEndpoint = "https://github.com/login/oauth/authorize";

        public static readonly string TokenEndpoint = "https://github.com/login/oauth/access_token";

        public static readonly string UserInformationEndpoint = "https://api.github.com/user";
    }
}
