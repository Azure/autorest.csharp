// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class InheritanceChooser
    {
        public static CSharpType? GetExactMatch(OperationGroup? operationGroup, MgmtObjectType childType, ObjectTypeProperty[] properties)
        {
            foreach (System.Type parentType in ReferenceClassFinder.ReferenceClassCollection)
            {
                if (IsEqual(parentType, properties))
                {
                    return GetCSharpType(operationGroup, childType, parentType);
                }
            }
            return null;
        }

        public static CSharpType? GetSupersetMatch(OperationGroup? operationGroup, MgmtObjectType originalType, ObjectTypeProperty[] properties)
        {
            foreach (System.Type parentType in ReferenceClassFinder.ReferenceClassCollection)
            {
                if (IsSuperset(parentType, properties))
                {
                    return GetCSharpType(operationGroup, originalType, parentType);
                }
            }
            return null;
        }

        private static CSharpType GetCSharpType(OperationGroup? operationGroup, MgmtObjectType originalType, Type parentType)
        {
            var newParentType = operationGroup == null || !parentType.IsGenericType
                ? parentType
                : parentType.GetGenericTypeDefinition().MakeGenericType(operationGroup.GetResourceIdentifierType(originalType.Context));
            return CSharpType.FromSystemType(originalType.Context, newParentType);
        }

        private static bool IsEqual(System.Type parentType, ObjectTypeProperty[] properties)
        {
            var childProperties = properties.ToList();
            List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

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

        private static bool DoesPropertyExistInParent(ObjectTypeProperty childProperty, Dictionary<string, PropertyInfo> parentDict)
        {
            PropertyInfo? parentProperty;
            CSharpType childPropertyType = childProperty.Declaration.Type;

            if (!parentDict.TryGetValue(childProperty.Declaration.Name, out parentProperty))
                return false;

            if (parentProperty.PropertyType.IsGenericType)
            {
                if (!childPropertyType.Equals(new CSharpType(parentProperty.PropertyType)))
                    return false;
            }
            else if (parentProperty.PropertyType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}" ||
                IsAssignable(parentProperty.PropertyType, childPropertyType))
            {
                if (childProperty.IsReadOnly != (parentProperty.GetSetMethod() == null))
                    return false;
            }
            else if (!(parentProperty.PropertyType.IsGenericParameter && IsAssignable(parentProperty.PropertyType.BaseType!, childPropertyType)))
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

        private static bool IsSuperset(System.Type parentType, ObjectTypeProperty[] properties)
        {
            var childProperties = properties.ToList();
            List<PropertyInfo> parentProperties = parentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

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

                if (DoesPropertyExistInParent(childProperty, parentDict))
                    matchCount++;
            }

            return parentProperties.Count == matchCount;
        }
    }
}
