// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Authentication.OAuth2
{
    /// <summary>
    /// OAuth2 client.
    /// </summary>
    public partial class OAuth2Client
    {
        /// <summary>
        /// The authorization scopes. We add this for test purpose, because the original AuthorizationScopes is private. We add this public property so that we could refer to in the test case.
        /// </summary>
        public static string[] TokenScopes => AuthorizationScopes;
    }
}
