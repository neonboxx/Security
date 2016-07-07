// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.GitHub;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Configuration options for <see cref="GitHubMiddleware"/>.
    /// </summary>
    public class GitHubOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="GitHubOptions"/>.
        /// </summary>
        public GitHubOptions()
        {
            AuthenticationScheme = GitHubDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-GitHub");
            SendAppSecretProof = true;
            AuthorizationEndpoint = GitHubDefaults.AuthorizationEndpoint;
            TokenEndpoint = GitHubDefaults.TokenEndpoint;
            UserInformationEndpoint = GitHubDefaults.UserInformationEndpoint;
            Scope.Add("user");
            // Fields.Add("name");
            // Fields.Add("email");
            // Fields.Add("first_name");
            // Fields.Add("last_name");
        }

        // GitHub uses a non-standard term for this field.
        /// <summary>
        /// Gets or sets the GitHub-assigned appId.
        /// </summary>
        public string AppId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        // GitHub uses a non-standard term for this field.
        /// <summary>
        /// Gets or sets the GitHub-assigned app secret.
        /// </summary>
        public string AppSecret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }

        /// <summary>
        /// Gets or sets if the appsecret_proof should be generated and sent with GitHub API calls.
        /// This is enabled by default.
        /// </summary>
        public bool SendAppSecretProof { get; set; }

        /// <summary>
        /// The list of fields to retrieve from the UserInformationEndpoint.
        /// https://developers.GitHub.com/docs/graph-api/reference/user
        /// </summary>
        public ICollection<string> Fields { get; } = new HashSet<string>();
    }
}
