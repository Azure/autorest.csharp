// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Generated;
using AutoRest.CSharp.V3.Output.Models;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;
using AutoRest.CSharp.V3.Utilities;
using Azure.Core;
using HttpHeader = AutoRest.CSharp.V3.Input.Generated.HttpHeader;
using Parameter = AutoRest.CSharp.V3.Output.Models.Shared.Parameter;
using Request = AutoRest.CSharp.V3.Output.Models.Requests.Request;
using Response = AutoRest.CSharp.V3.Output.Models.Responses.Response;
using SerializationFormat = AutoRest.CSharp.V3.Output.Models.Serialization.SerializationFormat;

namespace AutoRest.CSharp.V3.Output.Builders
{
    internal class ClientBuilder
    {
        public static Client BuildClient(OperationGroup operationGroup)
        {
            List<Method> methods = new List<Method>();
            Dictionary<string, Parameter> clientParameters = new Dictionary<string, Parameter>();

            var allClientParameters = operationGroup.Operations
                .SelectMany(op => op.Request.Parameters)
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct();

            // Deduplication required because of https://github.com/Azure/autorest.modelerfour/issues/100
            foreach (Input.Generated.Parameter clientParameter in allClientParameters)
            {
                clientParameters[clientParameter.Language.Default.Name] = BuildParameter(clientParameter);
            }

            string clientName = operationGroup.CSharpName();

            foreach (Operation operation in operationGroup.Operations)
            {
                var method = BuildMethod(operation, clientName, clientParameters);
                if (method != null)
                {
                    methods.Add(method);
                }
            }

            return new Client(clientName,
                operationGroup.Language.Default.Description,
                OrderParameters(clientParameters.Values),
                methods.ToArray());
        }

        private static Parameter[] OrderParameters(IEnumerable<Parameter> parameters)
        {
            return parameters.OrderBy(p => p.DefaultValue != null).ToArray();
        }

        private static Constant? CreateDefaultValueConstant(Input.Generated.Parameter requestParameter)
        {
            if (requestParameter.ClientDefaultValue != null)
            {
                return BuilderHelpers.ParseClientConstant(
                    requestParameter.ClientDefaultValue,
                    (FrameworkTypeReference)BuilderHelpers.CreateType(requestParameter.Schema, requestParameter.IsNullable()));
            }

            return null;
        }

        private static Method? BuildMethod(Operation operation, string clientName, IReadOnlyDictionary<string, Parameter> clientParameters)
        {
            var httpRequest = operation.Request.Protocol.Http as HttpRequest;
            var httpRequestWithBody = httpRequest as HttpWithBodyRequest;

            //TODO: Handle multiple responses
            var response = operation.Responses.FirstOrDefault();
            var httpResponse = response?.Protocol.Http as HttpResponse;

            if (httpRequest == null || httpResponse == null)
            {
                return null;
            }

            Dictionary<string, RequestParameter> uriParameters = new Dictionary<string, RequestParameter>();
            Dictionary<string, PathSegment> pathParameters = new Dictionary<string, PathSegment>();
            List<QueryParameter> query = new List<QueryParameter>();
            List<RequestHeader> headers = new List<RequestHeader>();
            List<Parameter> methodParameters = new List<Parameter>();

            RequestBody? body = null;
            foreach (Input.Generated.Parameter requestParameter in operation.Request.Parameters ?? Array.Empty<Input.Generated.Parameter>())
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                RequestParameter constantOrParameter;
                Schema valueSchema = requestParameter.Schema;

                if (requestParameter.Implementation == ImplementationLocation.Method)
                {
                    switch (requestParameter.Schema)
                    {
                        case ConstantSchema constant:
                            constantOrParameter = BuilderHelpers.ParseClientConstant(constant);
                            valueSchema = constant.ValueType;
                            break;
                        case BinarySchema _:
                            // skip
                            continue;
                        default:
                            constantOrParameter = BuildParameter(requestParameter);
                            break;
                    }

                    if (!constantOrParameter.IsConstant)
                    {
                        methodParameters.Add(constantOrParameter.Parameter);
                    }
                }
                else
                {
                    constantOrParameter = clientParameters[requestParameter.Language.Default.Name];
                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    SerializationFormat serializationFormat = BuilderHelpers.GetSerializationFormat(valueSchema);
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrParameter, serializationFormat));
                            break;
                        case ParameterLocation.Query:
                            query.Add(new QueryParameter(serializedName, constantOrParameter, GetSerializationStyle(httpParameter, valueSchema), true, serializationFormat));
                            break;
                        case ParameterLocation.Path:
                            pathParameters.Add(serializedName, new PathSegment(constantOrParameter, true, serializationFormat));
                            break;
                        case ParameterLocation.Body:
                            Debug.Assert(httpRequestWithBody != null);
                            var serialization = SerializationBuilder.Build(httpRequestWithBody.KnownMediaType, requestParameter.Schema, requestParameter.IsNullable());
                            body = new RequestBody(constantOrParameter, serialization);
                            break;
                        case ParameterLocation.Uri:
                            uriParameters[defaultName] = constantOrParameter;
                            break;
                    }
                }
            }

            if (httpRequestWithBody != null)
            {
                headers.AddRange(httpRequestWithBody.MediaTypes.Select(mediaType => new RequestHeader("Content-Type", BuilderHelpers.StringConstant(mediaType))));
            }

            var request = new Request(
                ToCoreRequestMethod(httpRequest.Method) ?? RequestMethod.Get,
                ToParts(httpRequest.Uri, uriParameters),
                ToPathParts(httpRequest.Path, pathParameters),
                query.ToArray(),
                headers.ToArray(),
                body
            );

            ResponseBody? responseBody = null;
            if (response is SchemaResponse schemaResponse)
            {
                var schema = schemaResponse.Schema is ConstantSchema constantSchema ? constantSchema.ValueType : schemaResponse.Schema;
                var responseType = BuilderHelpers.CreateType(schema, isNullable: false);

                ObjectSerialization serialization = SerializationBuilder.Build(httpResponse.KnownMediaType, schema, isNullable: false);

                responseBody = new ObjectResponseBody(responseType, serialization);
            }
            else if (response is BinaryResponse)
            {
                responseBody = new StreamResponseBody();
            }

            Response clientResponse = new Response(
                responseBody,
                httpResponse.StatusCodes.Select(ToStatusCode).ToArray(),
                BuildResponseHeaderModel(operation, httpResponse)
            );

            string operationName = operation.CSharpName();
            //TODO: This is a hack since we don't have the model information at this point
            var schemaForPaging = ((responseBody as ObjectResponseBody)?.Type as SchemaTypeReference)?.Schema as ObjectSchema;
            return new Method(
                operationName,
                BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                request,
                OrderParameters(methodParameters),
                clientResponse,
                new Diagnostic($"{clientName}.{operationName}",Array.Empty<DiagnosticAttribute>()),
                GetClientMethodPaging(operation, schemaForPaging)
            );
        }

        private static Paging? GetClientMethodPaging(Operation operation, ObjectSchema? schema)
        {
            var pageable = operation.Extensions.GetValue<IDictionary<object, object>>("x-ms-pageable");
            if (pageable == null) return null;

            var nextLinkName = pageable.GetValue<string>("nextLinkName");
            //TODO: This should actually reference an operation: https://github.com/Azure/autorest.csharp/issues/397
            var operationName = pageable.GetValue<string>("operationName");

            var itemName = pageable.GetValue<string>("itemName");
            //TODO: Hack to figure out the property name on the model
            var itemProperty = schema?.Properties?.FirstOrDefault(p => p.SerializedName == itemName);
            itemName = itemProperty?.CSharpName() ?? itemName ?? "Value";
            var nextLinkProperty = schema?.Properties?.FirstOrDefault(p => p.SerializedName == nextLinkName);
            nextLinkName = nextLinkProperty?.CSharpName() ?? nextLinkName;
            // If itemName resolves to Value, we can't use itemProperty. So, get the correct property.
            var itemTypeProperty = schema?.Properties?.FirstOrDefault(p => p.CSharpName() == itemName);
            var itemTypeValueSchema = (itemTypeProperty?.Schema as ArraySchema)?.ElementType;
            var itemType = BuilderHelpers.CreateType(itemTypeValueSchema ?? new Schema(), false);
            return new Paging(nextLinkName, itemName, itemType, operationName);
        }

        private static Parameter BuildParameter(Input.Generated.Parameter requestParameter)
        {
            Constant? defaultValue = null;
            if (requestParameter.Schema is ConstantSchema constantSchema)
            {
                defaultValue = BuilderHelpers.ParseClientConstant(constantSchema);
            }

            ParameterLocation? location = null;
            if (requestParameter.Protocol.Http is HttpParameter httpParameter)
            {
                location = httpParameter.In;
            }

            return new Parameter(
                requestParameter.CSharpName(),
                CreateDescription(requestParameter),
                BuilderHelpers.CreateType(requestParameter.Schema, requestParameter.IsNullable()),
                CreateDefaultValueConstant(requestParameter) ?? defaultValue,
                requestParameter.Required == true,
                location);
        }

        private static ResponseHeaderGroup? BuildResponseHeaderModel(Operation operation, HttpResponse httpResponse)
        {
            if (!httpResponse.Headers.Any())
            {
                return null;
            }

            ResponseHeader CreateResponseHeader(HttpHeader header) =>
                new ResponseHeader(header.Header.ToCleanName(), header.Header, BuilderHelpers.CreateType(header.Schema, true));

            string operationName = operation.CSharpName();

            return new ResponseHeaderGroup(
                operationName + "Headers",
                $"Header model for {operationName}",
                httpResponse.Headers.Select(CreateResponseHeader).ToArray()
                );
        }

        private static QuerySerializationStyle GetSerializationStyle(HttpParameter httpParameter, Schema valueSchema)
        {
            Debug.Assert(httpParameter.In == ParameterLocation.Query);

            switch (httpParameter.Style)
            {
                case null:
                case SerializationStyle.Form:
                    return valueSchema is ArraySchema ? QuerySerializationStyle.CommaDelimited : QuerySerializationStyle.Simple;
                case SerializationStyle.PipeDelimited:
                    return QuerySerializationStyle.PipeDelimited;
                case SerializationStyle.SpaceDelimited:
                    return QuerySerializationStyle.SpaceDelimited;
                case SerializationStyle.TabDelimited:
                    return QuerySerializationStyle.TabDelimited;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static RequestParameter[] ToParts(string httpRequestUri, Dictionary<string, RequestParameter> parameters)
        {
            List<RequestParameter> host = new List<RequestParameter>();
            foreach ((string text, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                host.Add(isLiteral ? BuilderHelpers.StringConstant(text) : parameters[text]);
            }

            return host.ToArray();
        }

        private static PathSegment[] ToPathParts(string httpRequestUri, Dictionary<string, PathSegment> parameters)
        {
            PathSegment TextSegment(string text)
            {
                return new PathSegment(BuilderHelpers.StringConstant(text), false, SerializationFormat.Default);
            }

            List<PathSegment> host = new List<PathSegment>();
            foreach ((string text, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                host.Add(isLiteral ? TextSegment(text) : parameters[text]);
            }

            return host.ToArray();
        }

        private static int ToStatusCode(StatusCodes arg) => int.Parse(arg.ToString().Trim('_'));

        private static RequestMethod? ToCoreRequestMethod(HttpMethod method) => method switch
        {
            HttpMethod.Delete => RequestMethod.Delete,
            HttpMethod.Get => RequestMethod.Get,
            HttpMethod.Head => RequestMethod.Head,
            HttpMethod.Options => (RequestMethod?)null,
            HttpMethod.Patch => RequestMethod.Patch,
            HttpMethod.Post => RequestMethod.Post,
            HttpMethod.Put => RequestMethod.Put,
            HttpMethod.Trace => null,
            _ => null
        };

        private static string CreateDescription(Input.Generated.Parameter requestParameter)
        {
            return string.IsNullOrWhiteSpace(requestParameter.Language.Default.Description) ?
                $"The {requestParameter.Schema.Name} to use." :
                BuilderHelpers.EscapeXmlDescription(requestParameter.Language.Default.Description);
        }
    }
}
