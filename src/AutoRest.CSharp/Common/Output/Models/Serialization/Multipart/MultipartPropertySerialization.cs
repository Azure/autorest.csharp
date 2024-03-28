// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartPropertySerialization: PropertySerialization
    {
        /*
        public MultipartPropertySerialization(
            string parameterName,
            TypedValueExpression value,
            string serializedName,
            CSharpType? serializedType,
            ObjectSerialization valueSerialization,
            bool isRequired,
            ValueExpression serializedValue,
            bool shouldExcludeInWireSerialization,
            ValueExpression? deserializedValue,
            TypedValueExpression? enumerableExpression = null)
            : base(parameterName, value, serializedName, serializedType, isRequired, shouldExcludeInWireSerialization, enumerableExpression)
        {
            ValueSerialization = valueSerialization;
            SerializedValue = serializedValue;
            DeserializedValue = deserializedValue;
        }

        public ValueExpression SerializedValue { get;}
        public ValueExpression? DeserializedValue { get;}
        public string ContentType { get; set; } = "application/octet-stream";
        public ObjectSerialization ValueSerialization { get;}
        */
        public MultipartPropertySerialization(
            string parameterName,
            TypedValueExpression value,
            string serializedName,
            CSharpType? serializedType,
            MultipartSerialization valueSerialization,
            bool isRequired,
            bool shouldExcludeInWireSerialization,
            TypedValueExpression? enumerableExpression = null)
            : base(parameterName, value, serializedName, serializedType, isRequired, shouldExcludeInWireSerialization, enumerableExpression)
        {
            ValueSerialization = valueSerialization;
        }

        public string? ContentType { get; set; } = "application/octet-stream";
        public string? FileName { get; set; }
        public MultipartSerialization ValueSerialization { get; }
    }
}
