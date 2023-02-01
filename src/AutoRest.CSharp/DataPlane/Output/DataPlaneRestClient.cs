// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using static AutoRest.CSharp.Common.Output.Builders.ClientBuilder;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneRestClient : TypeProvider
    {
        private readonly string _clientName;
        private readonly IReadOnlyDictionary<InputOperation, RestClientMethod> _requestMethods;
        private readonly IReadOnlyDictionary<InputOperation, RestClientMethod> _nextPageRequestMethods;

        public IReadOnlyList<LowLevelClientMethod> ProtocolMethods { get; }
        public RestClientBuilder ClientBuilder { get; }
        public ClientFields Fields { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public IReadOnlyList<RestClientMethod> Methods { get; }
        public ConstructorSignature Constructor { get; }

        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        public DataPlaneRestClient(InputClient inputClient, RestClientBuilder clientBuilder, TypeFactory typeFactory, DataPlaneOutputLibrary library, string clientName, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            _clientName = clientName;
            var clientPrefix = GetClientPrefix(clientName, defaultNamespace);
            ClientPrefix = clientPrefix;
            DefaultName = clientPrefix + "Rest" + GetClientSuffix();

            Parameters = GetOrderedParameters(clientBuilder);
            ClientBuilder = clientBuilder;
            Fields = ClientFields.CreateForRestClient(Parameters);

            _requestMethods = EnsureNormalMethods(inputClient, Fields, typeFactory, library);
            _nextPageRequestMethods = EnsureGetNextPageMethods(inputClient, _requestMethods);

            Constructor = new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, MethodSignatureModifiers.Public, Parameters.ToArray());
            Methods = BuildAllMethods(inputClient, _requestMethods, _nextPageRequestMethods).ToArray();
            ProtocolMethods = GetProtocolMethods(Methods, Fields, inputClient, typeFactory, library).ToList();
        }

        private static Dictionary<InputOperation, RestClientMethod> EnsureNormalMethods(InputClient inputClient, ClientFields fields, TypeFactory typeFactory, DataPlaneOutputLibrary library)
        {
            var requestMethods = new Dictionary<InputOperation, RestClientMethod>();

            foreach (var operation in inputClient.Operations)
            {
                var headerModel = library.FindHeaderModel(operation);
                var parameters = new List<Parameter>();
                var requestParts = new List<RequestPartSource>();

                foreach (var inputParameter in operation.Parameters.Where(rp => !RestClientBuilder.IsIgnoredHeaderParameter(rp)))
                {
                    var parameter = Parameter.FromInputParameter(inputParameter, typeFactory.CreateType(inputParameter.Type), typeFactory);
                    // Grouped and flattened parameters shouldn't be added to methods
                    if (inputParameter.Kind == InputOperationParameterKind.Method)
                    {
                        parameters.Add(parameter);
                    }

                    var reference = MethodParametersBuilder.CreateReference(inputParameter, parameter, fields, typeFactory);
                    var serializationFormat = SerializationBuilder.GetSerializationFormat(inputParameter.Type);
                    requestParts.Add(new RequestPartSource(inputParameter.NameInRequest, inputParameter, reference, serializationFormat));
                }

                var method = RestClientBuilder.BuildRequestMethod(operation, RestClientBuilder.OrderParametersByRequired(parameters), requestParts, headerModel, typeFactory);
                requestMethods.Add(operation, method);
            }

            return requestMethods;
        }

        private static Dictionary<InputOperation, RestClientMethod> EnsureGetNextPageMethods(InputClient inputClient, IReadOnlyDictionary<InputOperation, RestClientMethod> normalMethods)
        {
            var nextPageMethods = new Dictionary<InputOperation, RestClientMethod>();
            foreach (var operation in inputClient.Operations)
            {
                var paging = operation.Paging;
                if (paging == null)
                {
                    continue;
                }

                RestClientMethod? nextMethod = null;
                if (paging.NextLinkOperation != null)
                {
                    nextMethod = normalMethods[paging.NextLinkOperation];
                }
                else if (paging.NextLinkName != null)
                {
                    var method = normalMethods[operation];
                    nextMethod = RestClientBuilder.BuildNextPageMethod(method);
                }

                if (nextMethod != null)
                {
                    nextPageMethods.Add(operation, nextMethod);
                }
            }

            return nextPageMethods;
        }

        private static IEnumerable<RestClientMethod> BuildAllMethods(InputClient inputClient, IReadOnlyDictionary<InputOperation, RestClientMethod> requestMethods, IReadOnlyDictionary<InputOperation, RestClientMethod> nextPageRequestMethods)
        {
            foreach (var operation in inputClient.Operations)
            {
                yield return requestMethods[operation];
            }

            foreach (var operation in inputClient.Operations)
            {
                // remove duplicates when GetNextPage method is not autogenerated
                if (nextPageRequestMethods.TryGetValue(operation, out RestClientMethod? nextOperationMethod) && operation.Paging?.NextLinkOperation == null)
                {
                    yield return nextOperationMethod;
                }
            }
        }

        private static IReadOnlyList<Parameter> GetOrderedParameters(RestClientBuilder clientBuilder)
        {
            var parameters = new List<Parameter> { KnownParameters.ClientDiagnostics, KnownParameters.Pipeline };
            parameters.AddRange(clientBuilder.GetOrderedParametersByRequired());
            return parameters;
        }

        private IEnumerable<LowLevelClientMethod> GetProtocolMethods(IEnumerable<RestClientMethod> methods, ClientFields fields, InputClient inputClient, TypeFactory typeFactory, DataPlaneOutputLibrary library)
        {
            // At least one protocol method is found in the config for this operationGroup
            if (!inputClient.Operations.Any(operation => IsProtocolMethodExists(operation, inputClient, library)))
            {
                return Enumerable.Empty<LowLevelClientMethod>();
            }

            // Filter protocol method requests for this operationGroup based on the config
            var operations = methods.Select(m => m.Operation).Where(operation => IsProtocolMethodExists(operation, inputClient, library));
            return LowLevelClient.BuildMethods(typeFactory, operations, fields, _clientName);
        }

        public RestClientMethod? GetNextOperationMethod(InputOperation request)
        {
            _nextPageRequestMethods.TryGetValue(request, out RestClientMethod? value);
            return value;
        }

        public RestClientMethod GetOperationMethod(InputOperation request)
            => _requestMethods[request];

        private static bool IsProtocolMethodExists(InputOperation operation, InputClient inputClient, DataPlaneOutputLibrary library)
            => library.ProtocolMethodsDictionary.TryGetValue(inputClient.Key, out var protocolMethods) &&
               protocolMethods.Any(m => m.Equals(operation.Name, StringComparison.OrdinalIgnoreCase));
    }
}
