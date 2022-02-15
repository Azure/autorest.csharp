// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Output.Models
{
    internal record FieldDeclaration(FormattableString? Description, FieldModifiers Modifiers, CSharpType Type, CodeWriterDeclaration Declaration, FormattableString? DefaultValue, bool WriteAsProperty = false)
    {
        public string Name => Declaration.ActualName;

        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, bool writeAsProperty = false) : this(null, modifiers, type, name, writeAsProperty) { }
        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, bool writeAsProperty = false) : this(null, modifiers, type, name, defaultValue, writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), null, writeAsProperty) { }
        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, bool writeAsProperty = false) : this(description, modifiers, type, new CodeWriterDeclaration(name), defaultValue, writeAsProperty) { }
    }

    [Flags]
    internal enum FieldModifiers
    {
        Public = 1,
        Private = 2,
        Static = 4,
        ReadOnly = 8,
        Const = 16
    }
}
