// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
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

        public RestClientBuilder(IEnumerable<InputOperationParameter> clientParameters, BuildContext context)
        {
            _serializationBuilder = new SerializationBuilder();
            _context = context;
            _library = context.BaseLibrary!;
            _parameters = clientParameters.ToDictionary(p => p.Name, BuildConstructorParameter);
        }

        /// <summary>
        /// Get sorted parameters, required parameters are at the beginning.
        /// </summary>
        /// <returns></returns>
        public Parameter[] GetOrderedParametersByRequired()
        {
            return OrderParametersByRequired(_parameters.Values);
        }

        public static IEnumerable<InputOperationParameter> GetParametersFromOperations(IEnumerable<InputOperation> operations) =>
            operations
                .SelectMany(op => op.Parameters)
                .Where(p => p.Kind == InputOperationParameterKind.Client)
                .Distinct()
                .ToList();

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        public RestClientMethod BuildRequestMethod(InputOperation operation)
        {
            var accessibility = operation.Accessibility ?? "public";
            var requestParameters = operation.Parameters
                .Where(rp => !IsIgnoredHeaderParameter(rp));

            var buildContext = CreateRequestMethodBuildContext(operation, requestParameters);
            Request request = BuildRequest(operation, buildContext);

            var isHeadAsBoolean = request.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;
            Response[] responses = BuildResponses(operation, isHeadAsBoolean, out var responseType);

            return new RestClientMethod(
                operation.Name.ToCleanName(),
                BuilderHelpers.EscapeXmlDescription(operation.Description),
                responseType,
                request,
                buildContext.OrderedParameters.ToArray(),
                responses,
                null,
                operation.BufferResponse,
                accessibility: accessibility,
                operation,
                buildContext.RequestConditionFlag
            );
        }

        public IReadOnlyDictionary<string, (ReferenceOrConstant ReferenceOrConstant, bool SkipUrlEncoding)> GetReferencesToOperationParameters(InputOperation operation)
        {
            var allParameters = GetOperationAllParameters(operation);
            return allParameters.ToDictionary(kvp => kvp.Key.NameInRequest, kvp => (CreateReference(kvp.Key, kvp.Value), kvp.Value.SkipUrlEncoding));
        }

        /// <summary>
        /// Build RestClientMethod for mgmt and HLC
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="responseHeaderModel"></param>
        /// <param name="accessibility"></param>
        /// <param name="returnNullOn404Func"></param>
        /// <returns></returns>
        public RestClientMethod BuildMethod(InputOperation operation, DataPlaneResponseHeaderGroupType? responseHeaderModel, string accessibility, Func<string?, bool>? returnNullOn404Func = null)
        {
            var allParameters = GetOperationAllParameters(operation);
            var methodParameters = BuildMethodParameters(allParameters);
            var references = allParameters.ToDictionary(kvp => kvp.Key.NameInRequest, kvp => new ParameterInfo(kvp.Key, CreateReference(kvp.Key, kvp.Value)));
            var request = BuildRequest(operation, new RequestMethodBuildContext(methodParameters, references));

            var isHeadAsBoolean = request.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;
            Response[] responses = BuildResponses(operation, isHeadAsBoolean, out var responseType, returnNullOn404Func);

            return new RestClientMethod(
                operation.Name.ToCleanName(),
                BuilderHelpers.EscapeXmlDescription(operation.Description),
                responseType,
                request,
                methodParameters,
                responses,
                responseHeaderModel,
                operation.BufferResponse,
                accessibility: accessibility,
                operation
            );
        }

        private Dictionary<InputOperationParameter, Parameter> GetOperationAllParameters(InputOperation operation)
        {
            return operation.Parameters
                .Where(rp => !IsIgnoredHeaderParameter(rp))
                .ToDictionary(p => p, parameter => BuildParameter(parameter));
        }

        private Response[] BuildResponses(InputOperation operation, bool headAsBoolean, out CSharpType? responseType, Func<string?, bool>? returnNullOn404Func = null)
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
                foreach (var statusCode in response.StatusCodes)
                {
                    statusCodes.Add(new StatusCodes(statusCode, null));
                }

                var responseBody = operation.LongRunning != null ? null : BuildResponseBody(response);
                clientResponse.Add(new Response(responseBody, statusCodes.ToArray()));
            }

            if (returnNullOn404Func != null && returnNullOn404Func(clientResponse.FirstOrDefault()?.ResponseBody?.Type.Name))
                clientResponse.Add(new Response(null, new[] { new StatusCodes(404, null) }));

            responseType = ReduceResponses(clientResponse);
            return clientResponse.ToArray();
        }

        private RequestMethodBuildContext CreateRequestMethodBuildContext(InputOperation operation, IEnumerable<InputOperationParameter> operationParameters)
        {
            var pathParameters = new Dictionary<string, InputOperationParameter>();
            var requiredRequestParameters = new List<InputOperationParameter>();
            var optionalRequestParameters = new List<InputOperationParameter>();

            var requestConditionHeaders = RequestConditionHeaders.None;
            var requestConditionSerializationFormat = SerializationFormat.Default;
            InputOperationParameter? contentTypeRequestParameter = null;
            InputOperationParameter? requestConditionRequestParameter = null;

            Parameter? bodyParameter = null;

            foreach (var operationParameter in operationParameters)
            {
                switch (operationParameter)
                {
                    case { Location: RequestLocation.Body } when bodyParameter != KnownParameters.RequestContent:
                        bodyParameter = operationParameter.IsRequired ? KnownParameters.RequestContent : KnownParameters.RequestContentNullable;
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true } when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header } when ConditionRequestHeader.TryGetValue(operationParameter.NameInRequest, out var header):
                        if (operationParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        requestConditionHeaders |= header;
                        requestConditionRequestParameter ??= operationParameter;
                        requestConditionSerializationFormat = requestConditionSerializationFormat == SerializationFormat.Default
                            ? SerializationBuilder.GetSerializationFormat(operationParameter.Type)
                            : requestConditionSerializationFormat;

                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path }:
                        pathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { IsRequired: true, DefaultValue: null }:
                        requiredRequestParameters.Add(operationParameter);
                        break;
                    default:
                        optionalRequestParameters.Add(operationParameter);
                        break;
                }
            }

            var parameters = new RequestMethodParametersBuilder(this);
            parameters.AddUriOrPathParameters(operation.Uri, pathParameters);
            parameters.AddUriOrPathParameters(operation.Path, pathParameters);
            parameters.AddQueryOrHeaderParameters(requiredRequestParameters);
            parameters.AddBody(bodyParameter, contentTypeRequestParameter, operation.RequestMediaTypes);
            parameters.AddQueryOrHeaderParameters(optionalRequestParameters);
            parameters.AddRequestConditionHeaders(requestConditionHeaders, requestConditionRequestParameter);
            parameters.AddRequestContext();

            return new RequestMethodBuildContext(parameters.OrderedParameters, parameters.References, bodyParameter, requestConditionSerializationFormat, requestConditionHeaders);
        }

        private Request BuildRequest(InputOperation operation, RequestMethodBuildContext buildContext)
        {
            var uriParametersMap = new Dictionary<string, PathSegment>();
            var pathParametersMap = new Dictionary<string, PathSegment>();
            var queryParameters = new List<QueryParameter>();
            var headerParameters = new List<RequestHeader>();
            foreach (var (parameterName, (operationParameter, reference)) in buildContext.References)
            {
                if (operationParameter == null)
                {
                    if (parameterName == KnownParameters.MatchConditionsParameter.Name || parameterName == KnownParameters.RequestConditionsParameter.Name)
                    {
                        headerParameters.Add(new RequestHeader(parameterName, reference, null, buildContext.ConditionalRequestSerializationFormat));
                    }
                    continue;
                }

                var serializationFormat = SerializationBuilder.GetSerializationFormat(operationParameter.Type);
                var escape = !operationParameter.SkipUrlEncoding;

                switch (operationParameter.Location)
                {
                    case RequestLocation.Uri:
                        uriParametersMap.Add(parameterName, new PathSegment(reference, escape, serializationFormat, isRaw: true));
                        break;
                    case RequestLocation.Path:
                        pathParametersMap.Add(parameterName, new PathSegment(reference, escape, serializationFormat, isRaw: false));
                        break;
                    case RequestLocation.Query:
                        queryParameters.Add(new QueryParameter(parameterName, reference, operationParameter.ArraySerializationDelimiter, escape, serializationFormat, operationParameter.Explode));
                        break;
                    case RequestLocation.Header:
                        var headerName = operationParameter.HeaderCollectionPrefix ?? parameterName;
                        headerParameters.Add(new RequestHeader(headerName, reference, operationParameter.ArraySerializationDelimiter, serializationFormat));
                        break;
                }
            }

            var uriParameters = GetPathSegments(operation.Uri, uriParametersMap, isRaw: true);
            var pathParameters = GetPathSegments(operation.Path, pathParametersMap, isRaw: false);

            var body = buildContext.BodyParameter != null
                ? new RequestContentRequestBody(buildContext.BodyParameter)
                : operation.RequestBodyMediaType != BodyMediaType.None
                    ? BuildRequestBody(buildContext.References, operation.RequestBodyMediaType)
                    : null;

            return new Request(
                operation.HttpMethod,
                uriParameters.Concat(pathParameters).ToArray(),
                queryParameters.ToArray(),
                headerParameters.ToArray(),
                body
            );
        }

        protected virtual Parameter[] BuildMethodParameters(IReadOnlyDictionary<InputOperationParameter, Parameter> allParameters)
        {
            List<Parameter> methodParameters = new();
            foreach (var (operationParameter, parameter) in allParameters)
            {
                // Grouped and flattened parameters shouldn't be added to methods
                if (operationParameter.Kind == InputOperationParameterKind.Method)
                {
                    methodParameters.Add(parameter);
                }
            }

            return OrderParametersByRequired(methodParameters);
        }

        private RequestBody? BuildRequestBody(IReadOnlyDictionary<string, ParameterInfo> allParameters, BodyMediaType bodyMediaType)
        {
            RequestBody? body = null;

            Dictionary<InputOperationParameter, ReferenceOrConstant> bodyParameters = new();
            foreach (var (_, (requestParameter, value)) in allParameters)
            {
                if (requestParameter is { Location: RequestLocation.Body })
                {
                    bodyParameters[requestParameter] = value;
                }
            }

            if (bodyParameters.Count > 0)
            {
                if (bodyMediaType == BodyMediaType.Multipart)
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
                else if (bodyMediaType == BodyMediaType.Form)
                {
                    UrlEncodedBody urlbody = new UrlEncodedBody();
                    foreach (var (bodyRequestParameter, bodyParameterValue) in bodyParameters)
                    {
                        urlbody.Add(bodyRequestParameter.NameInRequest, bodyParameterValue);
                    }

                    body = urlbody;
                }
                else
                {
                    Debug.Assert(bodyParameters.Count == 1);
                    var (bodyRequestParameter, bodyParameterValue) = bodyParameters.Single();
                    if (bodyMediaType == BodyMediaType.Binary ||
                        // WORKAROUND: https://github.com/Azure/autorest.modelerfour/issues/360
                        bodyRequestParameter.Type.Kind == InputTypeKind.Stream)
                    {
                        body = new BinaryRequestBody(bodyParameterValue);
                    }
                    else if (bodyMediaType == BodyMediaType.Text)
                    {
                        body = new TextRequestBody(bodyParameterValue);
                    }
                    else
                    {
                        var serialization = _serializationBuilder.Build(
                            bodyMediaType,
                            bodyRequestParameter.Type,
                            bodyParameterValue.Type);

                        // This method has a flattened body
                        if (bodyRequestParameter.Kind == InputOperationParameterKind.Flattened)
                        {
                            var objectType = (SchemaObjectType)_library.FindTypeForSchema(((CodeModelType)bodyRequestParameter.Type).Schema).Implementation;

                            var initializationMap = new List<ObjectPropertyInitializer>();
                            foreach (var (parameter, _) in allParameters.Values)
                            {
                                var virtualParameter = parameter?.VirtualParameter;
                                if (virtualParameter == null)
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

        private ReferenceOrConstant CreateReference(InputOperationParameter operationParameter, Parameter parameter)
        {
            if (operationParameter.Kind == InputOperationParameterKind.Client)
            {
                return (ReferenceOrConstant)_parameters[operationParameter.Name];
            }

            if (operationParameter.Kind == InputOperationParameterKind.Constant && parameter.DefaultValue != null)
            {
                return (ReferenceOrConstant)parameter.DefaultValue;
            }

            var groupedByParameter = operationParameter.GroupedBy;
            if (groupedByParameter == null)
            {
                return parameter;
            }

            var groupModel = (SchemaObjectType)_context.TypeFactory.CreateType(((CodeModelType)groupedByParameter.Type).Schema, false).Implementation;
            var property = groupModel.GetPropertyForGroupedParameter(operationParameter);

            return new Reference($"{groupedByParameter.Name.ToVariableName()}.{property.Declaration.Name}", property.Declaration.Type);

        }

        private ResponseBody? BuildResponseBody(OperationResponse response)
        {
            var bodyType = response.BodyType;
            if (bodyType == null)
            {
                return null;
            }

            if (response.BodyMediaType == BodyMediaType.Text)
            {
                return new StringResponseBody();
            }

            if (bodyType.Kind == InputTypeKind.Stream)
            {
                return new StreamResponseBody();
            }

            CSharpType responseType = TypeFactory.GetOutputType(_context.TypeFactory.CreateType(bodyType));
            ObjectSerialization serialization = _serializationBuilder.Build(response.BodyMediaType, bodyType, responseType);

            return new ObjectResponseBody(responseType, serialization);
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
        private static Parameter[] OrderParametersByRequired(IEnumerable<Parameter> parameters) => parameters.OrderBy(p => p.IsOptionalInSignature).ToArray();

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

        public virtual Parameter BuildConstructorParameter(InputOperationParameter operationParameter)
        {
            var parameter = BuildParameter(operationParameter);
            if (!operationParameter.IsEndpoint)
            {
                return parameter;
            }

            var name = "endpoint";
            var type = new CSharpType(typeof(Uri));
            var defaultValue = parameter.DefaultValue;
            var description = parameter.Description;
            var location = parameter.RequestLocation;

            return defaultValue != null
                ? new Parameter(name, description, type, Constant.Default(type.WithNullable(true)), ValidationType.None, $"new {typeof(Uri)}({defaultValue.Value.GetConstantFormattable()})", RequestLocation: location)
                : new Parameter(name, description, type, null, parameter.Validation, null, RequestLocation: location);
        }

        public static bool IsIgnoredHeaderParameter(InputOperationParameter operationParameter)
            => operationParameter.Location == RequestLocation.Header && IgnoredRequestHeader.Contains(operationParameter.NameInRequest);

        private Parameter BuildParameter(in InputOperationParameter operationParameter, Type? typeOverride = null)
        {
            CSharpType type = typeOverride != null ? new CSharpType(typeOverride, operationParameter.Type.IsNullable) : _context.TypeFactory.CreateType(operationParameter.Type);
            return Parameter.FromRequestParameter(operationParameter, type, _context.TypeFactory);
        }

        public static RestClientMethod BuildNextPageMethod(RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                typeof(string),
                DefaultValue: null,
                ValidationType.AssertNotNull,
                null);

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
            if (method.Operation.LongRunning != null)
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
            => parameters.Where(parameter => !parameter.IsOptionalInSignature).ToList();

        public static IEnumerable<Parameter> GetOptionalParameters(IEnumerable<Parameter> parameters, bool includeAPIVersion = false)
            => parameters.Where(parameter => parameter.IsOptionalInSignature && (includeAPIVersion || !parameter.IsApiVersionParameter)).ToList();

        public static IReadOnlyCollection<Parameter> GetConstructorParameters(IReadOnlyList<Parameter> parameters, CSharpType? credentialType, bool includeAPIVersion = false)
        {
            var constructorParameters = new List<Parameter>();

            constructorParameters.AddRange(GetRequiredParameters(parameters));

            if (credentialType != null)
            {
                var credentialParam = new Parameter(
                    "credential",
                    "A credential used to authenticate to an Azure Service.",
                    credentialType,
                    null,
                    ValidationType.AssertNotNull,
                    null);
                constructorParameters.Add(credentialParam);
            }

            constructorParameters.AddRange(GetOptionalParameters(parameters, includeAPIVersion));

            return constructorParameters;
        }

        protected static RequestLocation GetRequestLocation(RequestParameter requestParameter)
            => requestParameter.In switch
            {
                HttpParameterIn.Uri => RequestLocation.Uri,
                HttpParameterIn.Path => RequestLocation.Path,
                HttpParameterIn.Query => RequestLocation.Query,
                HttpParameterIn.Header => RequestLocation.Header,
                HttpParameterIn.Body => RequestLocation.Body,
                _ => RequestLocation.None
            };

        private record RequestMethodBuildContext(IReadOnlyList<Parameter> OrderedParameters, IReadOnlyDictionary<string, ParameterInfo> References, Parameter? BodyParameter = null, SerializationFormat ConditionalRequestSerializationFormat = SerializationFormat.Default, RequestConditionHeaders RequestConditionFlag = RequestConditionHeaders.None);

        private readonly record struct ParameterInfo(InputOperationParameter? Parameter, ReferenceOrConstant Reference);

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

            public void AddUriOrPathParameters(string uriPart, IReadOnlyDictionary<string, InputOperationParameter> requestParameters)
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

            public void AddQueryOrHeaderParameters(IEnumerable<InputOperationParameter> requestParameters)
            {
                foreach (var requestParameter in requestParameters)
                {
                    var parameter = _parent.BuildParameter(requestParameter);
                    AddRequestParameter(requestParameter.NameInRequest, requestParameter, parameter);
                }
            }

            public void AddBody(Parameter? bodyParameter, InputOperationParameter? contentTypeRequestParameter, IReadOnlyList<string>? requestMediaTypes)
            {
                if (bodyParameter != null)
                {
                    _parameters.Add(bodyParameter);
                    if (contentTypeRequestParameter != null)
                    {
                        if (requestMediaTypes?.Count > 1)
                        {
                            AddContentTypeRequestParameter(contentTypeRequestParameter, requestMediaTypes);
                        }
                        else
                        {
                            AddRequestParameter(contentTypeRequestParameter, typeof(ContentType));
                        }
                    }
                }
            }

            public void AddRequestConditionHeaders(RequestConditionHeaders requestConditionHeaders, InputOperationParameter? requestConditionRequestParameter)
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

            private void AddContentTypeRequestParameter(InputOperationParameter operationParameter, IReadOnlyList<string> requestMediaTypes)
            {
                var name = operationParameter.Name.ToVariableName();
                var description = Parameter.CreateDescription(operationParameter, typeof(ContentType), requestMediaTypes);
                var parameter = new Parameter(name, description, typeof(ContentType), null, ValidationType.None, null, RequestLocation: RequestLocation.Header);

                _referencesByName[operationParameter.NameInRequest] = new ParameterInfo(operationParameter, parameter);
                _parameters.Add(parameter);
            }

            private void AddRequestParameter(InputOperationParameter operationParameter, Type? frameworkParameterType = null)
             => AddRequestParameter(operationParameter.NameInRequest, operationParameter, frameworkParameterType);

            private void AddRequestParameter(string name, InputOperationParameter operationParameter, Type? frameworkParameterType = null)
            {
                var parameter = _parent.BuildParameter(operationParameter, frameworkParameterType);
                AddRequestParameter(name, operationParameter, parameter);
            }

            private void AddRequestParameter(string name, InputOperationParameter operationParameter, Parameter parameter)
            {
                var reference = _parent.CreateReference(operationParameter, parameter);

                _referencesByName[name] = new ParameterInfo(operationParameter, reference);
                if (operationParameter.Kind == InputOperationParameterKind.Method)
                {
                    _parameters.Add(parameter);
                }
            }
        }
    }
}
