// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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

            var isOverriddenValueType = innerProperty.Declaration.Type.IsValueType && !innerProperty.Declaration.Type.IsNullable;

            var declaration = new MemberDeclarationOptions(innerProperty.Declaration.Accessibility, myPropertyName, innerProperty.Declaration.Type.WithNullable(isOverriddenValueType));


            return new FlattenedObjectTypeProperty(declaration, innerProperty.ParameterDescription, innerProperty.IsReadOnly, isOverriddenValueType);
        }

        // The flattened object type property does not participate in the serialization or deserialization process, therefore we pass in null for SchemaProperty.
        private FlattenedObjectTypeProperty(MemberDeclarationOptions declaration, string parameterDescription, bool isReadOnly, bool isOverriddenValueType, CSharpType? valueType = null, bool optionalViaNullability = false) : base(declaration, parameterDescription, isReadOnly, null, valueType, optionalViaNullability)
        {
            IsOverriddenValueType = isOverriddenValueType;
        }

        public bool IsOverriddenValueType { get; } // maybe useless???
    }
}
