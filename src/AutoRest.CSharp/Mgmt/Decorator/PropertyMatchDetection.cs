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
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class PropertyMatchDetection
    {
        internal static bool IsEqual(Type sourceType, MgmtObjectType targetType, List<PropertyInfo> parentProperties, List<ObjectTypeProperty> childProperties, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            AddInternalIncludes(sourceType, parentProperties);

            bool allowExtra = GetAllowSetting(sourceType);

            if (parentProperties.Count != childProperties.Count && !allowExtra)
                return false;

            int matchCount = 0;
            Dictionary<string, PropertyInfo> parentDict = new Dictionary<string, PropertyInfo>();
            foreach (var parentProperty in parentProperties)
            {
                parentDict.Add(parentProperty.Name, parentProperty);
            }

            foreach (var childProperty in childProperties)
            {
                if (!DoesPropertyExistInParent(sourceType, targetType, childProperty, parentDict, propertiesInComparison))
                {
                    if (allowExtra)
                        continue;

                    return false;
                }

                matchCount++;
            }

            return matchCount == parentProperties.Count;
        }

        private static bool GetAllowSetting(Type sourceType)
        {
            var attribute = sourceType.GetCustomAttributes(false).FirstOrDefault(a => a.GetType().Name.Equals(TypeReferenceTypeChooser.TypeReferenceTypeAttributeType));
            var allowExtraValue = attribute?.GetType().GetProperty("IgnoreExtraProperties", BindingFlags.Instance | BindingFlags.Public)?.GetValue(attribute);
            return allowExtraValue is null ? false : (bool)allowExtraValue;
        }

        private static void AddInternalIncludes(Type sourceType, List<PropertyInfo> parentProperties)
        {
            var typeReferenceAttribute = sourceType.GetCustomAttributes(false).FirstOrDefault(a => a.GetType().Name.Equals(TypeReferenceTypeChooser.TypeReferenceTypeAttributeType));
            if (typeReferenceAttribute is not null)
            {
                var internalToInclude = typeReferenceAttribute.GetType().GetProperty("InternalPropertiesToInclude", BindingFlags.Instance | BindingFlags.Public)?.GetValue(typeReferenceAttribute);
                if (internalToInclude is not null)
                {
                    foreach (var propertyName in (string[])internalToInclude)
                    {
                        var property = sourceType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
                        if (property is null)
                            throw new InvalidOperationException($"{sourceType.Name} listed {propertyName} as an internal property to include in the match but that property was not found.");
                        parentProperties.Add(property);
                    }
                }
            }
        }

        /// <summary>
        /// Check if a <c>System.Type</c> has the same properties as our own <c>MgmtObjectType</c>.
        /// </summary>
        /// <param name="sourceType"><c>System.Type</c> from reflection.</param>
        /// <param name="targetType">A <c>MgmtObjectType</c> from M4 output.</param>
        /// <returns></returns>
        internal static bool IsEqual(Type sourceType, MgmtObjectType targetType)
        {
            var sourceTypeProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
            var targetTypeProperties = targetType.MyProperties.ToList();

            return IsEqual(sourceType, targetType, sourceTypeProperties, targetTypeProperties, new Dictionary<Type, CSharpType> { { sourceType, targetType.Type } });
        }

        internal static bool DoesPropertyExistInParent(Type sourceType, MgmtObjectType targetType, ObjectTypeProperty childProperty, Dictionary<string, PropertyInfo> parentDict, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            PropertyInfo? parentProperty;
            CSharpType childPropertyType = childProperty.Declaration.Type;

            if (!parentDict.TryGetValue(childProperty.Declaration.Name, out parentProperty))
            {
                if (childProperty.Declaration.Name.EndsWith("Type"))
                {
                    parentProperty = parentDict.FirstOrDefault(p => p.Key.EndsWith("Type")).Value;
                }
                if (parentProperty == null)
                    return false;
            }

            if (parentProperty.PropertyType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}" ||
                IsAssignable(parentProperty.PropertyType, childPropertyType))
            {
                if (childProperty.IsReadOnly != (parentProperty.GetSetMethod() == null))
                    return false;
            }
            else if (!ArePropertyTypesMatch(sourceType, targetType, parentProperty.PropertyType!, childPropertyType, propertiesInComparison))
            {
                return false;
            }

            return true;
        }

        private static bool ArePropertyTypesMatch(Type sourceType, MgmtObjectType targetType, Type parentPropertyType, CSharpType childPropertyType, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            if (DoesPropertyReferenceItself(sourceType, targetType, parentPropertyType, childPropertyType))
            {
                //both reference themselves and in the case of a TypeReplacement this is equivalent
                return true;
            }
            else if (IsGuidAndStringType(parentPropertyType!, childPropertyType!))
            {
                return true;
            }
            else if (parentPropertyType.IsGenericType)
            {
                return IsMatchingGenericType(sourceType, targetType, parentPropertyType!, childPropertyType!, propertiesInComparison);
            }
            else if (IsAssignable(parentPropertyType!, childPropertyType))
            {
                return true;
            }
            else if (parentPropertyType.FullName == $"{childPropertyType.Namespace}.{childPropertyType.Name}")
            {
                // This condition branch implies parentPropertyType is not a class because if it is a class, IsEqual() will always be called first and if the comparison for this branch is true, in DoesPropertyExistInParent, the branch for ArePropertyTypesMatch will never be called.
                // It can be used to match strings.
                return true;
            }
            // Need to compare subproperties recursively when the property Types have different names but should avoid infinite loop in cases like ErrorResponse has a property of List<ErrorResponse>, so we'll check whether we've compared properties in propertiesInComparison.
            else if (MatchProperty(sourceType, targetType, parentPropertyType, childPropertyType, propertiesInComparison, fromArePropertyTypesMatch: true))
            {
                return true;
            }
            else if (!(parentPropertyType.IsGenericParameter && IsAssignable(parentPropertyType.BaseType!, childPropertyType)))
            {
                return false;
            }

            return true;
        }

        private static bool DoesPropertyReferenceItself(Type sourceType, MgmtObjectType targetType, Type parentPropertyType, CSharpType childPropertyType)
        {
            return parentPropertyType.Equals(sourceType) &&
                childPropertyType.Equals(targetType.Type) &&
                sourceType.GetCustomAttributes(false).Any(a => a.GetType().Name.Equals(TypeReferenceTypeChooser.TypeReferenceTypeAttributeType));
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
            if (parentPropertyType.Name == "ResourceIdentifier" && childPropertyType.IsFrameworkType && childPropertyType.FrameworkType == typeof(string))
                return true;

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

        private static bool IsMatchingGenericType(Type sourceType, MgmtObjectType targetType, Type parentPropertyType, CSharpType childPropertyType, Dictionary<Type, CSharpType>? propertiesInComparison = null)
        {
            var parentGenericTypeDef = parentPropertyType.GetGenericTypeDefinition();
            if (parentGenericTypeDef == typeof(Nullable<>))
            {
                if (!childPropertyType.IsNullable)
                    return false;
                else
                {
                    Type parentArgType = parentPropertyType.GetGenericArguments()[0];
                    var isArgMatches = MatchProperty(sourceType, targetType, parentArgType, childPropertyType, propertiesInComparison);
                    return isArgMatches;
                }
            }
            else if (!(childPropertyType.IsFrameworkType && childPropertyType.FrameworkType.IsGenericType && childPropertyType.FrameworkType.GetGenericTypeDefinition() == parentGenericTypeDef))
            {
                return false;
            }
            for (int i = 0; i < parentPropertyType.GetGenericArguments().Length; i++)
            {
                Type parentArgType = parentPropertyType.GetGenericArguments()[i];
                CSharpType childArgType = childPropertyType.Arguments[i];
                var isArgMatches = MatchProperty(sourceType, targetType, parentArgType, childArgType, propertiesInComparison);
                if (!isArgMatches)
                    return false;
            }
            return true;
        }

        private static bool MatchProperty(Type sourceType, MgmtObjectType targetType, Type parentPropertyType, CSharpType childPropertyType, Dictionary<Type, CSharpType>? propertiesInComparison = null, bool fromArePropertyTypesMatch = false)
        {
            if (propertiesInComparison != null && propertiesInComparison.TryGetValue(parentPropertyType, out var val) && val == childPropertyType)
                return true;

            if (DoesPropertyReferenceItself(sourceType, targetType, parentPropertyType, childPropertyType))
                return true;

            var isArgMatches = false;
            if (parentPropertyType.IsClass && !childPropertyType.IsFrameworkType && childPropertyType.Implementation as MgmtObjectType != null)
            {
                var mgmtObjectType = childPropertyType.Implementation as MgmtObjectType;
                if (mgmtObjectType != null)
                    isArgMatches = IsEqual(parentPropertyType, mgmtObjectType, parentPropertyType.GetProperties().ToList(), mgmtObjectType.MyProperties.ToList(), new Dictionary<Type, CSharpType> { { parentPropertyType, childPropertyType } });
            }
            else if (!childPropertyType.IsFrameworkType && childPropertyType.Implementation as EnumType != null)
            {
                var childEnumType = childPropertyType.Implementation as EnumType;
                if (childEnumType != null)
                    isArgMatches = MatchEnum(parentPropertyType, childEnumType);
            }
            else if (!fromArePropertyTypesMatch)
            {
                isArgMatches = ArePropertyTypesMatch(sourceType, targetType, parentPropertyType, childPropertyType);
            }
            return isArgMatches;
        }

        private static bool MatchEnum(Type parentPropertyType, EnumType childPropertyType)
        {
            var parentProperties = parentPropertyType.GetProperties().ToList();
            if (parentProperties.Count != childPropertyType.Values.Count)
                return false;
            Dictionary<string, PropertyInfo> parentDict = parentProperties.ToDictionary(p => p.Name, p => p);
            foreach (var enumValue in childPropertyType.Values)
            {
                if (!parentDict.TryGetValue(enumValue.Declaration.Name, out var parentProperty))
                    return false;
                if (parentProperty.Name != enumValue.Declaration.Name)
                    return false;
            }

            return true;
        }
    }
}
