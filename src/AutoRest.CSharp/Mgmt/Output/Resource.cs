// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : TypeProvider
    {
        private Type? _resourceIdentifierType;
        private BuildContext<MgmtOutputLibrary> _context;
        private IEnumerable<ClientMethod>? _methods;
        private IEnumerable<PagingMethod>? _pagingMethods;
        private ClientMethod? _getMethod;
        private ClientMethod? _getByIdMethod;
        private List<ClientMethod>? _getMethods;
        private IEnumerable<ResourceListMethod>? _resourceListMethods;
        private IEnumerable<ResourceListMethod>? _subscriptionExtensionsListMethods;
        private IEnumerable<ResourceListMethod>? _resourceGroupExtensionsListMethods;
        private IEnumerable<ResourceListMethod>? _tenantExtensionsListMethods;
        private IEnumerable<ResourceListMethod>? _managementGroupExtensionsListMethods;

        private IDictionary<OperationGroup, MgmtNonResourceOperation> _childOperations;

        internal OperationGroup OperationGroup { get; }
        protected MgmtRestClient? _restClient;
        public bool IsScopeOrExtension { get; }

        public Resource(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context,
            IEnumerable<OperationGroup>? nonResourceOperationGroups = null): base(context)
        {
            _context = context;
            OperationGroup = operationGroup;
            // check if this is an extension resource, if so, we need to append the name of its parent to this resource name unless it's also a scope resource
            var isExtension = operationGroup.IsExtensionResource(context.Configuration.MgmtConfiguration);
            var isScope = operationGroup.IsScopeResource(context.Configuration.MgmtConfiguration);
            string parentValue = "";
            if (isExtension && !isScope)
            {
                var parentOperationGroup = operationGroup.ParentOperationGroup(context);
                // if we cannot find a parent operation group, we just give up and append nothing.
                // this case will only happen when resource's parent is tenant, subscriptions, or resourceGroups
                parentValue = parentOperationGroup?.Key.ToSingular(false) ?? string.Empty;
            }

            IsScopeOrExtension = isScope || isExtension;
            DefaultName = operationGroup.Resource(context.Configuration.MgmtConfiguration) + parentValue + SuffixValue;
            _childOperations = nonResourceOperationGroups?.ToDictionary(operationGroup => operationGroup,
                operationGroup => new MgmtNonResourceOperation(operationGroup, context, DefaultName)) ?? new Dictionary<OperationGroup, MgmtNonResourceOperation>();
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(OperationGroup, ResourceName));

        public ResourceContainer? ResourceContainer => _context.Library.GetResourceContainer(OperationGroup);

        public virtual string ResourceName => Type.Name;

        protected virtual string SuffixValue => string.Empty;

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public ResourceData ResourceData => _context.Library.GetResourceData(OperationGroup);

        public Type ResourceIdentifierType => _resourceIdentifierType ??= OperationGroup.GetResourceIdentifierType(_context);

        public IEnumerable<ClientMethod> Methods => _methods ??= GetMethodsInScope();

        public IEnumerable<ClientMethod> ResourceClientMethods => GetResourceClientMethods();

        public IEnumerable<RestClientMethod> ResourceLROMethods => GetResourceLROMethods();

        public IDictionary<OperationGroup, MgmtNonResourceOperation> ChildOperations => _childOperations;

        public IEnumerable<PagingMethod> PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration);

        public IEnumerable<ResourceListMethod> ResourceListMethods => _resourceListMethods ??= GetResourceListMethods();

        public IEnumerable<ResourceListMethod>? SubscriptionExtensionsListMethods => _subscriptionExtensionsListMethods ??= GetSubscriptionExtensionsListMethods();

        public IEnumerable<ResourceListMethod>? ResourceGroupExtensionsListMethods => _resourceGroupExtensionsListMethods ??= GetResourceGroupExtensionsListMethods();

        public IEnumerable<ResourceListMethod>? TenantExtensionsListMethods => _tenantExtensionsListMethods ??= GetTenantExtensionsListMethods();

        public IEnumerable<ResourceListMethod>? ManagementGroupExtensionListMethods => _managementGroupExtensionsListMethods ??= GetManagementGroupExtensionsListMethods();

        public virtual ClientMethod? GetMethod => _getMethod ??= Methods.FirstOrDefault(m => m.IsGetResourceMethod(ResourceData) && m.RestClientMethod.Parameters.FirstOrDefault()?.Name.Equals("scope") == true) ?? Methods.OrderBy(m => m.Name.Length).FirstOrDefault(m => m.IsGetResourceMethod(ResourceData));

        protected virtual IEnumerable<ClientMethod> GetMethodsInScope()
        {
            return ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration);
        }

        private IEnumerable<ClientMethod> GetResourceClientMethods()
        {
            var clientMethods = new List<ClientMethod>();
            foreach (var clientMethod in Methods)
            {
                var isMethodAlreadyExist = false;
                if (ResourceContainer != null)
                {
                    isMethodAlreadyExist = ResourceContainer.PutMethods.Any(m => m == clientMethod.RestClientMethod) ||
                        ResourceContainer.RemainingMethods.Any(m => m.RestClientMethod == clientMethod.RestClientMethod) ||
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

        public virtual ClientMethod? GetByIdMethod => _getByIdMethod ??= GetGetByIdMethod();
        public virtual List<ClientMethod> GetMethods => _getMethods ??= GetGetMethods();

        private List<ClientMethod> GetGetMethods()
        {
            var getMethods = new List<ClientMethod>();
            if (IsScopeOrExtension)
            {
                getMethods = Methods.Where(m => m.Name.StartsWith("Get") && m.RestClientMethod.Responses[0].ResponseBody?.Type.Name == ResourceData.Type.Name).ToList();
                if (GetByIdMethod != null && GetByIdMethod.Name != GetMethod!.Name)
                {
                    getMethods.RemoveAll(m => m.Name == GetByIdMethod.Name);
                }
            }
            else if (GetMethod != null)
            {
                getMethods.Add(GetMethod);
            }
            return getMethods;
        }

        private ClientMethod? GetGetByIdMethod()
        {
            return Methods.FirstOrDefault(m => m.RestClientMethod.Request.HttpMethod.Equals(RequestMethod.Get) && m.RestClientMethod.IsByIdMethod());
        }

        private IEnumerable<RestClientMethod> GetResourceLROMethods()
        {
            var clientMethods = new List<RestClientMethod>();
            foreach (var clientMethod in RestClient.Methods)
            {
                if (clientMethod.Operation != null && clientMethod.Operation.IsLongRunning)
                {
                    var isMethodExistInContainer = false;
                    if (ResourceContainer != null)
                    {
                        isMethodExistInContainer = ResourceContainer.PutMethods.Any(m => m == clientMethod) ||
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

        private IEnumerable<ResourceListMethod> GetResourceListMethods()
        {
            return GetListMethods(true, false);
        }

        private IEnumerable<ResourceListMethod>? GetSubscriptionExtensionsListMethods()
        {
            var listMethods = new List<ResourceListMethod>();
            // for resource grand child
            listMethods.AddRange(GetListMethods(false, true).ToList());

            // for non resource grand child
            listMethods.AddRange(GetListMethods(false, false).ToList());

            var subscriptionExtensionsListMethods = new List<ResourceListMethod>();

            foreach (var listMethod in listMethods)
            {
                var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

                // Subscriptions scope
                if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.Subscriptions}/") && !pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ResourceGroups}/"))
                {
                    subscriptionExtensionsListMethods.Add(listMethod);
                }
            }

            return subscriptionExtensionsListMethods;
        }

        private IEnumerable<ResourceListMethod>? GetResourceGroupExtensionsListMethods()
        {
            var listMethods = new List<ResourceListMethod>();
            // for resource grand child
            listMethods.AddRange(GetListMethods(false, true).ToList());

            // for non resource grand child
            listMethods.AddRange(GetListMethods(false, false).ToList());

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
            var listMethods = new List<ResourceListMethod>();
            // for resource grand child
            listMethods.AddRange(GetListMethods(false, true).ToList());

            // for non resource grand child
            listMethods.AddRange(GetListMethods(false, false).ToList());

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
            var listMethods = new List<ResourceListMethod>();
            // for resource grand child
            listMethods.AddRange(GetListMethods(false, true).ToList());

            // for non resource grand child
            listMethods.AddRange(GetListMethods(false, false).ToList());

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

        protected IEnumerable<ResourceListMethod> GetListMethods(bool shouldParentExistInPath, bool shouldReturnTypeBeResourceData)
        {
            List<ResourceListMethod> listMethods = new List<ResourceListMethod>();
            foreach (var pagingMethod in PagingMethods)
            {
                if (IsValidListMethod(shouldParentExistInPath, shouldReturnTypeBeResourceData, pagingMethod.Method))
                {
                    listMethods.Add(new ResourceListMethod(pagingMethod));
                }
            }

            foreach (var method in Methods)
            {
                if (IsValidListMethod(shouldParentExistInPath, shouldReturnTypeBeResourceData, method.RestClientMethod))
                {
                    listMethods.Add(new ResourceListMethod(method));
                }
            }

            return listMethods;
        }

        private bool IsValidListMethod(bool shouldParentExistInPath, bool shouldReturnTypeBeResourceData, RestClientMethod clientMethod)
        {
            var result = MethodExtensions.GetBodyTypeForList(clientMethod, OperationGroup, _context);

            if (!result.IsListFunction)
                return false;

            var parentResourceType = IsScopeOrExtension ? clientMethod.Operation.ParentResourceType() : OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);
            bool isParentExistsInPathParams = (parentResourceType == ResourceTypeBuilder.ResourceGroupResources || parentResourceType == ResourceTypeBuilder.Tenant) ? true : MethodExtensions.IsParentExistsInPathParamaters(clientMethod, parentResourceType);

            return (isParentExistsInPathParams == shouldParentExistInPath && result.WasResourceData == shouldReturnTypeBeResourceData);
        }

        public Diagnostic GetDiagnostic(RestClientMethod method)
        {
            return new Diagnostic($"{Declaration.Name}.{method.Name}", Array.Empty<DiagnosticAttribute>());
        }

        protected virtual string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A Class representing a {DefaultName} along with the instance operations that can be performed on it." :
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
