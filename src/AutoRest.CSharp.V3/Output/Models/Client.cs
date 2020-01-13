// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class Client
    {
        public Client(string name, string description, Parameter[] parameters, Method[] methods)
        {
            Name = name;
            Parameters = parameters;
            Methods = methods;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        public Method[] Methods { get; }
        public Parameter[] Parameters { get; }
    }
}
