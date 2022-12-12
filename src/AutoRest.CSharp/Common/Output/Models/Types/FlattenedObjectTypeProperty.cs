// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class FlattenedObjectTypeProperty : ObjectTypeProperty
    {
        public static FlattenedObjectTypeProperty CreateFrom(ObjectTypeProperty property)
        {
            var hierarchyStack = GetHeirarchyStack(property);
            // we can only get in this method when the property has a single property type, therefore the hierarchy stack here is guaranteed to have at least two values
            var innerProperty = hierarchyStack.Pop();
            var immediateParentProperty = hierarchyStack.Pop();

            var myPropertyName = GetCombinedPropertyName(innerProperty, immediateParentProperty);
            var childPropertyName = property.Equals(immediateParentProperty) ? innerProperty.Declaration.Name : myPropertyName;

            var propertyType = innerProperty.Declaration.Type;

            var isOverriddenValueType = innerProperty.Declaration.Type.IsValueType && !innerProperty.Declaration.Type.IsNullable;
            if (isOverriddenValueType)
                propertyType = propertyType.WithNullable(isOverriddenValueType);

            var declaration = new MemberDeclarationOptions(innerProperty.Declaration.Accessibility, myPropertyName, propertyType);

            // determines whether this property should has a setter
            var (isReadOnly, includeGetterNullCheck, includeSetterNullCheck) = GetFlags(property, innerProperty);

            return new FlattenedObjectTypeProperty(declaration, innerProperty.ParameterDescription, property, hierarchyStack, isReadOnly, includeGetterNullCheck, includeSetterNullCheck, childPropertyName, isOverriddenValueType);
        }

        // The flattened object type property does not participate in the serialization or deserialization process, therefore we pass in null for SchemaProperty.
        private FlattenedObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, ObjectTypeProperty underlyingProperty, Stack<ObjectTypeProperty> hierarchyStack, bool isReadOnly, bool? includeGetterNullCheck, bool includeSetterNullCheck, string childPropertyName, bool isOverriddenValueType, CSharpType? valueType = null, bool optionalViaNullability = false) : base(declaration, parameterDescription, isReadOnly, null, valueType, optionalViaNullability)
        {
            UnderlyingProperty = underlyingProperty;
            HierarchyStack = hierarchyStack;
            IncludeGetterNullCheck = includeGetterNullCheck;
            IncludeSetterNullCheck = includeSetterNullCheck;
            IsUnderlyingPropertyNullable = underlyingProperty.IsReadOnly;
            ChildPropertyName = childPropertyName;
            IsOverriddenValueType = isOverriddenValueType;
        }

        public Stack<ObjectTypeProperty> HierarchyStack { get; }

        public ObjectTypeProperty UnderlyingProperty { get; }

        public bool? IncludeGetterNullCheck { get; }

        public bool IncludeSetterNullCheck { get; }

        public bool IsUnderlyingPropertyNullable { get; }

        public bool IsOverriddenValueType { get; }

        public string ChildPropertyName { get; }

        private static (bool IsReadOnly, bool? IncludeGetterNullCheck, bool IncludeSetterNullCheck) GetFlags(ObjectTypeProperty property, ObjectTypeProperty innerProperty)
        {
            if (!property.IsReadOnly && innerProperty.IsReadOnly)
            {
                if (HasDefaultPublicCtor(property.Declaration.Type))
                {
                    if (innerProperty.Declaration.Type.Arguments.Length > 0)
                        return (true, true, false);
                    else
                        return (true, false, false);
                }
                else
                {
                    return (false, false, false);
                }
            }
            else if (!property.IsReadOnly && !innerProperty.IsReadOnly)
            {
                if (HasDefaultPublicCtor(property.Declaration.Type))
                    return (false, false, true);
                else
                    return (false, false, false);
            }

            return (true, null, false);
        }

        private static bool HasDefaultPublicCtor(CSharpType type)
        {
            if (!type.TryCast<ObjectType>(out var objType))
                return true;

            foreach (var ctor in objType.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) && !ctor.Signature.Parameters.Any())
                    return true;
            }

            return false;
        }

        private static Stack<ObjectTypeProperty> GetHeirarchyStack(ObjectTypeProperty property)
        {
            var heirarchyStack = new Stack<ObjectTypeProperty>();
            heirarchyStack.Push(property);
            BuildHeirarchy(property, heirarchyStack);
            return heirarchyStack;
        }

        private static void BuildHeirarchy(ObjectTypeProperty property, Stack<ObjectTypeProperty> heirarchyStack)
        {
            //if we get back the same property exit early since this means we have a single property type which references itself
            if (MgmtObjectType.IsSinglePropertyObject(property, out var childProp) && !property.Equals(childProp))
            {
                heirarchyStack.Push(childProp);
                BuildHeirarchy(childProp, heirarchyStack);
            }
        }

        internal static string GetCombinedPropertyName(ObjectTypeProperty innerProperty, ObjectTypeProperty immediateParentProperty)
        {
            var immediateParentPropertyName = GetPropertyName(immediateParentProperty.Declaration);

            if (innerProperty.Declaration.Type.Equals(typeof(bool)) || innerProperty.Declaration.Type.Equals(typeof(bool?)))
            {
                return innerProperty.Declaration.Name.Equals("Enabled", StringComparison.Ordinal) ? $"{immediateParentPropertyName}{innerProperty.Declaration.Name}" : innerProperty.Declaration.Name;
            }

            if (innerProperty.Declaration.Name.Equals("Id", StringComparison.Ordinal))
                return $"{immediateParentPropertyName}{innerProperty.Declaration.Name}";

            if (immediateParentPropertyName.EndsWith(innerProperty.Declaration.Name, StringComparison.Ordinal))
                return immediateParentPropertyName;

            var parentWords = immediateParentPropertyName.SplitByCamelCase();
            if (immediateParentPropertyName.EndsWith("Profile", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Policy", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Configuration", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Properties", StringComparison.Ordinal) ||
                immediateParentPropertyName.EndsWith("Settings", StringComparison.Ordinal))
            {
                parentWords = parentWords.Take(parentWords.Count() - 1);
            }

            var parentWordArray = parentWords.ToArray();
            var parentWordsHash = new HashSet<string>(parentWordArray);
            var nameWords = innerProperty.Declaration.Name.SplitByCamelCase().ToArray();
            var lastWord = string.Empty;
            for (int i = 0; i < nameWords.Length; i++)
            {
                var word = nameWords[i];
                lastWord = word;
                if (parentWordsHash.Contains(word))
                {
                    if (i == nameWords.Length - 2 && parentWordArray.Length >= 2 && word.Equals(parentWordArray[parentWordArray.Length - 2], StringComparison.Ordinal))
                    {
                        parentWords = parentWords.Take(parentWords.Count() - 2);
                        break;
                    }
                    {
                        return innerProperty.Declaration.Name;
                    }
                }

                //need to depluralize the last word and check
                if (i == nameWords.Length - 1 && parentWordsHash.Contains(lastWord.ToSingular(false)))
                    return innerProperty.Declaration.Name;
            }

            immediateParentPropertyName = string.Join("", parentWords);

            return $"{immediateParentPropertyName}{innerProperty.Declaration.Name}";
        }

        internal static string GetPropertyName(MemberDeclarationOptions property)
        {
            const string properties = "Properties";
            if (property.Name.Equals(properties, StringComparison.Ordinal))
            {
                string typeName = property.Type.Name;
                int index = typeName.IndexOf(properties);
                if (index > -1 && index + properties.Length == typeName.Length)
                    return typeName.Substring(0, index);

                return typeName;
            }
            return property.Name;
        }
    }
}
