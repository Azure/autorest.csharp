// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record HttpMessageExpression(ValueExpression Untyped) : TypedValueExpression(typeof(HttpMessage), Untyped)
    {
        public RequestExpression Request => new(new MemberExpression(Untyped, nameof(HttpMessage.Request)));
        public ResponseExpression Response => new(new MemberExpression(Untyped, nameof(HttpMessage.Response)));
        public ValueExpression BufferResponse => new MemberExpression(Untyped, nameof(HttpMessage.BufferResponse));

        public FrameworkTypeExpression ExtractResponseContent()
            => new(typeof(Stream), new InvokeInstanceMethodExpression(Untyped, nameof(HttpMessage.ExtractResponseContent)));
    }
}
