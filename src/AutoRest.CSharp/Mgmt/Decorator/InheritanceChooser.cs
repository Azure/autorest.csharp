// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class InheritanceChooser
    {
        internal const string ReferenceAttributeName = "ReferenceTypeAttribute";

        private static ConcurrentDictionary<Schema, CSharpType?> _valueCache = new ConcurrentDictionary<Schema, CSharpType?>();

        public static bool TryGetCachedExactMatch(Schema schema, out CSharpType? result)
        {
            return _valueCache.TryGetValue(schema, out result);
        }

        public static CSharpType? GetExactMatch(MgmtObjectType originalType, ObjectTypeProperty[] properties, BuildContext<MgmtOutputLibrary> context)
        {
            if (_valueCache.TryGetValue(originalType.ObjectSchema, out var result))
                return result;
            var propertyNames = properties.Select(p => p.Declaration.Name).ToHashSet();
            foreach (System.Type parentType in ReferenceClassFinder.GetReferenceClassCollection(context))
            {
                var attributeObj = parentType.GetCustomAttributes()?.Where(a => a.GetType().Name == ReferenceAttributeName).First();
                var optionalPropertiesForMatch = new HashSet<string>((attributeObj?.GetType().GetProperty("OptionalProperties")?.GetValue(attributeObj) as string[])!);
                List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !optionalPropertiesForMatch.Contains(p.PropertyType.Name) || propertyNames.Contains(p.PropertyType.Name)).ToList();
                if (PropertyMatchDetection.IsEqual(parentProperties, properties.ToList()))
                {
                    result = GetCSharpType(originalType, parentType);
                    _valueCache.TryAdd(originalType.ObjectSchema, result);
                    return result;
                }
            }
            _valueCache.TryAdd(originalType.ObjectSchema, null);
            return null;
        }

        public static CSharpType? GetSupersetMatch(MgmtObjectType originalType, ObjectTypeProperty[] properties, BuildContext<MgmtOutputLibrary> context)
        {
            foreach (System.Type parentType in ReferenceClassFinder.GetReferenceClassCollection(context))
            {
                if (IsSuperset(parentType, properties))
                {
                    return GetCSharpType(originalType, parentType);
                }
            }
            return null;
        }

        private static CSharpType GetCSharpType(MgmtObjectType originalType, Type parentType)
        {
            return CSharpType.FromSystemType(originalType.Context, parentType);
        }

        private static bool IsSuperset(System.Type parentType, ObjectTypeProperty[] properties)
        {
            var childProperties = properties.ToList();
            var propertyNames = properties.Select(p => p.Declaration.Name).ToHashSet();
            var attributeObj = parentType.GetCustomAttributes()?.Where(a => a.GetType().Name == ReferenceAttributeName).First();
            var optionalPropertiesForMatch = new HashSet<string>((attributeObj?.GetType().GetProperty("OptionalProperties")?.GetValue(attributeObj) as string[])!);
            List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !optionalPropertiesForMatch.Contains(p.PropertyType.Name) || propertyNames.Contains(p.PropertyType.Name)).ToList();

            if (parentProperties.Count >= childProperties.Count)
                return false;

            Dictionary<string, PropertyInfo> parentDict = new Dictionary<string, PropertyInfo>();
            int matchCount = 0;
            foreach (var parentProperty in parentProperties)
            {
                parentDict.Add(parentProperty.Name, parentProperty);
            }

            foreach (var childProperty in childProperties)
            {
                if (parentProperties.Count == matchCount)
                    break;

                if (PropertyMatchDetection.DoesPropertyExistInParent(childProperty, parentDict))
                    matchCount++;
            }

            return parentProperties.Count == matchCount;
        }
    }
}
