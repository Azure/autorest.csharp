// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Output.Models
{
    internal record FieldDeclaration(FormattableString? Description, string Modifiers, CSharpType Type, CodeWriterDeclaration Declaration, FormattableString? DefaultValue)
    {
        public string Name => Declaration.ActualName;

        public FieldDeclaration(string modifiers, CSharpType type, string name) : this(null, modifiers, type, new CodeWriterDeclaration(name), null) { }
        public FieldDeclaration(string modifiers, CSharpType type, string name, FormattableString? defaultValue) : this(null, modifiers, type, new CodeWriterDeclaration(name), defaultValue) { }
    }
}
