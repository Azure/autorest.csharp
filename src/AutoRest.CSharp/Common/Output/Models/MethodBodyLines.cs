// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal static class MethodBodyLines
    {
        public static MethodBodyLine Continue { get; } = new KeywordLine("continue");

        public static MethodBodyLine New(string name, out Utf8JsonRequestContentExpression variable)
            => Var(null, name, new Utf8JsonRequestContentExpression(ValueExpressions.New(typeof(Utf8JsonRequestContent))), d => new Utf8JsonRequestContentExpression(d), out variable);

        public static MethodBodyLine Return(CodeWriterDeclaration name) => new ReturnValueLine(new VariableReference(name));
        public static MethodBodyLine Return(ValueExpression value) => new ReturnValueLine(value);

        public static MethodBodyLine UsingVar(string name, JsonDocumentExpression value, out JsonDocumentExpression variable)
            => UsingVar(null, name, value, d => new JsonDocumentExpression(d), out variable);

        public static MethodBodyLine Var(string name, Utf8JsonWriterExpression value, out Utf8JsonWriterExpression variable)
            => Var(null, name, value, d => new Utf8JsonWriterExpression(d), out variable);

        private static MethodBodyLine Var<T>(CSharpType? type, string name, T value, Func<CodeWriterDeclaration, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(declaration);
            return new DeclareVariableLine(type, declaration, value);
        }

        private static MethodBodyLine UsingVar<T>(CSharpType? type, string name, T value, Func<CodeWriterDeclaration, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(declaration);
            return new UsingDeclareVariableLine(type, declaration, value);
        }

        public static MethodBodyStatement AsStatement(this IEnumerable<MethodBodyStatement> statements) => new MethodBodyStatements(statements.ToArray());

        public static class Assign
        {
            public static MethodBodyLine Value(CodeWriterDeclaration to, ValueExpression from) => new SetValueLine(to, from);
            public static MethodBodyLine ResponseValueId(CodeWriterDeclaration response, ValueExpression from) => new SetValueLine(GetResponseValueId(response), from);
        }

        public static class LineCall
        {
            public static class Dictionary
            {
                public static MethodBodyLine Add(ValueExpression dictionary, ValueExpression key, ValueExpression value) => new InstanceMethodCallLine(dictionary, nameof(Dictionary<object, object>.Add), new[]{key, value}, false);
            }

            public static class List
            {
                public static MethodBodyLine Add(ValueExpression list, ValueExpression value) => new InstanceMethodCallLine(list, nameof(List<object>.Add), new[]{value}, false);
            }

            public static class JsonElement
            {
                public static MethodBodyLine WriteTo(ValueExpression jsonElement, ValueExpression writer) => new InstanceMethodCallLine(jsonElement, nameof(System.Text.Json.JsonElement.WriteTo), new[]{writer}, false);
            }

            public static class JsonSerializer
            {
                public static MethodBodyLine Serialize(ValueExpression writer, ValueExpression value)
                    => new StaticMethodCallLine(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Serialize), new[]{writer, value});

                public static MethodBodyLine Serialize(ValueExpression writer, ValueExpression value, ValueExpression options)
                    => new StaticMethodCallLine(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Serialize), new[]{writer, value, options});
            }
        }

        public static class Declare
        {
            public static MethodBodyLine Default(CSharpType type, string name, out CodeWriterDeclaration declaration)
            {
                declaration = new CodeWriterDeclaration(name);
                return new DeclareVariableLine(type, declaration, ValueExpressions.Default);
            }

            public static MethodBodyLine FirstPageRequest(ValueExpression? restClient, string methodName, IEnumerable<ValueExpression> arguments, out CodeWriterDeclaration localFunctionName)
            {
                var requestMethodCall = new InstanceMethodCallExpression(restClient, methodName, arguments.ToList(), false);
                localFunctionName = new CodeWriterDeclaration("FirstPageRequest");
                return new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint}, typeof(HttpMessage), requestMethodCall);
            }

            public static MethodBodyLine NextPageRequest(ValueExpression? restClient, string methodName, IEnumerable<ValueExpression> arguments, out CodeWriterDeclaration localFunctionName)
            {
                var requestMethodCall = new InstanceMethodCallExpression(restClient, methodName, arguments.ToList(), false);
                localFunctionName = new CodeWriterDeclaration("NextPageRequest");
                return new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint, KnownParameters.NextLink}, typeof(HttpMessage), requestMethodCall);
            }

            public static MethodBodyLine Message(ValueExpression value, out CodeWriterDeclaration message)
            {
                message = new CodeWriterDeclaration("message");
                return new UsingDeclareVariableLine(typeof(HttpMessage), message, value);
            }

            public static MethodBodyLine Response(CSharpType responseType, ValueExpression value, out CodeWriterDeclaration response)
            {
                response = new CodeWriterDeclaration("response");
                return new DeclareVariableLine(responseType, response, value);
            }

            public static MethodBodyLine RequestContext(ValueExpression value, out CodeWriterDeclaration requestContext)
            {
                requestContext = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
                return new DeclareVariableLine(KnownParameters.RequestContext.Type, requestContext, value);
            }
        }
    }

    internal record Method(MethodSignature Signature, MethodBody Body);
    internal record MethodBody(IReadOnlyList<MethodBodyStatement> Blocks);

    internal record MethodBodyStatement;

    internal record ParameterValidationBlock(IReadOnlyList<Parameter> Parameters) : MethodBodyStatement;
    internal record DiagnosticScopeMethodBodyBlock(Diagnostic Diagnostic, Reference ClientDiagnosticsReference, MethodBodyStatement InnerStatement) : MethodBodyStatement;
    internal record TryCatchFinallyStatement(MethodBodyStatement Try, MethodBodyStatement? Catch, MethodBodyStatement? Finally) : MethodBodyStatement;
    internal record IfElseStatement(ValueExpression Condition, MethodBodyStatement If, MethodBodyStatement? Else) : MethodBodyStatement;
    internal record SwitchStatement(ValueExpression MatchExpression, params SwitchCase[] Cases) : MethodBodyStatement;
    internal record IfElsePreprocessorDirective(string Condition, MethodBodyStatement If, MethodBodyStatement? Else) : MethodBodyStatement;
    internal record ForeachStatement(CodeWriterDeclaration Item, ValueExpression Enumerable, MethodBodyStatement Body) : MethodBodyStatement;
    internal record MethodBodyStatements(IReadOnlyList<MethodBodyStatement> Blocks) : MethodBodyStatement
    {
        public MethodBodyStatements(MethodBodyStatement firstStatement, params MethodBodyStatement[] blocks) : this(blocks.Prepend(firstStatement).ToArray()) {}
    }

    internal record MethodBodyLine : MethodBodyStatement;

    internal record InstanceMethodCallLine(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, bool CallAsAsync) : MethodBodyLine;
    internal record StaticMethodCallLine(CSharpType? MethodType, string MethodName, IReadOnlyList<ValueExpression> Arguments, IReadOnlyList<CSharpType>? TypeArguments = null, bool CallAsExtension = false, bool CallAsAsync = false) : MethodBodyLine;
    internal record UsingDeclareVariableLine(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyLine;
    internal record DeclareVariableLine(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyLine;
    internal record KeywordLine(string Keyword) : MethodBodyLine;
    internal record ReturnValueLine(ValueExpression Value) : MethodBodyLine;
    internal record SetValueLine(ValueExpression To, ValueExpression From) : MethodBodyLine;
    internal record OneLineLocalFunction(CodeWriterDeclaration Name, IReadOnlyList<Parameter> Parameters, CSharpType ReturnType, ValueExpression Body) : MethodBodyLine;

    internal record SwitchCase : MethodBodyStatement;
    internal record SwitchCaseLine(string Case, MethodBodyLine Value) : SwitchCase;
}
