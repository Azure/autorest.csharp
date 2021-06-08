// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceOperation : TypeProvider
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Operations";
        private const string ContainerSuffixValue = "Container";
        private const string DataSuffixValue = "Data";
        private string _prefix;
        private Type? _resourceIdentifierType;
        private BuildContext<MgmtOutputLibrary> _context;
        private ClientMethod[]? _methods;
        private PagingMethod[]? _pagingMethods;

        private IEnumerable<OperationGroup>? _siblingOperationGroups;
        private IDictionary<OperationGroup, ClientMethod[]>? _childMethods;
        private IDictionary<OperationGroup, PagingMethod[]>? _childPagingMethods;

        internal OperationGroup OperationGroup { get; }
        protected MgmtRestClient? _restClient;

        public ResourceOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, IEnumerable<OperationGroup>? siblingOperationGroups = null)
            : base(context)
        {
            _context = context;
            OperationGroup = operationGroup;
            _siblingOperationGroups = siblingOperationGroups;
            _prefix = operationGroup.Resource(context.Configuration.MgmtConfiguration);
            var isExtension = operationGroup.IsExtensionResource(context.Configuration.MgmtConfiguration);
            string midValue = "";
            if (isExtension)
            {
                var parent = operationGroup.ParentResourceType(context.Configuration.MgmtConfiguration);
                var parentArr = parent.Split('/');
                midValue = parentArr[parentArr.Length - 1];
                midValue = FirstCharToUpper(midValue);
            }
            DefaultName = _prefix + midValue + SuffixValue;
        }

        public string ResourceName => OperationGroup.Resource(_context.Configuration.MgmtConfiguration);

        protected virtual string SuffixValue => OperationsSuffixValue;

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(OperationGroup, _prefix));

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public Type ResourceIdentifierType => _resourceIdentifierType ??= OperationGroup.GetResourceIdentifierType(
            _context.Library.GetResourceData(OperationGroup),
            _context.Configuration.MgmtConfiguration, false);

        public ClientMethod[] Methods => _methods ??= ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration).ToArray();

        public IDictionary<OperationGroup, ClientMethod[]> ChildMethods => _childMethods ??= EnsureChildMethods();

        private IDictionary<OperationGroup, ClientMethod[]> EnsureChildMethods()
        {
            var result = new Dictionary<OperationGroup, ClientMethod[]>();
            if (_siblingOperationGroups != null)
            {
                foreach (var operationGroup in _siblingOperationGroups)
                {
                    var methods = BuildMethods(operationGroup, _context.Library.GetRestClient(operationGroup), Declaration).ToArray();
                    if (methods.Length > 0)
                    {
                        result[operationGroup] = methods;
                    }
                }
            }
            return result;
        }

        // todo: BuildMethods is not very much different from ClientBuilder.BuildMethods
        // the only difference is that it overwrites the name of the method to always be "List{operationGroup.Key}
        private IEnumerable<ClientMethod> BuildMethods(OperationGroup operationGroup, RestClient restClient, TypeDeclarationOptions Declaration)
        {
            foreach (var operation in operationGroup.Operations)
            {
                if (operation.IsLongRunning || operation.Language.Default.Paging != null)
                {
                    continue;
                }

                foreach (var request in operation.Requests)
                {
                    var name = $"List{operationGroup.Key}";
                    RestClientMethod startMethod = restClient.GetOperationMethod(request);

                    yield return new ClientMethod(
                        name,
                        startMethod,
                        BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                        new Diagnostic($"{Declaration.Name}.{name}", Array.Empty<DiagnosticAttribute>()),
                        operation.Accessibility ?? "public");
                }
            }
        }

        public PagingMethod[] PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration).ToArray();

        public IDictionary<OperationGroup, PagingMethod[]> ChildPagingMethods => _childPagingMethods ??= EnsureChildPagingMethods();

        private IDictionary<OperationGroup, PagingMethod[]> EnsureChildPagingMethods()
        {
            var result = new Dictionary<OperationGroup, PagingMethod[]>();
            if (_siblingOperationGroups != null)
            {
                foreach (var operationGroup in _siblingOperationGroups)
                {
                    var methods = BuildPagingMethods(operationGroup, _context.Library.GetRestClient(operationGroup), Declaration).ToArray();
                    if (methods.Length > 0)
                    {
                        result[operationGroup] = methods;
                    }
                }
            }
            return result;
        }

        // same as BuildMethods
        private IEnumerable<PagingMethod> BuildPagingMethods(OperationGroup operationGroup, RestClient restClient, TypeDeclarationOptions Declaration)
        {
            foreach (var operation in operationGroup.Operations)
            {
                Paging? paging = operation.Language.Default.Paging;
                if (paging == null || operation.IsLongRunning)
                {
                    continue;
                }

                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = restClient.GetOperationMethod(serviceRequest);
                    RestClientMethod? nextPageMethod = restClient.GetNextOperationMethod(serviceRequest);

                    if (!(method.Responses.SingleOrDefault(r => r.ResponseBody != null)?.ResponseBody is ObjectResponseBody objectResponseBody))
                    {
                        throw new InvalidOperationException($"Method {method.Name} has to have a return value");
                    }

                    yield return new PagingMethod(
                        method,
                        nextPageMethod,
                        $"List{operationGroup.Key}",
                        new Diagnostic($"{Declaration.Name}.{method.Name}"),
                        new PagingResponseInfo(paging, objectResponseBody.Type));
                }
            }
        }

        protected virtual string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the operations that can be performed over a specific {clientPrefix}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        private static string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };
    }
}
