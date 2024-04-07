// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record AsExpression(ValueExpression Inner, CSharpType Type) : ValueExpression
    {
        public sealed override void Write(CodeWriter writer)
        {
            Inner.Write(writer);
            writer.Append($" as {Type}");
        }
    }
}
