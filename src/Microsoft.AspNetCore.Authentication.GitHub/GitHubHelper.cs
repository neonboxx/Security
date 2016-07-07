// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.GitHub
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from GitHub after a successful authentication process.
    /// </summary>
    public static class GitHubHelper
    {
        /// <summary>
        /// Gets the GitHub user ID.
        /// </summary>
        public static string GetId(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("id");
        }
        

        /// <summary>
        /// Gets the GitHub email.
        /// </summary>
        public static string GetEmail(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("email");
        }

        // Get the given subProperty from a property.
        private static string TryGetValue(JObject user, string propertyName, string subProperty)
        {
            JToken value;
            if (user.TryGetValue(propertyName, out value))
            {
                var subObject = JObject.Parse(value.ToString());
                if (subObject != null && subObject.TryGetValue(subProperty, out value))
                {
                    return value.ToString();
                }
            }
            return null;
        }

    }
}
