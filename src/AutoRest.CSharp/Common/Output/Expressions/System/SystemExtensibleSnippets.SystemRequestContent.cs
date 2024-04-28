// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Expressions.System
{
    internal partial class SystemExtensibleSnippets
    {
        internal class SystemRequestContentSnippets : RequestContentSnippets
        {
            public override ValueExpression Create(BinaryDataExpression binaryData)
                => BinaryContentExpression.Create(binaryData);
        }
    }
}
