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
using Azure.Core;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class RestClientBuilder
    {
        private readonly SerializationBuilder _serializationBuilder;
        private readonly BuildContext _context;
        private readonly OutputLibrary _library;
        private readonly Dictionary<string, Parameter> _parameters;

        public RestClientBuilder (OperationGroup operationGroup, BuildContext context)
        {
            _serializationBuilder = new SerializationBuilder ();
            _context = context;
            _library = context.BaseLibrary!;

            _parameters = operationGroup.Operations
                .SelectMany(op => op.Parameters.Concat(op.Requests.SelectMany(r => r.Parameters)))
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct()
                .ToDictionary(p => p.Language.Default.Name, BuildClientParameter);
        }

        public Parameter[] GetOrderedParameters ()
        {
            return OrderParameters(_parameters.Values);
        }

        private static readonly HashSet<string> IgnoredRequestHeader = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "x-ms-client-request-id",
            "tracestate",
            "traceparent"
        };

        private record ConstructedParameter(Parameter? Parameter, ReferenceOrConstant Reference);

        private string GetRequestParameterName (RequestParameter requestParameter)
        {
            string defaultName = requestParameter.Language.Default.Name;
            return requestParameter.Language.Default.SerializedName ?? defaultName;
        }

        public RestClientMethod BuildMethod(Operation operation, HttpRequest httpRequest, IEnumerable<RequestParameter> requestParameters, DataPlaneResponseHeaderGroupType? responseHeaderModel, string accessibility)
        {
            Dictionary<RequestParameter, ConstructedParameter> allParameters = new ();

            List<RequestParameter> parameters = operation.Parameters.Concat(requestParameters).ToList();
            // Remove ignored headers
            parameters.RemoveAll(requestParameter =>
                requestParameter.In == ParameterLocation.Header &&
                IgnoredRequestHeader.Contains(GetRequestParameterName(requestParameter)));

            foreach (RequestParameter requestParameter in parameters)
            {
                allParameters.Add(requestParameter, CreateParameter(requestParameter));
            }

            Request request = BuildRequest(httpRequest, parameters, allParameters);
            Response[] responses = BuildResponses(operation, request, out var responseType);
            Parameter[] methodParameters = BuildMethodParameters(parameters, allParameters);

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

        private Response[] BuildResponses(Operation operation, Request request, out CSharpType? responseType)
        {
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

            responseType = ReduceResponses(clientResponse);

            if (request.HttpMethod == RequestMethod.Head && _context.Configuration.HeadAsBoolean)
            {
                responseType = new CSharpType(typeof(bool));
                clientResponse = new List<Response>()
                {
                    new Response(
                        new ConstantResponseBody(new Constant(true, new CSharpType(typeof(bool)))),
                        new[] {new StatusCodes(null, 2)}),
                    new Response(
                        new ConstantResponseBody(new Constant(false, new CSharpType(typeof(bool)))),
                        new[] {new StatusCodes(null, 4)}),
                };
            }

            return clientResponse.ToArray();
        }

        private Request BuildRequest(HttpRequest httpRequest, IList<RequestParameter> requestParameters, Dictionary<RequestParameter, ConstructedParameter> allParameters)
        {
            RequestBody? body = null;
            if (httpRequest is HttpWithBodyRequest httpWithBodyRequest)
            {
                body = BuildRequestBody(requestParameters, allParameters, httpWithBodyRequest.KnownMediaType);
            }

            RequestHeader[] headers = BuildHeaders(requestParameters, allParameters);
            QueryParameter[] query = BuildQueryParameters(requestParameters, allParameters);
            Dictionary<string, PathSegment> uriParameters = BuildUriParameters(requestParameters, allParameters);
            Dictionary<string, PathSegment> pathParameters = BuildPathParameters(requestParameters, allParameters);

            PathSegment[] pathSegments = GetPathSegments(httpRequest.Uri, uriParameters, isRaw: true)
                .Concat(GetPathSegments(httpRequest.Path, pathParameters))
                .ToArray();
            Request request = new Request(
                httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                pathSegments,
                query.ToArray(),
                headers.ToArray(),
                body
            );
            return request;
        }

        private Dictionary<string, PathSegment> BuildPathParameters(IList<RequestParameter> requestParameters, Dictionary<RequestParameter, ConstructedParameter> allParameters)
        {
            Dictionary<string, PathSegment> path = new ();
            foreach (var requestParameter in requestParameters)
            {
                if (requestParameter.In == ParameterLocation.Path)
                {
                    var (_, reference) = allParameters[requestParameter];
                    var serializedName = GetRequestParameterName(requestParameter);
                    path[serializedName] = new PathSegment(reference, !requestParameter.Extensions!.SkipEncoding, GetSerializationFormat(requestParameter));
                }
            }

            return path;
        }

        private Dictionary<string, PathSegment> BuildUriParameters(IList<RequestParameter> requestParameters, Dictionary<RequestParameter, ConstructedParameter> allParameters)
        {
            Dictionary<string, PathSegment> uriParameters = new ();
            foreach (var requestParameter in requestParameters)
            {
                if (requestParameter.In == ParameterLocation.Uri)
                {
                    var (_, reference) = allParameters[requestParameter];
                    var serializedName = GetRequestParameterName(requestParameter);
                    uriParameters.Add(serializedName, new PathSegment(
                        reference,
                        !requestParameter.Extensions!.SkipEncoding,
                        GetSerializationFormat(requestParameter), isRaw: true));
                }
            }

            return uriParameters;
        }

        private RequestHeader[] BuildHeaders(IList<RequestParameter> requestParameters, Dictionary<RequestParameter, ConstructedParameter> allParameters)
        {
            List<RequestHeader> headers = new ();
            foreach (var requestParameter in requestParameters)
            {
                if (requestParameter.In == ParameterLocation.Header)
                {
                    var (_, reference) = allParameters[requestParameter];
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

            return headers.ToArray();
        }

        private QueryParameter[] BuildQueryParameters(IList<RequestParameter> requestParameters, Dictionary<RequestParameter, ConstructedParameter> allParameters)
        {
            List<QueryParameter> query = new ();
            foreach (var requestParameter in requestParameters)
            {
                if (requestParameter.In == ParameterLocation.Query)
                {
                    var (_, reference) = allParameters[requestParameter];
                    query.Add(new QueryParameter(
                        GetRequestParameterName(requestParameter),
                        reference,
                        GetSerializationStyle(requestParameter),
                        !requestParameter.Extensions!.SkipEncoding,
                        GetSerializationFormat(requestParameter)));
                }
            }

            return query.ToArray();
        }

        private Parameter[] BuildMethodParameters(IList<RequestParameter> parameters, Dictionary<RequestParameter, ConstructedParameter> allParameters)
        {
            List<Parameter> methodParameters = new ();
            foreach (var requestParameter in parameters)
            {
                var (parameter, _) = allParameters[requestParameter];
                // Grouped and flattened parameters shouldn't be added to methods
                if (parameter != null &&
                    requestParameter.Flattened != true &&
                    requestParameter.GroupedBy == null)
                {
                    methodParameters.Add(parameter);
                }
            }

            return OrderParameters(methodParameters);
        }

        private RequestBody? BuildRequestBody(
            IList<RequestParameter> requestParameters,
            Dictionary<RequestParameter, ConstructedParameter> allParameters,
            KnownMediaType mediaType)
        {
            RequestBody? body = null;

            Dictionary<RequestParameter, ReferenceOrConstant> bodyParameters = new ();
            foreach (var (requestParameter, (_, value)) in allParameters)
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

                        if (type.IsFrameworkType && type.FrameworkType == typeof(string))
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
                            var virtualParameters = requestParameters.OfType<VirtualParameter>().ToArray();

                            List<ObjectPropertyInitializer> initializationMap = new List<ObjectPropertyInitializer>();
                            foreach (var virtualParameter in virtualParameters)
                            {
                                if (virtualParameter.Schema is ConstantSchema)
                                    continue;

                                ConstructedParameter actualParameter = allParameters[virtualParameter];

                                initializationMap.Add(new ObjectPropertyInitializer(
                                    objectType.GetPropertyForSchemaProperty(virtualParameter.TargetProperty, true),
                                    actualParameter.Reference));
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

        private ConstructedParameter CreateParameter(RequestParameter requestParameter)
        {
            Parameter? parameter = null;
            ReferenceOrConstant constantOrReference;
            if (requestParameter.Implementation == ImplementationLocation.Method)
            {
                if (requestParameter.Schema is ConstantSchema constant)
                {
                    constantOrReference = ParseConstant(constant);
                }
                else
                {
                    parameter = BuildParameter(requestParameter);

                    if (requestParameter.GroupedBy is RequestParameter groupedByParameter)
                    {
                        var groupModel = (SchemaObjectType) _context.TypeFactory.CreateType(groupedByParameter.Schema, false).Implementation;
                        var property = groupModel.GetPropertyForGroupedParameter(requestParameter);

                        constantOrReference = new Reference($"{groupedByParameter.CSharpName()}.{property.Declaration.Name}", property.Declaration.Type);
                    }
                    else
                    {
                        constantOrReference = parameter;
                    }
                }
            }
            else
            {
                constantOrReference = _parameters[requestParameter.Language.Default.Name];
            }

            return new ConstructedParameter(parameter, constantOrReference);
        }

        private SerializationFormat GetSerializationFormat(RequestParameter requestParameter)
        {
            return BuilderHelpers.GetSerializationFormat(GetValueSchema(requestParameter));
        }

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

        private static Schema GetValueSchema(RequestParameter requestParameter)
        {
            Schema valueSchema = requestParameter.Schema;

            if (requestParameter.Schema is ConstantSchema constant)
            {
                valueSchema = constant.ValueType;
            }

            return valueSchema;
        }

        private static IEnumerable<PathSegment> GetPathSegments(string httpRequestUri, Dictionary<string, PathSegment> parameters, bool isRaw = false)
        {
            PathSegment TextSegment(string text)
            {
                return new PathSegment(BuilderHelpers.StringConstant(text), false, SerializationFormat.Default, isRaw);
            }

            foreach ((string text, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                if (isLiteral)
                {
                    yield return TextSegment(text);
                }
                else
                {
                    if (!parameters.ContainsKey (text))
                    {
                        ErrorHelpers.ThrowError ($"\n\nError while processing request '{httpRequestUri}'\n\n  '{text}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }
                    yield return parameters[text];
                }
            }
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

        public Parameter BuildClientParameter(RequestParameter requestParameter)
        {
            var parameter = BuildParameter(requestParameter);
            if (requestParameter.Origin == "modelerfour:synthesized/host")
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

        private Parameter BuildParameter(RequestParameter requestParameter)
        {
            CSharpType type = _context.TypeFactory.CreateType(requestParameter.Schema, requestParameter.IsNullable || !requestParameter.IsRequired);

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
                CreateDescription(requestParameter),
                TypeFactory.GetInputType(type),
                defaultValue,
                isRequired,
                requestParameter.Origin == "modelerfour:synthesized/api-version");
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

        private static string CreateDescription(RequestParameter requestParameter)
        {
            return string.IsNullOrWhiteSpace(requestParameter.Language.Default.Description) ?
                $"The {requestParameter.Schema.Name} to use." :
                BuilderHelpers.EscapeXmlDescription(requestParameter.Language.Default.Description);
        }

        private static IEnumerable<Parameter> GetRequiredParameters(Parameter[] parameters)
        {
            List<Parameter> requiredParameters = new List<Parameter>();
            foreach (var parameter in parameters)
            {
                if (parameter.DefaultValue == null)
                {
                    requiredParameters.Add(parameter);
                }
            }

            return requiredParameters;
        }

        private static IEnumerable<Parameter> GetOptionalParameters(Parameter[] parameters, bool includeAPIVersion = false)
        {
            List<Parameter> optionalParameters = new List<Parameter>();
            foreach (var parameter in parameters)
            {
                if (parameter.DefaultValue != null && (includeAPIVersion || !parameter.IsApiVersionParameter))
                {
                    optionalParameters.Add(parameter);
                }
            }

            return optionalParameters;
        }

        public static IReadOnlyCollection<Parameter> GetConstructorParameters(Parameter[] parameters, CSharpType? credentialType, bool includeAPIVersion = false)
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
    }
}
