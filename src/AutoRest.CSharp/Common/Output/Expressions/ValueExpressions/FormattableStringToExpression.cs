// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record FormattableStringToExpression(FormattableString Value) : ValueExpression // Shim between formattable strings and expressions
    {
        public override void Write(CodeWriter writer)
        {
            writer.Append(Value);
        }
    }
}
