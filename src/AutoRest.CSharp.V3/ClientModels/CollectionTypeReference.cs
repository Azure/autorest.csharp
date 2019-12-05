// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class CollectionTypeReference : ClientTypeReference
    {
        public ClientTypeReference ItemType { get; }

        public CollectionTypeReference(ClientTypeReference itemType)
        {
            ItemType = itemType;
        }

        //TODO: This should not be defaulted to nullable false
        public override bool IsNullable => false;
    }
}
