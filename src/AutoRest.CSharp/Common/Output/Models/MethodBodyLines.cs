// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal static class MethodBodyLines
    {
        public static MethodBodyLine Continue { get; } = new KeywordLine("continue");
        public static MethodBodyLine Return(CodeWriterDeclaration name) => new ReturnValueLine(new VariableReference(name));
        public static MethodBodyLine Return(ValueExpression value) => new ReturnValueLine(value);

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

            public static class JsonProperty
            {
                public static MethodBodyLine ThrowNonNullablePropertyIsNull(ValueExpression jsonProperty)
                    => new StaticMethodCallLine(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.ThrowNonNullablePropertyIsNull), new[]{jsonProperty}, CallAsExtension: true);
            }

            public static class JsonSerializer
            {
                public static MethodBodyLine Serialize(ValueExpression writer, ValueExpression value)
                    => new StaticMethodCallLine(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Serialize), new[]{writer, value});

                public static MethodBodyLine Serialize(ValueExpression writer, ValueExpression value, ValueExpression options)
                    => new StaticMethodCallLine(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Serialize), new[]{writer, value, options});
            }

            public static class Utf8JsonWriter
            {
                public static MethodBodyLine WriteStartObject(ValueExpression utf8JsonWriter) => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteStartObject), Array.Empty<ValueExpression>(), false);
                public static MethodBodyLine WriteEndObject(ValueExpression utf8JsonWriter) => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteEndObject), Array.Empty<ValueExpression>(), false);
                public static MethodBodyLine WriteStartArray(ValueExpression utf8JsonWriter) => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteStartArray), Array.Empty<ValueExpression>(), false);
                public static MethodBodyLine WriteEndArray(ValueExpression utf8JsonWriter) => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteEndArray), Array.Empty<ValueExpression>(), false);
                public static MethodBodyLine WritePropertyName(ValueExpression utf8JsonWriter, string propertyName) => WritePropertyName(utf8JsonWriter, LiteralU8(propertyName));
                public static MethodBodyLine WritePropertyName(ValueExpression utf8JsonWriter, ValueExpression propertyName) => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WritePropertyName), new[]{propertyName}, false);
                public static MethodBodyLine WriteNull(ValueExpression utf8JsonWriter, string propertyName) => WriteNull(utf8JsonWriter, Literal(propertyName));
                public static MethodBodyLine WriteNull(ValueExpression utf8JsonWriter, ValueExpression propertyName) => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteNull), new[]{propertyName}, false);
                public static MethodBodyLine WriteNullValue(ValueExpression utf8JsonWriter) => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteNullValue), Array.Empty<ValueExpression>(), false);

                public static MethodBodyLine WriteNumberValue(ValueExpression utf8JsonWriter, ValueExpression value)
                    => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteNumberValue), new[]{value}, false);

                public static MethodBodyLine WriteStringValue(ValueExpression utf8JsonWriter, ValueExpression value)
                    => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteStringValue), new[]{value}, false);

                public static MethodBodyLine WriteBooleanValue(ValueExpression utf8JsonWriter, ValueExpression value)
                    => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteBooleanValue), new[]{value}, false);

                public static MethodBodyLine WriteRawValue(ValueExpression utf8JsonWriter, ValueExpression value)
                    => new InstanceMethodCallLine(utf8JsonWriter, nameof(System.Text.Json.Utf8JsonWriter.WriteRawValue), new[]{value}, false);

                public static MethodBodyLine WriteNumberValue(ValueExpression utf8JsonWriter, ValueExpression value, string? format)
                    => new StaticMethodCallLine(typeof(Azure.Core.Utf8JsonWriterExtensions), nameof(Azure.Core.Utf8JsonWriterExtensions.WriteNumberValue), new[]{utf8JsonWriter, value, Literal(format)}, null, true);

                public static MethodBodyLine WriteStringValue(ValueExpression utf8JsonWriter, ValueExpression value, string? format)
                    => new StaticMethodCallLine(typeof(Azure.Core.Utf8JsonWriterExtensions), nameof(Azure.Core.Utf8JsonWriterExtensions.WriteStringValue), new[]{utf8JsonWriter, value, Literal(format)}, null, true);

                public static MethodBodyLine WriteObjectValue(ValueExpression utf8JsonWriter, ValueExpression value)
                    => new StaticMethodCallLine(typeof(Azure.Core.Utf8JsonWriterExtensions), nameof(Azure.Core.Utf8JsonWriterExtensions.WriteObjectValue), new[]{utf8JsonWriter, value}, null, true);

                public static MethodBodyLine WriteBase64StringValue(ValueExpression utf8JsonWriter, ValueExpression value, string? format)
                    => new StaticMethodCallLine(typeof(Azure.Core.Utf8JsonWriterExtensions), nameof(Azure.Core.Utf8JsonWriterExtensions.WriteBase64StringValue), new[]{utf8JsonWriter, value, Literal(format)}, null, true);
            }
        }

        public static class Declare
        {
            public static MethodBodyLine Var(string name, ValueExpression value, out CodeWriterDeclaration declaration)
            {
                declaration = new CodeWriterDeclaration(name);
                return new DeclareVariableLine(null, declaration, value);
            }

            public static MethodBodyLine New(CSharpType type, string name, out CodeWriterDeclaration declaration)
            {
                declaration = new CodeWriterDeclaration(name);
                return new DeclareVariableLine(null, declaration, ValueExpressions.New(type));
            }

            public static MethodBodyLine Default(CSharpType type, string name, out CodeWriterDeclaration declaration)
            {
                declaration = new CodeWriterDeclaration(name);
                return new DeclareVariableLine(type, declaration, ValueExpressions.Default);
            }

            public static MethodBodyLine JsonDocument(ValueExpression value, out CodeWriterDeclaration document)
            {
                document = new CodeWriterDeclaration("document");
                return new UsingDeclareVariableLine(null, document, value);
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
    internal record SwitchStatement(ValueExpression MatchExpression, params MethodBodyStatement[] Statements) : MethodBodyStatement;
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
}
