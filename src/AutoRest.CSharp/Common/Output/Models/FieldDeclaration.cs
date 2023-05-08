// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models
{
    internal record FieldDeclaration(FormattableString? Description, FieldModifiers Modifiers, CSharpType Type, CodeWriterDeclaration Declaration, FormattableString? DefaultValue, bool IsRequired, bool IsField = false, bool WriteAsProperty = false, FieldModifiers? GetterModifiers = null, FieldModifiers? SetterModifiers = null, SourcePropertySerailizationMapping? SerializationMapping = null)
    {
        public string Name => Declaration.ActualName;
        public string Accessibility => (Modifiers & FieldModifiers.Public) > 0 ? "public" : "internal";

        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, bool writeAsProperty = false) : this(null, modifiers, type, name, writeAsProperty: writeAsProperty) { }
        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, bool writeAsProperty = false) : this(null, modifiers, type, name, defaultValue, false, writeAsProperty: writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), null, false, false, writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, bool isRequired, bool isField = false, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), defaultValue, isRequired, isField, writeAsProperty) { }
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
