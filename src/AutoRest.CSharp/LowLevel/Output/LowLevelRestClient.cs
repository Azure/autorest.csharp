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
    internal class LowLevelRestClient : TypeProvider
    {
        private readonly OperationGroup _operationGroup;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private RestClientBuilder _builder;

        private LowLevelClientMethod[]? _allMethods;

        protected override string DefaultAccessibility { get; } = "public";

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            _builder = new RestClientBuilder (operationGroup, context);
            Parameters = _builder.GetOrderedParameters ().Where (p => !p.IsApiVersionParameter).ToArray();
            ClientPrefix = ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context);
            var clientSuffix = ClientBuilder.GetClientSuffix(context);
            DefaultName = ClientPrefix + clientSuffix;
        }

        public Parameter[] Parameters { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(_operationGroup, ClientBuilder.GetClientPrefix(Declaration.Name, _context)));
        public LowLevelClientMethod[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }

        private IEnumerable<LowLevelClientMethod> BuildAllMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, LowLevelClientMethod>();

            foreach (var operation in _operationGroup.Operations)
            {
                ServiceRequest serviceRequest = operation.Requests.FirstOrDefault(r => r.Protocol.Http is HttpRequest);
                if (serviceRequest != null)
                {
                    // Prepare our parameter list. If there were any parameters that should be passed in the body of the request,
                    // we want to generate a single parameter of type `RequestContent` named `requestBody` paramter. We want that
                    // parameter to be the last required parameter in the method signature (so any required path or query parameters
                    // will show up first.

                    IEnumerable<RequestParameter> requestParameters = serviceRequest.Parameters.Where (FilterServiceParamaters);
                    var accessibility = operation.Accessibility ?? "public";
                    RestClientMethod method = _builder.BuildMethod(operation, (HttpRequest)serviceRequest.Protocol.Http!, requestParameters, null, accessibility);
                    List<Parameter> parameters = method.Parameters.ToList();
                    RequestBody? body = null;
                    LowLevelClientMethod.SchemaDocumentation[]? schemaDocumentation = null;

                    if (serviceRequest.Parameters.Any(p => p.In == ParameterLocation.Body))
                    {
                        RequestParameter bodyParameter = serviceRequest.Parameters.First(p => p.In == ParameterLocation.Body);

                        // The service request had some parameters for the body, so create a parameter for the body and inject it into the list of parameters,
                        // right before the first optional parameter.
                        Parameter bodyParam = new Parameter("content", "The content to send as the body of the request.", typeof(Azure.Core.RequestContent), null, true);
                        int firstOptionalParameterIndex = parameters.FindIndex(p => p.DefaultValue != null);
                        if (firstOptionalParameterIndex == -1)
                        {
                            firstOptionalParameterIndex = parameters.Count;
                        }
                        parameters.Insert(firstOptionalParameterIndex, bodyParam);
                        body = new RequestContentRequestBody(bodyParam);
                        schemaDocumentation = GetSchemaDocumentationsForParameter(bodyParameter);
                    }

                    // Inject the RequestOptions
                    CSharpType requestType = new CSharpType (typeof(Azure.RequestOptions)).WithNullable(true);
                    Parameter options = new Parameter ("options", "The request options", requestType, new Constant(null, requestType), true);
                    parameters.Insert (parameters.Count, options);

                    Request request = new Request (method.Request.HttpMethod, method.Request.PathSegments, method.Request.Query, method.Request.Headers, body);
                    Diagnostic diagnostic = new Diagnostic($"{Declaration.Name}.{method.Name}");
                    yield return new LowLevelClientMethod(method.Name, method.Description, method.ReturnType, request, parameters.ToArray(), method.Responses, method.HeaderModel, method.BufferResponse, method.Accessibility, schemaDocumentation, diagnostic);
                }
            }
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

        private bool FilterServiceParamaters (RequestParameter p)
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

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType? credentialType)
        {
            return RestClientBuilder.GetConstructorParameters(Parameters, credentialType, true);
        }
    }
}
