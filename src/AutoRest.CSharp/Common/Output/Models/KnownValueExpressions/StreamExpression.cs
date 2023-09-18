// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record StreamExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Stream), Untyped)
    {
        public MethodBodyStatement CopyTo(StreamExpression destination) => new InvokeInstanceMethodStatement(Untyped, nameof(Stream.CopyTo), destination);
    }
}
