// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class InvokeConvert
        {
            public static ValueExpression ToDouble(StringExpression value) => new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToDouble), Arguments: new[] { value });
            public static ValueExpression ToInt32(StringExpression value) => new InvokeStaticMethodExpression(typeof(Convert), nameof(Convert.ToInt32), Arguments: new[] { value });
        }
    }
}
