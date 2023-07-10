// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Utilities
{
    internal static class ReflectionExtensions
    {
        internal static bool IsReadOnly(this PropertyInfo property)
        {
            if (TypeFactory.IsCollectionType(property.PropertyType))
            {
                return TypeFactory.IsReadOnlyDictionary(property.PropertyType) || TypeFactory.IsReadOnlyList(property.PropertyType);
            }

            // since we are potentially comparing internal properties, set nonPublic to true
            return property.GetSetMethod(true) == null;
        }
    }
}
