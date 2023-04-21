// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
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
using Azure.Core;
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

        public static IReadOnlyList<InputParameter> GetParametersFromOperations(IEnumerable<InputOperation> operations) =>
            operations
                .SelectMany(op => op.Parameters)
                .Where(p => p.Kind == InputOperationParameterKind.Client)
                .Distinct()
                .ToList();

        public static Parameter BuildConstructorParameter(InputParameter inputParameter, TypeFactory typeFactory)
        {
            var parameter = Parameter.FromInputParameter(inputParameter, typeFactory.CreateType(inputParameter.Type), typeFactory);
            if (!inputParameter.IsEndpoint)
            {
                return parameter;
            }

            var defaultValue = parameter.DefaultValue;
            var description = parameter.Description;
            var location = parameter.RequestLocation;

            return defaultValue != null
                ? KnownParameters.Endpoint with { Description = description, RequestLocation = location, DefaultValue = Constant.Default(new CSharpType(typeof(Uri), true)), Initializer = $"new {typeof(Uri)}({defaultValue.Value.GetConstantFormattable()})"}
                : KnownParameters.Endpoint with { Description = description, RequestLocation = location, Validation = parameter.Validation };
        }

        public static bool IsIgnoredHeaderParameter(InputParameter operationParameter)
            => operationParameter.Location == RequestLocation.Header && IgnoredRequestHeader.Contains(operationParameter.NameInRequest);

        public static RestClientMethod BuildRequestMethod(InputOperation operation, IReadOnlyList<Parameter> parameters, IReadOnlyCollection<RequestPartSource> requestParts, DataPlaneResponseHeaderGroupType? responseHeaderModel, CSharpType? resourceDataType, ClientFields fields, TypeFactory typeFactory)
        {
            Request request = BuildRequest(operation, requestParts, fields, typeFactory);
            Response[] responses = BuildResponses(operation, resourceDataType, typeFactory, out var responseType);

            return new RestClientMethod(
                operation.Name.ToCleanName(),
                operation.Summary != null ? BuilderHelpers.EscapeXmlDescription(operation.Summary) : null,
                BuilderHelpers.EscapeXmlDescription(operation.Description),
                responseType,
                request,
                parameters,
                responses,
                responseHeaderModel,
                operation.BufferResponse,
                accessibility: operation.Accessibility ?? "public",
                operation
            );
        }

        public static Response[] BuildResponses(InputOperation operation, CSharpType? resourceDataType, TypeFactory typeFactory, out CSharpType? responseType)
        {
            if (operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean)
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

            var clientResponse = new List<Response>();
            foreach (var response in operation.Responses.Where(r => !r.IsErrorResponse))
            {
                var statusCodes = new List<StatusCodes>();
                foreach (var statusCode in response.StatusCodes)
                {
                    statusCodes.Add(new StatusCodes(statusCode, null));
                }

                var responseBody = operation.LongRunning != null ? null : BuildResponseBody(response, typeFactory);
                clientResponse.Add(new Response(responseBody, statusCodes.ToArray()));
            }

            if (resourceDataType is not null && clientResponse.Any())
            {
                var responseBodyTypeName = clientResponse[0].ResponseBody?.Type.Name;
                if (responseBodyTypeName == resourceDataType.Name && operation.Responses.Any(r => r.BodyType is {} type && resourceDataType.EqualsIgnoreNullable(typeFactory.CreateType(type))))
                {
                    clientResponse.Add(new Response(null, new[] { new StatusCodes(404, null) }));
                }
            }

            responseType = ReduceResponses(clientResponse);
            return clientResponse.ToArray();
        }

        private static ReferenceOrConstant CreateReference(InputParameter? operationParameter, Parameter parameter, ClientFields fields, TypeFactory typeFactory)
        {
            if (operationParameter is null)
            {
                return parameter;
            }

            if (operationParameter.Kind == InputOperationParameterKind.Client)
            {
                var field = operationParameter.IsEndpoint ? fields.EndpointField : fields.GetFieldByParameter(parameter);
                if (field == null)
                {
                    throw new InvalidOperationException($"Parameter {parameter.Name} should have matching field");
                }

                return new Reference(field.Name, field.Type);
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

            var groupModel = (SchemaObjectType)typeFactory.CreateType(groupedByParameter.Type with {IsNullable = false}).Implementation;
            var property = groupModel.GetPropertyForGroupedParameter(operationParameter.Name);

            return new Reference($"{groupedByParameter.Name.ToVariableName()}.{property.Declaration.Name}", property.Declaration.Type);
        }

        private static Request BuildRequest(InputOperation operation, IReadOnlyCollection<RequestPartSource> requestParts, ClientFields fields, TypeFactory typeFactory)
        {
            var uriParametersMap = new Dictionary<string, PathSegment>();
            var pathParametersMap = new Dictionary<string, PathSegment>();
            var queryParameters = new List<QueryParameter>();
            var headerParameters = new List<RequestHeader>();
            var bodyParameters = new Dictionary<InputParameter, ReferenceOrConstant>();
            RequestBody? body = null;

            foreach (var (nameInRequest, inputParameter, outputParameter, serializationFormat) in requestParts)
            {
                var reference = CreateReference(inputParameter, outputParameter, fields, typeFactory);

                if (inputParameter == null)
                {
                    Debug.Assert(nameInRequest == KnownParameters.MatchConditionsParameter.Name || nameInRequest == KnownParameters.RequestConditionsParameter.Name);
                    headerParameters.Add(new RequestHeader(nameInRequest, reference, null, serializationFormat));
                    continue;
                }

                var escape = !inputParameter.SkipUrlEncoding;

                switch (inputParameter.Location)
                {
                    case RequestLocation.Uri:
                        uriParametersMap.Add(nameInRequest, new PathSegment(reference, escape, serializationFormat, isRaw: true));
                        break;
                    case RequestLocation.Path:
                        pathParametersMap.Add(nameInRequest, new PathSegment(reference, escape, serializationFormat, isRaw: false));
                        break;
                    case RequestLocation.Query:
                        queryParameters.Add(new QueryParameter(nameInRequest, reference, inputParameter.ArraySerializationDelimiter, escape, serializationFormat, inputParameter.Explode));
                        break;
                    case RequestLocation.Header:
                        var headerName = inputParameter.HeaderCollectionPrefix ?? nameInRequest;
                        headerParameters.Add(new RequestHeader(headerName, reference, inputParameter.ArraySerializationDelimiter, serializationFormat));
                        break;
                    case RequestLocation.Body when reference.Type.EqualsIgnoreNullable(KnownParameters.RequestContent.Type):
                        body = new RequestContentRequestBody(reference.Reference.Name);
                        break;
                    case RequestLocation.Body when operation.RequestBodyMediaType != BodyMediaType.None:
                        bodyParameters.Add(inputParameter, reference);
                        break;
                }
            }

            var uriParameters = GetPathSegments(operation.Uri, uriParametersMap, isRaw: true);
            var pathParameters = GetPathSegments(operation.Path, pathParametersMap, isRaw: false);
            if (body == null && bodyParameters.Any())
            {
                body = BuildRequestBody(bodyParameters, requestParts, operation.RequestBodyMediaType, fields, typeFactory);
            }

            return new Request(
                operation.HttpMethod,
                uriParameters.Concat(pathParameters).ToArray(),
                queryParameters.ToArray(),
                headerParameters.ToArray(),
                body
            );
        }

        private static RequestBody? BuildRequestBody(IReadOnlyDictionary<InputParameter, ReferenceOrConstant> bodyParameters, IReadOnlyCollection<RequestPartSource> allParameters, BodyMediaType bodyMediaType, ClientFields fields, TypeFactory typeFactory)
        {
            RequestBody? body = null;
            if (bodyParameters.Count > 0)
            {
                if (bodyMediaType == BodyMediaType.Multipart)
                {
                    List<MultipartRequestBodyPart> value = new List<MultipartRequestBodyPart>();
                    foreach (var (_, reference) in bodyParameters)
                    {
                        var type = reference.Type;
                        RequestBody requestBody;

                        if (type.Equals(typeof(string)))
                        {
                            requestBody = new TextRequestBody(reference);
                        }
                        else if (type.IsFrameworkType && type.FrameworkType == typeof(Stream))
                        {
                            requestBody = new BinaryRequestBody(reference);
                        }
                        else if (TypeFactory.IsList(type))
                        {
                            requestBody = new BinaryCollectionRequestBody(reference);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }

                        value.Add(new MultipartRequestBodyPart(reference.Reference.Name, requestBody));
                    }

                    body = new MultipartRequestBody(value.ToArray());
                }
                else if (bodyMediaType == BodyMediaType.Form)
                {
                    UrlEncodedBody urlbody = new UrlEncodedBody();
                    foreach (var (inputParameter, reference) in bodyParameters)
                    {
                        urlbody.Add(inputParameter.NameInRequest, reference);
                    }

                    body = urlbody;
                }
                else
                {
                    Debug.Assert(bodyParameters.Count == 1);
                    var (bodyRequestParameter, bodyParameterValue) = bodyParameters.First();
                    if (bodyMediaType == BodyMediaType.Binary ||
                        // WORKAROUND: https://github.com/Azure/autorest.modelerfour/issues/360
                        bodyRequestParameter.Type is InputPrimitiveType { Kind: InputTypeKind.Stream })
                    {
                        body = new BinaryRequestBody(bodyParameterValue);
                    }
                    else if (bodyMediaType == BodyMediaType.Text)
                    {
                        body = new TextRequestBody(bodyParameterValue);
                    }
                    else
                    {
                        var serialization = SerializationBuilder.Build(
                            bodyMediaType,
                            bodyRequestParameter.Type,
                            bodyParameterValue.Type);

                        // This method has a flattened body
                        if (bodyRequestParameter.Kind == InputOperationParameterKind.Flattened)
                        {
                            var objectType = (SchemaObjectType)typeFactory.CreateType(bodyRequestParameter.Type).Implementation;

                            var initializationMap = new List<ObjectPropertyInitializer>();
                            var references = allParameters
                                .Where(rp => rp.InputParameter is not null)
                                .ToDictionary(rp => rp.InputParameter!.NameInRequest, rp => CreateReference(rp.InputParameter, rp.OutputParameter, fields, typeFactory));

                            foreach ((_, InputParameter? inputParameter, _, _) in allParameters)
                            {
                                if (inputParameter is { VirtualParameter: { } virtualParameter })
                                {
                                    initializationMap.Add(new ObjectPropertyInitializer(objectType.GetPropertyForSchemaProperty(virtualParameter.TargetProperty, true), references[GetRequestParameterName(virtualParameter)]));
                                }
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

        private static ResponseBody? BuildResponseBody(OperationResponse response, TypeFactory typeFactory)
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

            if (bodyType is InputPrimitiveType { Kind: InputTypeKind.Stream })
            {
                return new StreamResponseBody();
            }

            CSharpType responseType = TypeFactory.GetOutputType(typeFactory.CreateType(bodyType));
            ObjectSerialization serialization = SerializationBuilder.Build(response.BodyMediaType, bodyType, responseType);

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

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        // Merges operations without response types types together
        private static CSharpType? ReduceResponses(List<Response> responses)
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

        public static RestClientMethod BuildNextPageMethod(RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                typeof(string),
                DefaultValue: null,
                Validation.AssertNotNull,
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
                    "A credential used to authenticate to an Azure Service.",
                    credentialType,
                    null,
                    Validation.AssertNotNull,
                    null);
                constructorParameters.Add(credentialParam);
            }

            constructorParameters.AddRange(GetOptionalParameters(parameters, includeAPIVersion));

            return constructorParameters;
        }
    }

    internal record RequestPartSource(string NameInRequest, InputParameter? InputParameter, Parameter OutputParameter, SerializationFormat SerializationFormat);
}
