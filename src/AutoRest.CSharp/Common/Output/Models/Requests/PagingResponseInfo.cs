// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class PagingResponseInfo
    {
        public PagingResponseInfo(string? nextLinkName, string? itemName, CSharpType type)
        {
            NextLinkPropertyName = nextLinkName;
            ItemPropertyName = itemName ?? "value";

            ObjectTypeProperty itemProperty = GetPropertyBySerializedName(type, ItemPropertyName);
            if (!TypeFactory.IsList(itemProperty.Declaration.Type))
            {
                throw new InvalidOperationException($"'{itemName}' property must be be an array input type instead of '{itemProperty.InputModelProperty?.Type}'");
            }
            ItemType = TypeFactory.GetElementType(itemProperty.Declaration.Type);
        }

        public string? NextLinkPropertyName { get; }
        public string ItemPropertyName { get; }
        public CSharpType ItemType { get; }

        private ObjectTypeProperty GetPropertyBySerializedName(CSharpType type, string name)
        {
            TypeProvider implementation = type.Implementation;

            if (implementation is SchemaObjectType objectType)
            {
                return objectType.GetPropertyBySerializedName(name);
            }

            if (implementation is ModelTypeProvider modelType)
            {
                return modelType.GetPropertyBySerializedName(name);
            }

            throw new InvalidOperationException($"The type '{type}' has to be an object schema to be used in paging");
        }
    }
}
