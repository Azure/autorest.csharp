// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input
{
    internal record InputOAuth2Flow(IReadOnlyCollection<string> Scopes, string? AuthorizationUrl, string? TokenUrl, string? RefreshUrl);
}
