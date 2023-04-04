// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static class Optional
        {
            public static ValueExpression IsCollectionDefined(ValueExpression collection) => new InvokeStaticMethodExpression(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.IsCollectionDefined), new[]{collection});
            public static ValueExpression IsDefined(ValueExpression value) => new InvokeStaticMethodExpression(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.IsDefined), new[]{value});
            public static ValueExpression ToDictionary(ValueExpression dictionary) => new InvokeStaticMethodExpression(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.ToDictionary), new[]{dictionary});
            public static ValueExpression ToList(ValueExpression collection) => new InvokeStaticMethodExpression(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.ToList), new[]{collection});
            public static ValueExpression ToNullable(ValueExpression optional) => new InvokeStaticMethodExpression(typeof(Azure.Core.Optional), nameof(Azure.Core.Optional.ToNullable), new[]{optional});
        }
    }
}
