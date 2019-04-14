// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Owin;

namespace Microsoft.Owin.Security.OAuth2.Messages
{
    /// <summary>
    /// Data object used by TokenEndpointRequest which contains parameter information when the "grant_type" is unrecognized.
    /// </summary>
    public class TokenEndpointRequestCustomExtension
    {
        /// <summary>
        /// The parameter information when the "grant_type" is unrecognized.
        /// </summary>
        public IReadableStringCollection Parameters { get; set; }
    }
}