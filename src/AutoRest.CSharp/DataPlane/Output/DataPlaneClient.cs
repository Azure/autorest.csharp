// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneClient : TypeProvider
    {
        private readonly InputClient _inputClient;
        private readonly BuildContext<DataPlaneOutputLibrary> _context;
        private PagingMethod[]? _pagingMethods;
        private ClientMethod[]? _methods;
        private LongRunningOperationMethod[]? _longRunningOperationMethods;
        private DataPlaneRestClient? _restClient;

        public DataPlaneClient(InputClient inputClient, BuildContext<DataPlaneOutputLibrary> context) :
            this(inputClient, context, ClientBuilder.GetClientPrefix(inputClient.Name, context), ClientBuilder.GetClientSuffix())
        {
        }

        private DataPlaneClient(InputClient inputClient, BuildContext<DataPlaneOutputLibrary> context, string clientPrefix, string clientSuffix) : base(context)
        {
            _inputClient = inputClient;
            _context = context;
            DefaultName = clientPrefix + clientSuffix;
            ClientShortName = string.IsNullOrEmpty(clientPrefix) ? DefaultName : clientPrefix;
        }

        public string ClientShortName { get; }
        protected override string DefaultName { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(_inputClient.Description, ClientBuilder.GetClientPrefix(Declaration.Name, _context)));
        public DataPlaneRestClient RestClient => _restClient ??= _context.Library.FindRestClient(_inputClient);
        public ClientMethod[] Methods => _methods ??= ClientBuilder.BuildMethods(_inputClient, RestClient, Declaration).ToArray();

        public PagingMethod[] PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(_inputClient, RestClient, Declaration).ToArray();

        public LongRunningOperationMethod[] LongRunningOperationMethods => _longRunningOperationMethods ??= BuildLongRunningOperationMethods().ToArray();

        protected override string DefaultAccessibility { get; } = "public";

        private IEnumerable<LongRunningOperationMethod> BuildLongRunningOperationMethods()
        {
            foreach (var operation in _inputClient.Operations)
            {
                if (operation.LongRunning == null)
                {
                    continue;
                }

                var name = operation.CleanName;
                RestClientMethod startMethod = RestClient.GetOperationMethod(operation);

                yield return new LongRunningOperationMethod(
                    name,
                    _context.Library.FindLongRunningOperation(operation),
                    startMethod,
                    new Diagnostic($"{Declaration.Name}.Start{name}")
                );
            }
        }

        public IReadOnlyCollection<Parameter> GetClientConstructorParameters(CSharpType credentialType)
        {
            return RestClientBuilder.GetConstructorParameters(RestClient.ClientBuilder.GetOrderedParametersByRequired(), credentialType, false);
        }
    }
}
