// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartFormDataSerialization: MultipartSerialization
    {
        public MultipartFormDataSerialization(bool isNullable) : base(isNullable)
        {
        }
        public string subType { get; } = "form-data";
    }
}
