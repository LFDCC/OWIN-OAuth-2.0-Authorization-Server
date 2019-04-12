// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Custom.OAuth.Messages;
using Microsoft.Owin;

namespace Custom.OAuth
{
    /// <summary>
    /// Provides context information used in validating an OAuth authorization request.
    /// </summary>
    public class OAuthValidateAuthorizeRequestContext : BaseValidatingContext<OAuthAuthorizationServerOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthValidateAuthorizeRequestContext"/> class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="authorizeRequest"></param>
        /// <param name="clientContext"></param>
        public OAuthValidateAuthorizeRequestContext(
            IOwinContext context,
            OAuthAuthorizationServerOptions options,
            AuthorizeEndpointRequest authorizeRequest,
            OAuthValidateClientRedirectUriContext clientContext) : base(context, options)
        {
            AuthorizeRequest = authorizeRequest;
            ClientContext = clientContext;
        }

        /// <summary>
        /// Gets OAuth authorization request data.
        /// </summary>
        public AuthorizeEndpointRequest AuthorizeRequest { get; private set; }

        /// <summary>
        /// Gets data about the OAuth client.
        /// </summary>
        public OAuthValidateClientRedirectUriContext ClientContext { get; private set; }
    }
}