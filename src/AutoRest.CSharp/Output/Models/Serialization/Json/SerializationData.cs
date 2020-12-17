// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class SerializationData
    {
        public SerializationData(CodeWriterDelegate write, CSharpType type)
        {
            Write = write;
            Type = type;
        }

        public CodeWriterDelegate Write { get; }
        public CSharpType Type { get; }
    }
}
