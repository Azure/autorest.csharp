// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Authentication.Union
{
    public partial class UnionClient
    {
        /// <summary>
        /// Gets the scopes required for authentication. We add this for test purpose, because the original AuthorizationScopes is private. We add this public property so that we could refer to in the test case.
        /// </summary>
        public static string[] TokenScopes => AuthorizationScopes;
    }
}
