// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using AutoRest.CSharp.Output.Models;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record Utf8JsonRequestContentExpression(ValueExpression Untyped) : ValueExpression<Utf8JsonRequestContent>(Untyped)
    {
        public Utf8JsonWriterExpression JsonWriter { get; }  = new(new MemberReference(Untyped, nameof(Utf8JsonRequestContent.JsonWriter)));
    }
}
