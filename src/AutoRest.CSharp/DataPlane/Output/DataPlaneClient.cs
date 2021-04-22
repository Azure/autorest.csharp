// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
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
    internal class DataPlaneClient : TypeProvider
    {
        private readonly OperationGroup _operationGroup;
        private readonly BuildContext<DataPlaneOutputLibrary> _context;
        private PagingMethod[]? _pagingMethods;
        private ClientMethod[]? _methods;
        private DataPlaneLongRunningOperationMethod[]? _longRunningOperationMethods;
        private DataPlaneRestClient? _restClient;

        public DataPlaneClient(OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context): base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            DefaultAccessibility = "public"; 
            var clientPrefix = ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context);
            var clientSuffix = ClientBuilder.GetClientSuffix(context);
            DefaultName = clientPrefix + clientSuffix;
            ClientShortName = string.IsNullOrEmpty(clientPrefix) ? DefaultName : clientPrefix;
        }

        public string ClientShortName { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(_operationGroup, ClientBuilder.GetClientPrefix(Declaration.Name, _context)));
        public DataPlaneRestClient RestClient => _restClient ??= _context.Library.FindRestClient(_operationGroup);
        public ClientMethod[] Methods => _methods ??= BuildMethods().ToArray();

        public PagingMethod[] PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(_operationGroup, RestClient, Declaration).ToArray();

        public DataPlaneLongRunningOperationMethod[] LongRunningOperationMethods => _longRunningOperationMethods ??= BuildLongRunningOperationMethods().ToArray();

        public override string DefaultName { get; }

        private IEnumerable<DataPlaneLongRunningOperationMethod> BuildLongRunningOperationMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                if (operation.IsLongRunning)
                {
                    foreach (var serviceRequest in operation.Requests)
                    {
                        var name = operation.CSharpName();
                        RestClientMethod startMethod = RestClient.GetOperationMethod(serviceRequest);

                        yield return new DataPlaneLongRunningOperationMethod(
                            name,
                            _context.Library.FindLongRunningOperation(operation),
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
                        new Diagnostic($"{Declaration.Name}.{name}", Array.Empty<DiagnosticAttribute>()),
                        operation.Accessibility ?? "public");
                }
            }
        }

        public IReadOnlyCollection<Parameter> GetClientConstructorParameters(CSharpType credentialType)
        {
            return RestClientBuilder.GetConstructorParameters(RestClient.Parameters, credentialType, false);
        }
    }
}
