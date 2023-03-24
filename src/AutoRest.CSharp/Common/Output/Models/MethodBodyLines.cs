// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
        public static MethodBodyLine Return(CodeWriterDeclaration name) => new ReturnValueLine(new VariableReference(name));
        public static MethodBodyLine Return(ValueExpression value) => new ReturnValueLine(value);

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
        }

        public static class Declare
        {
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

            public static MethodBodyLine NewModelInstance(ModelTypeProvider model, IEnumerable<Parameter> arguments, out CodeWriterDeclaration variable)
                => NewModelInstance(model, arguments.Select(p => new ParameterReference(p)).ToList(), out variable);

            public static MethodBodyLine NewModelInstance(ModelTypeProvider model, IReadOnlyList<ValueExpression> arguments, out CodeWriterDeclaration variable)
            {
                variable = new CodeWriterDeclaration(model.Type.Name.ToVariableName());
                var newInstance = new NewInstanceExpression(model.Type, arguments);
                return new DeclareVariableLine(model.Type, variable, newInstance);
            }
        }
    }

    internal record Method(MethodSignature Signature, MethodBody Body);
    internal record MethodBody(IReadOnlyList<MethodBodyBlock> Blocks);

    internal record MethodBodyBlock;

    internal record ParameterValidationBlock(IReadOnlyList<Parameter> Parameters) : MethodBodyBlock;
    internal record DiagnosticScopeMethodBodyBlock(Diagnostic Diagnostic, Reference ClientDiagnosticsReference, MethodBodyBlock InnerBlock) : MethodBodyBlock;
    internal record TryCatchFinallyBlock(MethodBodyBlock Try, MethodBodyBlock? Catch, MethodBodyBlock? Finally) : MethodBodyBlock;
    internal record IfElseBlock(ValueExpression Condition, MethodBodyBlock If, MethodBodyBlock? Else) : MethodBodyBlock;
    internal record ForeachBlock(CodeWriterDeclaration Item, ValueExpression Enumerable, MethodBodyBlock Body) : MethodBodyBlock;
    internal record MethodBodyBlocks(IReadOnlyList<MethodBodyBlock> Blocks) : MethodBodyBlock
    {
        public MethodBodyBlocks(MethodBodyBlock firstBlock, params MethodBodyBlock[] blocks) : this(blocks.Prepend(firstBlock).ToArray()) {}
    }

    internal record MethodBodyLine : MethodBodyBlock;

    internal record InstanceMethodCallLine(ValueExpression? InstanceReference, string MethodName, IReadOnlyList<ValueExpression> Arguments, bool CallAsAsync) : MethodBodyLine;
    internal record UsingDeclareVariableLine(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyLine;
    internal record DeclareVariableLine(CSharpType? Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyLine;
    internal record ReturnValueLine(ValueExpression Value) : MethodBodyLine;
    internal record SetValueLine(ValueExpression To, ValueExpression From) : MethodBodyLine;
    internal record OneLineLocalFunction(CodeWriterDeclaration Name, IReadOnlyList<Parameter> Parameters, CSharpType ReturnType, ValueExpression Body) : MethodBodyLine;
}
