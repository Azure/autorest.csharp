// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtRestClient : RestClient
    {
        public static readonly Parameter ApplicationIdParameter = new("applicationId", "The application id to use for user agent", new CSharpType(typeof(string)), null, false);

        private readonly MgmtRestClientBuilder _clientBuilder;
        private readonly CachedDictionary<ServiceRequest, RestClientMethod> _updatedRequestMethods;
        private readonly CachedDictionary<ServiceRequest, RestClientMethod> _updatedNextPageRequestMethods;
        private IReadOnlyList<Resource>? _resources;
        private RestClientMethod[]? _allUpdatedMethods;
        public Dictionary<RestClientMethod, ObjectSchema>? ClientMethodToSchema;
        public Schema[]? _optionalSchemas;

        public ClientFields Fields { get; }
        public RestClientMethod[] UpdatedMethods => _allUpdatedMethods ??= BuildAllUpdatedMethods().ToArray();

        public MgmtRestClient(OperationGroup operationGroup, MgmtRestClientBuilder clientBuilder)
            : base(operationGroup, MgmtContext.Context, operationGroup.Language.Default.Name, GetOrderedParameters(clientBuilder))
        {
            _clientBuilder = clientBuilder;
            _updatedRequestMethods = new CachedDictionary<ServiceRequest, RestClientMethod>(EnsureUpdatedNormalMethods);
            _updatedNextPageRequestMethods = new CachedDictionary<ServiceRequest, RestClientMethod>(EnsureUpdatedGetNextPageMethods);
            Fields = ClientFields.CreateForRestClient(new[] { KnownParameters.Pipeline }.Union(clientBuilder.GetOrderedParametersByRequired()));
        }

        protected override Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            EnsureNormalMethodsHelper(requestMethods, false);
            return requestMethods;
        }

        private Dictionary<ServiceRequest, RestClientMethod> EnsureUpdatedNormalMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            EnsureNormalMethodsHelper(requestMethods, true);
            return requestMethods;
        }

        private void EnsureNormalMethodsHelper(Dictionary<ServiceRequest, RestClientMethod> requestMethods, bool isPropertyBag)
        {
            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // See also LowLevelRestClient::EnsureNormalMethods if changing
                    if (serviceRequest.Protocol.Http is not HttpRequest httpRequest)
                    {
                        continue;
                    }
                    RestClientMethod method = _clientBuilder.BuildMethod(operation, httpRequest, serviceRequest.Parameters, null, "public", ShouldReturnNullOn404(operation));
                    if (isPropertyBag && method.Parameters.Where(p => p.DefaultValue != null).Count() > 2)
                    {
                        ObjectSchema schema = PropertyBag.UpdateMgmtRestClientParameters(operation, ref method, ClientPrefix);
                        if (ClientMethodToSchema is null)
                        {
                            ClientMethodToSchema = new Dictionary<RestClientMethod, ObjectSchema>();
                        }
                        ClientMethodToSchema.Add(method, schema);
                    }
                    requestMethods.Add(serviceRequest, method);
                }
            }
        }

        private Dictionary<ServiceRequest, RestClientMethod> EnsureUpdatedGetNextPageMethods()
        {
            var nextPageMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            foreach (var operation in OperationGroup.Operations)
            {
                var paging = operation.Language.Default.Paging;
                if (paging == null)
                {
                    continue;
                }
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod? nextMethod = null;
                    if (paging.NextLinkOperation != null)
                    {
                        nextMethod = GetUpdatedOperationMethod(paging.NextLinkOperation.Requests.Single());
                    }
                    else if (paging.NextLinkName != null)
                    {
                        var method = GetUpdatedOperationMethod(serviceRequest);
                        nextMethod = RestClientBuilder.BuildNextPageMethod(method);
                    }

                    if (nextMethod != null)
                    {
                        nextPageMethods.Add(serviceRequest, nextMethod);
                    }
                }
            }

            return nextPageMethods;
        }

        private IEnumerable<RestClientMethod> BuildAllUpdatedMethods()
        {
            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = GetUpdatedOperationMethod(serviceRequest);
                    yield return method;
                }
            }

            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // remove duplicates when GetNextPage method is not autogenerated
                    if (GetUpdatedNextOperationMethod(serviceRequest) is { } nextOperationMethod &&
                        operation.Language.Default.Paging?.NextLinkOperation == null)
                    {
                        yield return nextOperationMethod;
                    }
                }
            }
        }

        private static Func<string?, bool> ShouldReturnNullOn404(Operation operation)
        {
            Func<string?, bool> f = delegate (string? responseBodyType)
            {
                if (!MgmtContext.Library.TryGetResourceData(operation.GetHttpPath(), out var resourceData))
                    return false;
                if (!operation.IsGetResourceOperation(responseBodyType, resourceData))
                    return false;

                return operation.Responses.Any(r => r.ResponseSchema == resourceData.ObjectSchema);
            };
            return f;
        }

        public IReadOnlyList<Resource> Resources => _resources ??= GetResources();

        private IReadOnlyList<Resource> GetResources()
        {
            HashSet<Resource> candidates = new HashSet<Resource>();
            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var resource in operation.GetResourceFromResourceType())
                {
                    candidates.Add(resource);
                }
            }
            return candidates.ToList();
        }

        private static IReadOnlyList<Parameter> GetOrderedParameters(RestClientBuilder clientBuilder)
            => new[] {KnownParameters.Pipeline, ApplicationIdParameter}.Union(clientBuilder.GetOrderedParametersByRequired()).ToArray();

        public RestClientMethod? GetUpdatedNextOperationMethod(ServiceRequest request)
        {
            _updatedNextPageRequestMethods.TryGetValue(request, out RestClientMethod? value);
            return value;
        }

        public RestClientMethod GetUpdatedOperationMethod(ServiceRequest request)
        {
            return _updatedRequestMethods[request];
        }
    }
}
