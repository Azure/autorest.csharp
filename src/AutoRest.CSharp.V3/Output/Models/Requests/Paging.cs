// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class Paging
    {
        public Paging(Method method, Method nextPageMethod, string name, string? nextLinkName, string itemName, TypeReference itemType, string? operationName)
        {
            Method = method;
            NextPageMethod = nextPageMethod;
            Name = name;
            NextLinkName = nextLinkName;
            ItemName = itemName;
            ItemType = itemType;
            OperationName = operationName;
        }

        public string Name { get; }
        public ClientMethod Method { get; }
        public ClientMethod NextPageMethod { get; }
        public string? NextLinkName { get; }
        public string ItemName { get; }
        public TypeReference ItemType { get; }
        public string? OperationName { get; }
    }
}
