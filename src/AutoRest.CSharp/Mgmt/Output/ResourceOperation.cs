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
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceOperation : TypeProvider
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Operations";
        private const string ContainerSuffixValue = "Container";
        private const string DataSuffixValue = "Data";
        private Type? _resourceIdentifierType;
        private BuildContext<MgmtOutputLibrary> _context;
        private IEnumerable<ClientMethod>? _methods;
        private IEnumerable<PagingMethod>? _pagingMethods;
        private ClientMethod? _getMethod;
        private IEnumerable<ResourceListMethod>? _resourceOperationsListMethods;
        private ResourceListMethod? _subscriptionExtensionsListMethod;
        private ResourceListMethod? _tenantListMethod;
        private ResourceListMethod? _locationsListMethod;

        private IDictionary<OperationGroup, MgmtNonResourceOperation> _childOperations;

        internal OperationGroup OperationGroup { get; }
        protected MgmtRestClient? _restClient;

        public ResourceOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context,
            IEnumerable<OperationGroup>? nonResourceOperationGroups = null) : base(context)
        {
            _context = context;
            OperationGroup = operationGroup;
            DefaultName = ResourceName + SuffixValue;
            _childOperations = nonResourceOperationGroups?.ToDictionary(operationGroup => operationGroup,
                operationGroup => new MgmtNonResourceOperation(operationGroup, context, DefaultName)) ?? new Dictionary<OperationGroup, MgmtNonResourceOperation>();
        }

        public Resource Resource => _context.Library.GetArmResource(OperationGroup);

        public string ResourceName => Resource.Type.Name;

        protected virtual string SuffixValue => OperationsSuffixValue;

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(OperationGroup, ResourceName));

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public ResourceData ResourceData => _context.Library.GetResourceData(OperationGroup);

        public Type ResourceIdentifierType => _resourceIdentifierType ??= OperationGroup.GetResourceIdentifierType(_context);

        public IEnumerable<ClientMethod> Methods => _methods ??= GetMethodsInScope();

        public IDictionary<OperationGroup, MgmtNonResourceOperation> ChildOperations => _childOperations;

        public IEnumerable<PagingMethod> PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration);

        public IEnumerable<ResourceListMethod> ResourceOperationsListMethods => _resourceOperationsListMethods ??= GetResourceOperationsListMethod();

        public ResourceListMethod? SubscriptionExtensionsListMethod => _subscriptionExtensionsListMethod ??= GetSubscriptionExtensionsListMethod();

        public ResourceListMethod? TenantListMethod => _tenantListMethod ??= GetTenantListMethod();

        public ResourceListMethod? LocationsListMethod => _locationsListMethod ??= GetLocationsListMethod();

        public virtual ClientMethod? GetMethod => _getMethod ??= Methods.FirstOrDefault(m => m.Name.StartsWith("Get") && m.RestClientMethod.Responses[0].ResponseBody?.Type.Name == ResourceData.Type.Name);

        protected virtual IEnumerable<ClientMethod> GetMethodsInScope()
        {
            return ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration);
        }

        private IEnumerable<ResourceListMethod> GetResourceOperationsListMethod()
        {
            return GetListMethods(true, false);
        }

        private ResourceListMethod? GetSubscriptionExtensionsListMethod()
        {
            var listMethods = GetListMethods(false, true);
            foreach (var listMethod in listMethods)
            {
                var restClientMethod = GetRestClientMethod(listMethod);
                var pathSegments = restClientMethod?.Request.PathSegments;

                // subscriptions scope
                if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == "/subscriptions/") &&
                    !pathSegments.Any(p => p.Value.IsConstant && (p.Value.Constant.Value?.ToString() == "/resourceGroups/" || p.Value.Constant.Value?.ToString() == "/providers/Microsoft.Compute/locations/")))
                {
                    return listMethod;
                }
            }

            return null;
        }

        private ResourceListMethod? GetLocationsListMethod()
        {
            var listMethods = GetListMethods(false, true);
            foreach (var listMethod in listMethods)
            {
                var restClientMethod = GetRestClientMethod(listMethod);
                var pathSegments = restClientMethod?.Request.PathSegments;

                // locations scope
                if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == "/subscriptions/") &&
                    pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == "/providers/Microsoft.Compute/locations/") &&
                    !pathSegments.Any(p => p.Value.IsConstant && (p.Value.Constant.Value?.ToString() == "/resourceGroups/")))
                {
                    return listMethod;
                }
            }

            return null;
        }

        private ResourceListMethod? GetResourceGroupsListMethod()
        {
            var listMethods = GetListMethods(false, true);
            foreach (var listMethod in listMethods)
            {
                var restClientMethod = GetRestClientMethod(listMethod);
                var pathSegments = restClientMethod?.Request.PathSegments;

                // resourceGroups scope
                if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == "/resourceGroups/"))
                {
                    return listMethod;
                }
            }

            return null;
        }

        private ResourceListMethod? GetTenantListMethod()
        {
            var listMethods = GetListMethods(false, true);
            foreach (var listMethod in listMethods)
            {
                var restClientMethod = GetRestClientMethod(listMethod);
                var pathSegments = restClientMethod?.Request.PathSegments;

                // tenant scope
                if (!pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == "/subscriptions/") &&
                    !pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == "/resourceGroups/"))
                {
                    return listMethod;
                }
            }

            return null;
        }

        public RestClientMethod? GetRestClientMethod(ResourceListMethod? listMethod)
        {
            if (listMethod != null)
            {
                if (listMethod.PagingMethod != null)
                {
                    return listMethod.PagingMethod.Method;
                }
                else if (listMethod.ClientMethod != null)
                {
                    return listMethod.ClientMethod.RestClientMethod;
                }
            }

            return null;
        }

        protected IEnumerable<ResourceListMethod> GetListMethods(bool parentExistsInPathParam, bool returnTypeIsResourceData)
        {
            List<ResourceListMethod> listMethods = new List<ResourceListMethod>();
            var parentResourceType = OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);

            foreach (var pagingMethod in PagingMethods)
            {
                if (IsValidListMethod(parentExistsInPathParam, returnTypeIsResourceData, pagingMethod.Method))
                {
                    listMethods.Add(new ResourceListMethod(pagingMethod, null));
                }
            }

            foreach (var method in Methods)
            {
                if (IsValidListMethod(parentExistsInPathParam, returnTypeIsResourceData, method.RestClientMethod))
                {
                    listMethods.Add(new ResourceListMethod(null, method));
                }
            }

            return listMethods;
        }

        private bool IsValidListMethod(bool parentExistsInPathParam, bool returnTypeIsResourceData, RestClientMethod clientMethod)
        {
            var parentResourceType = OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);
            bool isParentExistsInPathParams = false;
            bool isReturnTypeResourceData = false;

            var parentParamName = "";
            if (clientMethod.Operation?.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest)
            {
                var path = httpRequest.Path;
                var parentIndex = path.IndexOf(parentResourceType);
                if (parentIndex > 0)
                {
                    path = path.Substring(parentIndex + parentResourceType.Length);
                    var pathArr = path.Split('/');
                    char[] charsToTrim = { '{', '}' };
                    parentParamName = pathArr[1].Trim(charsToTrim);

                    isParentExistsInPathParams = clientMethod.PathParameters.Any(p => p.Name == parentParamName);
                }
            }

            var resourceData = _context.Library.GetResourceData(OperationGroup);
            var returnType = clientMethod.ReturnType;
            if (returnType != null && !returnType.IsFrameworkType)
            {
                var objType = returnType.Implementation as MgmtObjectType;
                isReturnTypeResourceData = objType != null && objType.Properties.Any(p => p.ValueType.Arguments != null && p.ValueType.Arguments.Length > 0 && p.ValueType.Arguments[0].Name == resourceData.Type.Name);
            }
            else if (returnType != null && returnType.Arguments != null)
            {
                isReturnTypeResourceData = returnType.Arguments != null && returnType.Arguments.Length > 0 && returnType.Arguments[0].Name == resourceData.Type.Name;
            }

            if (isParentExistsInPathParams == parentExistsInPathParam && isReturnTypeResourceData == returnTypeIsResourceData)
            {
                return true;
            }

            return false;
        }

        public Diagnostic GetDiagnostic(RestClientMethod method)
        {
            return new Diagnostic($"{Declaration.Name}.{method.Name}", Array.Empty<DiagnosticAttribute>());
        }

        protected virtual string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the operations that can be performed over a specific {clientPrefix}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        public class ResourceListMethod
        {
            public PagingMethod? PagingMethod { get; }

            public ClientMethod? ClientMethod { get; }

            public ResourceListMethod(PagingMethod? pagingMethod = null, ClientMethod? clientMethod = null)
            {
                PagingMethod = pagingMethod;
                ClientMethod = clientMethod;
            }
        }
    }
}
