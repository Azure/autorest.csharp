// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Shared;

using CSharpType = AutoRest.CSharp.V3.Generation.Types.CSharpType;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(string name, string description, CSharpType type, bool isReadOnly, CSharpType? implementationType, Property schemaProperty, Constant? defaultValue = null)
        {
            Name = name;
            Description = description;
            Type = type;
            IsReadOnly = isReadOnly;
            ImplementationType = implementationType;
            SchemaProperty = schemaProperty;
            DefaultValue = defaultValue;
        }

        public string Name { get; }
        public string Description { get; }
        public Constant? DefaultValue { get; }
        public CSharpType Type { get; }
        public CSharpType? ImplementationType { get; }
        public Property SchemaProperty { get; }
        public bool IsReadOnly { get; }
     }
}
