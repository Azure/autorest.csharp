// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types.HelperTypeProviders;
using static AutoRest.CSharp.Common.Output.Expressions.ExtensibleSnippets;

namespace AutoRest.CSharp.Common.Output.Expressions.Azure
{
    internal partial class AzureMultipartFormDataRequestContentSnippets: MultipartFormDataRequestContentSnippets
    {
        public override MethodBodyStatement Add(ValueExpression multipartContent, ValueExpression content, ValueExpression name, ValueExpression? fileName, ValueExpression? contentType)
        {
            return MultipartFormDataRequestContentProvider.Instance.Add(multipartContent, content, name, fileName, contentType);
        }
        public override MethodBodyStatement WriteTo(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken)
        {
            return MultipartFormDataRequestContentProvider.Instance.WriteTo(multipartContent, stream, cancellationToken);
        }
        public override MethodBodyStatement WriteToAsync(VariableReference multipartContent, ValueExpression stream, ValueExpression? cancellationToken)
        {
            return MultipartFormDataRequestContentProvider.Instance.WriteToAsync(multipartContent, stream, cancellationToken);
        }
    }
}
