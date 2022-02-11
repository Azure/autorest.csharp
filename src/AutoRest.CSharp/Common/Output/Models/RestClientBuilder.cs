// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Operation = AutoRest.CSharp.Input.Operation;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using Response = AutoRest.CSharp.Output.Models.Responses.Response;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class RestClientBuilder
    {
        private static readonly HashSet<string> IgnoredRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            "x-ms-client-request-id",
            "tracestate",
            "traceparent"
        };

        private static readonly Dictionary<string, RequestConditionHeaders> ConditionRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            ["If-Match"] = RequestConditionHeaders.IfMatch,
            ["If-None-Match"] = RequestConditionHeaders.IfNoneMatch,
            ["If-Modified-Since"] = RequestConditionHeaders.IfModifiedSince,
            ["If-Unmodified-Since"] = RequestConditionHeaders.IfUnmodifiedSince
        };

        private readonly SerializationBuilder _serializationBuilder;
        protected readonly BuildContext _context;
        private readonly OutputLibrary _library;
        private readonly Dictionary<string, Parameter> _parameters;


        public RestClientBuilder(ICollection<Operation> operations, BuildContext context)
            : this(GetParametersFromOperations(operations), context)
        {
        }

        public RestClientBuilder(IEnumerable<RequestParameter> clientParameters, BuildContext context)
        {
            _serializationBuilder = new SerializationBuilder();
            _context = context;
            _library = context.BaseLibrary!;
            _parameters = clientParameters.ToDictionary(p => p.Language.Default.Name, BuildConstructorParameter);
        }

        /// <summary>
        /// Get sorted parameters, required parameters are at the beginning.
        /// </summary>
        /// <returns></returns>
        public Parameter[] GetOrderedParametersByRequired()
        {
            return OrderParametersByRequired(_parameters.Values);
        }

        public static IEnumerable<RequestParameter> GetParametersFromOperations(ICollection<Operation> operations) =>
            operations
                .SelectMany(op => op.Parameters.Concat(op.Requests.SelectMany(r => r.Parameters)))
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct();

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        public RestClientMethod BuildRequestMethod(Operation operation, ServiceRequest serviceRequest, HttpRequest httpRequest)
        {
            var accessibility = operation.Accessibility ?? "public";
            var requestParameters = operation.Parameters
                .Concat(serviceRequest.Parameters)
                .Where(rp => !IsIgnoredHeaderParameter(rp));

            var buildContext = CreateRequestMethodBuildContext(httpRequest, requestParameters);
            Request request = BuildRequest(httpRequest, buildContext);

            var isHeadAsBoolean = request.HttpMethod == RequestMethod.Head && _context.Configuration.HeadAsBoolean;
            Response[] responses = BuildResponses(operation, isHeadAsBoolean, out var responseType);

            return new RestClientMethod(
                operation.CSharpName(),
                BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                responseType,
                request,
                buildContext.OrderedParameters.ToArray(),
                responses,
                null,
                operation.Extensions?.BufferResponse ?? true,
                accessibility: accessibility,
                operation
            );
        }

        /// <summary>
        /// Build RestClientMethod for mgmt and HLC
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="httpRequest"></param>
        /// <param name="requestParameters"></param>
        /// <param name="responseHeaderModel"></param>
        /// <param name="accessibility"></param>
        /// <param name="returnNullOn404Func"></param>
        /// <returns></returns>
        public RestClientMethod BuildMethod(Operation operation, HttpRequest httpRequest, IEnumerable<RequestParameter> requestParameters, DataPlaneResponseHeaderGroupType? responseHeaderModel, string accessibility, Func<string?, bool>? returnNullOn404Func = null)
        {
            var allParameters = GetOperationAllParameters(operation, requestParameters);
            var methodParameters = BuildMethodParameters(allParameters);
            var references = allParameters.ToDictionary(kvp => GetRequestParameterName(kvp.Key), kvp => new ParameterInfo(kvp.Key, CreateReference(kvp.Key, kvp.Value)));
            var request = BuildRequest(httpRequest, new RequestMethodBuildContext(methodParameters, references));

            var isHeadAsBoolean = request.HttpMethod == RequestMethod.Head && _context.Configuration.HeadAsBoolean;
            Response[] responses = BuildResponses(operation, isHeadAsBoolean, out var responseType, returnNullOn404Func);

            return new RestClientMethod(
                operation.CSharpName(),
                BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                responseType,
                request,
                methodParameters,
                responses,
                responseHeaderModel,
                operation.Extensions?.BufferResponse ?? true,
                accessibility: accessibility,
                operation
            );
        }

        private Dictionary<RequestParameter, Parameter> GetOperationAllParameters(Operation operation, IEnumerable<RequestParameter> requestParameters)
        {
            var parameters = operation.Parameters
                .Concat(requestParameters)
                .Where(rp => !IsIgnoredHeaderParameter(rp))
                .ToArray();

            return parameters.ToDictionary(rp => rp, requestParameter => BuildParameter(requestParameter));
        }

        private Response[] BuildResponses(Operation operation, bool headAsBoolean, out CSharpType? responseType, Func<string?, bool>? returnNullOn404Func = null)
        {
            if (headAsBoolean)
            {
                responseType = new CSharpType(typeof(bool));
                return new[]
                {
                    new Response(
                        new ConstantResponseBody(new Constant(true, responseType)),
                        new[] {new StatusCodes(null, 2)}),
                    new Response(
                        new ConstantResponseBody(new Constant(false, responseType)),
                        new[] {new StatusCodes(null, 4)}),
                };
            }

            List<Response> clientResponse = new List<Response>();
            foreach (var response in operation.Responses)
            {
                List<StatusCodes> statusCodes = new List<StatusCodes>();
                foreach (var statusCode in response.HttpResponse.IntStatusCodes)
                {
                    statusCodes.Add(new StatusCodes(statusCode, null));
                }

                clientResponse.Add(new Response(
                    operation.IsLongRunning ? null : BuildResponseBody(response),
                    statusCodes.ToArray()
                ));
            }

            if (returnNullOn404Func != null && returnNullOn404Func(clientResponse.FirstOrDefault()?.ResponseBody?.Type.Name))
                clientResponse.Add(new Response(null, new[] { new StatusCodes(404, null) }));

            responseType = ReduceResponses(clientResponse);
            return clientResponse.ToArray();
        }

        private RequestMethodBuildContext CreateRequestMethodBuildContext(HttpRequest httpRequest, IEnumerable<RequestParameter> requestParameters)
        {
            var pathParameters = new Dictionary<string, RequestParameter>();
            var requiredRequestParameters = new List<RequestParameter>();
            var optionalRequestParameters = new List<RequestParameter>();

            var requestConditionHeaders = RequestConditionHeaders.None;
            var requestConditionSerializationFormat = SerializationFormat.Default;
            RequestParameter? contentTypeRequestParameter = null;
            RequestParameter? requestConditionRequestParameter = null;

            Parameter? bodyParameter = null;

            foreach (var requestParameter in requestParameters)
            {
                switch (requestParameter)
                {
                    case { In: ParameterLocation.Body } when bodyParameter != KnownParameters.RequestContent:
                        bodyParameter = requestParameter.IsRequired ? KnownParameters.RequestContent : KnownParameters.RequestContentNullable;
                        break;
                    case { In: ParameterLocation.Header, Origin: "modelerfour:synthesized/content-type" } when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = requestParameter;
                        break;
                    case { In: ParameterLocation.Header } when ConditionRequestHeader.TryGetValue(GetRequestParameterName(requestParameter), out var header):
                        if (requestParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        requestConditionHeaders |= header;
                        requestConditionRequestParameter ??= requestParameter;
                        requestConditionSerializationFormat = requestConditionSerializationFormat == SerializationFormat.Default
                            ? GetSerializationFormat(requestParameter)
                            : requestConditionSerializationFormat;

                        break;
                    case { In: ParameterLocation.Uri or ParameterLocation.Path }:
                        pathParameters.Add(GetRequestParameterName(requestParameter), requestParameter);
                        break;
                    case { Required: true } when !HasDefaultValue(requestParameter):
                        requiredRequestParameters.Add(requestParameter);
                        break;
                    default:
                        optionalRequestParameters.Add(requestParameter);
                        break;
                }
            }

            var parameters = new RequestMethodParametersBuilder(this);
            parameters.AddUriOrPathParameters(httpRequest.Uri, pathParameters);
            parameters.AddUriOrPathParameters(httpRequest.Path, pathParameters);
            parameters.AddQueryOrHeaderParameters(requiredRequestParameters);
            parameters.AddBody(bodyParameter, contentTypeRequestParameter);
            parameters.AddQueryOrHeaderParameters(optionalRequestParameters);
            parameters.AddRequestConditionHeaders(requestConditionHeaders, requestConditionRequestParameter);
            parameters.AddRequestContext();

            return new RequestMethodBuildContext(parameters.OrderedParameters, parameters.References, bodyParameter, requestConditionSerializationFormat);
        }

        private Request BuildRequest(HttpRequest httpRequest, RequestMethodBuildContext buildContext)
        {
            var uriParametersMap = new Dictionary<string, PathSegment>();
            var pathParametersMap = new Dictionary<string, PathSegment>();
            var queryParameters = new List<QueryParameter>();
            var headerParameters = new List<RequestHeader>();
            foreach (var (parameterName, (requestParameter, reference)) in buildContext.References)
            {
                if (requestParameter == null)
                {
                    if (parameterName == KnownParameters.MatchConditionsParameter.Name || parameterName == KnownParameters.RequestConditionsParameter.Name)
                    {
                        headerParameters.Add(new RequestHeader(parameterName, reference, RequestParameterSerializationStyle.Simple, buildContext.ConditionalRequestSerializationFormat));
                    }
                    continue;
                }

                var serializationFormat = GetSerializationFormat(requestParameter);
                var escape = !requestParameter.Extensions!.SkipEncoding;

                switch (requestParameter.In)
                {
                    case ParameterLocation.Uri:
                        uriParametersMap.Add(parameterName, new PathSegment(reference, escape, serializationFormat, isRaw: true));
                        break;
                    case ParameterLocation.Path:
                        pathParametersMap.Add(parameterName, new PathSegment(reference, escape, serializationFormat, isRaw: false));
                        break;
                    case ParameterLocation.Query:
                        queryParameters.Add(new QueryParameter(parameterName, reference, GetSerializationStyle(requestParameter), escape, serializationFormat, GetExplode(requestParameter)));
                        break;
                    case ParameterLocation.Header:
                        var headerName = requestParameter.Extensions?.HeaderCollectionPrefix ?? parameterName;
                        headerParameters.Add(new RequestHeader(headerName, reference, GetSerializationStyle(requestParameter), serializationFormat));
                        break;
                }
            }

            var uriParameters = GetPathSegments(httpRequest.Uri, uriParametersMap, isRaw: true);
            var pathParameters = GetPathSegments(httpRequest.Path, pathParametersMap, isRaw: false);

            var body = buildContext.BodyParameter != null
                ? new RequestContentRequestBody(buildContext.BodyParameter)
                : httpRequest is HttpWithBodyRequest httpWithBodyRequest
                    ? BuildRequestBody(buildContext.References, httpWithBodyRequest.KnownMediaType)
                    : null;

            return new Request(
                httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                uriParameters.Concat(pathParameters).ToArray(),
                queryParameters.ToArray(),
                headerParameters.ToArray(),
                body
            );
        }

        protected virtual Parameter[] BuildMethodParameters(IReadOnlyDictionary<RequestParameter, Parameter> allParameters)
        {
            List<Parameter> methodParameters = new();
            foreach (var (requestParameter, parameter) in allParameters)
            {
                // Grouped and flattened parameters shouldn't be added to methods
                if (IsMethodParameter(requestParameter))
                {
                    methodParameters.Add(parameter);
                }
            }

            return OrderParametersByRequired(methodParameters);
        }

        private RequestBody? BuildRequestBody(IReadOnlyDictionary<string, ParameterInfo> allParameters, KnownMediaType mediaType)
        {
            RequestBody? body = null;

            Dictionary<RequestParameter, ReferenceOrConstant> bodyParameters = new();
            foreach (var (_, (requestParameter, value)) in allParameters)
            {
                if (requestParameter is {In: ParameterLocation.Body})
                {
                    bodyParameters[requestParameter] = value;
                }
            }

            if (bodyParameters.Count > 0)
            {
                if (mediaType == KnownMediaType.Multipart)
                {
                    List<MultipartRequestBodyPart> value = new List<MultipartRequestBodyPart>();
                    foreach (var parameter in bodyParameters)
                    {
                        var type = parameter.Value.Type;
                        RequestBody requestBody;

                        if (type.Equals(typeof(string)))
                        {
                            requestBody = new TextRequestBody(parameter.Value);
                        }
                        else if (type.IsFrameworkType && type.FrameworkType == typeof(Stream))
                        {
                            requestBody = new BinaryRequestBody(parameter.Value);
                        }
                        else if (TypeFactory.IsList(type))
                        {
                            requestBody = new BinaryCollectionRequestBody(parameter.Value);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }

                        value.Add(new MultipartRequestBodyPart(parameter.Value.Reference.Name, requestBody));
                    }

                    body = new MultipartRequestBody(value.ToArray());
                }
                else if (mediaType == KnownMediaType.Form)
                {
                    UrlEncodedBody urlbody = new UrlEncodedBody();
                    foreach (var (bodyRequestParameter, bodyParameterValue) in bodyParameters)
                    {
                        urlbody.Add(GetRequestParameterName(bodyRequestParameter), bodyParameterValue);
                    }

                    body = urlbody;
                }
                else
                {
                    Debug.Assert(bodyParameters.Count == 1);
                    var (bodyRequestParameter, bodyParameterValue) = bodyParameters.Single();
                    if (mediaType == KnownMediaType.Binary ||
                        // WORKAROUND: https://github.com/Azure/autorest.modelerfour/issues/360
                        bodyRequestParameter.Schema is BinarySchema)
                    {
                        body = new BinaryRequestBody(bodyParameterValue);
                    }
                    else if (mediaType == KnownMediaType.Text)
                    {
                        body = new TextRequestBody(bodyParameterValue);
                    }
                    else
                    {
                        var serialization = _serializationBuilder.Build(
                            mediaType,
                            bodyRequestParameter.Schema,
                            bodyParameterValue.Type);

                        // This method has a flattened body
                        if (bodyRequestParameter.Flattened == true)
                        {
                            var objectType = (SchemaObjectType)_library.FindTypeForSchema(bodyRequestParameter.Schema).Implementation;

                            var initializationMap = new List<ObjectPropertyInitializer>();
                            foreach (var (parameter, _) in allParameters.Values)
                            {
                                if (parameter is not VirtualParameter virtualParameter || virtualParameter.Schema is ConstantSchema)
                                {
                                    continue;
                                }

                                initializationMap.Add(new ObjectPropertyInitializer(
                                    objectType.GetPropertyForSchemaProperty(virtualParameter.TargetProperty, true),
                                    allParameters[GetRequestParameterName(virtualParameter)].Reference));
                            }

                            body = new FlattenedSchemaRequestBody(objectType, initializationMap.ToArray(), serialization);
                        }
                        else
                        {
                            body = new SchemaRequestBody(bodyParameterValue, serialization);
                        }
                    }
                }
            }

            return body;
        }

        private ReferenceOrConstant CreateReference(RequestParameter requestParameter, Parameter parameter)
        {
            if (requestParameter.Implementation != ImplementationLocation.Method)
            {
                return (ReferenceOrConstant) _parameters[requestParameter.Language.Default.Name];
            }

            if (requestParameter.Schema is ConstantSchema constant)
            {
                return ParseConstant(constant);
            }

            var groupedByParameter = requestParameter.GroupedBy;
            if (groupedByParameter == null)
            {
                return parameter;
            }

            var groupModel = (SchemaObjectType)_context.TypeFactory.CreateType(groupedByParameter.Schema, false).Implementation;
            var property = groupModel.GetPropertyForGroupedParameter(requestParameter);

            return new Reference($"{groupedByParameter.CSharpName()}.{property.Declaration.Name}", property.Declaration.Type);

        }

        private static SerializationFormat GetSerializationFormat(RequestParameter requestParameter)
            => BuilderHelpers.GetSerializationFormat(GetValueSchema(requestParameter));

        private ResponseBody? BuildResponseBody(ServiceResponse response)
        {
            if (response.HttpResponse.KnownMediaType == KnownMediaType.Text)
            {
                return new StringResponseBody();
            }
            else if (response is SchemaResponse schemaResponse)
            {
                Schema schema = schemaResponse.Schema is ConstantSchema constantSchema ? constantSchema.ValueType : schemaResponse.Schema;
                CSharpType responseType = TypeFactory.GetOutputType(_context.TypeFactory.CreateType(schema, isNullable: schemaResponse.IsNullable));

                ObjectSerialization serialization = _serializationBuilder.Build(response.HttpResponse.KnownMediaType, schema, responseType);

                return new ObjectResponseBody(responseType, serialization);
            }
            else if (response is BinaryResponse)
            {
                return new StreamResponseBody();
            }

            return null;
        }

        private static RequestParameterSerializationStyle GetSerializationStyle(RequestParameter requestParameter)
        {
            var valueSchema = GetValueSchema(requestParameter);
            var httpParameter = requestParameter.Protocol.Http as HttpParameter;

            Debug.Assert(httpParameter!.In == ParameterLocation.Query || httpParameter.In == ParameterLocation.Header);

            switch (httpParameter.Style)
            {
                case null:
                case SerializationStyle.Form:
                case SerializationStyle.Simple:
                    return valueSchema is ArraySchema ? RequestParameterSerializationStyle.CommaDelimited : RequestParameterSerializationStyle.Simple;
                case SerializationStyle.PipeDelimited:
                    return RequestParameterSerializationStyle.PipeDelimited;
                case SerializationStyle.SpaceDelimited:
                    return RequestParameterSerializationStyle.SpaceDelimited;
                case SerializationStyle.TabDelimited:
                    return RequestParameterSerializationStyle.TabDelimited;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static bool GetExplode(RequestParameter requestParameter) => requestParameter.Protocol.Http is HttpParameter httpParameter && httpParameter.Explode == true;

        private static Schema GetValueSchema(RequestParameter requestParameter)
        {
            Schema valueSchema = requestParameter.Schema;
            return requestParameter.Schema is ConstantSchema constant
                ? constant.ValueType
                : valueSchema;
        }

        private static IEnumerable<PathSegment> GetPathSegments(string httpRequestUri, IReadOnlyDictionary<string, PathSegment> parameters, bool isRaw)
        {
            var segments = new List<PathSegment>();

            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                var text = span.ToString();
                if (isLiteral)
                {
                    segments.Add(new PathSegment(BuilderHelpers.StringConstant(text), false, SerializationFormat.Default, isRaw));
                }
                else
                {
                    if (parameters.TryGetValue(text, out var parameter))
                    {
                        segments.Add(parameter);
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{httpRequestUri}'\n\n  '{text}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }
                }
            }

            return segments;
        }

        /// <summary>
        /// Sort the parameters, move required parameters at the beginning, in order.
        /// </summary>
        /// <param name="parameters">Parameters to sort</param>
        /// <returns></returns>
        private static Parameter[] OrderParametersByRequired(IEnumerable<Parameter> parameters) => parameters.OrderBy(p => p.DefaultValue != null).ToArray();

        // Merges operations without response types types together
        private CSharpType? ReduceResponses(List<Response> responses)
        {
            foreach (var typeGroup in responses.GroupBy(r => r.ResponseBody))
            {
                foreach (var individualResponse in typeGroup)
                {
                    responses.Remove(individualResponse);
                }

                responses.Add(new Response(
                    typeGroup.Key,
                    typeGroup.SelectMany(r => r.StatusCodes).Distinct().ToArray()));
            }

            var bodyTypes = responses.Select(r => r.ResponseBody?.Type)
                .OfType<CSharpType>()
                .Distinct()
                .ToArray();

            return bodyTypes.Length switch
            {
                0 => null,
                1 => bodyTypes[0],
                _ => typeof(object)
            };
        }

        public virtual Parameter BuildConstructorParameter(RequestParameter requestParameter)
        {
            var parameter = BuildParameter(requestParameter);
            if (IsEndpointParameter(requestParameter))
            {
                parameter = new Parameter(
                    "endpoint",
                    parameter.Description,
                    typeof(Uri),
                    parameter.DefaultValue,
                    parameter.Validate,
                    RequestLocation: GetRequestLocation(requestParameter)
                );
            }

            return parameter;
        }

        protected static bool IsMethodParameter(RequestParameter requestParameter)
            => requestParameter.Implementation == ImplementationLocation.Method && requestParameter.Schema is not ConstantSchema && !requestParameter.IsFlattened && requestParameter.GroupedBy == null;

        public static bool IsEndpointParameter(RequestParameter requestParameter)
            => requestParameter.Origin == "modelerfour:synthesized/host";

        public static bool IsContentTypeParameter(RequestParameter requestParameter)
            => requestParameter.Origin == "modelerfour:synthesized/content-type";

        public static bool IsIgnoredHeaderParameter(RequestParameter requestParameter)
            => requestParameter.In == ParameterLocation.Header && IgnoredRequestHeader.Contains(GetRequestParameterName(requestParameter));

        private static bool IsRequestConditionHeader(RequestParameter requestParameter, out RequestConditionHeaders header)
        {
            header = RequestConditionHeaders.None;
            return requestParameter.In == ParameterLocation.Header && ConditionRequestHeader.TryGetValue(GetRequestParameterName(requestParameter), out header);
        }

        private Parameter BuildParameter(RequestParameter requestParameter, Type? frameworkParameterType = null)
        {
            CSharpType type = frameworkParameterType != null
                ? new CSharpType(frameworkParameterType, requestParameter.IsNullable || !requestParameter.IsRequired)
                : _context.TypeFactory.CreateType(requestParameter.Schema, requestParameter.IsNullable || !requestParameter.IsRequired);

            var defaultValue = ParseConstant(requestParameter);

            if (defaultValue != null && !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                type = type.WithNullable(true);
            }

            if (!requestParameter.IsRequired && defaultValue == null)
            {
                defaultValue = Constant.Default(type);
            }

            return new Parameter(
                requestParameter.CSharpName(),
                CreateDescription(requestParameter, type),
                TypeFactory.GetInputType(type),
                defaultValue,
                requestParameter.IsRequired,
                IsApiVersionParameter: requestParameter.Origin == "modelerfour:synthesized/api-version",
                IsResourceIdentifier: requestParameter.IsResourceParameter,
                SkipUrlEncoding: requestParameter.Extensions?.SkipEncoding ?? false,
                RequestLocation: GetRequestLocation(requestParameter));
        }

        private Constant ParseConstant(ConstantSchema constant) =>
            BuilderHelpers.ParseConstant(constant.Value.Value, _context.TypeFactory.CreateType(constant.ValueType, constant.Value.Value == null));

        protected Constant? ParseConstant(RequestParameter parameter)
        {
            if (parameter.ClientDefaultValue != null)
            {
                CSharpType constantTypeReference = _context.TypeFactory.CreateType(parameter.Schema, parameter.IsNullable);
                return BuilderHelpers.ParseConstant(parameter.ClientDefaultValue, constantTypeReference);
            }

            if (parameter.Schema is ConstantSchema constantSchema)
            {
                return ParseConstant(constantSchema);
            }

            return null;
        }

        private static bool HasDefaultValue(RequestParameter parameter)
            => parameter.ClientDefaultValue != null || parameter.Schema is ConstantSchema;

        private static string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"The {clientPrefix} service client." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        protected static string CreateDescription(RequestParameter requestParameter, CSharpType type)
        {
            var description = string.IsNullOrWhiteSpace(requestParameter.Language.Default.Description) ?
                $"The {requestParameter.Schema.Name} to use." :
                BuilderHelpers.EscapeXmlDescription(requestParameter.Language.Default.Description);

            return requestParameter.Schema switch
            {
                ChoiceSchema choiceSchema when type.IsFrameworkType => AddAllowedValues(description, choiceSchema.Choices),
                SealedChoiceSchema sealedChoiceSchema when type.IsFrameworkType => AddAllowedValues(description, sealedChoiceSchema.Choices),
                _ => description
            };

            static string AddAllowedValues(string description, ICollection<ChoiceValue> choices)
            {
                var allowedValues = string.Join(" | ", choices.Select(c => c.Value).Select(v => $"\"{v}\""));

                return string.IsNullOrEmpty(allowedValues)
                    ? description
                    : $"{description}{(description.EndsWith(".") ? "" : ".")} Allowed values: {BuilderHelpers.EscapeXmlDescription(allowedValues)}";
            }
        }

        public static RestClientMethod BuildNextPageMethod(RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                typeof(string),
                DefaultValue: null,
                Validate: true);

            PathSegment[] pathSegments = method.Request.PathSegments
                .Where(ps => ps.IsRaw)
                .Append(new PathSegment(nextPageUrlParameter, false, SerializationFormat.Default, isRaw: true))
                .ToArray();

            var request = new Request(
                RequestMethod.Get,
                pathSegments,
                Array.Empty<QueryParameter>(),
                method.Request.Headers,
                null);

            Parameter[] parameters = method.Parameters.Where(p => p.Name != nextPageUrlParameter.Name)
                .Prepend(nextPageUrlParameter)
                .ToArray();

            var responses = method.Responses;

            // We hardcode 200 as expected response code for paged LRO results
            if (method.Operation.IsLongRunning)
            {
                responses = new[]
                {
                    new Response(null, new[] { new StatusCodes(200, null) })
                };
            }

            return new RestClientMethod(
                $"{method.Name}NextPage",
                method.Description,
                method.ReturnType,
                request,
                parameters,
                responses,
                method.HeaderModel,
                bufferResponse: true,
                accessibility: "internal",
                method.Operation);
        }

        public static IEnumerable<Parameter> GetRequiredParameters(IEnumerable<Parameter> parameters)
            => parameters.Where(parameter => parameter.DefaultValue == null).ToList();

        public static IEnumerable<Parameter> GetOptionalParameters(IEnumerable<Parameter> parameters, bool includeAPIVersion = false)
            => parameters.Where(parameter => parameter.DefaultValue != null && (includeAPIVersion || !parameter.IsApiVersionParameter)).ToList();

        public static IReadOnlyCollection<Parameter> GetConstructorParameters(IReadOnlyList<Parameter> parameters, CSharpType? credentialType, bool includeAPIVersion = false)
        {
            List<Parameter> constructorParameters = new List<Parameter>();

            constructorParameters.AddRange(GetRequiredParameters(parameters));

            if (credentialType != null)
            {
                var credentialParam = new Parameter(
                    "credential",
                    "A credential used to authenticate to an Azure Service.",
                    credentialType!,
                    null,
                    true);
                constructorParameters.Add(credentialParam);
            }

            constructorParameters.AddRange(GetOptionalParameters(parameters, includeAPIVersion));

            return constructorParameters;
        }

        protected static RequestLocation GetRequestLocation(RequestParameter requestParameter)
            => requestParameter.In switch
            {
                ParameterLocation.Uri => RequestLocation.Uri,
                ParameterLocation.Path => RequestLocation.Path,
                ParameterLocation.Query => RequestLocation.Query,
                ParameterLocation.Header => RequestLocation.Header,
                ParameterLocation.Body => RequestLocation.Body,
                _ => RequestLocation.None
            };

        private record RequestMethodBuildContext(IReadOnlyList<Parameter> OrderedParameters, IReadOnlyDictionary<string, ParameterInfo> References, Parameter? BodyParameter = null, SerializationFormat ConditionalRequestSerializationFormat = SerializationFormat.Default);

        private readonly record struct ParameterInfo(RequestParameter? Parameter, ReferenceOrConstant Reference);

        private readonly ref struct RequestMethodParametersBuilder
        {
            private readonly RestClientBuilder _parent;
            private readonly Dictionary<string, ParameterInfo> _referencesByName;
            private readonly List<Parameter> _parameters;

            public IReadOnlyList<Parameter> OrderedParameters => _parameters;
            public IReadOnlyDictionary<string, ParameterInfo> References => _referencesByName;

            public RequestMethodParametersBuilder(RestClientBuilder parent)
            {
                _parent = parent;
                _referencesByName = new Dictionary<string, ParameterInfo>();
                _parameters = new List<Parameter>();
            }

            public void AddUriOrPathParameters(string uriPart, IReadOnlyDictionary<string, RequestParameter> requestParameters)
            {
                foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uriPart))
                {
                    if (isLiteral)
                    {
                        continue;
                    }

                    var text = span.ToString();
                    if (requestParameters.TryGetValue(text, out var requestParameter))
                    {
                        AddRequestParameter(text, requestParameter);
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{uriPart}'\n\n  '{text}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }
                }
            }

            public void AddQueryOrHeaderParameters(IEnumerable<RequestParameter> requestParameters)
            {
                foreach (var requestParameter in requestParameters)
                {
                    var parameter = _parent.BuildParameter(requestParameter);
                    var type = parameter.Type;
                    parameter = parameter with
                    {
                        Type = TypeFactory.IsList(type) || type.IsValueType ? type : type.WithNullable(true),
                        Validate = false
                    };
                    AddRequestParameter(GetRequestParameterName(requestParameter), requestParameter, parameter);
                }
            }

            public void AddBody(Parameter? bodyParameter, RequestParameter? contentTypeRequestParameter)
            {
                if (bodyParameter != null)
                {
                    _parameters.Add(bodyParameter);
                    if (contentTypeRequestParameter != null)
                    {
                        AddRequestParameter(contentTypeRequestParameter, typeof(ContentType));
                    }
                }
            }

            public void AddRequestConditionHeaders(RequestConditionHeaders requestConditionHeaders, RequestParameter? requestConditionRequestParameter)
            {
                if (requestConditionHeaders == RequestConditionHeaders.None || requestConditionRequestParameter == null)
                {
                    return;
                }

                switch (requestConditionHeaders)
                {
                    case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                        _parameters.Add(KnownParameters.MatchConditionsParameter);
                        _referencesByName[KnownParameters.MatchConditionsParameter.Name] = new ParameterInfo(null, KnownParameters.MatchConditionsParameter);
                        break;
                    case RequestConditionHeaders.IfMatch:
                    case RequestConditionHeaders.IfNoneMatch:
                        AddRequestParameter(requestConditionRequestParameter, typeof(ETag));
                        break;
                    default:
                        _parameters.Add(KnownParameters.RequestConditionsParameter);
                        _referencesByName[KnownParameters.RequestConditionsParameter.Name] = new ParameterInfo(null, KnownParameters.RequestConditionsParameter);
                        break;
                }
            }

            public void AddRequestContext()
            {
                _parameters.Add(KnownParameters.RequestContext);
            }

            private void AddRequestParameter(RequestParameter requestParameter, Type? frameworkParameterType = null)
             => AddRequestParameter(GetRequestParameterName(requestParameter), requestParameter, frameworkParameterType);

            private void AddRequestParameter(string name, RequestParameter requestParameter, Type? frameworkParameterType = null)
            {
                var parameter = _parent.BuildParameter(requestParameter, frameworkParameterType);
                AddRequestParameter(name, requestParameter, parameter);
            }

            private void AddRequestParameter(string name, RequestParameter requestParameter, Parameter parameter)
            {
                var reference = _parent.CreateReference(requestParameter, parameter);

                _referencesByName[name] = new ParameterInfo(requestParameter, reference);
                if (IsMethodParameter(requestParameter))
                {
                    _parameters.Add(parameter);
                }
            }
        }

        [Flags]
        private enum RequestConditionHeaders
        {
            None = 0,
            IfMatch = 1,
            IfNoneMatch = 2,
            IfModifiedSince = 4,
            IfUnmodifiedSince = 8
        }
    }
}
