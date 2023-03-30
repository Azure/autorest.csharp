// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal static class MethodBodyLines
    {
        public static MethodBodyStatement AsStatement(this IEnumerable<MethodBodyStatement> statements) => new MethodBodyStatements(statements.ToArray());

        public static class LineCall
        {
            public static class Dictionary
            {
                public static MethodBodyStatement Add(ValueExpression dictionary, ValueExpression key, ValueExpression value) => new InstanceMethodCallLine(dictionary, nameof(Dictionary<object, object>.Add), new[]{key, value}, false);
            }

            public static class List
            {
                public static MethodBodyStatement Add(ValueExpression list, ValueExpression value) => new InstanceMethodCallLine(list, nameof(List<object>.Add), new[]{value}, false);
            }

            public static class JsonSerializer
            {
                public static MethodBodyStatement Serialize(ValueExpression writer, ValueExpression value)
                    => new StaticMethodCallLine(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Serialize), new[]{writer, value});

                public static MethodBodyStatement Serialize(ValueExpression writer, ValueExpression value, ValueExpression options)
                    => new StaticMethodCallLine(typeof(System.Text.Json.JsonSerializer), nameof(System.Text.Json.JsonSerializer.Serialize), new[]{writer, value, options});
            }
        }

        public static class Declare
        {
            public static DeclarationStatement FirstPageRequest(ValueExpression? restClient, string methodName, IEnumerable<ValueExpression> arguments, out CodeWriterDeclaration localFunctionName)
            {
                var requestMethodCall = new InstanceMethodCallExpression(restClient, methodName, arguments.ToList(), false);
                localFunctionName = new CodeWriterDeclaration("FirstPageRequest");
                return new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint}, typeof(HttpMessage), requestMethodCall);
            }

            public static DeclarationStatement NextPageRequest(ValueExpression? restClient, string methodName, IEnumerable<ValueExpression> arguments, out CodeWriterDeclaration localFunctionName)
            {
                var requestMethodCall = new InstanceMethodCallExpression(restClient, methodName, arguments.ToList(), false);
                localFunctionName = new CodeWriterDeclaration("NextPageRequest");
                return new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint, KnownParameters.NextLink}, typeof(HttpMessage), requestMethodCall);
            }
        }
    }

    internal record Method(MethodSignature Signature, MethodBody Body);
    internal record MethodBody(IReadOnlyList<MethodBodyStatement> Statements);

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

    internal record DeclarationStatement : MethodBodyStatement;

    internal record InstanceMethodCallLine(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, bool CallAsAsync) : MethodBodyStatement;
    internal record StaticMethodCallLine(CSharpType? MethodType, string MethodName, IReadOnlyList<ValueExpression> Arguments, IReadOnlyList<CSharpType>? TypeArguments = null, bool CallAsExtension = false, bool CallAsAsync = false) : MethodBodyStatement;

    internal record SwitchCase(string Case, MethodBodyStatement Statement, bool Inline = false) ;
}
