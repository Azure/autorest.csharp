// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using Azure;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class PagingResponseInfo
    {
        public PagingResponseInfo(string? nextLinkName, string? itemName, CSharpType type)
        {
            ResponseType = type;
            NextLinkPropertyName = nextLinkName;
            ItemPropertyName = itemName ?? "value";

            ObjectTypeProperty itemProperty = GetPropertyBySerializedName(type, ItemPropertyName);
            if (!itemProperty.Declaration.Type.IsList)
            {
                throw new InvalidOperationException($"'{itemName}' property must be be an array schema instead of '{itemProperty.InputModelProperty?.Type}'");
            }
            ItemType = itemProperty.Declaration.Type.ElementType;
        }

        public CSharpType ResponseType { get; }
        public string? NextLinkPropertyName { get; }
        public string ItemPropertyName { get; }
        public CSharpType PageType => new CSharpType(typeof(Page<>), ItemType);
        public CSharpType ItemType { get; }

        private ObjectTypeProperty GetPropertyBySerializedName(CSharpType type, string name)
        {
            TypeProvider implementation = type.Implementation;

            if (implementation is SchemaObjectType objectType)
            {
                return objectType.GetPropertyBySerializedName(name, true);
            }

            if (implementation is ModelTypeProvider modelType)
            {
                return modelType.GetPropertyBySerializedName(name, true);
            }

            throw new InvalidOperationException($"The type '{type}' has to be an object schema to be used in paging");
        }
    }
}
