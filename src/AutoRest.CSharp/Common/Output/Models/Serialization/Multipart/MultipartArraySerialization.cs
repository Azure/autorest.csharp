// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartArraySerialization : MultipartSerialization
    {
        public MultipartArraySerialization(CSharpType implementationType, MultipartSerialization valueSerialization, bool isNullable) : base(isNullable, implementationType)
        {
            ValueSerialization = valueSerialization;
        }
        public MultipartSerialization ValueSerialization { get; }
    }
}
