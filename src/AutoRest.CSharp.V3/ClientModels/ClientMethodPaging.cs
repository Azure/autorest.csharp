// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethodPaging
    {
        public ClientMethodPaging(ClientMethod method, ClientMethod nextPageMethod, string name, string? nextLinkName, string itemName, ClientTypeReference itemType, string? operationName)
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
        public ClientTypeReference ItemType { get; }
        public string? OperationName { get; }
    }
}
