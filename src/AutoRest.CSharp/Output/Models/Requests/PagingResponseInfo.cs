// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using Azure;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class PagingResponseInfo
    {
        public PagingResponseInfo(Paging paging, CSharpType type)
        {
            ResponseType = type;

            TypeProvider implementation = type.Implementation;
            if (!(implementation is ObjectType objectType))
            {
                throw new InvalidOperationException($"The type '{type}' has to be an object schema to be used in paging");
            }

            string? nextLinkName = paging.NextLinkName;
            string itemName = paging.ItemName ?? "value";

            ObjectTypeProperty itemProperty = objectType.GetPropertyBySerializedName(itemName);

            ObjectTypeProperty? nextLinkProperty = null;
            if (!string.IsNullOrWhiteSpace(nextLinkName))
            {
                nextLinkProperty = objectType.GetPropertyBySerializedName(nextLinkName);
            }

            if (!TypeFactory.IsList(itemProperty.Declaration.Type))
            {
                throw new InvalidOperationException($"{itemName} property has to be an array schema, actual {itemProperty.SchemaProperty?.Schema}");
            }

            CSharpType itemType = TypeFactory.GetElementType(itemProperty.Declaration.Type);
            NextLinkProperty = nextLinkProperty;
            ItemProperty = itemProperty;
            ItemType = itemType;
        }

        public CSharpType ResponseType { get; }
        public ObjectTypeProperty? NextLinkProperty { get; }
        public ObjectTypeProperty ItemProperty { get; }
        public CSharpType PageType => new CSharpType(typeof(Page<>), ItemType);
        public CSharpType ItemType { get; }
    }
}