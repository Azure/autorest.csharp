// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelRestClient : RestClient
    {
        protected override string DefaultAccessibility { get; } = "public";

        private BuildContext<LowLevelOutputLibrary> _context;

        public override Parameter[] Parameters { get; }

        public override string Description => BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(OperationGroup, ClientBuilder.GetClientPrefix(Declaration.Name, _context)));

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(operationGroup, context, null)
        {
            _context = context;
            Parameters = Builder.GetOrderedParameters().Where(p => !p.IsApiVersionParameter).ToArray();
        }

        protected override Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in OperationGroup.Operations)
            {
                foreach (ServiceRequest serviceRequest in operation.Requests)
                {
                    // See also DataPlaneRestClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }

                    // Prepare our parameter list. If there were any parameters that should be passed in the body of the request,
                    // we want to generate a single parameter of type `RequestContent` named `requestBody` paramter. We want that
                    // parameter to be the last required parameter in the method signature (so any required path or query parameters
                    // will show up first.

                    IEnumerable<RequestParameter> requestParameters = serviceRequest.Parameters.Where(FilterServiceParamaters);
                    var accessibility = operation.Accessibility ?? "public";
                    RestClientMethod method = Builder.BuildMethod(operation, (HttpRequest)serviceRequest.Protocol.Http!, requestParameters, null, accessibility);
                    RequestHeader[] requestHeaders = method.Request.Headers;
                    List<Parameter> parameters = method.Parameters.ToList();
                    RequestBody? body = null;
                    LowLevelClientMethod.SchemaDocumentation[]? schemaDocumentation = null;

                    if (serviceRequest.Parameters.Any(p => p.In == ParameterLocation.Body))
                    {
                        RequestParameter bodyParameter = serviceRequest.Parameters.First(p => p.In == ParameterLocation.Body);

                        // The service request had some parameters for the body, so create a parameter for the body and inject it into the list of parameters,
                        // right before the first optional parameter.
                        Parameter bodyParam = new Parameter("content", "The content to send as the body of the request.", typeof(Azure.Core.RequestContent), null, true);
                        int bodyIndex = parameters.FindIndex(p => p.DefaultValue != null);
                        if (bodyIndex == -1)
                        {
                            bodyIndex = parameters.Count;
                        }
                        parameters.Insert(bodyIndex, bodyParam);
                        body = new RequestContentRequestBody(bodyParam);
                        schemaDocumentation = GetSchemaDocumentationsForParameter(bodyParameter);

                        // If there's a Content-Type parameter in the parameters list, move it to after the parameter for the body, and change the
                        // type to be `Content-Type`
                        RequestParameter contentTypeRequestParameter = requestParameters.FirstOrDefault(IsSynthesizedContentTypeParameter);
                        if (contentTypeRequestParameter != null)
                        {
                            int contentTypeParamIndex = parameters.FindIndex(p => p.Name == contentTypeRequestParameter.CSharpName());

                            // If the service parameter has a constant value (which is the case in general, because most operations only use
                            // a single content type), it will not be in the parameter list for the operation method.
                            if (contentTypeParamIndex != -1)
                            {
                                Parameter contentTypeParameter = parameters[contentTypeParamIndex] with { Type = new CSharpType(typeof(Azure.Core.ContentType)) };

                                parameters.RemoveAt(contentTypeParamIndex);

                                // If the Content-Type paramter came before the the body, the removal of it above shifted the body parameter
                                // closer to the start of the list.
                                if (contentTypeParamIndex < bodyIndex)
                                {
                                    bodyIndex--;
                                }

                                parameters.Insert(bodyIndex + 1, contentTypeParameter);

                                // The request headers will have a reference to the parameter we've just updated the type of, so we need to update that reference as well.
                                for (int i = 0; i < requestHeaders.Length; i++)
                                {
                                    var requestHeader = requestHeaders[i];
                                    if (!requestHeader.Value.IsConstant && requestHeader.Value.Reference.Name == contentTypeParameter.Name)
                                    {
                                        requestHeaders[i] = new RequestHeader(requestHeader.Name, contentTypeParameter, requestHeader.SerializationStyle, requestHeader.Format);
                                    }
                                }
                            }
                        }
                    }

                    // Inject the RequestOptions
                    CSharpType requestType = new CSharpType (typeof(Azure.RequestOptions)).WithNullable(true);
                    Parameter options = new Parameter ("options", "The request options", requestType, new Constant(null, requestType), true);
                    parameters.Insert (parameters.Count, options);

                    Request request = new Request (method.Request.HttpMethod, method.Request.PathSegments, method.Request.Query, requestHeaders, body);
                    Diagnostic diagnostic = new Diagnostic($"{Declaration.Name}.{method.Name}");

                    requestMethods.Add(serviceRequest, new LowLevelClientMethod(method.Name, method.Description, method.ReturnType, request, parameters.ToArray(), method.Responses, method.HeaderModel, method.BufferResponse, method.Accessibility, operation, schemaDocumentation, diagnostic));
                }
            }

            return requestMethods;
        }
        private LowLevelClientMethod.SchemaDocumentation[]? GetSchemaDocumentationsForParameter(RequestParameter parameter)
        {
            // Visit each schema in the graph and for object schemas, collect information about all the properties.
            HashSet<string> visitedSchema = new HashSet<string>();
            Queue<Schema> schemasToExplore = new Queue<Schema>(new Schema[] { parameter.Schema });
            List<(string SchemaName, List<LowLevelClientMethod.SchemaDocumentation.DocumentationRow> Rows)> documentationObjects = new();

            while (schemasToExplore.Any())
            {
                Schema toExplore = schemasToExplore.Dequeue();

                if (visitedSchema.Contains(toExplore.Name))
                {
                    continue;
                }

                switch (toExplore)
                {
                    case OrSchema o:
                        foreach (Schema s in o.AnyOf)
                        {
                            schemasToExplore.Enqueue(s);
                        }
                        break;
                    case DictionarySchema d:
                        schemasToExplore.Enqueue(d.ElementType);
                        break;
                    case ArraySchema a:
                        schemasToExplore.Enqueue(a.ElementType);
                        break;
                    case ObjectSchema o:
                        List<LowLevelClientMethod.SchemaDocumentation.DocumentationRow> propertyDocumentation = new();

                        // We must also include any properties introduced by our parent chain.
                        foreach (ObjectSchema s in (o.Parents?.All ?? Array.Empty<ComplexSchema>()).Concat(new ComplexSchema[] { o }).OfType<ObjectSchema>())
                        {
                            foreach (Property prop in s.Properties)
                            {
                                propertyDocumentation.Add(new LowLevelClientMethod.SchemaDocumentation.DocumentationRow(
                                    prop.SerializedName,
                                    BuilderHelpers.EscapeXmlDescription(StringifyTypeForTable(prop.Schema)),
                                    prop.Required ?? false,
                                    BuilderHelpers.EscapeXmlDescription(prop.Language.Default.Description)));

                                schemasToExplore.Enqueue(prop.Schema);
                            }
                        }

                        documentationObjects.Add(new(parameter.Schema == o ? "Request Body" : StringifyTypeForTable(o), propertyDocumentation));
                        break;
                }

                visitedSchema.Add(toExplore.Name);
            }

            if (!documentationObjects.Any())
            {
                return null;
            }

            return documentationObjects.Select(o => new LowLevelClientMethod.SchemaDocumentation(o.SchemaName, o.Rows.ToArray())).ToArray();
        }

        private string StringifyTypeForTable(Schema s)
        {
            string RemovePrefix(string s, string prefix)
            {
                if (s.StartsWith(prefix))
                {
                    return s.Substring(prefix.Length);
                }

                return s;
            }

            switch (s)
            {
                case BooleanSchema:
                    return "boolean";
                case StringSchema:
                    return "string";
                case NumberSchema:
                    return "number";
                case AnySchema:
                    return "object";
                case DateTimeSchema:
                    return "string (ISO 8601 Format)";
                case ChoiceSchema c:
                    return string.Join(" | ", c.Choices.Select(c => $"\"{c.Value}\""));
                case DictionarySchema d:
                    return $"Dictionary<string, {StringifyTypeForTable(d.ElementType)}>";
                case ArraySchema a:
                    return $"{StringifyTypeForTable(a.ElementType)}[]";
                default:
                    return $"{RemovePrefix(s.Name, "Json")}";
            }
        }

        private bool FilterServiceParamaters(RequestParameter p)
        {
            switch (p.In)
            {
                case ParameterLocation.Header:
                case ParameterLocation.Query:
                case ParameterLocation.Path:
                case ParameterLocation.Uri:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsSynthesizedContentTypeParameter(RequestParameter p)
        {
            return p.Origin == "modelerfour:synthesized/content-type";
        }

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType? credentialType)
        {
            return RestClientBuilder.GetConstructorParameters(Parameters, credentialType, true);
        }
    }
}
