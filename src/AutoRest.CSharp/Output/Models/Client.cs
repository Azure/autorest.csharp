// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class Client: ClientBase
    {
        private readonly OperationGroup _operationGroup;
        private PagingMethod[]? _pagingMethods;
        private ClientMethod[]? _methods;
        private LongRunningOperationMethod[]? _longRunningOperationMethods;
        private RestClient? _restClient;

        public Client(OperationGroup operationGroup, BuildContext context): base(context)
        {
            _operationGroup = operationGroup;

            var clientPrefix = GetClientPrefix(operationGroup.Language.Default.Name, Context);
            DefaultName = clientPrefix + ClientSuffix;
            ClientShortName = string.IsNullOrEmpty(clientPrefix) ? DefaultName : clientPrefix;
        }

        public string ClientShortName { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(_operationGroup, GetClientPrefix(Declaration.Name, Context)));
        public RestClient RestClient => _restClient ??= Context.Library.FindRestClient(_operationGroup);
        public ClientMethod[] Methods => _methods ??= BuildMethods().ToArray();

        public PagingMethod[] PagingMethods => _pagingMethods ??= BuildPagingMethods().ToArray();

        public LongRunningOperationMethod[] LongRunningOperationMethods => _longRunningOperationMethods ??= BuildLongRunningOperationMethods().ToArray();

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        private IEnumerable<PagingMethod> BuildPagingMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                Paging? paging = operation.Language.Default.Paging;
                if (paging == null || operation.IsLongRunning)
                {
                    continue;
                }

                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = RestClient.GetOperationMethod(serviceRequest);
                    RestClientMethod? nextPageMethod = RestClient.GetNextOperationMethod(serviceRequest);

                    if (!(method.Responses.SingleOrDefault(r => r.ResponseBody != null)?.ResponseBody is ObjectResponseBody objectResponseBody))
                    {
                        throw new InvalidOperationException($"Method {method.Name} has to have a return value");
                    }

                    yield return new PagingMethod(
                        method,
                        nextPageMethod,
                        method.Name,
                        new Diagnostic($"{Declaration.Name}.{method.Name}"),
                        new PagingResponseInfo(paging, objectResponseBody.Type));
                }
            }
        }

        private IEnumerable<LongRunningOperationMethod> BuildLongRunningOperationMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                if (operation.IsLongRunning)
                {
                    foreach (var serviceRequest in operation.Requests)
                    {
                        var name = operation.CSharpName();
                        RestClientMethod startMethod = RestClient.GetOperationMethod(serviceRequest);

                        yield return new LongRunningOperationMethod(
                            name,
                            Context.Library.FindLongRunningOperation(operation),
                            startMethod,
                            new Diagnostic($"{Declaration.Name}.Start{name}")
                        );
                    }
                }
            }
        }

        private IEnumerable<ClientMethod> BuildMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                if (operation.IsLongRunning || operation.Language.Default.Paging != null)
                {
                    continue;
                }

                foreach (var request in operation.Requests)
                {
                    var name = operation.CSharpName();
                    RestClientMethod startMethod = RestClient.GetOperationMethod(request);

                    yield return new ClientMethod(
                        name,
                        startMethod,
                        BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                        new Diagnostic($"{Declaration.Name}.{name}", Array.Empty<DiagnosticAttribute>()));
                }
            }
        }

        private IEnumerable<Parameter> GetRequiredParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            foreach (var parameter in RestClient.Parameters)
            {
                if (parameter.DefaultValue == null)
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        private IEnumerable<Parameter> GetOptionalParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            foreach (var parameter in RestClient.Parameters)
            {
                if (parameter.DefaultValue != null && !parameter.IsApiVersionParameter)
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        public IReadOnlyCollection<Parameter> GetClientConstructorParameters(CSharpType credentialType)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.AddRange(GetRequiredParameters());

            var credentialParam = new Parameter(
                "credential",
                "A credential used to authenticate to an Azure Service.",
                credentialType,
                null,
                true);
            parameters.Add(credentialParam);

            parameters.AddRange(GetOptionalParameters());

            return parameters;
        }

        private IEnumerable<Parameter> GetRequiredParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            foreach (var parameter in RestClient.Parameters)
            {
                if (parameter.DefaultValue == null)
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        private IEnumerable<Parameter> GetOptionalParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            foreach (var parameter in RestClient.Parameters)
            {
                if (parameter.DefaultValue != null && !parameter.IsApiVersionParameter)
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        public IReadOnlyCollection<Parameter> GetClientConstructorParameters(CSharpType credentialType)
        {
            List<Parameter> parameters = new List<Parameter>();

            parameters.AddRange(GetRequiredParameters());

            var credentialParam = new Parameter(
                "credential",
                "A credential used to authenticate to an Azure Service.",
                credentialType,
                null,
                true);
            parameters.Add(credentialParam);

            parameters.AddRange(GetOptionalParameters());

            return parameters;
        }
    }
}
