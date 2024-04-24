// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal abstract partial class ExtensibleSnippets
    {
        internal abstract class MultipartFormDataRequestContentSnippets
        {
            public abstract MethodBodyStatement Add(ValueExpression multipartContent, ValueExpression content, ValueExpression name, ValueExpression? fileName, ValueExpression? contentType);
            public abstract MethodBodyStatement WriteTo(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken);
            public abstract MethodBodyStatement WriteToAsync(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken);
        }
    }
}
