// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartPropertySerialization: PropertySerialization
    {
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

        public MultipartSerialization ValueSerialization { get; }
    }
}
