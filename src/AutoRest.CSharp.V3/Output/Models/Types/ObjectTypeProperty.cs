﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(MemberDeclarationOptions declaration, string description, bool isReadOnly, Property? schemaProperty)
        {
            Description = description;
            IsReadOnly = isReadOnly;
            SchemaProperty = schemaProperty;
            Declaration = declaration;
        }

        public MemberDeclarationOptions Declaration { get; }
        public string Description { get; }
        public Property? SchemaProperty { get; }
        public bool IsReadOnly { get; }
    }
}
