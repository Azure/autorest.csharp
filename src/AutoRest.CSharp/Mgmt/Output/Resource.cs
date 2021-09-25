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
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : TypeProvider
    {
        protected BuildContext<MgmtOutputLibrary> _context;
        //private IEnumerable<ClientMethod>? _methods;
        //private IEnumerable<PagingMethod>? _pagingMethods;
        //private ClientMethod? _getByIdMethod;
        //private List<ClientMethod>? _getMethods;
        //private IEnumerable<ResourceListMethod>? _resourceListMethods;
        //private IEnumerable<ResourceListMethod>? _subscriptionExtensionsListMethods;
        //private IEnumerable<ResourceListMethod>? _resourceGroupExtensionsListMethods;
        //private IEnumerable<ResourceListMethod>? _tenantExtensionsListMethods;
        //private IEnumerable<ResourceListMethod>? _managementGroupExtensionsListMethods;

        //internal OperationGroup OperationGroup { get; }
        public bool IsScopeOrExtension { get; }

        public IReadOnlyDictionary<OperationSet, HashSet<Operation>> OperationSets { get; }

        private IDictionary<OperationSet, RequestPath>? _contextualPaths;
        public virtual IDictionary<OperationSet, RequestPath> ContextualPaths => _contextualPaths ??= OperationSets.Keys.ToDictionary(
                operationSet => operationSet,
                operationSet => operationSet.GetRequestPath(_context));

        private IEnumerable<string>? _requestPaths;
        public IEnumerable<string> RequestPaths => _requestPaths ??= OperationSets.Keys.Select(operationSet => operationSet.RequestPath);

        private IDictionary<OperationSet, MgmtRestClient>? _restClients;
        public IDictionary<OperationSet, MgmtRestClient> RestClients => _restClients ??= OperationSets.Keys.ToDictionary(
                operationSet => operationSet,
                operationSet => _context.Library.GetRestClient(operationSet.RequestPath));

        public Resource(IReadOnlyDictionary<OperationSet, HashSet<Operation>> operationSets, string resourceName, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
            OperationSets = operationSets;
            DefaultName = resourceName + SuffixValue;
            IsSingleton = operationSets.Keys.First().IsSingletonResource(context);

            GetMethods = GetMethodsWithVerb(HttpMethod.Get);
            DeleteMethods = GetMethodsWithVerb(HttpMethod.Delete);
        }

        protected IDictionary<OperationSet, RestClientMethod> GetMethodsWithVerb(HttpMethod method)
        {
            var result = new Dictionary<OperationSet, RestClientMethod>();
            foreach (var operationSet in OperationSets.Keys)
            {
                var operation = operationSet.GetOperation(method);
                if (operation is not null)
                    result.Add(operationSet, _context.Library.RestClientMethods[operation]);
            }

            return result;
        }

        //public Resource(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context,
        //    IEnumerable<OperationGroup>? nonResourceOperationGroups = null): base(context)
        //{
        //    _context = context;
        //    OperationGroup = operationGroup;
        //    // check if this is an extension resource, if so, we need to append the name of its parent to this resource name unless it's also a scope resource
        //    var isExtension = operationGroup.IsExtensionResource(context.Configuration.MgmtConfiguration);
        //    var isScope = operationGroup.IsScopeResource(context.Configuration.MgmtConfiguration);
        //    string parentValue = "";
        //    if (isExtension && !isScope)
        //    {
        //        var parentOperationGroup = operationGroup.ParentOperationGroup(context);
        //        // if we cannot find a parent operation group, we just give up and append nothing.
        //        // this case will only happen when resource's parent is tenant, subscriptions, or resourceGroups
        //        parentValue = parentOperationGroup?.Key.ToSingular(false) ?? string.Empty;
        //    }

        //    IsScopeOrExtension = isScope || isExtension;
        //    DefaultName = operationGroup.Resource(context.Configuration.MgmtConfiguration) + parentValue + SuffixValue;
        //    _childOperations = nonResourceOperationGroups?.ToDictionary(operationGroup => operationGroup,
        //        operationGroup => new MgmtNonResourceOperation(operationGroup, context, DefaultName)) ?? new Dictionary<OperationGroup, MgmtNonResourceOperation>();
        //}

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(ResourceName));

        public bool IsSingleton { get; }

        /// <summary>
        /// Finds the corresponding <see cref="ResourceContainer"/> of this <see cref="Resource"/>
        /// Return null when this resource is a singleton.
        /// </summary>
        public ResourceContainer? ResourceContainer => _context.Library.GetResourceContainer(RequestPaths.First());

        /// <summary>
        /// Finds the corresponding <see cref="ResourceData"/> of this <see cref="Resource"/>
        /// </summary>
        public ResourceData ResourceData => _context.Library.GetResourceData(RequestPaths.First());

        public virtual string ResourceName => Type.Name;
        
        protected virtual string SuffixValue => string.Empty;

        //public Type ResourceIdentifierType => typeof(ResourceIdentifier);

        //public IEnumerable<ClientMethod> Methods => _methods ??= GetMethodsInScope();

        //public IEnumerable<ClientMethod> ResourceClientMethods => GetResourceClientMethods();

        //public IEnumerable<RestClientMethod> ResourceLROMethods => GetResourceLROMethods();

        //public IEnumerable<PagingMethod> PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration);

        //public IEnumerable<ResourceListMethod> ResourceListMethods => _resourceListMethods ??= GetResourceListMethods();

        //public IEnumerable<ResourceListMethod>? SubscriptionExtensionsListMethods => _subscriptionExtensionsListMethods ??= GetSubscriptionExtensionsListMethods();

        //public IEnumerable<ResourceListMethod>? ResourceGroupExtensionsListMethods => _resourceGroupExtensionsListMethods ??= GetResourceGroupExtensionsListMethods();

        //public IEnumerable<ResourceListMethod>? TenantExtensionsListMethods => _tenantExtensionsListMethods ??= GetTenantExtensionsListMethods();

        //public IEnumerable<ResourceListMethod>? ManagementGroupExtensionListMethods => _managementGroupExtensionsListMethods ??= GetManagementGroupExtensionsListMethods();

        //public virtual ClientMethod? GetMethod => _getMethod ??= Methods.FirstOrDefault(m => m.IsGetResourceMethod(ResourceData) && m.RestClientMethod.Parameters.FirstOrDefault()?.Name.Equals("scope") == true) ?? Methods.OrderBy(m => m.Name.Length).FirstOrDefault(m => m.IsGetResourceMethod(ResourceData));

        public virtual IDictionary<OperationSet, RestClientMethod> GetMethods { get; }
        public virtual IDictionary<OperationSet, RestClientMethod> DeleteMethods { get; }

        private IDictionary<OperationSet, IEnumerable<Operation>>? _operations;
        public IDictionary<OperationSet, IEnumerable<Operation>> Operations => _operations ??= OperationSets.ToDictionary(
            pair => pair.Key,
            pair => pair.Value.Where(operation => ShouldIncludeOperation(operation)));

        protected virtual bool ShouldIncludeOperation(Operation operation)
        {
            // In the resource class, we need to exclude the List operations
            var restClientMethod = _context.Library.RestClientMethods[operation];
            if (restClientMethod.IsListMethod(out var valueType, out _))
                return !valueType.EqualsByName(ResourceData.Type);
            return true;
        }

        private IEnumerable<MgmtRestClient>? _operationRestClients;
        public IEnumerable<MgmtRestClient> OperationRestClients => _operationRestClients ??=
            OperationSets.Values.SelectMany(o => o).Select(operation => _context.Library.GetRestClient(operation.GetHttpPath())).Distinct();

        private IDictionary<OperationSet, Models.ResourceType>? _resourceTypes;
        public IDictionary<OperationSet, Models.ResourceType> ResourceTypes => _resourceTypes ??= ContextualPaths.ToDictionary(
            pair => pair.Key,
            pair => pair.Value.GetResourceType(_context.Configuration.MgmtConfiguration));

        //protected virtual IEnumerable<ClientMethod> GetMethodsInScope()
        //{
        //    return ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration);
        //}

        //private IEnumerable<ClientMethod> GetResourceClientMethods()
        //{
        //    var clientMethods = new List<ClientMethod>();
        //    foreach (var clientMethod in Methods)
        //    {
        //        var isMethodAlreadyExist = false;
        //        if (ResourceContainer != null)
        //        {
        //            isMethodAlreadyExist = ResourceContainer.PutMethods.Any(m => m == clientMethod.RestClientMethod) ||
        //                ResourceContainer.RemainingMethods.Any(m => m.RestClientMethod == clientMethod.RestClientMethod) ||
        //                ResourceContainer.ListMethods.Any(m => m.GetRestClientMethod() == clientMethod.RestClientMethod ||
        //                SubscriptionExtensionsListMethods.Any(s => clientMethod.RestClientMethod == s.GetRestClientMethod()));
        //        }
        //        if (!isMethodAlreadyExist)
        //        {
        //            clientMethods.Add(clientMethod);
        //        }
        //    }

        //    return clientMethods;
        //}

        //public virtual ClientMethod? GetByIdMethod => _getByIdMethod ??= GetGetByIdMethod();
        //public virtual List<ClientMethod> GetMethods => _getMethods ??= GetGetMethods();

        //private List<ClientMethod> GetGetMethods()
        //{
        //    var getMethods = new List<ClientMethod>();
        //    if (IsScopeOrExtension)
        //    {
        //        getMethods = Methods.Where(m => m.Name.StartsWith("Get") && m.RestClientMethod.Responses[0].ResponseBody?.Type.Name == ResourceData.Type.Name).ToList();
        //        if (GetByIdMethod != null && GetByIdMethod.Name != GetMethod!.Name)
        //        {
        //            getMethods.RemoveAll(m => m.Name == GetByIdMethod.Name);
        //        }
        //    }
        //    else if (GetMethod != null)
        //    {
        //        getMethods.Add(GetMethod);
        //    }
        //    return getMethods;
        //}

        //private ClientMethod? GetGetByIdMethod()
        //{
        //    return Methods.FirstOrDefault(m => m.RestClientMethod.Request.HttpMethod.Equals(RequestMethod.Get) && m.RestClientMethod.IsByIdMethod());
        //}

        //private IEnumerable<RestClientMethod> GetResourceLROMethods()
        //{
        //    var clientMethods = new List<RestClientMethod>();
        //    foreach (var clientMethod in RestClient.Methods)
        //    {
        //        if (clientMethod.Operation != null && clientMethod.Operation.IsLongRunning)
        //        {
        //            var isMethodExistInContainer = false;
        //            if (ResourceContainer != null)
        //            {
        //                isMethodExistInContainer = ResourceContainer.PutMethods.Any(m => m == clientMethod) ||
        //                    ResourceContainer.RemainingMethods.Any(m => m.RestClientMethod == clientMethod) ||
        //                    ResourceContainer.ListMethods.Any(m => m.GetRestClientMethod() == clientMethod ||
        //                    SubscriptionExtensionsListMethods.Any(s => clientMethod == s.GetRestClientMethod()));
        //            }
        //            if (!isMethodExistInContainer)
        //            {
        //                clientMethods.Add(clientMethod);
        //            }
        //        }
        //    }

        //    return clientMethods;
        //}

        //private IEnumerable<ResourceListMethod> GetResourceListMethods()
        //{
        //    return GetListMethods(true, false);
        //}

        //private IEnumerable<ResourceListMethod>? GetSubscriptionExtensionsListMethods()
        //{
        //    var listMethods = new List<ResourceListMethod>();
        //    // for resource grand child
        //    listMethods.AddRange(GetListMethods(false, true).ToList());

        //    // for non resource grand child
        //    listMethods.AddRange(GetListMethods(false, false).ToList());

        //    var subscriptionExtensionsListMethods = new List<ResourceListMethod>();

        //    foreach (var listMethod in listMethods)
        //    {
        //        var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

        //        // Subscriptions scope
        //        if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.Subscriptions}/") && !pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ResourceGroups}/"))
        //        {
        //            subscriptionExtensionsListMethods.Add(listMethod);
        //        }
        //    }

        //    return subscriptionExtensionsListMethods;
        //}

        //private IEnumerable<ResourceListMethod>? GetResourceGroupExtensionsListMethods()
        //{
        //    var listMethods = new List<ResourceListMethod>();
        //    // for resource grand child
        //    listMethods.AddRange(GetListMethods(false, true).ToList());

        //    // for non resource grand child
        //    listMethods.AddRange(GetListMethods(false, false).ToList());

        //    var resourceGroupExtensionsListMethod = new List<ResourceListMethod>();
        //    foreach (var listMethod in listMethods)
        //    {
        //        var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

        //        // Resource group scope
        //        if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ResourceGroups}/"))
        //        {
        //            resourceGroupExtensionsListMethod.Add(listMethod);
        //        }
        //    }

        //    return resourceGroupExtensionsListMethod;
        //}

        //private IEnumerable<ResourceListMethod>? GetTenantExtensionsListMethods()
        //{
        //    var listMethods = new List<ResourceListMethod>();
        //    // for resource grand child
        //    listMethods.AddRange(GetListMethods(false, true).ToList());

        //    // for non resource grand child
        //    listMethods.AddRange(GetListMethods(false, false).ToList());

        //    var tenantExtensionListMethods = new List<ResourceListMethod>();
        //    foreach (var listMethod in listMethods)
        //    {
        //        var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

        //        // Tenant scope
        //        if (!pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.Subscriptions}/") &&
        //            !pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ResourceGroups}/") &&
        //            !pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ManagementGroups}/"))
        //        {
        //            tenantExtensionListMethods.Add(listMethod);
        //        }
        //    }

        //    return tenantExtensionListMethods;
        //}

        //private IEnumerable<ResourceListMethod>? GetManagementGroupExtensionsListMethods()
        //{
        //    var listMethods = new List<ResourceListMethod>();
        //    // for resource grand child
        //    listMethods.AddRange(GetListMethods(false, true).ToList());

        //    // for non resource grand child
        //    listMethods.AddRange(GetListMethods(false, false).ToList());

        //    var managementGroupExtensionsListMethod = new List<ResourceListMethod>();
        //    foreach (var listMethod in listMethods)
        //    {
        //        var pathSegments = listMethod.GetRestClientMethod()?.Request.PathSegments;

        //        // Management Group scope
        //        if (pathSegments.Any(p => p.Value.IsConstant && p.Value.Constant.Value?.ToString() == $"/{ResourceTypeBuilder.ManagementGroups}/"))
        //        {
        //            managementGroupExtensionsListMethod.Add(listMethod);
        //        }
        //    }

        //    return managementGroupExtensionsListMethod;
        //}

        //protected IEnumerable<ResourceListMethod> GetListMethods(bool shouldParentExistInPath, bool shouldReturnTypeBeResourceData)
        //{
        //    List<ResourceListMethod> listMethods = new List<ResourceListMethod>();
        //    foreach (var pagingMethod in PagingMethods)
        //    {
        //        if (IsValidListMethod(shouldParentExistInPath, shouldReturnTypeBeResourceData, pagingMethod.Method))
        //        {
        //            listMethods.Add(new ResourceListMethod(pagingMethod));
        //        }
        //    }

        //    foreach (var method in Methods)
        //    {
        //        if (IsValidListMethod(shouldParentExistInPath, shouldReturnTypeBeResourceData, method.RestClientMethod))
        //        {
        //            listMethods.Add(new ResourceListMethod(method));
        //        }
        //    }

        //    return listMethods;
        //}

        //private bool IsValidListMethod(bool shouldParentExistInPath, bool shouldReturnTypeBeResourceData, RestClientMethod clientMethod)
        //{
        //    var result = MethodExtensions.GetBodyTypeForList(clientMethod, OperationGroup, _context);

        //    if (!result.IsListFunction)
        //        return false;

        //    var parentResourceType = IsScopeOrExtension ? clientMethod.Operation.ParentResourceType() : OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);
        //    bool isParentExistsInPathParams = (parentResourceType == ResourceTypeBuilder.ResourceGroupResources || parentResourceType == ResourceTypeBuilder.Tenant) ? true : MethodExtensions.IsParentExistsInPathParamaters(clientMethod, parentResourceType);

        //    return (isParentExistsInPathParams == shouldParentExistInPath && result.WasResourceData == shouldReturnTypeBeResourceData);
        //}

        public Diagnostic GetDiagnostic(RestClientMethod method)
        {
            return new Diagnostic($"{Declaration.Name}.{method.Name}", Array.Empty<DiagnosticAttribute>());
        }

        protected virtual string CreateDescription(string clientPrefix)
        {
            return $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.";
        }

        //public class ResourceListMethod
        //{
        //    public PagingMethod? PagingMethod { get; }

        //    public ClientMethod? ClientMethod { get; }

        //    public ResourceListMethod(PagingMethod pagingMethod)
        //    {
        //        PagingMethod = pagingMethod;
        //        ClientMethod = null;
        //    }
        //    public ResourceListMethod(ClientMethod clientMethod)
        //    {
        //        PagingMethod = null;
        //        ClientMethod = clientMethod;
        //    }

        //    public RestClientMethod? GetRestClientMethod()
        //    {
        //        if (PagingMethod != null)
        //        {
        //            return PagingMethod.Method;
        //        }
        //        else if (ClientMethod != null)
        //        {
        //            return ClientMethod.RestClientMethod;
        //        }

        //        return null;
        //    }
        //}
    }
}
