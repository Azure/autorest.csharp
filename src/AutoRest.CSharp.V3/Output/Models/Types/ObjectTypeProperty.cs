// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(MemberDeclarationOptions declaration, string description, bool isReadOnly, Property? schemaProperty, bool isRequired, CSharpType? valueType = null)
        {
            Description = description;
            IsReadOnly = isReadOnly;
            SchemaProperty = schemaProperty;
            ValueType = valueType ?? declaration.Type;
            Declaration = declaration;
            IsRequired = isRequired;
        }

        public bool IsRequired { get; }

        public MemberDeclarationOptions Declaration { get; }
        public string Description { get; }
        public Property? SchemaProperty { get; }

        /// <summary>
        /// When property is not required we transform the type to be able to express "omitted" value.
        /// For example we turn int type into int?.
        /// ValueType property contains the original type the property had before the transformation was applied to it.
        /// </summary>
        public CSharpType ValueType { get; }
        public bool IsReadOnly { get; }
    }
}
