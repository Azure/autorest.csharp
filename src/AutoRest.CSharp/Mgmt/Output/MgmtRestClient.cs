// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtRestClient : RestClient
    {
        public static readonly Parameter ApplicationIdParameter = new("applicationId", "The application id to use for user agent", new CSharpType(typeof(string)), null, ValidationType.None, null);

        private readonly MgmtRestClientBuilder _clientBuilder;
        private IReadOnlyList<Resource>? _resources;

        public ClientFields Fields { get; }
        public OperationGroup OperationGroup { get; }

        public MgmtRestClient(InputClient inputClient, OperationGroup operationGroup, MgmtRestClientBuilder clientBuilder)
            : base(inputClient, MgmtContext.Context, inputClient.Name, GetOrderedParameters(clientBuilder))
        {
            OperationGroup = operationGroup;
            _clientBuilder = clientBuilder;
            Fields = ClientFields.CreateForRestClient(new[] { KnownParameters.Pipeline }.Union(clientBuilder.GetOrderedParametersByRequired()));
        }

        protected override Dictionary<InputOperation, RestClientMethod> EnsureNormalMethods()
        {
            return InputClient.Operations.ToDictionary(op => op, op => _clientBuilder.BuildMethod(op, null, "public", ShouldReturnNullOn404(op)));
        }

        private static Func<string?, bool> ShouldReturnNullOn404(InputOperation operation)
        {
            Func<string?, bool> f = delegate (string? responseBodyType)
            {
                if (!MgmtContext.Library.TryGetResourceData(GetHttpPath(operation), out var resourceData))
                    return false;
                if (!IsGetResourceOperation(operation, responseBodyType, resourceData))
                    return false;

                return operation.Responses.Any(r => r.BodyType is CodeModelType cmt && cmt.Schema == resourceData.ObjectSchema);
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

        private static bool IsGetResourceOperation(InputOperation operation, string? responseBodyType, ResourceData resourceData)
        {
            // first we need to be a GET operation
            if (operation.HttpMethod != RequestMethod.Get)
                return false;
            // then we get the corresponding OperationSet and see if this OperationSet corresponds to a resource
            var operationSet = MgmtContext.Library.GetOperationSet(GetHttpPath(operation));
            if (!operationSet.IsResource())
                return false;
            return responseBodyType == resourceData.Type.Name;
        }

        private static string GetHttpPath(InputOperation operation)
        {
            var path = operation.Path;
            // Do not trim the tenant resource path '/'.
            return path.Length == 1 ? path : path.TrimEnd('/');
        }
    }
}
