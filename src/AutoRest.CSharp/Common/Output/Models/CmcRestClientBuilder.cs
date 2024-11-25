// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.InputTypes;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using Response = AutoRest.CSharp.Output.Models.Responses.Response;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class CmcRestClientBuilder
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

        protected readonly BuildContext _context;
        private readonly OutputLibrary _library;
        private readonly Dictionary<string, Parameter> _parameters;
        protected readonly IEnumerable<InputParameter> _clientParameters;

        public CmcRestClientBuilder(IEnumerable<InputParameter> clientParameters, BuildContext context)
        {
            _context = context;
            _library = context.BaseLibrary!;
            _clientParameters = clientParameters;
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

        private static string GetRequestParameterName(InputParameter requestParameter) => requestParameter.NameInRequest ?? requestParameter.Name;

        public IReadOnlyDictionary<string, (ReferenceOrConstant ReferenceOrConstant, bool SkipUrlEncoding)> GetReferencesToOperationParameters(InputOperation operation, IEnumerable<InputParameter> requestParameters, IEnumerable<InputParameter> clientParameters)
        {
            var allParameters = GetOperationAllParameters(operation, requestParameters, clientParameters);
            return allParameters.ToDictionary(kvp => GetRequestParameterName(kvp.Key), kvp => (CreateReference(kvp.Key, kvp.Value), kvp.Value.SkipUrlEncoding));
        }

        /// <summary>
        /// Build CmcRestClientMethod for mgmt
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="httpRequest"></param>
        /// <param name="requestParameters"></param>
        /// <param name="responseHeaderModel"></param>
        /// <param name="accessibility"></param>
        /// <param name="returnNullOn404Func"></param>
        /// <returns></returns>
        public RestClientMethod BuildMethod(InputOperation operation, IEnumerable<InputParameter> requestParameters, IEnumerable<InputParameter> clientParameters, DataPlaneResponseHeaderGroupType? responseHeaderModel, string accessibility, Func<string?, bool>? returnNullOn404Func = null)
        {
            var allParameters = GetOperationAllParameters(operation, requestParameters, clientParameters);
            var methodParameters = BuildMethodParameters(allParameters);
            var references = allParameters.ToDictionary(kvp => GetRequestParameterName(kvp.Key), kvp => new ParameterInfo(kvp.Key, CreateReference(kvp.Key, kvp.Value)));
            var request = BuildRequest(operation, new RequestMethodBuildContext(methodParameters, references));

            var isHeadAsBoolean = request.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;
            Response[] responses = BuildResponses(operation, isHeadAsBoolean, out var responseType, returnNullOn404Func);

            return new RestClientMethod(
                operation.CSharpName(),
                BuilderHelpers.EscapeXmlDocDescription(operation.Summary ?? string.Empty),
                BuilderHelpers.EscapeXmlDocDescription(operation.Description),
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

        private Dictionary<InputParameter, Parameter> GetOperationAllParameters(InputOperation operation, IEnumerable<InputParameter> requestParameters, IEnumerable<InputParameter> clientParameters)
        {
            var parameters = operation.Parameters
                .Concat(clientParameters)
                .Concat(requestParameters)
                .Where(rp => !IsIgnoredHeaderParameter(rp))
                .DistinctBy(p => p.NameInRequest ?? p.Name)
                .ToArray();

            // TODO: why are there duplicates in the list?
            return parameters.Distinct().ToDictionary(rp => rp, requestParameter => BuildParameter(requestParameter, null, operation.KeepClientDefaultValue));
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

        private Request BuildRequest(InputOperation operation, RequestMethodBuildContext buildContext)
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
                        headerParameters.Add(new RequestHeader(parameterName, reference, null, buildContext.ConditionalRequestSerializationFormat));
                    }
                    continue;
                }

                var serializationFormat = GetSerializationFormat(requestParameter);
                var escape = !requestParameter.SkipUrlEncoding;

                switch (requestParameter.Location)
                {
                    case RequestLocation.Uri:
                        uriParametersMap.Add(parameterName, new PathSegment(reference, escape, serializationFormat, isRaw: true));
                        break;
                    case RequestLocation.Path:
                        pathParametersMap.Add(parameterName, new PathSegment(reference, escape, serializationFormat, isRaw: false));
                        break;
                    case RequestLocation.Query:
                        queryParameters.Add(new QueryParameter(parameterName, reference, requestParameter.ArraySerializationDelimiter, escape, serializationFormat, requestParameter.Explode, requestParameter.IsApiVersion));
                        break;
                    case RequestLocation.Header:
                        var headerName = requestParameter.HeaderCollectionPrefix ?? parameterName;
                        headerParameters.Add(new RequestHeader(headerName, reference, requestParameter.ArraySerializationDelimiter, serializationFormat));
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

        protected virtual Parameter[] BuildMethodParameters(IReadOnlyDictionary<InputParameter, Parameter> allParameters)
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

        private RequestBody? BuildRequestBody(IReadOnlyDictionary<string, ParameterInfo> allParameters, BodyMediaType mediaType)
        {
            RequestBody? body = null;

            Dictionary<InputParameter, ReferenceOrConstant> bodyParameters = new();
            foreach (var (_, (requestParameter, value)) in allParameters)
            {
                if (requestParameter?.Location == RequestLocation.Body)
                {
                    bodyParameters[requestParameter] = value;
                }
            }

            if (bodyParameters.Count > 0)
            {
                if (mediaType == BodyMediaType.Multipart)
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
                        else if (type.IsList)
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
                else if (mediaType == BodyMediaType.Form)
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
                    if (mediaType == BodyMediaType.Binary)
                    {
                        body = new BinaryRequestBody(bodyParameterValue);
                    }
                    else if (mediaType == BodyMediaType.Text)
                    {
                        body = new TextRequestBody(bodyParameterValue);
                    }
                    else
                    {
                        var serialization = SerializationBuilder.Build(
                            mediaType,
                            bodyRequestParameter.Type,
                            bodyParameterValue.Type,
                            null);

                        // This method has a flattened body
                        if (bodyRequestParameter.Kind == InputOperationParameterKind.Flattened)
                        {
                            var objectType = (SchemaObjectType)_context.TypeFactory.CreateType(bodyRequestParameter.Type).Implementation;
                            var initializationMap = new List<ObjectPropertyInitializer>();
                            foreach (var (parameter, _) in allParameters.Values)
                            {
                                if (parameter?.FlattenedBodyProperty is null)
                                {
                                    continue;
                                }

                                initializationMap.Add(new ObjectPropertyInitializer(
                                    objectType.GetPropertyForSchemaProperty(parameter.FlattenedBodyProperty, true),
                                    allParameters[GetRequestParameterName(parameter!)].Reference));
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

        private ReferenceOrConstant CreateReference(InputParameter requestParameter, Parameter parameter)
        {
            if (requestParameter.Kind == InputOperationParameterKind.Client)
            {
                return (ReferenceOrConstant)_parameters[requestParameter.Name];
            }

            if (requestParameter is { Kind: InputOperationParameterKind.Constant })
            {
                if (requestParameter.Type is InputLiteralType { Value: not null } literalType)
                {
                    return ParseConstant(literalType);
                }
                if (requestParameter.DefaultValue is not null) // TODO: we're using default value to store constant value, this should be fixed.
                {
                    return ParseConstant(requestParameter.DefaultValue);
                }
            }

            var groupedByParameter = requestParameter.GroupedBy;
            if (groupedByParameter == null)
            {
                return parameter;
            }

            var groupModel = (SchemaObjectType)_context.TypeFactory.CreateType(groupedByParameter.Type).Implementation;
            var property = groupModel.GetPropertyForGroupedParameter(requestParameter.Name);

            return new Reference($"{groupedByParameter.CSharpName()}.{property.Declaration.Name}", property.Declaration.Type);
        }

        private static SerializationFormat GetSerializationFormat(InputParameter requestParameter)
            => SerializationBuilder.GetSerializationFormat(requestParameter.Type);

        private ResponseBody? BuildResponseBody(OperationResponse response)
        {
            if (response.BodyMediaType == BodyMediaType.Text)
            {
                return new StringResponseBody();
            }
            else if (response.BodyMediaType == BodyMediaType.Binary)
            {
                return new StreamResponseBody();
            }
            else if (response.BodyType is not null)
            {
                CSharpType responseType = _context.TypeFactory.CreateType(response.BodyType).OutputType;

                ObjectSerialization serialization = SerializationBuilder.Build(response.BodyMediaType, response.BodyType, responseType, null);

                return new ObjectResponseBody(responseType, serialization);
            }

            return null;
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

        public virtual Parameter BuildConstructorParameter(InputParameter requestParameter)
        {
            var parameter = BuildParameter(requestParameter);
            if (!requestParameter.IsEndpoint)
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

        protected static bool IsMethodParameter(InputParameter requestParameter)
            => requestParameter.Kind == InputOperationParameterKind.Method && requestParameter.GroupedBy == null;

        private static bool IsIgnoredHeaderParameter(InputParameter requestParameter)
            => requestParameter.Location == RequestLocation.Header && IgnoredRequestHeader.Contains(GetRequestParameterName(requestParameter));

        private Parameter BuildParameter(in InputParameter requestParameter, Type? typeOverride = null, bool keepClientDefaultValue = false)
        {
            var isNullable = requestParameter.Type is InputNullableType || !requestParameter.IsRequired;
            CSharpType type = typeOverride != null
                ? new CSharpType(typeOverride, isNullable)
                : _context.TypeFactory.CreateType(requestParameter.Type);
            return Parameter.FromInputParameter(requestParameter, type, _context.TypeFactory, keepClientDefaultValue);
        }

        private Constant ParseConstant(InputConstant constant) =>
            BuilderHelpers.ParseConstant(constant.Value, _context.TypeFactory.CreateType(constant.Type));

        public static RestClientMethod BuildNextPageMethod(InputOperation operation, RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                $"The URL to the next page of results.",
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
            if (operation.IsLongRunning)
            {
                responses = new[]
                {
                    new Response(null, new[] { new StatusCodes(200, null) })
                };
            }

            return new RestClientMethod(
                $"{method.Name}NextPage",
                method.Summary,
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
                    Configuration.ApiTypes.CredentialDescription,
                    credentialType,
                    null,
                    ValidationType.AssertNotNull,
                    null);
                constructorParameters.Add(credentialParam);
            }

            constructorParameters.AddRange(GetOptionalParameters(parameters, includeAPIVersion));

            return constructorParameters;
        }

        private record RequestMethodBuildContext(IReadOnlyList<Parameter> OrderedParameters, IReadOnlyDictionary<string, ParameterInfo> References, Parameter? BodyParameter = null, SerializationFormat ConditionalRequestSerializationFormat = SerializationFormat.Default, RequestConditionHeaders RequestConditionFlag = RequestConditionHeaders.None);

        private readonly record struct ParameterInfo(InputParameter? Parameter, ReferenceOrConstant Reference);
    }
}
