// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethodPaging
    {
        public ClientMethodPaging(string name, string? description, ClientMethodRequest request, ServiceClientParameter[] parameters, ClientMethodResponse responseType, ClientMethodDiagnostics diagnostics, bool includesPaging)
        {
            IncludesPaging = includesPaging;
        }

        public bool IncludesPaging { get; }
    }
}
