// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record MultipartFormDataExpression(ValueExpression Untyped) : TypedValueExpression<MultipartFormDataRequestContent>(Untyped)
    {
        public ValueExpression ContentParts => new MemberExpression(this, nameof(MultipartFormDataRequestContent.ContentParts));
        public MethodBodyStatement Add() => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataRequestContent.Add));
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, ValueExpression name) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataRequestContent.Add), new[] { toBinaryDataExpress, name }, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataRequestContent.Add), new[] { toBinaryDataExpress, Literal(name)}, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataRequestContent.Add), new[] {toBinaryDataExpress, Literal(name), headers}, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, ValueExpression name, ValueExpression fileName) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataRequestContent.Add), new[] { toBinaryDataExpress, name, fileName }, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, string fileName, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataRequestContent.Add), new[] { toBinaryDataExpress, Literal(name), Literal(fileName), headers }, false);
        public MethodBodyStatement ToContent() => new InvokeInstanceMethodStatement(Untyped, nameof(ModelReaderWriter.Write));
        //public MethodBodyStatement Create(ValueExpression content) => new InvokeStaticMethodStatement(typeof(MultipartFormDataContent), nameof(MultipartFormDataContent.Create), new[] { content });
        public static MultipartFormDataExpression Create(ValueExpression content, ValueExpression contentType) => new(InvokeStatic(nameof(MultipartFormDataContent.Create), new[] { content, contentType }));
        public ValueExpression ParseToFormData() => Extensible.MultipartFormData.ParseToFormData(this);
    }
}
