// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartDictionarySerialization: MultipartSerialization
    {
        public MultipartDictionarySerialization(CSharpType type, MultipartSerialization valueSerialization, bool isNullable): base(isNullable, type)
        {
            ValueSerialization = valueSerialization;
        }
        public MultipartSerialization ValueSerialization { get; }
    }
}
