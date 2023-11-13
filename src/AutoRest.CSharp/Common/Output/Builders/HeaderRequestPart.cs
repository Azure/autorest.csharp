// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal record HeaderRequestPart(string? NameInRequest, TypedValueExpression Value, MethodBodyStatement? Conversion, SerializationFormat SerializationFormat, string? ArraySerializationDelimiter);
}
