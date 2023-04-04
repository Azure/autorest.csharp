// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class InvokeOptional
        {
            public static ValueExpression IsCollectionDefined(ValueExpression collection) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.IsCollectionDefined), new[]{collection});
            public static ValueExpression IsDefined(ValueExpression value) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.IsDefined), new[]{value});
            public static ValueExpression ToDictionary(ValueExpression dictionary) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.ToDictionary), new[]{dictionary});
            public static ValueExpression ToList(ValueExpression collection) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.ToList), new[]{collection});
            public static ValueExpression ToNullable(ValueExpression optional) => new InvokeStaticMethodExpression(typeof(Optional), nameof(Optional.ToNullable), new[]{optional});
        }
    }
}
