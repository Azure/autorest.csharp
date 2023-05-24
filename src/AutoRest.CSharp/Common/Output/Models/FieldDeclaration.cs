﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models
{
    internal record FieldDeclaration(FormattableString? Description, FieldModifiers Modifiers, CSharpType Type, CSharpType ValueType, CodeWriterDeclaration Declaration, FormattableString? DefaultValue, bool IsRequired, SerializationFormat SerializationFormat, bool IsField = false, bool WriteAsProperty = false, FieldModifiers? GetterModifiers = null, FieldModifiers? SetterModifiers = null, SourcePropertySerializationMapping? SerializationMapping = null)
    {
        public string Name => Declaration.ActualName;
        public string Accessibility => (Modifiers & FieldModifiers.Public) > 0 ? "public" : "internal";

        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, bool writeAsProperty = false)
            : this(description: null,
                  modifiers: modifiers,
                  type: type,
                  name: name,
                  serializationFormat: SerializationFormat.Default,
                  writeAsProperty: writeAsProperty)
        { }

        public FieldDeclaration(FieldModifiers modifiers, CSharpType type, string name, FormattableString? defaultValue, SerializationFormat serializationFormat, bool writeAsProperty = false)
            : this(Description: null,
                  Modifiers: modifiers,
                  Type: type,
                  ValueType: type,
                  Declaration: new CodeWriterDeclaration(name),
                  DefaultValue: defaultValue,
                  IsRequired: false,
                  SerializationFormat: serializationFormat,
                  IsField: false,
                  WriteAsProperty: writeAsProperty,
                  GetterModifiers: null,
                  SetterModifiers: null)
        { }

        public FieldDeclaration(FormattableString? description, FieldModifiers modifiers, CSharpType type, string name, SerializationFormat serializationFormat, bool writeAsProperty = false)
            : this(Description: description,
                  Modifiers: modifiers,
                  Type: type,
                  ValueType: type,
                  Declaration: new CodeWriterDeclaration(name),
                  DefaultValue: null,
                  IsRequired: false,
                  SerializationFormat: serializationFormat,
                  IsField: false,
                  WriteAsProperty: writeAsProperty)
        { }
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
