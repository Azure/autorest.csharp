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
        private static readonly CSharpType MatchConditionsType = new(typeof(MatchConditions), true);
        private static readonly CSharpType RequestConditionsType = new(typeof(RequestConditions), true);
        private static readonly Parameter MatchConditionsParameter = new("matchConditions", "The content to send as the request conditions of the request.", MatchConditionsType, Constant.Default(RequestConditionsType), false);
        private static readonly Parameter RequestConditionsParameter = new("requestConditions", "The content to send as the request conditions of the request.", RequestConditionsType, Constant.Default(RequestConditionsType), false);

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
        private readonly BuildContext _context;
        private readonly OutputLibrary _library;
        private readonly Dictionary<string, Parameter> _parameters;


        public RestClientBuilder(OperationGroup operationGroup, BuildContext context)
            : this(GetParametersFromOperationGroups(operationGroup), context)
        {
        }

        public RestClientBuilder(IEnumerable<RequestParameter> clientParameters, BuildContext context)
        {
            _serializationBuilder = new SerializationBuilder();
            _context = context;
            _library = context.BaseLibrary!;
            _parameters = clientParameters.ToDictionary(p => p.Language.Default.Name, BuildConstructorParameter);
        }

        public Parameter[] GetOrderedParameters()
        {
            return OrderParameters(_parameters.Values);
        }

        private static IEnumerable<RequestParameter> GetParametersFromOperationGroups(OperationGroup operationGroup) =>
            operationGroup.Operations
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

            var buildContext = CreateRequestMethodBuildContext(operation, requestParameters);
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

        public RestClientMethod BuildMethod(Operation operation, HttpRequest httpRequest, IEnumerable<RequestParameter> requestParameters, DataPlaneResponseHeaderGroupType? responseHeaderModel, string accessibility, Func<string?, bool>? returnNullOn404Func = null)
        {
            var parameters = operation.Parameters
                .Concat(requestParameters)
                .Where(rp => !IsIgnoredHeaderParameter(rp))
                .ToArray();

            var allParameters = parameters.ToDictionary(rp => rp, requestParameter => BuildParameter(requestParameter));
            var methodParameters = BuildMethodParameters(allParameters);
            var references = allParameters.ToDictionary(kvp => kvp.Key, kvp => CreateReference(kvp.Key, kvp.Value));
            Request request = BuildRequest(httpRequest, new RequestMethodBuildContext(methodParameters, references));

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

        private RequestMethodBuildContext CreateRequestMethodBuildContext(Operation operation, IEnumerable<RequestParameter> requestParameters)
        {
            var references = new Dictionary<RequestParameter, ReferenceOrConstant>();
            var orderedParameters = new List<Parameter>();
            var optionalParameters = new List<Parameter>();

            var hasBody = false;
            var isBodyRequired = false;
            var requestConditionHeaders = RequestConditionHeaders.None;
            RequestParameter? contentTypeRequestParameter = null;
            RequestParameter? requestConditionRequestParameter = null;

            Parameter? bodyParameter = null;
            Parameter? requestConditionParameter = null;
            SerializationFormat requestConditionSerializationFormat = SerializationFormat.Default;

            foreach (var requestParameter in requestParameters)
            {
                if (requestParameter.In == ParameterLocation.Body)
                {
                    hasBody = true;
                    isBodyRequired = isBodyRequired || requestParameter.IsRequired;
                }
                else if (contentTypeRequestParameter == null && IsContentTypeParameter(requestParameter))
                {
                    contentTypeRequestParameter = requestParameter;
                }
                else if (IsRequestConditionHeader(requestParameter, out var header))
                {
                    if (requestParameter.IsRequired)
                    {
                        throw new Exception("Required conditional request headers are not supported.");
                    }

                    requestConditionHeaders |= header;
                    requestConditionRequestParameter = requestParameter;
                }
                else
                {
                    var parameter = BuildParameter(requestParameter);
                    references[requestParameter] = CreateReference(requestParameter, parameter); ;
                    if (IsMethodParameter(requestParameter))
                    {
                        if (parameter.DefaultValue == null)
                        {
                            orderedParameters.Add(parameter);
                        }
                        else
                        {
                            optionalParameters.Add(parameter);
                        }
                    }
                }
            }

            if (hasBody)
            {
                var bodyType = new CSharpType(typeof(RequestContent), !isBodyRequired);
                bodyParameter = new Parameter("content", "The content to send as the body of the request.", bodyType, null, isBodyRequired);
                orderedParameters.Add(bodyParameter);
                if (contentTypeRequestParameter != null)
                {
                    var parameter = BuildParameter(contentTypeRequestParameter, typeof(ContentType));
                    references[contentTypeRequestParameter] = CreateReference(contentTypeRequestParameter, parameter);
                    if (IsMethodParameter(contentTypeRequestParameter))
                    {
                        orderedParameters.Add(parameter);
                    }
                }
            }

            orderedParameters.AddRange(optionalParameters);

            if (requestConditionHeaders != RequestConditionHeaders.None && requestConditionRequestParameter != null)
            {
                requestConditionSerializationFormat = GetSerializationFormat(requestConditionRequestParameter);
                switch (requestConditionHeaders)
                {
                    case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                        requestConditionParameter = MatchConditionsParameter;
                        break;
                    case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch | RequestConditionHeaders.IfModifiedSince | RequestConditionHeaders.IfUnmodifiedSince:
                        requestConditionParameter = RequestConditionsParameter;
                        break;
                    case RequestConditionHeaders.IfMatch:
                    case RequestConditionHeaders.IfNoneMatch:
                        requestConditionParameter = BuildParameter(requestConditionRequestParameter, typeof(ETag));
                        references[requestConditionRequestParameter] = CreateReference(requestConditionRequestParameter, requestConditionParameter);
                        break;
                    default:
                        throw new NotSupportedException($"Behavior for combination of headers '{requestConditionHeaders}' in '{operation.Language.Default.Name}' is undefined");
                }
                orderedParameters.Add(requestConditionParameter);
            }

            return new RequestMethodBuildContext(orderedParameters, references, bodyParameter, requestConditionParameter, requestConditionSerializationFormat);
        }

        private Request BuildRequest(HttpRequest httpRequest, RequestMethodBuildContext buildContext)
        {
            RequestHeader[] headers = BuildHeaders(buildContext);
            QueryParameter[] query = BuildQueryParameters(buildContext.References);
            Dictionary<string, PathSegment> uriParameters = BuildUriParameters(buildContext.References);
            Dictionary<string, PathSegment> pathParameters = BuildPathParameters(buildContext.References);

            PathSegment[] pathSegments = GetPathSegments(httpRequest.Uri, uriParameters, isRaw: true)
                .Concat(GetPathSegments(httpRequest.Path, pathParameters, isRaw: false))
                .ToArray();

            var body = buildContext.BodyParameter != null
                ? new RequestContentRequestBody(buildContext.BodyParameter)
                : httpRequest is HttpWithBodyRequest httpWithBodyRequest
                    ? BuildRequestBody(buildContext.References, httpWithBodyRequest.KnownMediaType)
                    : null;

            return new Request(
                httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                pathSegments,
                query,
                headers,
                body
            );
        }

        private static RequestHeader[] BuildHeaders(RequestMethodBuildContext buildContext)
        {
            List<RequestHeader> headers = new();
            foreach (var (requestParameter, reference) in buildContext.References)
            {
                if (requestParameter.In == ParameterLocation.Header)
                {
                    var serializedName = GetRequestParameterName(requestParameter);
                    if (requestParameter.Extensions!.HeaderCollectionPrefix != null)
                    {
                        serializedName = requestParameter.Extensions.HeaderCollectionPrefix;
                    }

                    headers.Add(new RequestHeader(serializedName,
                        reference,
                        GetSerializationStyle(requestParameter),
                        GetSerializationFormat(requestParameter)));
                }
            }

            if (buildContext.ConditionalRequestParameter != null)
            {
                headers.Add(new RequestHeader("conditions", buildContext.ConditionalRequestParameter, RequestParameterSerializationStyle.Simple, buildContext.ConditionalRequestSerializationFormat));
            }

            return headers.ToArray();
        }

        private static QueryParameter[] BuildQueryParameters(IReadOnlyDictionary<RequestParameter, ReferenceOrConstant> allParameters)
        {
            List<QueryParameter> query = new();
            foreach (var (requestParameter, reference) in allParameters)
            {
                if (requestParameter.In == ParameterLocation.Query)
                {
                    query.Add(new QueryParameter(
                        GetRequestParameterName(requestParameter),
                        reference,
                        GetSerializationStyle(requestParameter),
                        !requestParameter.Extensions!.SkipEncoding,
                        GetSerializationFormat(requestParameter),
                        GetExplode(requestParameter)
                    ));
                }
            }

            return query.ToArray();
        }

        private static Dictionary<string, PathSegment> BuildUriParameters(IReadOnlyDictionary<RequestParameter, ReferenceOrConstant> allParameters)
        {
            Dictionary<string, PathSegment> uriParameters = new();
            foreach (var (requestParameter, reference) in allParameters)
            {
                if (requestParameter.In == ParameterLocation.Uri)
                {
                    var serializedName = GetRequestParameterName(requestParameter);
                    uriParameters.Add(serializedName, new PathSegment(
                        reference,
                        !requestParameter.Extensions!.SkipEncoding,
                        GetSerializationFormat(requestParameter), isRaw: true));
                }
            }

            return uriParameters;
        }

        private static Dictionary<string, PathSegment> BuildPathParameters(IReadOnlyDictionary<RequestParameter, ReferenceOrConstant> allParameters)
        {
            Dictionary<string, PathSegment> path = new();
            foreach (var (requestParameter, reference) in allParameters)
            {
                if (requestParameter.In == ParameterLocation.Path)
                {
                    var serializedName = GetRequestParameterName(requestParameter);
                    path[serializedName] = new PathSegment(reference, !requestParameter.Extensions!.SkipEncoding, GetSerializationFormat(requestParameter));
                }
            }

            return path;
        }

        private Parameter[] BuildMethodParameters(IReadOnlyDictionary<RequestParameter, Parameter> allParameters)
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

            return OrderParameters(methodParameters);
        }

        private RequestBody? BuildRequestBody(IReadOnlyDictionary<RequestParameter, ReferenceOrConstant> allParameters, KnownMediaType mediaType)
        {
            RequestBody? body = null;

            Dictionary<RequestParameter, ReferenceOrConstant> bodyParameters = new();
            foreach (var (requestParameter, value) in allParameters)
            {
                if (requestParameter.In == ParameterLocation.Body)
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
                            var virtualParameters = allParameters.Keys.OfType<VirtualParameter>().ToArray();

                            List<ObjectPropertyInitializer> initializationMap = new List<ObjectPropertyInitializer>();
                            foreach (var virtualParameter in virtualParameters)
                            {
                                if (virtualParameter.Schema is ConstantSchema)
                                    continue;

                                initializationMap.Add(new ObjectPropertyInitializer(
                                    objectType.GetPropertyForSchemaProperty(virtualParameter.TargetProperty, true),
                                    allParameters[virtualParameter].Reference));
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

            if (requestParameter.GroupedBy is { } groupedByParameter)
            {
                var groupModel = (SchemaObjectType)_context.TypeFactory.CreateType(groupedByParameter.Schema, false).Implementation;
                var property = groupModel.GetPropertyForGroupedParameter(requestParameter);

                ReferenceOrConstant constantOrReference = new Reference($"{groupedByParameter.CSharpName()}.{property.Declaration.Name}", property.Declaration.Type);
                return constantOrReference;
            }

            return parameter;
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

            if (requestParameter.Schema is ConstantSchema constant)
            {
                valueSchema = constant.ValueType;
            }

            return valueSchema;
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

        private static Parameter[] OrderParameters(IEnumerable<Parameter> parameters) => parameters.OrderBy(p => p.DefaultValue != null).ToArray();

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

        public Parameter BuildConstructorParameter(RequestParameter requestParameter)
        {
            var parameter = BuildParameter(requestParameter);
            if (IsEndpointParameter(requestParameter))
            {
                parameter = new Parameter(
                    "endpoint",
                    parameter.Description,
                    typeof(Uri),
                    parameter.DefaultValue,
                    parameter.ValidateNotNull
                );
            }

            return parameter;
        }

        private static bool IsMethodParameter(RequestParameter requestParameter)
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

            var isRequired = requestParameter.Required == true;
            var defaultValue = ParseConstant(requestParameter);

            if (defaultValue != null && !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                type = type.WithNullable(true);
            }

            if (!isRequired && defaultValue == null)
            {
                defaultValue = Constant.Default(type);
            }

            return new Parameter(
                requestParameter.CSharpName(),
                CreateDescription(requestParameter, type),
                TypeFactory.GetInputType(type),
                defaultValue,
                isRequired,
                IsApiVersionParameter: requestParameter.Origin == "modelerfour:synthesized/api-version",
                SkipUrlEncoding: requestParameter.Extensions?.SkipEncoding ?? false);
        }

        private Constant ParseConstant(ConstantSchema constant) =>
            BuilderHelpers.ParseConstant(constant.Value.Value, _context.TypeFactory.CreateType(constant.ValueType, constant.Value.Value == null));

        private Constant? ParseConstant(RequestParameter parameter)
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

        private static string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"The {clientPrefix} service client." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        private static string CreateDescription(RequestParameter requestParameter, CSharpType type)
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
                ValidateNotNull: true);

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

        private record RequestMethodBuildContext(
            IReadOnlyList<Parameter> OrderedParameters,
            IReadOnlyDictionary<RequestParameter, ReferenceOrConstant> References,
            Parameter? BodyParameter = null,
            Parameter? ConditionalRequestParameter = null,
            SerializationFormat ConditionalRequestSerializationFormat = SerializationFormat.Default);

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
