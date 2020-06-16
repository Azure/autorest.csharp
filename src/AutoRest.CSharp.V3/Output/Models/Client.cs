﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class Client: ClientBase
    {
        private readonly OperationGroup _operationGroup;
        private readonly BuildContext _context;
        private PagingMethod[]? _pagingMethods;
        private ClientMethod[]? _methods;
        private LongRunningOperationMethod[]? _longRunningOperationMethods;
        private RestClient? _restClient;

        public Client(OperationGroup operationGroup, BuildContext context): base(context)
        {
            _operationGroup = operationGroup;
            _context = context;

            var clientPrefix = GetClientPrefix(operationGroup.Language.Default.Name);
            DefaultName = clientPrefix + ClientSuffix;
            ClientShortName = string.IsNullOrEmpty(clientPrefix) ? DefaultName : clientPrefix;
        }

        public string ClientShortName { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(_operationGroup, GetClientPrefix(Declaration.Name)));
        public RestClient RestClient => _restClient ??= _context.Library.FindRestClient(_operationGroup);
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
                        new Diagnostic($"{Declaration.Name}.{name}", Array.Empty<DiagnosticAttribute>()));
                }
            }
        }
    }
}