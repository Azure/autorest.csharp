﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
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
    internal sealed record MultipartFormDataExpression(ValueExpression Untyped) : TypedValueExpression<MultipartFormData>(Untyped)
    {
        //public ValueExpression ContentParts => new TypedMemberExpression(null, "ContentParts", typeof(List<MultipartContentPart>));
        //public ValueExpression ContentParts => new(Property(nameof(MultipartFormDataContent.ContentParts)));
        public ValueExpression ContentParts => new MemberExpression(this, nameof(MultipartFormData.ContentParts));
        public MethodBodyStatement Add() => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormData.Add));
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormData.Add), new[] { toBinaryDataExpress, Literal(name)}, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormData.Add), new[] {toBinaryDataExpress, Literal(name), headers}, false);
        public MethodBodyStatement Add(ValueExpression toBinaryDataExpress, string name, string fileName, ValueExpression headers) => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormData.Add), new[] { toBinaryDataExpress, Literal(name), Literal(fileName), headers }, false);
        public MethodBodyStatement ToContent() => new InvokeInstanceMethodStatement(Untyped, nameof(MultipartFormData.ToContent));
        //public MethodBodyStatement Create(ValueExpression content) => new InvokeStaticMethodStatement(typeof(MultipartFormDataContent), nameof(MultipartFormDataContent.Create), new[] { content });
        public static MultipartFormDataExpression Create(ValueExpression content) => new(InvokeStatic(nameof(MultipartFormData.Create), new[] { content }));
        //public static MultipartFormDataContentExpression FromObject(ValueExpression value) => new(new InvokeStaticMethodExpression(typeof(RequestContentHelper), nameof(RequestContentHelper.FromObject), new[] { value }));
        public static MultipartFormDataExpression ParseToFormData() => new(InvokeStatic(nameof(MultipartFormDataExtensions.ParseToFormData)));
    }
}
