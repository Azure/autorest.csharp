// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace security_aad_LowLevel
{
    public partial class AutorestSecurityAadClient
    {
        public static string[] TokenScopes => AuthorizationScopes;
    }
}
