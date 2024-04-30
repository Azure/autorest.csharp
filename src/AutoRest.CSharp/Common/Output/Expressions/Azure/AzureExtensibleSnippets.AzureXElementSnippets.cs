// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions.Azure
{
    internal partial class AzureExtensibleSnippets
    {
        private class AzureXElementSnippets : XElementSnippets
        {
            public override ValueExpression GetBytesFromBase64Value(XElementExpression xElement, string? format)
                => XElementExtensionsProvider.Instance.GetBytesFromBase64Value(xElement, format);
            public override ValueExpression GetDateTimeOffsetValue(XElementExpression xElement, string? format)
                => XElementExtensionsProvider.Instance.GetDateTimeOffsetValue(xElement, format);
            public override ValueExpression GetTimeSpanValue(XElementExpression xElement, string? format)
                => XElementExtensionsProvider.Instance.GetTimeSpanValue(xElement, format);
        }
    }
}
