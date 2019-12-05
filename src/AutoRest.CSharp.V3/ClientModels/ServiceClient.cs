// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ServiceClient
    {
        public ServiceClient(string name, ClientMethod[] methods)
        {
            Name = name;
            Methods = methods;
        }

        public string Name { get; }

        public ClientMethod[] Methods { get; }
    }
}
