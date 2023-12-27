// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record MultipartFormDataContentExpression(ValueExpression Untyped) : TypedValueExpression<MultipartFormDataContent>(Untyped)
    {
        public MethodBodyStatement Add() => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataContent.Add));
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataContent.Add), new[] { toBinaryDataExpress, Literal(name)}, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataContent.Add), new[] {toBinaryDataExpress, Literal(name), headers}, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, string fileName, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataContent.Add), new[] { toBinaryDataExpress, Literal(name), Literal(fileName), headers }, false);
        public MethodBodyStatement ToContent() => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataContent.ToContent));
    }
}
