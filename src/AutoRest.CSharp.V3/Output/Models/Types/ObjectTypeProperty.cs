// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Shared;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(MemberDeclarationOptions declaration, string description, bool isReadOnly, CSharpType? implementationType, Property? schemaProperty, Constant? defaultValue = null)
        {
            Description = description;
            IsReadOnly = isReadOnly;
            ImplementationType = implementationType;
            SchemaProperty = schemaProperty;
            Declaration = declaration;
            DefaultValue = defaultValue;
        }

        public MemberDeclarationOptions Declaration { get; }
        public string Description { get; }
        public Constant? DefaultValue { get; }
        public CSharpType? ImplementationType { get; }
        public Property? SchemaProperty { get; }
        public bool IsReadOnly { get; }
    }
}
