// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal readonly struct PropertyInitializer
    {
        public PropertyInitializer(ObjectTypeProperty property, CodeWriterDelegate value, CSharpType? type = null)
        {
            Property = property;
            Value = value;
            Type = type ?? property.Declaration.Type;
        }

        public ObjectTypeProperty Property { get; }
        public CodeWriterDelegate Value { get; }
        public CSharpType? Type { get; }
    }
}