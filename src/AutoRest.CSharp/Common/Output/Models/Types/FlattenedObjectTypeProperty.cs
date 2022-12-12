// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class FlattenedObjectTypeProperty : ObjectTypeProperty
    {
        public static FlattenedObjectTypeProperty CreateFrom(ObjectTypeProperty property)
        {
            var hierarchyStack = property.GetHeirarchyStack();
            // we can only get in this method when the property has a single property type, therefore the hierarchy stack here is guaranteed to have at least two values
            var innerProperty = hierarchyStack.Pop();
            var immediateParentProperty = hierarchyStack.Pop();

            var myPropertyName = innerProperty.GetCombinedPropertyName(immediateParentProperty);
            var childPropertyName = property.Equals(immediateParentProperty) ? innerProperty.Declaration.Name : myPropertyName;

            var propertyType = innerProperty.Declaration.Type;

            var isOverriddenValueType = innerProperty.Declaration.Type.IsValueType && !innerProperty.Declaration.Type.IsNullable;
            if (isOverriddenValueType)
                propertyType = propertyType.WithNullable(isOverriddenValueType);

            var declaration = new MemberDeclarationOptions(innerProperty.Declaration.Accessibility, myPropertyName, propertyType);

            // determines whether this property should has a setter
            var (isReadOnly, includeGetterNullCheck, includeSetterNullCheck) = GetFlags(property, innerProperty);

            return new FlattenedObjectTypeProperty(declaration, innerProperty.ParameterDescription, property, isReadOnly, includeGetterNullCheck, includeSetterNullCheck, childPropertyName);
        }

        // The flattened object type property does not participate in the serialization or deserialization process, therefore we pass in null for SchemaProperty.
        private FlattenedObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, ObjectTypeProperty underlyingProperty, bool isReadOnly, bool? includeGetterNullCheck, bool includeSetterNullCheck, string childPropertyName, CSharpType? valueType = null, bool optionalViaNullability = false) : base(declaration, parameterDescription, isReadOnly, null, valueType, optionalViaNullability)
        {
            UnderlyingProperty = underlyingProperty;
            IncludeGetterNullCheck = includeGetterNullCheck;
            IncludeSetterNullCheck = includeSetterNullCheck;
            IsUnderlyingPropertyNullable = underlyingProperty.IsReadOnly;
            ChildPropertyName = childPropertyName;
        }

        public ObjectTypeProperty UnderlyingProperty { get; }

        public bool? IncludeGetterNullCheck { get; }

        public bool IncludeSetterNullCheck { get; }

        public bool IsUnderlyingPropertyNullable { get; }

        public string ChildPropertyName { get; }

        private static (bool IsReadOnly, bool? IncludeGetterNullCheck, bool IncludeSetterNullCheck) GetFlags(ObjectTypeProperty property, ObjectTypeProperty innerProperty)
        {
            if (!property.IsReadOnly && innerProperty.IsReadOnly)
            {
                if (HasDefaultPublicCtor(property))
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
                if (HasDefaultPublicCtor(property))
                    return (false, false, true);
                else
                    return (false, false, false);
            }

            return (true, null, false);
        }

        internal static bool HasCtorWithSingleParam(ObjectTypeProperty property, ObjectTypeProperty innerProperty)
        {
            var type = property.Declaration.Type;
            if (type.IsFrameworkType)
                return false;

            if (type.Implementation is not ObjectType objType)
                return false;

            foreach (var ctor in objType.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    ctor.Signature.Parameters.Count == 1)
                {
                    var paramType = ctor.Signature.Parameters[0].Type;
                    var propertyType = innerProperty.Declaration.Type;
                    if (paramType.Arguments.Length == 0 && paramType.Equals(propertyType))
                        return true;

                    if (paramType.Arguments.Length == 1 && propertyType.Arguments.Length == 1 && paramType.Arguments[0].Equals(propertyType.Arguments[0]))
                        return true;
                }
            }

            return false;
        }

        private static bool HasDefaultPublicCtor(ObjectTypeProperty objectTypeProperty)
        {
            var type = objectTypeProperty.Declaration.Type;
            if (type.IsFrameworkType)
                return true;

            if (type.Implementation is not ObjectType objType)
                return true;

            foreach (var ctor in objType.Constructors)
            {
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) && !ctor.Signature.Parameters.Any())
                    return true;
            }

            return false;
        }
    }
}
