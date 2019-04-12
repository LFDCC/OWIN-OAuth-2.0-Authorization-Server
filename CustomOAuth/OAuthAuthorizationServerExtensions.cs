// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Custom.OAuth;

namespace Owin
{
    /// <summary>
    /// Extension methods to add Authorization Server capabilities to an OWIN pipeline
    /// </summary>
    public static class OAuthAuthorizationServerExtensions
    {
        /// <summary>
        /// Adds OAuth2 Authorization Server capabilities to an OWIN web application. This middleware
        /// performs the request processing for the Authorize and Token endpoints defined by the OAuth2 specification.
        /// See also http://tools.ietf.org/html/rfc6749
        /// </summary>
        /// <param name="app">The web application builder</param>
        /// <param name="options">Options which control the behavior of the Authorization Server.</param>
        /// <returns>The application builder</returns>
        public static IAppBuilder UseOAuthAuthorizationServer(this IAppBuilder app, OAuthAuthorizationServerOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            app.Use(typeof(OAuthAuthorizationServerMiddleware), app, options);
            return app;
        }
    }
}