// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartFormDataSerialization: MultipartSerialization
    {
        public MultipartFormDataSerialization(bool isNullable, CSharpType type) : base(isNullable, type)
        {
        }
        public string subType { get; } = "form-data";
    }
}
