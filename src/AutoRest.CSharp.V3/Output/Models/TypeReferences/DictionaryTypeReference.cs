// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.Output.Models.TypeReferences
{
    internal class DictionaryTypeReference: TypeReference
    {
        public DictionaryTypeReference(TypeReference keyType, TypeReference valueType, bool isNullable)
        {
            KeyType = keyType;
            ValueType = valueType;
            IsNullable = isNullable;
        }

        public TypeReference KeyType { get; }
        public TypeReference ValueType { get; }
        public override bool IsNullable { get; }
    }
}
