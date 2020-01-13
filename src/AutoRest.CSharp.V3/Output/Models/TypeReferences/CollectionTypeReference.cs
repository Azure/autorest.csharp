// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class CollectionTypeReference : TypeReference
    {
        public CollectionTypeReference(TypeReference itemType, bool isNullable)
        {
            ItemType = itemType;
            IsNullable = isNullable;
        }

        public TypeReference ItemType { get; }
        public override bool IsNullable { get; }
    }
}
