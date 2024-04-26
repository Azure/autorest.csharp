// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal abstract class MultipartSerialization : ObjectSerialization
    {
        protected MultipartSerialization(bool isNullable, CSharpType type)
        {
            IsNullable = isNullable;
            Type = type;
        }
        public bool IsNullable { get; }
        public CSharpType Type { get; }
    }
}
