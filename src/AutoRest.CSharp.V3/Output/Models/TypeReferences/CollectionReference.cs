// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class CollectionTypeReference : ClientTypeReference
    {
        public CollectionTypeReference(ClientTypeReference itemType, bool isNullable)
        {
            ItemType = itemType;
            IsNullable = isNullable;
        }

        public ClientTypeReference ItemType { get; }
        public override bool IsNullable { get; }
    }
}
