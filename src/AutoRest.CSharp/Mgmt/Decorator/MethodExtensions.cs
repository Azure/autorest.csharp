// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class MethodExtensions
    {
        /// <summary>
        /// Return true if this operation is a list method. Also returns the itemType of what this operation is listing of, and the property name on the list result model.
        /// This function will return true in the following circumstances:
        /// 1. This operation is a paging method, in this case, valuePropertyName is the same as configured in the pageable options (x-ms-pageable)
        /// 2. This operation is not a paging method, but the return value is a collection type (IReadOnlyList), in this case, valuePropertyName is the empty string
        /// 3. This operation is not a paging method and the return value is not a collection type, but it has similar structure as paging method (has a value property, and value property is a collection)
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="itemType"></param>
        /// <param name="valuePropertyName"></param>
        /// <param name="nextLinkPropertyName"></param>
        /// <returns></returns>
        internal static bool IsListMethod(this Operation operation, [MaybeNullWhen(false)] out CSharpType itemType, [MaybeNullWhen(false)] out string valuePropertyName, out string? nextLinkPropertyName)
        {
            itemType = null;
            valuePropertyName = null;
            nextLinkPropertyName = null;

            var methods = MgmtContext.Library.GetOperationMethods(operation);
            var returnType = methods.ResponseType;
            if (returnType == null)
            {
                return false;
            }

            if (returnType is { IsFrameworkType: false, Implementation: SchemaObjectType schemaObject })
            {
                valuePropertyName = methods.Operation.Paging?.ItemName ?? "value";
                nextLinkPropertyName = methods.Operation.Paging?.NextLinkName;
                itemType = GetValueProperty(schemaObject, valuePropertyName)?.ValueType.Arguments.FirstOrDefault();
            }
            else if (TypeFactory.IsList(returnType))
            {
                itemType = returnType.Arguments[0];
                valuePropertyName = string.Empty;
                nextLinkPropertyName = null;
                return true;
            }

            return itemType != null;
        }

        /// <summary>
        /// Return true if this operation is a list method. Also returns the itemType of what this operation is listing of.
        /// This function will return true in the following circumstances:
        /// 1. This operation is a paging method.
        /// 2. This operation is not a paging method, but the return value is a collection type (IReadOnlyList)
        /// 3. This operation is not a paging method and the return value is not a collection type, but it has similar structure as paging method (has a value property, and value property is a collection)
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="itemType">The type of the item in the collection</param>
        /// <returns></returns>
        public static bool IsListMethod(this Operation operation, [MaybeNullWhen(false)] out CSharpType itemType) => IsListMethod(operation, out itemType, out _, out _);

        private static ObjectTypeProperty? GetValueProperty(SchemaObjectType schemaObject, string pagingItemName)
        {
            return schemaObject.Properties.FirstOrDefault(p => p.SchemaProperty?.SerializedName == pagingItemName &&
                p.SchemaProperty?.FlattenedNames.Count == 0 && p.Declaration.Type.IsFrameworkType &&
                TypeFactory.IsList(p.Declaration.Type));
        }
    }
}
