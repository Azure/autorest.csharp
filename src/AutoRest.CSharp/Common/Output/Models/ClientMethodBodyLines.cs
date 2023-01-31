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
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal static class ClientMethodBodyLines
    {
        public static MethodBodyLine Return(CodeWriterDeclaration name) => new ReturnValueLine(new VariableReference(name));
        public static MethodBodyLine Return(ValueExpression value) => new ReturnValueLine(value);

        public static void CreatePageableMethodArguments(this IList<MethodBodyLine> lines, IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> parameters, out IReadOnlyList<ValueExpression> createRequestArguments, out ValueExpression? requestContextVariable)
        {
            var arguments = new List<ValueExpression>();
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

        public static void CreateProtocolMethodArguments(this IList<MethodBodyLine> lines, IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> parameters, out IReadOnlyList<ValueExpression> protocolMethodArguments)
        {
            var arguments = new List<ValueExpression>();
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

        private static ValueExpression CreateConversion(Parameter fromParameter, CSharpType toType)
        {
            return fromParameter.Type switch
            {
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } }  when toType.EqualsIgnoreNullable(typeof(string)) => Call.ToString(fromParameter),
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: false } } when toType.EqualsIgnoreNullable(typeof(string)) => Call.ToSerialString(fromParameter),
                { IsFrameworkType: false, Implementation: ModelTypeProvider }                when toType.EqualsIgnoreNullable(typeof(RequestContent)) => Call.ToRequestContent(fromParameter),
                _ => new ParameterReference(fromParameter)
            };
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, CSharpType fromType, CSharpType toType)
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

        public static class Set
        {
            public static MethodBodyLine ResponseValueId(CodeWriterDeclaration response, ValueExpression from)
            {
                return new SetValueLine(GetResponseValueId(response), from);
            }
        }

        public static class Declare
        {
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

    internal record MethodBodyBlock
    {
        public static MethodBodyBlock Create(params MethodBodyLine[] lines) => new MethodBodyLines(lines);
    }

    internal record ParameterValidationBlock(IReadOnlyList<Parameter> Parameters) : MethodBodyBlock;
    internal record DiagnosticScopeMethodBodyBlock(Diagnostic Diagnostic, Reference ClientDiagnosticsReference, MethodBodyBlock InnerBlock) : MethodBodyBlock;
    internal record TryCatchFinallyBlock(MethodBodyBlock Try, MethodBodyBlock? Catch, MethodBodyBlock? Finally) : MethodBodyBlock;

    internal record MethodBodyLines(IReadOnlyList<MethodBodyLine> MethodBodySingleLine) : MethodBodyBlock;
    internal record MethodBodyLine;

    internal record UsingDeclareVariableLine(CSharpType Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyLine;
    internal record DeclareVariableLine(CSharpType Type, CodeWriterDeclaration Name, ValueExpression Value) : MethodBodyLine;
    internal record ReturnValueLine(ValueExpression Value) : MethodBodyLine;
    internal record SetValueLine(ValueExpression To, ValueExpression From) : MethodBodyLine;
    internal record OneLineLocalFunction(CodeWriterDeclaration Name, IReadOnlyList<Parameter> Parameters, CSharpType ReturnType, ValueExpression Body) : MethodBodyLine;
}
