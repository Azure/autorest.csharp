// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Output.Models
{
    internal record FieldDeclaration(FormattableString? Description, FieldModifiers Modifiers, CSharpType Type, CodeWriterDeclaration Declaration, FormattableString? DefaultValue, bool IsRequired, bool IsField = false, bool WriteAsProperty = false)
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
        Public = 1,
        Internal = 2,
        Private = 4,
        Static = 8,
        ReadOnly = 16,
        Const = 32
    }
}
