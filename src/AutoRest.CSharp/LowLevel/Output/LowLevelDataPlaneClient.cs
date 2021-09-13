﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelDataPlaneClient : TypeProvider
    {
        private readonly OperationGroup _operationGroup;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private LowLevelClientMethod[]? _methods;
        private LowLevelLongRunningOperationMethod[]? _longRunningOperationMethods;
        private LowLevelRestClient? _restClient;

        public LowLevelDataPlaneClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            var clientPrefix = ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context);
            var clientSuffix = ClientBuilder.GetClientSuffix(context);
            DefaultName = clientPrefix + clientSuffix;
            ClientShortName = string.IsNullOrEmpty(clientPrefix) ? DefaultName : clientPrefix;
        }

        public string ClientShortName { get; }
        public Parameter[] Parameters { get => RestClient.Parameters; }
        public string Description => BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(_operationGroup, ClientBuilder.GetClientPrefix(Declaration.Name, _context)));
        public LowLevelRestClient RestClient => _restClient ??= _context.Library.FindRestClient(_operationGroup);
        public LowLevelClientMethod[] Methods => _methods ??= BuildMethods().ToArray();

        public LowLevelLongRunningOperationMethod[] LongRunningOperationMethods => _longRunningOperationMethods ??= BuildLongRunningOperationMethods().ToArray();

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        private IEnumerable<LowLevelClientMethod> BuildMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                if (operation.IsLongRunning)
                {
                    continue;
                }

                foreach (var request in operation.Requests)
                {
                    RestClientMethod method = RestClient.GetOperationMethod(request);
                    Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body)?.Schema;
                    Schema? responseSchema = operation.Responses.FirstOrDefault()?.ResponseSchema;
                    Schema? exceptionSchema = operation.Exceptions.FirstOrDefault()?.ResponseSchema;

                    yield return new LowLevelClientMethod(
                        method,
                        new LowLevelOperationSchemaInfo(requestSchema, responseSchema, exceptionSchema),
                        new Diagnostic($"{Declaration.Name}.{method.Name}"));
                }
            }
        }

        private IEnumerable<LowLevelLongRunningOperationMethod> BuildLongRunningOperationMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                if (operation.IsLongRunning)
                {
                    foreach (var request in operation.Requests)
                    {
                        RestClientMethod startMethod = RestClient.GetOperationMethod(request);
                        Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body)?.Schema;
                        Schema? responseSchema = operation.Responses.FirstOrDefault()?.ResponseSchema;
                        Schema? exceptionSchema = operation.Exceptions.FirstOrDefault()?.ResponseSchema;

                        yield return new LowLevelLongRunningOperationMethod(
                            startMethod,
                            new LowLevelOperationSchemaInfo(requestSchema, responseSchema, exceptionSchema),
                            new Diagnostic($"{Declaration.Name}.{startMethod.Name}")
                        );
                    }
                }
            }
        }

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType? credentialType)
        {
            return RestClientBuilder.GetConstructorParameters(Parameters, credentialType, false);
        }
    }
}
