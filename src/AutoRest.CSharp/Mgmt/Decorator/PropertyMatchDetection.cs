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
        internal static bool IsEqual(List<PropertyInfo> parentProperties, List<ObjectTypeProperty> childProperties)
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
                if (!DoesPropertyExistInParent(childProperty, parentDict))
                    return false;
            }

            return true;
        }

        internal static bool DoesPropertyExistInParent(ObjectTypeProperty childProperty, Dictionary<string, PropertyInfo> parentDict)
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
            else if (!ArePropertyTypesMatch(parentProperty.PropertyType!, childPropertyType))
            {
                return false;
            }

            return true;
        }

        private static bool ArePropertyTypesMatch(System.Type parentPropertyType, CSharpType childPropertyType)
        {
            if (IsGuidAndStringType(parentPropertyType!, childPropertyType!))
            {
                return true;
            }
            else if (IsMatchingDictionary(parentPropertyType!, childPropertyType!))
            {
                return true;
            }
            else if (parentPropertyType.IsGenericType)
            {
                var parentCSharpType = new CSharpType(parentPropertyType);
                if (!childPropertyType.Equals(parentCSharpType))
                    return false;
            }
            else if (IsAssignable(parentPropertyType!, childPropertyType))
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

        private static bool IsMatchingDictionary(System.Type parentPropertyType, CSharpType childPropertyType)
        {
            bool isParentDict = parentPropertyType.IsGenericType && parentPropertyType.GetGenericTypeDefinition() == typeof(IDictionary<,>);
            bool isChildDict = childPropertyType.IsFrameworkType && childPropertyType.FrameworkType.IsGenericType && childPropertyType.FrameworkType.GetGenericTypeDefinition() == typeof(IDictionary<,>);
            if (!isParentDict || !isChildDict)
            {
                return false;
            }

            Type parentKeyType = parentPropertyType.GetGenericArguments()[0];
            Type parentValueType = parentPropertyType.GetGenericArguments()[1];

            CSharpType childKeyType = childPropertyType.Arguments[0];
            CSharpType childValueType = childPropertyType.Arguments[1];

            var isKeyMatches = false;
            if (parentKeyType.IsClass && !childKeyType.IsFrameworkType && childKeyType.Implementation as MgmtObjectType != null)
            {
                var mgmtObjectType = childKeyType.Implementation as MgmtObjectType;

                if (mgmtObjectType != null)
                {
                    isKeyMatches = IsEqual(parentKeyType.GetProperties().ToList(), mgmtObjectType.MyProperties.ToList());
                }
            }
            else
            {
                isKeyMatches = ArePropertyTypesMatch(parentKeyType, childKeyType);
            }

            var isValueMatches = false;
            if (parentValueType.IsClass && !childValueType.IsFrameworkType && childValueType.Implementation as MgmtObjectType != null)
            {
                var mgmtObjectType = childValueType.Implementation as MgmtObjectType;

                if (mgmtObjectType != null)
                {
                    isValueMatches = IsEqual(parentValueType.GetProperties().ToList(), mgmtObjectType.MyProperties.ToList());
                }
            }
            else
            {
                isValueMatches = ArePropertyTypesMatch(parentValueType, childValueType);
            }

            return isKeyMatches && isValueMatches;
        }
    }
}
