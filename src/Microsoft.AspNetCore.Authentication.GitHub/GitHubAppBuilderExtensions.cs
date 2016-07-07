// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Authentication.GitHub;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add GitHub authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class GitHubAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitHubMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables GitHub authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseGitHubAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<GitHubMiddleware>();
        }

        /// <summary>
        /// Adds the <see cref="GitHubMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables GitHub authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A <see cref="GitHubOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseGitHubAuthentication(this IApplicationBuilder app, GitHubOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<GitHubMiddleware>(Options.Create(options));
        }
    }
}
