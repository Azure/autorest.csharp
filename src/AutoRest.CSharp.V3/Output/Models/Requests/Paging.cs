// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class Paging
    {
        public Paging(string? nextLinkName, string itemName, TypeReference itemType, string? operationName)
        {
            NextLinkName = nextLinkName;
            ItemName = itemName;
            ItemType = itemType;
            OperationName = operationName;
        }

        public string? NextLinkName { get; }
        public string ItemName { get; }
        public TypeReference? ItemType { get; }
        public string? OperationName { get; }
    }
}
