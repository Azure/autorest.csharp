// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethod
    {
        public ClientMethod(string name, ClientMethodRequest request, ServiceClientParameter[] parameters, ClientMethodResponse responseType)
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Response = responseType;
        }

        public string Name { get; }

        public ClientMethodRequest Request { get; }
        public ServiceClientParameter[] Parameters { get; }
        public ClientMethodResponse Response { get; }
    }
}
