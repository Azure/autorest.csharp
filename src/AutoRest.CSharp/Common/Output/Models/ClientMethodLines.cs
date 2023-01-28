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

namespace AutoRest.CSharp.Output.Models
{
    internal static class ClientMethodLines
    {
        public static void DeclareCreateFirstPageRequestLocalFunction(this IList<MethodBodySingleLine> lines, InlineableExpression? restClient, string methodName, IReadOnlyList<InlineableExpression> arguments, out CodeWriterDeclaration localFunctionName)
        {
            var requestMethodCall = new InstanceMethodCallExpression(restClient, RequestWriterHelpers.CreateRequestMethodName(methodName), arguments, false);
            localFunctionName = new CodeWriterDeclaration("FirstPageRequest");
            lines.Add(new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint}, typeof(HttpMessage), requestMethodCall));
        }

        public static void DeclareCreateNextPageRequestLocalFunction(this IList<MethodBodySingleLine> lines, InlineableExpression? restClient, string methodName, IReadOnlyList<InlineableExpression> arguments, out CodeWriterDeclaration localFunctionName)
        {
            var requestMethodCall = new InstanceMethodCallExpression(restClient, RequestWriterHelpers.CreateRequestMethodName(methodName), arguments.Prepend(new ParameterReference(KnownParameters.NextLink)).ToList(), false);
            localFunctionName = new CodeWriterDeclaration("NextPageRequest");
            lines.Add(new OneLineLocalFunction(localFunctionName, new[]{KnownParameters.PageSizeHint, KnownParameters.NextLink}, typeof(HttpMessage), requestMethodCall));
        }

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
                            var requestContext = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
                            var cancellationToken = new ParameterReference(convenienceParameter);
                            var canBeCanceled = new TernaryConditionalOperator(
                                new MemberReference(cancellationToken, nameof(CancellationToken.CanBeCanceled)),
                                new NewInstanceExpression(typeof(RequestContext), new Dictionary<string, InlineableExpression>{ [nameof(RequestContext.CancellationToken)] = cancellationToken }),
                                new ExpressionAsFormattableString($"null"));

                            requestContextVariable = new VariableReference(requestContext);
                            lines.Add(new DeclareVariableLine(KnownParameters.RequestContext.Type, requestContext, canBeCanceled));
                            arguments.Add(requestContextVariable);
                        }
                        else if (convenienceParameter != protocolParameter)
                        {
                            var conversion = CreateConversion(convenienceParameter, protocolParameter.Type);
                            var argument = new CodeWriterDeclaration(protocolParameter.Name);
                            lines.Add(new DeclareVariableLine(protocolParameter.Type, argument, conversion));
                            arguments.Add(new VariableReference(argument));
                        }
                        else
                        {
                            if (protocolParameter == KnownParameters.RequestContext)
                            {
                                requestContextVariable = new ParameterReference(protocolParameter);
                            }
                            arguments.Add(new ParameterReference(protocolParameter));
                        }
                        break;
                    case { ProtocolParameters.Count: > 1, ConvenienceParameters.Count: 1, IntermediateModel: {} model }:
                        // Grouping is not supported yet
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters.Count: > 1, IntermediateModel: {} model }:
                        var variable = new CodeWriterDeclaration(model.Type.Name.ToVariableName());
                        var newInstance = new NewInstanceExpression(model.Type, parameterLink.ConvenienceParameters.Select(p => new ParameterReference(p)).ToList());
                        lines.Add(new DeclareVariableLine(model.Type, variable, newInstance));
                        arguments.Add(CreateConversion(new VariableReference(variable), model.Type, protocolParameter.Type));
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
                            DeclareRequestContext(lines, arguments);
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
                    case { ProtocolParameters.Count: > 1, ConvenienceParameters.Count: 1, IntermediateModel: {} model }:
                        // Grouping is not supported yet
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters.Count: > 1, IntermediateModel: {} model }:
                        var variable = new CodeWriterDeclaration(model.Type.Name.ToVariableName());
                        var newInstance = new NewInstanceExpression(model.Type, parameterLink.ConvenienceParameters.Select(p => new ParameterReference(p)).ToList());
                        lines.Add(new DeclareVariableLine(model.Type, variable, newInstance));
                        arguments.Add(CreateConversion(new VariableReference(variable), model.Type, protocolParameter.Type));
                        break;
                }
            }

            protocolMethodArguments = arguments;
        }

        public static void CallPageableHelpersCreatePageableAndReturn(this IList<MethodBodySingleLine> lines,
            CodeWriterDeclaration createFirstPageRequest,
            CodeWriterDeclaration? createNextPageRequest,
            CodeWriterDeclaration clientDiagnostics,
            CodeWriterDeclaration pipeline,
            CSharpType? pageItemType,
            string scopeName,
            string itemPropertyName,
            string? nextLinkPropertyName,
            InlineableExpression? requestContextVariable,
            bool async)
        {
            var arguments = new List<InlineableExpression>
            {
                new VariableReference(createFirstPageRequest),
                createNextPageRequest != null ? new VariableReference(createNextPageRequest) : new ExpressionAsFormattableString($"null"),
                new ExpressionAsFormattableString(PageableMethodsWriterExtensions.GetValueFactory(pageItemType)),
                new VariableReference(clientDiagnostics),
                new VariableReference(pipeline),
                new ExpressionAsFormattableString($"{scopeName:L}"),
                new ExpressionAsFormattableString($"{itemPropertyName:L}"),
                new ExpressionAsFormattableString($"{nextLinkPropertyName:L}")
            };

            if (requestContextVariable is not null)
            {
                arguments.Add(requestContextVariable);
            }

            var methodName = async ? nameof(PageableHelpers.CreateAsyncPageable) : nameof(PageableHelpers.CreatePageable);
            var convertMethodCall = new StaticMethodCallExpression(typeof(PageableHelpers), methodName, arguments, false);
            lines.Add(new ReturnValueLine(convertMethodCall));
        }

        public static void CallProtocolMethod(this IList<MethodBodySingleLine> lines, string methodName, IReadOnlyList<InlineableExpression> arguments, CSharpType responseType, bool async, out CodeWriterDeclaration response)
        {
            var protocolMethodName = async ? methodName + "Async" : methodName;
            var protocolMethodCall = new InstanceMethodCallExpression(null, protocolMethodName, arguments, async);
            response = new CodeWriterDeclaration("response");
            lines.Add(new DeclareVariableLine(responseType, response, protocolMethodCall));
        }

        public static void CallProtocolMethodAndReturn(this IList<MethodBodySingleLine> lines, string methodName, IReadOnlyList<InlineableExpression> arguments, bool async)
        {
            var protocolMethodName = async ? methodName + "Async" : methodName;
            var protocolMethodCall = new InstanceMethodCallExpression(null, protocolMethodName, arguments, async);
            lines.Add(new ReturnValueLine(protocolMethodCall));
        }

        public static void CallResponseFromValueAndReturn(this IList<MethodBodySingleLine> lines, CSharpType responseType, CodeWriterDeclaration response)
        {
            var responseVariable = new VariableReference(response);
            var fromResponseCall = new StaticMethodCallExpression(responseType, "FromResponse", new[]{responseVariable}, false);
            var fromValueCall = new StaticMethodCallExpression(typeof(Response), nameof(Response.FromValue), new InlineableExpression[]{fromResponseCall, responseVariable}, false);
            lines.Add(new ReturnValueLine(fromValueCall));
        }

        public static void CallProtocolOperationHelpersConvertAndReturn(this IList<MethodBodySingleLine> lines, CSharpType responseType, CodeWriterDeclaration response, CodeWriterDeclaration clientDiagnostics, string scopeName)
        {
            var responseVariable = new VariableReference(response);
            var fromResponseReference = new MemberReference(new TypeReference(responseType), "FromResponse");
            var diagnosticsReference = new VariableReference(clientDiagnostics);
            var arguments = new InlineableExpression[] { responseVariable, fromResponseReference, diagnosticsReference, new ExpressionAsFormattableString($"{scopeName:L}") };
            var convertMethodCall = new StaticMethodCallExpression(typeof(ProtocolOperationHelpers), nameof(ProtocolOperationHelpers.Convert), arguments, false);
            lines.Add(new ReturnValueLine(convertMethodCall));
        }

        private static void DeclareRequestContext(ICollection<MethodBodySingleLine> lines, ICollection<InlineableExpression> arguments)
        {
            var variable = new CodeWriterDeclaration(KnownParameters.RequestContext.Name);
            arguments.Add(new VariableReference(variable));

            var callFromCancellationToken = new StaticMethodCallExpression(null, "FromCancellationToken", new[]{ new ParameterReference(KnownParameters.CancellationTokenParameter) }, false);
            lines.Add(new DeclareVariableLine(KnownParameters.RequestContext.Type, variable, callFromCancellationToken));
        }

        private static InlineableExpression CreateConversion(Parameter fromParameter, CSharpType toType)
            => CreateConversion(new ParameterReference(fromParameter), fromParameter.Type, toType);

        private static InlineableExpression CreateConversion(InlineableExpression fromExpression, CSharpType fromType, CSharpType toType)
        {
            if (fromType.IsNullable && toType.IsNullable)
            {
                fromExpression = new NullConditionalExpression(fromExpression);
            }

            return fromType switch
            {
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } }  when toType.EqualsIgnoreNullable(typeof(string)) => new InstanceMethodCallExpression(fromExpression, "ToString", Array.Empty<InlineableExpression>(), false),
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: false } } when toType.EqualsIgnoreNullable(typeof(string)) => new StaticMethodCallExpression(fromType, "ToSerialString", new[]{ fromExpression }, true),
                { IsFrameworkType: false, Implementation: ModelTypeProvider }                when toType.EqualsIgnoreNullable(typeof(RequestContent)) => new InstanceMethodCallExpression(fromExpression, "ToRequestContent", Array.Empty<InlineableExpression>(), false),
                _ => fromExpression
            };
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

    internal record StaticMethodCallExpression(CSharpType? MethodType, string MethodName, IReadOnlyList<InlineableExpression> Arguments, bool CallAsExtension) : InlineableExpression;

    internal record InstanceMethodCallExpression(InlineableExpression? InstanceReference, string MethodName, IReadOnlyList<InlineableExpression> Arguments, bool CallAsAsync) : InlineableExpression;
}
