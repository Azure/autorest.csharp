// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System
{
    internal sealed record MultipartFormDataBinaryContentExpression(ValueExpression Untyped) : TypedValueExpression<MultipartFormDataBinaryContent>(Untyped)
    {
        public ValueExpression ContentParts => new MemberExpression(this, nameof(MultipartFormDataBinaryContent.ContentParts));
        public MethodBodyStatement Add() => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataBinaryContent.Add));
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, ValueExpression name) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataBinaryContent.Add), new[] { toBinaryDataExpress, name }, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataBinaryContent.Add), new[] { toBinaryDataExpress, Literal(name) }, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataBinaryContent.Add), new[] { toBinaryDataExpress, Literal(name), headers }, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, ValueExpression name, ValueExpression fileName) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataBinaryContent.Add), new[] { toBinaryDataExpress, name, fileName }, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, string fileName, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormDataBinaryContent.Add), new[] { toBinaryDataExpress, Literal(name), Literal(fileName), headers }, false);
        public MethodBodyStatement ToContent() => new InvokeInstanceMethodStatement(Untyped, nameof(ModelReaderWriter.Write));
        //public MethodBodyStatement Create(ValueExpression content) => new InvokeStaticMethodStatement(typeof(MultipartFormDataContent), nameof(MultipartFormDataContent.Create), new[] { content });
        public static MultipartFormDataBinaryContentExpression Create(ValueExpression content, ValueExpression contentType) => new(InvokeStatic(nameof(MultipartFormDataBinaryContent.Create), new[] { content, contentType }));
        public ValueExpression ParseToFormData() => Extensible.MultipartFormDataBinaryContent.ParseToFormData(this);
    }
}
