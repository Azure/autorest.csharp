﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Utilities
{
    internal static class ReflectionExtensions
    {
        internal static bool IsReadOnly(this PropertyInfo property, bool allowInternal = false)
        {
            CSharpType propertyType = property.PropertyType;
            if (TypeFactory.IsCollectionType(property.PropertyType))
            {
                return propertyType.IsReadOnlyDictionary || TypeFactory.IsReadOnlyList(property.PropertyType);
            }

            var setMethod = property.GetSetMethod(nonPublic: allowInternal);

            return setMethod == null || setMethod is { IsPublic: false, IsAssembly: false };
        }
    }
}
