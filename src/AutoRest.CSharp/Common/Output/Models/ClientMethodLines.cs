// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.InlineableExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal static class ClientMethodLines
    {
        public static MethodBodySingleLine Return(CodeWriterDeclaration name) => new ReturnValueLine(new VariableReference(name));
        public static MethodBodySingleLine Return(InlineableExpression value) => new ReturnValueLine(value);

        public static void CreatePageableMethodArguments(this IList<MethodBodySingleLine> lines, IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> parameters, out IReadOnlyList<InlineableExpression> createRequestArguments, out InlineableExpression? requestContextVariable)
        {
            var arguments = new List<InlineableExpression>();
            requestContextVariable = null;
            foreach (var parameterLink in parameters)
            {
                switch (parameterLink)
                {
                    case { ProtocolParameters.Count: 0 }:
                        // Skip the convenience-only parameters
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters: [var convenienceParameter], IntermediateModel: null }:
                        if (protocolParameter == KnownParameters.RequestContext && convenienceParameter == KnownParameters.CancellationTokenParameter)
                        {
                            lines.Add(Declare.RequestContext(Instantiate.IfCancellationTokenCanBeCanceled(), out var requestContext));
                            requestContextVariable = new VariableReference(requestContext);
                            arguments.Add(new VariableReference(requestContext));
                        }
                        else if (convenienceParameter != protocolParameter)
                        {
                            var conversion = CreateConversion(convenienceParameter, protocolParameter.Type);
                            var argument = new CodeWriterDeclaration(protocolParameter.Name);
                            lines.Add(new DeclareVariableLine(protocolParameter.Type, argument, conversion));
                            arguments.Add(new VariableReference(argument));
                        }
                        else if (protocolParameter == KnownParameters.RequestContext)
                        {
                            requestContextVariable = new ParameterReference(protocolParameter);
                            arguments.Add(requestContextVariable);
                        }
                        else
                        {
                            arguments.Add(new ParameterReference(protocolParameter));
                        }
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters.Count: > 1, IntermediateModel: {} model }:
                        lines.Add(Declare.NewModelInstance(model, parameterLink.ConvenienceParameters, out var variable));
                        arguments.Add(CreateConversion(new VariableReference(variable), model.Type, protocolParameter.Type));
                        break;
                    case { ProtocolParameters.Count: > 1, ConvenienceParameters.Count: 1, IntermediateModel: {} model }:
                        // Grouping is not supported yet
                        break;
                }
            }

            createRequestArguments = arguments;
        }

        public static void CreateProtocolMethodArguments(this IList<MethodBodySingleLine> lines, IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> parameters, out IReadOnlyList<InlineableExpression> protocolMethodArguments)
        {
            var arguments = new List<InlineableExpression>();
            foreach (var parameterLink in parameters)
            {
                switch (parameterLink)
                {
                    case { ProtocolParameters.Count: 0 }:
                        // Skip the convenience-only parameters
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters: [var convenienceParameter], IntermediateModel: null }:
                        if (protocolParameter == KnownParameters.RequestContext && convenienceParameter == KnownParameters.CancellationTokenParameter)
                        {
                            lines.Add(Declare.RequestContext(Call.FromCancellationToken(), out var requestContext));
                            arguments.Add(new VariableReference(requestContext));
                        }
                        else if (convenienceParameter != protocolParameter)
                        {
                            arguments.Add(CreateConversion(convenienceParameter, protocolParameter.Type));
                        }
                        else
                        {
                            arguments.Add(new ParameterReference(protocolParameter));
                        }
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters.Count: > 1, IntermediateModel: {} model }:
                        lines.Add(Declare.NewModelInstance(model, parameterLink.ConvenienceParameters, out var variable));
                        arguments.Add(CreateConversion(new VariableReference(variable), model.Type, protocolParameter.Type));
                        break;
                    case { ProtocolParameters.Count: > 1, ConvenienceParameters.Count: 1, IntermediateModel: {} model }:
                        // Grouping is not supported yet
                        break;
                }
            }

            protocolMethodArguments = arguments;
        }

        private static InlineableExpression CreateConversion(Parameter fromParameter, CSharpType toType)
        {
            return fromParameter.Type switch
            {
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } }  when toType.EqualsIgnoreNullable(typeof(string)) => Call.ToString(fromParameter),
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: false } } when toType.EqualsIgnoreNullable(typeof(string)) => Call.ToSerialString(fromParameter),
                { IsFrameworkType: false, Implementation: ModelTypeProvider }                when toType.EqualsIgnoreNullable(typeof(RequestContent)) => Call.ToRequestContent(fromParameter),
                _ => new ParameterReference(fromParameter)
            };
        }

        private static InlineableExpression CreateConversion(InlineableExpression fromExpression, CSharpType fromType, CSharpType toType)
        {
            if (fromType.IsNullable && toType.IsNullable)
            {
                fromExpression = new NullConditionalExpression(fromExpression);
            }

            return fromType switch
            {
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } }  when toType.EqualsIgnoreNullable(typeof(string)) => Call.ToString(fromExpression),
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: false } } when toType.EqualsIgnoreNullable(typeof(string)) => Call.ToSerialString(fromType, fromExpression),
                { IsFrameworkType: false, Implementation: ModelTypeProvider }                when toType.EqualsIgnoreNullable(typeof(RequestContent)) => Call.ToRequestContent(fromExpression),
                _ => fromExpression
            };
        }

        public static class Declare
        {
            public static MethodBodySingleLine FirstPageRequest(InlineableExpression? restClient, string methodName, IEnumerable<InlineableExpression> arguments, out CodeWriterDeclaration localFunctionName)
            {
                var requestMethodCall = new InstanceMethodCallExpression(restClient, RequestWriterHelpers.CreateRequestMethodName(methodName), arguments.ToList(), false);
                localFunctionName = new CodeWriterDeclaration("FirstPageRequest");
                return new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint}, typeof(HttpMessage), requestMethodCall);
            }

            public static MethodBodySingleLine NextPageRequest(InlineableExpression? restClient, string methodName, IEnumerable<InlineableExpression> arguments, out CodeWriterDeclaration localFunctionName)
            {
                var requestMethodCall = new InstanceMethodCallExpression(restClient, RequestWriterHelpers.CreateRequestMethodName(methodName), arguments.ToList(), false);
                localFunctionName = new CodeWriterDeclaration("NextPageRequest");
                return new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint, KnownParameters.NextLink}, typeof(HttpMessage), requestMethodCall);
            }

            public static MethodBodySingleLine Message(InlineableExpression value, out CodeWriterDeclaration message)
            {
                message = new CodeWriterDeclaration("message");
                return new UsingDeclareVariableLine(typeof(HttpMessage), message, value);
            }

            public static MethodBodySingleLine Response(CSharpType responseType, InlineableExpression value, out CodeWriterDeclaration response)
            {
                response = new CodeWriterDeclaration("response");
                return new DeclareVariableLine(responseType, response, value);
            }

            public static MethodBodySingleLine RequestContext(InlineableExpression value, out CodeWriterDeclaration requestContext)
            {
                requestContext = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
                return new DeclareVariableLine(KnownParameters.RequestContext.Type, requestContext, value);
            }

            public static MethodBodySingleLine NewModelInstance(ModelTypeProvider model, IEnumerable<Parameter> arguments, out CodeWriterDeclaration variable)
                => NewModelInstance(model, arguments.Select(p => new ParameterReference(p)).ToList(), out variable);

            public static MethodBodySingleLine NewModelInstance(ModelTypeProvider model, IReadOnlyList<InlineableExpression> arguments, out CodeWriterDeclaration variable)
            {
                variable = new CodeWriterDeclaration(model.Type.Name.ToVariableName());
                var newInstance = new NewInstanceExpression(model.Type, arguments);
                return new DeclareVariableLine(model.Type, variable, newInstance);
            }
        }
    }

    internal record Method(MethodSignature Signature, MethodBody Body);
    internal record MethodBody(IReadOnlyList<MethodBodyBlock> Blocks);

    internal record MethodBodyBlock
    {
        public static MethodBodyBlock Create(params MethodBodySingleLine[] lines) => new MethodBodyLines(lines);
    }

    internal record ParameterValidationBlock(IReadOnlyList<Parameter> Parameters) : MethodBodyBlock;
    internal record DiagnosticScopeMethodBodyBlock(Diagnostic Diagnostic, Reference ClientDiagnosticsReference, MethodBodyBlock InnerBlock) : MethodBodyBlock;
    internal record TryCatchFinallyBlock(MethodBodyBlock Try, MethodBodyBlock? Catch, MethodBodyBlock? Finally) : MethodBodyBlock;

    internal record MethodBodyLines(IReadOnlyList<MethodBodySingleLine> MethodBodySingleLine) : MethodBodyBlock;
    internal record MethodBodySingleLine;

    internal record UsingDeclareVariableLine(CSharpType Type, CodeWriterDeclaration Name, InlineableExpression Value) : MethodBodySingleLine;
    internal record DeclareVariableLine(CSharpType Type, CodeWriterDeclaration Name, InlineableExpression Value) : MethodBodySingleLine;
    internal record ReturnValueLine(InlineableExpression Value) : MethodBodySingleLine;
    internal record OneLineLocalFunction(CodeWriterDeclaration Name, IReadOnlyList<Parameter> Parameters, CSharpType ReturnType, InlineableExpression Body) : MethodBodySingleLine;

    internal record InlineableExpression;

    internal record DefaultValueExpression(CSharpType Type) : InlineableExpression;
    internal record NewInstanceExpression(CSharpType Type, IReadOnlyList<InlineableExpression> Arguments, IReadOnlyDictionary<string, InlineableExpression> Properties) : InlineableExpression
    {
        public NewInstanceExpression(CSharpType type) : this(type, Array.Empty<InlineableExpression>(), new Dictionary<string, InlineableExpression>()){}
        public NewInstanceExpression(CSharpType type, IReadOnlyList<InlineableExpression> arguments) : this(type, arguments, new Dictionary<string, InlineableExpression>()){}
        public NewInstanceExpression(CSharpType type, IReadOnlyDictionary<string, InlineableExpression> properties) : this(type, Array.Empty<InlineableExpression>(), properties){}
    }

    internal record TernaryConditionalOperator(InlineableExpression Condition, InlineableExpression Consequent, InlineableExpression Alternative) : InlineableExpression;
    internal record TypeReference(CSharpType Type) : InlineableExpression;
    internal record MemberReference(InlineableExpression Inner, string MemberName) : InlineableExpression;
    internal record ParameterReference(Parameter Parameter) : InlineableExpression;
    internal record VariableReference(CodeWriterDeclaration Name) : InlineableExpression;
    internal record ExpressionAsFormattableString(FormattableString Value) : InlineableExpression; // Shim between formattable strings and expressions

    internal record NullConditionalExpression(InlineableExpression Inner) : InlineableExpression;

    internal record StaticMethodCallExpression(CSharpType? MethodType, string MethodName, IReadOnlyList<InlineableExpression> Arguments, bool CallAsExtension, bool CallAsAsync) : InlineableExpression;

    internal record InstanceMethodCallExpression(InlineableExpression? InstanceReference, string MethodName, IReadOnlyList<InlineableExpression> Arguments, bool CallAsAsync) : InlineableExpression;
}
