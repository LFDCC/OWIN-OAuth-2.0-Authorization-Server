// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Microsoft.Owin.Security.OAuth2
{
    /// <summary>
    /// Contains the authentication ticket data from an OAuth bearer token.
    /// </summary>
    public class OAuthValidateIdentityContext : BaseValidatingTicketContext<OAuthBearerAuthenticationOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthValidateIdentityContext"/> class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="ticket"></param>
        public OAuthValidateIdentityContext(
            IOwinContext context,
            OAuthBearerAuthenticationOptions options,
            AuthenticationTicket ticket) : base(context, options, ticket)
        {
        }
    }
}