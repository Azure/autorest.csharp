// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartValueSerialization : MultipartSerialization
    {
        public MultipartValueSerialization(CSharpType type, SerializationFormat format, bool isNullable) : base(isNullable, type)
        {
            Format = format;
        }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
        public SerializationFormat Format { get; }
    }
}
