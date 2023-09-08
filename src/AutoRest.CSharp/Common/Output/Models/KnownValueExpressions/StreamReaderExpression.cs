// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record StreamReaderExpression(ValueExpression Untyped) : TypedValueExpression(typeof(StreamReader), Untyped)
    {
        public ValueExpression ReadToEnd(bool async)
        {
            var methodName = async ? nameof(StreamReader.ReadToEndAsync) : nameof(StreamReader.ReadToEnd);
            return Untyped.Invoke(methodName, Array.Empty<ValueExpression>(), async);
        }
    }
}
