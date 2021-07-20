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
        private IEnumerable<ResourceListMethod>? _subscriptionExtensionsListMethods;
        private IEnumerable<ResourceListMethod>? _resourceGroupExtensionsListMethods;
        private IEnumerable<ResourceListMethod>? _tenantExtensionsListMethods;
        private IEnumerable<ResourceListMethod>? _managementGroupExtensionsListMethods;

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

        public ResourceContainer? ResourceContainer => _context.Library.GetResourceContainer(OperationGroup);

        public string ResourceName => Resource.Type.Name;

        protected virtual string SuffixValue => OperationsSuffixValue;

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(OperationGroup, ResourceName));

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public ResourceData ResourceData => _context.Library.GetResourceData(OperationGroup);

        public Type ResourceIdentifierType => _resourceIdentifierType ??= OperationGroup.GetResourceIdentifierType(_context);

        public IEnumerable<ClientMethod> Methods => _methods ??= GetMethodsInScope();

        public IEnumerable<ClientMethod> ResourceOperationsClientMethods => GetResourceOperationsClientMethods();

        public IEnumerable<RestClientMethod> ResourceOperationsLROMethods => GetResourceOperationsLROMethods();

        public IDictionary<OperationGroup, MgmtNonResourceOperation> ChildOperations => _childOperations;

        public IEnumerable<PagingMethod> PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration);

        public IEnumerable<ResourceListMethod> ResourceOperationsListMethods => _resourceOperationsListMethods ??= GetResourceOperationsListMethod();

        public IEnumerable<ResourceListMethod>? SubscriptionExtensionsListMethods => _subscriptionExtensionsListMethods ??= GetSubscriptionExtensionsListMethods();

        public IEnumerable<ResourceListMethod>? ResourceGroupExtensionsListMethods => _resourceGroupExtensionsListMethods ??= GetResourceGroupExtensionsListMethods();

        public IEnumerable<ResourceListMethod>? TenantExtensionsListMethods => _tenantExtensionsListMethods ??= GetTenantExtensionsListMethods();

        public IEnumerable<ResourceListMethod>? ManagementGroupExtensionListMethods => _managementGroupExtensionsListMethods ??= GetManagementGroupExtensionsListMethods();

        public virtual ClientMethod? GetMethod => _getMethod ??= Methods.FirstOrDefault(m => m.Name.StartsWith("Get") && m.RestClientMethod.Responses[0].ResponseBody?.Type.Name == ResourceData.Type.Name);

        protected virtual IEnumerable<ClientMethod> GetMethodsInScope()
        {
            return ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration);
        }

        private IEnumerable<ClientMethod> GetResourceOperationsClientMethods()
        {
            var clientMethods = new List<ClientMethod>();
            foreach (var clientMethod in Methods)
            {
                var isMethodAlreadyExist = false;
                if (ResourceContainer != null)
                {
                    isMethodAlreadyExist = clientMethod.RestClientMethod == ResourceContainer.CreateMethod ||
                        ResourceContainer.RemainingMethods.Any(m => m == clientMethod) ||
                        ResourceContainer.ListMethods.Any(m => m.GetRestClientMethod() == clientMethod.RestClientMethod ||
                        SubscriptionExtensionsListMethods.Any(s => clientMethod.RestClientMethod == s.GetRestClientMethod()));
                }
                if (!isMethodAlreadyExist)
                {
                    clientMethods.Add(clientMethod);
                }
            }

            return clientMethods;
        }

        private IEnumerable<RestClientMethod> GetResourceOperationsLROMethods()
        {
            var clientMethods = new List<RestClientMethod>();
            foreach (var clientMethod in RestClient.Methods)
            {
                if (clientMethod.Operation != null && clientMethod.Operation.IsLongRunning)
                {
                    var isMethodExistInContainer = false;
                    if (ResourceContainer != null)
                    {
                        isMethodExistInContainer = clientMethod == ResourceContainer.CreateMethod ||
                            ResourceContainer.RemainingMethods.Any(m => m.RestClientMethod == clientMethod) ||
                            ResourceContainer.ListMethods.Any(m => m.GetRestClientMethod() == clientMethod ||
                            SubscriptionExtensionsListMethods.Any(s => clientMethod == s.GetRestClientMethod()));
                    }
                    if (!isMethodExistInContainer)
                    {
                        clientMethods.Add(clientMethod);
                    }
                }
            }

            return clientMethods;
        }

        private IEnumerable<ResourceListMethod> GetResourceOperationsListMethod()
        {
            return GetListMethods(true, false);
        }

        private IEnumerable<ResourceListMethod>? GetSubscriptionExtensionsListMethods()
        {
            var listMethods = GetListMethods(false, true);
            var subscriptionExtensionsListMethods = new List<ResourceListMethod>();

            foreach (var listMethod in listMethods)
            {
                var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

                // Subscriptions scope
                if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.Subscriptions}/"))
                {
                    subscriptionExtensionsListMethods.Add(listMethod);
                }
            }

            return subscriptionExtensionsListMethods;
        }

        private IEnumerable<ResourceListMethod>? GetResourceGroupExtensionsListMethods()
        {
            var listMethods = GetListMethods(false, true);
            var resourceGroupExtensionsListMethod = new List<ResourceListMethod>();

            foreach (var listMethod in listMethods)
            {
                var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

                // Resource group scope
                if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ResourceGroups}/"))
                {
                    resourceGroupExtensionsListMethod.Add(listMethod);
                }
            }

            return resourceGroupExtensionsListMethod;
        }

        private IEnumerable<ResourceListMethod>? GetTenantExtensionsListMethods()
        {
            var listMethods = GetListMethods(false, true);
            var tenantExtensionListMethods = new List<ResourceListMethod>();

            foreach (var listMethod in listMethods)
            {
                var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

                // Tenant scope
                if (!pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.Subscriptions}/") &&
                    !pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ResourceGroups}/") &&
                    !pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ManagementGroups}/"))
                {
                    tenantExtensionListMethods.Add(listMethod);
                }
            }

            return tenantExtensionListMethods;
        }

        private IEnumerable<ResourceListMethod>? GetManagementGroupExtensionsListMethods()
        {
            var listMethods = GetListMethods(false, true);
            var managementGroupExtensionsListMethod = new List<ResourceListMethod>();

            foreach (var listMethod in listMethods)
            {
                var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

                // Management Group scope
                if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ManagementGroups}/"))
                {
                    managementGroupExtensionsListMethod.Add(listMethod);
                }
            }

            return managementGroupExtensionsListMethod;
        }

        protected IEnumerable<ResourceListMethod> GetListMethods(bool parentExistsInPathParam, bool returnTypeIsResourceData)
        {
            List<ResourceListMethod> listMethods = new List<ResourceListMethod>();
            foreach (var pagingMethod in PagingMethods)
            {
                if (IsValidListMethod(parentExistsInPathParam, returnTypeIsResourceData, pagingMethod.Method))
                {
                    listMethods.Add(new ResourceListMethod(pagingMethod));
                }
            }

            foreach (var method in Methods)
            {
                if (IsValidListMethod(parentExistsInPathParam, returnTypeIsResourceData, method.RestClientMethod))
                {
                    listMethods.Add(new ResourceListMethod(method));
                }
            }

            return listMethods;
        }

        private bool IsValidListMethod(bool parentExistsInPathParam, bool returnTypeIsResourceData, RestClientMethod clientMethod)
        {
            bool isParentExistsInPathParams = false;
            bool isReturnTypeResourceData = false;

            var parentResourceType = OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);
            isParentExistsInPathParams = MethodExtensions.IsParentExistsInPathParamaters(clientMethod, parentResourceType);

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

            public ResourceListMethod(PagingMethod pagingMethod)
            {
                PagingMethod = pagingMethod;
                ClientMethod = null;
            }
            public ResourceListMethod(ClientMethod clientMethod)
            {
                PagingMethod = null;
                ClientMethod = clientMethod;
            }

            public RestClientMethod? GetRestClientMethod()
            {
                if (PagingMethod != null)
                {
                    return PagingMethod.Method;
                }
                else if (ClientMethod != null)
                {
                    return ClientMethod.RestClientMethod;
                }

                return null;
            }
        }
    }
}
