// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Requests
{
    internal class RequestConditionsHeader : RequestHeader
    {
        public RequestConditionsHeader(string name, ReferenceOrConstant value, RequestParameterSerializationStyle serializationStyle, SerializationFormat format = SerializationFormat.Default): base(name, value, serializationStyle, format)
        {
        }
    }
}
