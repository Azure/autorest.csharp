// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal abstract class MulitipartSerialization: ObjectSerialization
    {
        protected MulitipartSerialization(string format)
        {
            Format = format;
        }
        public string Format { get; }
    }
}
