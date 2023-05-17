// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models
{
    internal record FieldDeclaration(FormattableString? Description, FieldModifiers Modifiers, CSharpType Type, CodeWriterDeclaration Declaration, FormattableString? DefaultValue, bool IsRequired, SerializationFormat SerializationFormat, bool IsField = false, bool WriteAsProperty = false, FieldModifiers? GetterModifiers = null, FieldModifiers? SetterModifiers = null)
    {
        public string Name => Declaration.ActualName;
        public string Accessibility => (Modifiers & FieldModifiers.Public) > 0 ? "public" : "internal";

        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, bool writeAsProperty = false) : this(null, modifiers, type, name, SerializationFormat.Default, writeAsProperty: writeAsProperty) { }
        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, SerializationFormat serializationFormat, bool writeAsProperty = false) : this(null, modifiers, type, name, defaultValue, false, serializationFormat, writeAsProperty: writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, SerializationFormat serializationFormat, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), null, false, serializationFormat, false, writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, bool isRequired, SerializationFormat serializationFormat, bool isField = false, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), defaultValue, isRequired, serializationFormat, isField, writeAsProperty) { }
    }

    [Flags]
    internal enum FieldModifiers
    {
        Public = 1 << 0,
        Internal = 1 << 1,
        Protected = 1 << 2,
        Private = 1 << 3,
        Static = 1 << 4,
        ReadOnly = 1 << 5,
        Const = 1 << 6
    }
}
