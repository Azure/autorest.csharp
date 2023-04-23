// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class OperationMethodsBuilderBase
    {
        private readonly ClientFields _fields;
        private readonly string _clientName;
        private readonly TypeFactory _typeFactory;
        private readonly IReadOnlyList<RequestPartSource> _requestParts;

        private readonly string? _summary;
        private readonly string? _description;
        private readonly MethodSignatureModifiers _protocolAccessibility;
        private readonly MethodSignatureModifiers _convenienceAccessibility;

        public InputOperation Operation { get; }

        protected CodeWriterDeclaration ClientDiagnosticsDeclaration { get; }
        protected HttpPipelineExpression PipelineField { get; }
        protected ValueExpression? RestClient { get; }

        protected string CreateMessageMethodName { get; }
        protected string ProtocolMethodName { get; }

        protected CSharpType ProtocolMethodReturnType { get; }
        protected CSharpType ConvenienceMethodReturnType { get; }

        protected IReadOnlyList<Parameter> CreateMessageMethodParameters { get; }
        protected IReadOnlyList<Parameter> ProtocolMethodParameters { get; }
        protected IReadOnlyList<Parameter> ConvenienceMethodParameters { get; }

        protected OperationMethodsBuilderBase(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodReturnTypes returnTypes, ClientMethodParameters clientMethodParameters)
        {
            Operation = operation;
            ClientDiagnosticsDeclaration = fields.ClientDiagnosticsProperty.Declaration;
            PipelineField = new HttpPipelineExpression(fields.PipelineField.Declaration);
            RestClient = restClient;

            ProtocolMethodName = operation.Name.ToCleanName();
            CreateMessageMethodName = $"Create{ProtocolMethodName}Request";

            ProtocolMethodReturnType = returnTypes.ProtocolMethodReturnType;
            ConvenienceMethodReturnType = returnTypes.ConvenienceMethodReturnType;

            CreateMessageMethodParameters = clientMethodParameters.CreateMessage;
            ProtocolMethodParameters = clientMethodParameters.Protocol;
            ConvenienceMethodParameters = clientMethodParameters.Convenience;

            _fields = fields;
            _clientName = clientName;
            _typeFactory = typeFactory;
            _requestParts = clientMethodParameters.RequestParts;
            _summary = operation.Summary != null ? BuilderHelpers.EscapeXmlDescription(operation.Summary) : null;
            _description = BuilderHelpers.EscapeXmlDescription(operation.Description);
            _protocolAccessibility = operation.GenerateProtocolMethod ? GetAccessibility(operation.Accessibility) : MethodSignatureModifiers.Internal;
            _convenienceAccessibility = GetAccessibility(operation.Accessibility);
        }

        public LowLevelClientMethod BuildDpg()
        {
            var createRequestMethods = BuildCreateRequestMethods(null, null).ToArray();
            var protocolMethods = new[]{ BuildProtocolMethod(true), BuildProtocolMethod(false) };
            var convenienceMethods = Array.Empty<Method>();
            if (Operation.GenerateConvenienceMethod && ShouldConvenienceMethodGenerated())
            {
                var needNameChange = ProtocolMethodParameters.Where(p => !p.IsOptionalInSignature).SequenceEqual(ConvenienceMethodParameters.Where(p => !p.IsOptionalInSignature));
                var convenienceMethodName = needNameChange
                    ? ProtocolMethodName.IsLastWordSingular() ? $"{ProtocolMethodName}Value" : $"{ProtocolMethodName.LastWordToSingular()}Values"
                    : ProtocolMethodName;

                convenienceMethods = new[]{ BuildConvenienceMethod(convenienceMethodName, true), BuildConvenienceMethod(convenienceMethodName, false) };
            }

            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            return new LowLevelClientMethod(convenienceMethods, protocolMethods, createRequestMethods, requestBodyType, responseBodyType, Operation.Paging is not null, Operation.LongRunning is not null, Operation.Paging?.ItemName ?? "value");
        }

        public LegacyMethods BuildLegacy(DataPlaneResponseHeaderGroupType? headerModel, CSharpType? resourceDataType)
        {
            var createRequestMethods = BuildCreateRequestMethods(headerModel, resourceDataType).ToArray();
            var convenienceMethods = Operation.LongRunning is null
                ? new[]{ BuildLegacyConvenienceMethod(true), BuildLegacyConvenienceMethod(false) }
                : Array.Empty<Method>();

            return new LegacyMethods(Operation, createRequestMethods, convenienceMethods);
        }

        protected virtual IEnumerable<RestClientMethod> BuildCreateRequestMethods(DataPlaneResponseHeaderGroupType? headerModel, CSharpType? resourceDataType)
        {
            yield return RestClientBuilder.BuildRequestMethod(Operation, CreateMessageMethodParameters, _requestParts, headerModel, resourceDataType, _fields, _typeFactory);
        }

        private Method BuildLegacyCreateRequestMethod()
        {
            var signature = CreateMethodSignature(CreateMessageMethodName, MethodSignatureModifiers.Internal, CreateMessageMethodParameters, typeof(HttpMessage));
            return new Method(signature, BuildLegacyCreateRequestMethodBody().AsStatement());
        }

        private IEnumerable<MethodBodyStatement> BuildLegacyCreateRequestMethodBody()
        {
            var callPipelineCreateMessage = CreateMessageMethodParameters.Contains(KnownParameters.RequestContext)
                ? PipelineField.CreateMessage(new RequestContextExpression(KnownParameters.RequestContext))
                : PipelineField.CreateMessage();

            yield return Var("message", callPipelineCreateMessage, out var message);
            yield return Var("request", message.Request, out var request);
            if (Operation.BufferResponse)
            {
                yield return Assign(message.BufferResponse, False);
            }
            yield return Assign(request.Method, new MemberReference(typeof(RequestMethod), Operation.HttpMethod.ToRequestMethodName()));
            yield return Var("uri", RawRequestUriBuilderExpression.New(), out var uriBuilder);
            yield return AddUri(uriBuilder, Operation.Uri);
            yield return AddPath(uriBuilder, Operation.Path);
            yield return AddQuery(uriBuilder).AsStatement();
        }

        private List<MethodBodyStatement> AddUri(RawRequestUriBuilderExpression uriBuilder, string uri)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uri))
            {
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendRaw(span.ToString(), false));
                }
                else if (TryGetRequestPart(span, RequestLocation.Uri, out var inputParameter, out var reference, out _))
                {
                    lines.Add(uriBuilder.AppendRaw(reference, !inputParameter.SkipUrlEncoding));
                }
                else
                {
                    ErrorHelpers.ThrowError($"\n\nError while processing request '{uri}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                }
            }
            return lines;
        }

        private List<MethodBodyStatement> AddPath(RawRequestUriBuilderExpression uriBuilder, string path)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(path))
            {
                var text = span.ToString();
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendPath(span.ToString(), false));
                }
                else if (TryGetRequestPart(span, RequestLocation.Uri, out var inputParameter, out var reference, out var format))
                {
                    var formatSpecifier = format.ToFormatSpecifier();
                    lines.Add(formatSpecifier is not null
                        ? uriBuilder.AppendPath(reference, formatSpecifier, !inputParameter.SkipUrlEncoding)
                        : uriBuilder.AppendPath(reference, !inputParameter.SkipUrlEncoding));
                }
                else
                {
                    ErrorHelpers.ThrowError($"\n\nError while processing request '{path}'\n\n  '{text}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                }
            }
            return lines;
        }

        private IEnumerable<MethodBodyStatement> AddQuery(RawRequestUriBuilderExpression uriBuilder)
        {
            foreach (var (nameInRequest, inputParameter, outputParameter, serializationFormat) in _requestParts)
            {
                if (inputParameter is not null && inputParameter.Location == RequestLocation.Query)
                {
                    // nameInRequest, reference, inputParameter.ArraySerializationDelimiter, escape, serializationFormat, inputParameter.Explode
                }
            }
            yield break;
        }

        private bool TryGetRequestPart(in ReadOnlySpan<char> key, in RequestLocation location, [MaybeNullWhen(false)] out InputParameter inputParameter, [MaybeNullWhen(false)] out ValueExpression reference, out SerializationFormat serializationFormat)
        {
            foreach (var part in _requestParts)
            {
                if (part.InputParameter?.Location == location && part.NameInRequest.AsSpan().Equals(key, StringComparison.InvariantCulture))
                {
                    inputParameter = part.InputParameter;
                    reference = part.SerializationFormat != SerializationFormat.Default && part.OutputParameter.Type.IsFrameworkType
                        ? CreateConversion(CreateValueForRequestPart(part), part.OutputParameter.Type, part.OutputParameter.Type.WithNullable(false))
                        : CreateConversion(CreateValueForRequestPart(part), part.OutputParameter.Type, typeof(string));
                    serializationFormat = part.SerializationFormat;
                    return true;
                }
            }

            inputParameter = null;
            reference = null;
            serializationFormat = SerializationFormat.Default;
            return false;
        }

        private ValueExpression CreateValueForRequestPart(RequestPartSource part)
        {
            var inputParameter = part.InputParameter;
            var outputParameter = part.OutputParameter;

            if (inputParameter is null)
            {
                return outputParameter;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Client)
            {
                var field = inputParameter.IsEndpoint ? _fields.EndpointField : _fields.GetFieldByParameter(outputParameter);
                if (field == null)
                {
                    throw new InvalidOperationException($"Parameter {outputParameter.Name} should have matching field");
                }

                return field.Declaration;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Constant && outputParameter.DefaultValue is {} defaultValue)
            {
                return new ConstantExpression(defaultValue);
            }

            var groupedByParameter = inputParameter.GroupedBy;
            if (groupedByParameter != null)
            {
                var groupModel = (SchemaObjectType)_typeFactory.CreateType(groupedByParameter.Type with { IsNullable = false }).Implementation;
                var property = groupModel.GetPropertyForGroupedParameter(inputParameter.Name);

                return new MemberReference(new FormattableStringToExpression($"{groupedByParameter.Name.ToVariableName()}"), property.Declaration.Name);
            }

            return outputParameter;
        }

        protected virtual bool ShouldConvenienceMethodGenerated()
        {
            return !Operation.GenerateProtocolMethod
                || !ConvenienceMethodParameters.Where(p => p != KnownParameters.CancellationTokenParameter).SequenceEqual(ProtocolMethodParameters.Where(p => p != KnownParameters.RequestContext));
        }

        protected string CreateScopeName(string methodName) => $"{_clientName}.{methodName}";

        private Method BuildProtocolMethod(bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, _protocolAccessibility, ProtocolMethodParameters, ProtocolMethodReturnType);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters),
                CreateProtocolMethodBody(async)
            };
            return new Method(signature.WithAsync(async), body);
        }

        private Method BuildConvenienceMethod(string methodName, bool async)
        {
            var signature = CreateMethodSignature(methodName, _convenienceAccessibility, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters),
                CreateConvenienceMethodBody(methodName, async)
            };
            return new Method(signature.WithAsync(async), body);
        }

        private Method BuildLegacyConvenienceMethod(bool async)
        {
            var signature = CreateMethodSignature(ProtocolMethodName, _convenienceAccessibility, ConvenienceMethodParameters, ConvenienceMethodReturnType);
            var body = CreateLegacyConvenienceMethodBody(async);
            return new Method(signature.WithAsync(async), body);
        }

        private MethodSignature CreateMethodSignature(string name, MethodSignatureModifiers accessibility, IReadOnlyList<Parameter> parameters, CSharpType returnType)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _summary, _description, accessibility | MethodSignatureModifiers.Virtual, returnType, null, parameters, attributes);
        }

        protected abstract MethodBodyStatement CreateProtocolMethodBody(bool async);

        protected abstract MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async);

        protected abstract MethodBodyStatement CreateLegacyConvenienceMethodBody(bool async);

        protected MethodBodyStatement WrapInDiagnosticScope(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), _fields.ClientDiagnosticsProperty, statements);

        protected MethodBodyStatement WrapInDiagnosticScopeLegacy(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), new Reference($"_{KnownParameters.ClientDiagnostics.Name}", KnownParameters.ClientDiagnostics.Type), statements);

        protected static IEnumerable<MethodBodyStatement> CreateSpreadConversion(Utf8JsonWriterExpression utf8JsonWriter, IReadOnlyList<MethodParametersBuilder.JsonSpreadParameterSerialization> serializations)
        {
            yield return utf8JsonWriter.WriteStartObject();
            foreach (var (parameter, serializedName, valueSerialization, isRequired) in serializations)
            {
                yield return CreateSpreadWriteProperty(utf8JsonWriter, parameter, serializedName, valueSerialization, isRequired);
            }
            yield return utf8JsonWriter.WriteEndObject();
        }

        private static MethodBodyStatement CreateSpreadWriteProperty(Utf8JsonWriterExpression utf8JsonWriter, Parameter parameter, string serializedName, JsonSerialization valueSerialization, bool isRequired)
        {
            var writeProperty = new[]
            {
                utf8JsonWriter.WritePropertyName(serializedName),
                JsonSerializationMethodsBuilder.SerializeExpression(utf8JsonWriter, valueSerialization, parameter)
            };

            if (isRequired)
            {
                return parameter.Type.IsNullable
                    ? new IfElseStatement(Snippets.IsNotNull(parameter), writeProperty, utf8JsonWriter.WriteNull(serializedName))
                    : writeProperty;
            }

            var condition = TypeFactory.IsCollectionType(parameter.Type)
                ? parameter.Type.IsNullable
                    ? Snippets.And(Snippets.IsNotNull(parameter), Snippets.InvokeOptional.IsCollectionDefined(parameter))
                    : Snippets.InvokeOptional.IsCollectionDefined(parameter)
                : Snippets.InvokeOptional.IsDefined(parameter);

            return new IfElseStatement(condition, writeProperty, null);
        }

        protected HttpMessageExpression InvokeCreateRequestMethod()
            => new(new InvokeInstanceMethodExpression(null, CreateMessageMethodName, CreateMessageMethodParameters.Select(p => new ParameterReference(p)).ToList(), null, false));

        protected ResponseExpression InvokeProtocolMethod(ValueExpression? instance, IReadOnlyList<ValueExpression> arguments, bool async)
            => new(new InvokeInstanceMethodExpression(instance, async ? $"{ProtocolMethodName}Async" : ProtocolMethodName, arguments, null, async));

        protected ValueExpression InvokeProtocolOperationHelpersConvertMethod(SerializableObjectType responseType, ResponseExpression response, string scopeName)
        {
            var arguments = new[] { response, SerializableObjectTypeExpression.FromResponseDelegate(responseType), _fields.ClientDiagnosticsProperty, Snippets.Literal(scopeName) };
            return new InvokeStaticMethodExpression(typeof(ProtocolOperationHelpers), nameof(ProtocolOperationHelpers.Convert), arguments);
        }

        protected static ValueExpression CreateConversion(Parameter fromParameter, CSharpType toType)
        {
            return CreateConversion(fromParameter, fromParameter.Type, toType);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, CSharpType fromType, CSharpType toType)
        {
            if (fromType.IsNullable)
            {
                fromExpression = new NullConditionalExpression(fromExpression);
            }

            return fromType.IsFrameworkType
                ? CreateConversion(fromExpression, fromType.FrameworkType, toType)
                : CreateConversion(fromExpression, fromType.Implementation, toType);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, Type fromFrameworkType, CSharpType toType)
        {
            if ((fromFrameworkType == typeof(BinaryData) || fromFrameworkType == typeof(string)) && toType.EqualsIgnoreNullable(typeof(RequestContent)))
            {
                return fromExpression;
            }

            return RequestContentExpression.Create(fromExpression);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, TypeProvider fromTypeImplementation, CSharpType toType)
        {
            return fromTypeImplementation switch
            {
                EnumType enumType           when toType.EqualsIgnoreNullable(typeof(string)) => new EnumExpression(enumType, fromExpression).ToSerial(),
                SerializableObjectType type when toType.EqualsIgnoreNullable(typeof(RequestContent)) => new SerializableObjectTypeExpression(type, fromExpression).ToRequestContent(),
                _ => fromExpression
            };
        }

        private static MethodSignatureModifiers GetAccessibility(string? accessibility) => accessibility switch
        {
            "public" => MethodSignatureModifiers.Public,
            "internal" => MethodSignatureModifiers.Internal,
            "protected" => MethodSignatureModifiers.Protected,
            "private" => MethodSignatureModifiers.Private,
            null => MethodSignatureModifiers.Public,
            _ => throw new NotSupportedException()
        };
    }
}
