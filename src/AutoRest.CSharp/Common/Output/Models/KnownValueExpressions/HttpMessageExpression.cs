// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record HttpMessageExpression(ValueExpression Untyped) : TypedValueExpression<HttpMessage>(Untyped)
    {
        public RequestExpression Request => new(Property(nameof(HttpMessage.Request)));
        public ResponseExpression Response => new(Property(nameof(HttpMessage.Response)));
        public ValueExpression BufferResponse => Property(nameof(HttpMessage.BufferResponse));

        public StreamExpression ExtractResponseContent() => new(Invoke(nameof(HttpMessage.ExtractResponseContent)));
    }
}
