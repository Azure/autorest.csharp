// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Output.Models
{
    internal record FieldDeclaration(FormattableString? Description, FieldModifiers Modifiers, CSharpType Type, CodeWriterDeclaration Declaration, FormattableString? DefaultValue, bool IsRequired = true, bool WriteAsProperty = false)
    {
        public string Name => Declaration.ActualName;

        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, bool writeAsProperty = false) : this(null, modifiers, type, name, writeAsProperty) { }
        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, bool writeAsProperty = false) : this(null, modifiers, type, name, defaultValue, writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, bool isRequired = true, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), null, isRequired, writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, bool isRequired = true, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), defaultValue, isRequired, writeAsProperty) { }
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
