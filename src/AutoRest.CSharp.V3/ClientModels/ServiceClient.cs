// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ServiceClient
    {
        public ServiceClient(string name, string description, ServiceClientParameter[] parameters, ClientMethod[] methods, ClientMethodPaging[] pagingMethods)
        {
            Name = name;
            Parameters = parameters;
            Methods = methods;
            PagingMethods = pagingMethods;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }

        public ClientMethod[] Methods { get; }
        public ClientMethodPaging[] PagingMethods { get; }
        public ServiceClientParameter[] Parameters { get; }
    }
}
