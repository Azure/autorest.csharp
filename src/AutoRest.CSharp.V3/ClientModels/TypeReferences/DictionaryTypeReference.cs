// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class DictionaryTypeReference: ClientTypeReference
    {
        public ClientTypeReference KeyType { get; }
        public ClientTypeReference ValueType { get; }

        public DictionaryTypeReference(ClientTypeReference keyType, ClientTypeReference valueType, bool isNullable)
        {
            KeyType = keyType;
            ValueType = valueType;
            IsNullable = isNullable;
        }

        public override bool IsNullable { get; }
    }
}
