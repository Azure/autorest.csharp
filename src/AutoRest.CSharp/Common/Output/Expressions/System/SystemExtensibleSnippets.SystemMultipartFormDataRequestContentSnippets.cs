// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types.HelperTypeProviders;

namespace AutoRest.CSharp.Common.Output.Expressions.System
{
    internal partial class SystemExtensibleSnippets
    {
        internal class SystemMultipartFormDataRequestContentSnippets : MultipartFormDataRequestContentSnippets
        {
            public override MethodBodyStatement Add(ValueExpression multipartContent, ValueExpression content, ValueExpression name, ValueExpression? fileName, ValueExpression? contentType)
            {
                return MultipartFormDataBinaryContentProvider.Instance.Add(multipartContent, content, name, fileName, contentType);
            }
            public override MethodBodyStatement WriteTo(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken)
            {
                return MultipartFormDataBinaryContentProvider.Instance.WriteTo(multipartContent, stream, cancellationToken);
            }
            public override MethodBodyStatement WriteToAsync(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken)
            {
                return MultipartFormDataBinaryContentProvider.Instance.WriteToAsync(multipartContent, stream, cancellationToken);
            }
        }
    }
}
