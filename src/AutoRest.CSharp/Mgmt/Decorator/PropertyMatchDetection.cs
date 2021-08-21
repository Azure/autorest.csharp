// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class PropertyMatchDetection
    {
        internal static bool IsEqual(List<PropertyInfo> parentProperties, List<ObjectTypeProperty> childProperties, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            if (parentProperties.Count != childProperties.Count)
                return false;

            Dictionary<string, PropertyInfo> parentDict = new Dictionary<string, PropertyInfo>();
            foreach (var parentProperty in parentProperties)
            {
                parentDict.Add(parentProperty.Name, parentProperty);
            }

            foreach (var childProperty in childProperties)
            {
                if (!DoesPropertyExistInParent(childProperty, parentDict, propertiesInComparison))
                    return false;
            }

            return true;
        }

        internal static bool DoesPropertyExistInParent(ObjectTypeProperty childProperty, Dictionary<string, PropertyInfo> parentDict, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            PropertyInfo? parentProperty;
            CSharpType childPropertyType = childProperty.Declaration.Type;

            if (!parentDict.TryGetValue(childProperty.Declaration.Name, out parentProperty))
                return false;

            if (parentProperty.PropertyType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}" ||
                IsAssignable(parentProperty.PropertyType, childPropertyType))
            {
                if (childProperty.IsReadOnly != (parentProperty.GetSetMethod() == null))
                    return false;
            }
            else if (!ArePropertyTypesMatch(parentProperty.PropertyType!, childPropertyType, propertiesInComparison))
            {
                return false;
            }

            return true;
        }

        private static bool ArePropertyTypesMatch(System.Type parentPropertyType, CSharpType childPropertyType, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            if (IsGuidAndStringType(parentPropertyType!, childPropertyType!))
            {
                return true;
            }
            else if (parentPropertyType.IsGenericType)
            {
                return IsMatchingGenericType(parentPropertyType!, childPropertyType!, propertiesInComparison);
            }
            else if (IsAssignable(parentPropertyType!, childPropertyType))
            {
                return true;
            }
            else if (parentPropertyType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}")
            {
                // This branch implies parentPropertyType is not a class because if it is a class, IsEqual() will always be called first and if the comparison for this branch is true, in DoesPropertyExistInParent, the branch for ArePropertyTypesMatch will never be called.
                return true;
            }
            // Need to compare subproperties recursively when the property Types have different names but should avoid infinite loop in cases like ErrorResponse has a property of List<ErrorResponse>, so we'll check whether we've compared properties in propertiesInComparison.
            else if (parentPropertyType.IsClass && matchProperty(parentPropertyType, childPropertyType, propertiesInComparison, fromArePropertyTypesMatch: true))
            {
                return true;
            }
            else if (!(parentPropertyType.IsGenericParameter && IsAssignable(parentPropertyType.BaseType!, childPropertyType)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Tells if <paramref name="childPropertyType" /> can be assigned to <paramref name="parentPropertyType" />
        /// by checking if there's an implicit type convertor in <paramref name="parentPropertyType" />.
        /// Todo: should we check childPropertyType as well since an implicit can be defined in either classes?
        /// </summary>
        /// <param name="parentPropertyType">The type to be assigned to.</param>
        /// <param name="childPropertyType">The type to assign.</param>
        /// <returns></returns>
        private static bool IsAssignable(System.Type parentPropertyType, CSharpType childPropertyType)
        {
            return parentPropertyType.GetMethods().Where(m => m.Name == "op_Implicit" &&
                m.ReturnType == parentPropertyType &&
                m.GetParameters().First().ParameterType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}").Count() > 0;
        }

        private static bool IsGuidAndStringType(System.Type parentPropertyType, CSharpType childPropertyType)
        {
            var isParentGuidType = parentPropertyType.GetTypeInfo() == typeof(Guid) || parentPropertyType.GetTypeInfo() == typeof(Guid?);
            var isChildStringType = childPropertyType.IsFrameworkType && childPropertyType.FrameworkType == typeof(string);

            var isParentStringType = parentPropertyType.GetTypeInfo() == typeof(string);
            var isChildGuidType = childPropertyType.IsFrameworkType && (childPropertyType.FrameworkType == typeof(Guid) || childPropertyType.FrameworkType == typeof(Guid?));

            return (isParentGuidType && isChildStringType) || (isParentStringType && isChildGuidType);
        }

        private static bool IsMatchingGenericType(System.Type parentPropertyType, CSharpType childPropertyType, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            var parentGenericTypeDef = parentPropertyType.GetGenericTypeDefinition();
            if (!(childPropertyType.IsFrameworkType && childPropertyType.FrameworkType.IsGenericType && childPropertyType.FrameworkType.GetGenericTypeDefinition() == parentGenericTypeDef))
                return false;
            for (int i = 0; i < parentPropertyType.GetGenericArguments().Length; i++)
            {
                Type parentArgType = parentPropertyType.GetGenericArguments()[i];
                CSharpType childArgType = childPropertyType.Arguments[i];
                var isArgMatches = matchProperty(parentArgType, childArgType, propertiesInComparison);
                if (!isArgMatches)
                    return false;
            }
            return true;
        }

        private static bool matchProperty(Type parentPropertyType, CSharpType childPropertyType, Dictionary<Type, CSharpType>? propertiesInComparison = null, bool fromArePropertyTypesMatch = false)
        {
            if (propertiesInComparison != null && propertiesInComparison.TryGetValue(parentPropertyType, out var val) && val == childPropertyType)
                return true;
            var isArgMatches = false;
            if (parentPropertyType.IsClass && !childPropertyType.IsFrameworkType && childPropertyType.Implementation as MgmtObjectType != null)
            {
                var mgmtObjectType = childPropertyType.Implementation as MgmtObjectType;
                if (mgmtObjectType != null)
                {
                    isArgMatches = IsEqual(parentPropertyType.GetProperties().ToList(), mgmtObjectType.MyProperties.ToList(), new Dictionary<Type, CSharpType>{{parentPropertyType, childPropertyType}});
                }
            }
            else
            {
                if (!fromArePropertyTypesMatch)
                    isArgMatches = ArePropertyTypesMatch(parentPropertyType, childPropertyType);
            }
            return isArgMatches;
        }
    }
}
