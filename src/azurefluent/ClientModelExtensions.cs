// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Text.RegularExpressions;
using AutoRest.Core.Model;
using AutoRest.CSharp.Azure.Fluent.Model;

namespace AutoRest.CSharp.Azure.Fluent
{
    public static class ClientModelExtensions
    {
        public static bool IsResource(this IModelType type)
        {
            var compositeType = type as CompositeTypeCsaf;
            return (compositeType != null) && compositeType.IsResource;
        }

        public static bool IsResourceArray(this IModelType type)
        {
            var arrayType = type as SequenceType;
            return arrayType != null && IsResource(arrayType.ElementType);
        }

        public static bool IsResourceMap(this IModelType type)
        {
            var mapType = type as DictionaryType;
            return mapType != null && IsResource(mapType.ValueType);
        }
    }
}