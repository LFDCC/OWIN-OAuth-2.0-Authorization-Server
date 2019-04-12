// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Owin;

namespace Custom.OAuth
{
    /// <summary>
    /// Base class used for certain event contexts
    /// </summary>
    public abstract class BaseValidatingClientContext : BaseValidatingContext<OAuthAuthorizationServerOptions>
    {
        /// <summary>
        /// Initializes base class used for certain event contexts
        /// </summary>
        protected BaseValidatingClientContext(
            IOwinContext context,
            OAuthAuthorizationServerOptions options,
            string clientId)
            : base(context, options)
        {
            ClientId = clientId;
        }

        /// <summary>
        /// The "client_id" parameter for the current request. The Authorization Server application is responsible for
        /// validating this value identifies a registered client.
        /// </summary>
        public string ClientId { get; protected set; }
    }
}