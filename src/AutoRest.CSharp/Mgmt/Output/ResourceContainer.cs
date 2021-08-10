// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceContainer : Resource
    {
        private const string _suffixValue = "Container";
        private BuildContext<MgmtOutputLibrary> _context;
        public const string ResourceGroupOperationsResourceType = "ResourceGroupOperations.ResourceType";
        public const string SubscriptionOperationsResourceType = "SubscriptionOperations.ResourceType";
        public const string TenantResourceType = "ResourceIdentifier.RootResourceIdentifier.ResourceType";
        private const string ResourceGroupCommentName = "ResourceGroup";
        private const string SubscriptionCommentName = "Subscription";
        private const string TenantCommentName = "Tenant";
        private const string ManagementGroupCommentName = "ManagementGroup";

        private RestClientMethod? _createMethod;
        private List<RestClientMethod>? _putMethods;
        private RestClientMethod? _putByIdMethod;
        private ClientMethod? _getMethod;
        private List<ClientMethod>? _getMethods;
        private ClientMethod? _getByIdMethod;

        public ResourceContainer(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(operationGroup, context)
        {
            _context = context;
        }

        public IEnumerable<ClientMethod> RemainingMethods => Methods.Where(m => m.RestClientMethod != CreateMethod && !IsPutMethod(m.RestClientMethod)
        && !ListMethods.Any(s => m.RestClientMethod == s.GetRestClientMethod()) && !SubscriptionExtensionsListMethods.Any(s => m.RestClientMethod == s.GetRestClientMethod()) && !ResourceListMethods.Any(r => r.GetRestClientMethod() == m.RestClientMethod));
        
        public Resource Resource => _context.Library.GetArmResource(OperationGroup);

        public override string ResourceName => Resource.ResourceName;

        public RestClientMethod? CreateMethod => _createMethod ??= GetCreateMethod();

        public List<RestClientMethod> PutMethods => _putMethods ??= GetPutMethods();

        public RestClientMethod? PutByIdMethod => _putByIdMethod ??= GetPutByIdMethod();

        public IEnumerable<ResourceListMethod> ListMethods => FindContainerListMethods(); // TODO: should only call once with lazy init

        public override ClientMethod? GetMethod => _getMethod ??= _context.Library.GetArmResource(OperationGroup).GetMethod;

        public override List<ClientMethod> GetMethods => _getMethods ??= _context.Library.GetArmResource(OperationGroup).GetMethods;

        public override ClientMethod? GetByIdMethod => _getByIdMethod ??= _context.Library.GetArmResource(OperationGroup).GetByIdMethod;

        private IEnumerable<ResourceListMethod> FindContainerListMethods()
        {
            return GetListMethods(true, true);
        }

        private List<RestClientMethod> GetPutMethods()
        {
            var putMethods = new List<RestClientMethod>();
            if (IsScopeOrExtension)
            {
                putMethods = RestClient.Methods.Where(m => m.Request.HttpMethod.Equals(RequestMethod.Put)).ToList();
                if (PutByIdMethod != null && PutByIdMethod.Name != CreateMethod!.Name)
                {
                    putMethods.RemoveAll(m => m.Name == PutByIdMethod.Name);
                }
            }
            else if (CreateMethod != null)
            {
                putMethods.Add(CreateMethod);
            }
            return putMethods;
        }

        private RestClientMethod? GetPutByIdMethod()
        {
            return RestClient.Methods.FirstOrDefault(m => m.Request.HttpMethod.Equals(RequestMethod.Put) && m.IsByIdMethod());
        }

        private RestClientMethod? GetCreateMethod()
        {
            return RestClient.Methods.FirstOrDefault(m => IsCreateResourceMethod(m) && m.Parameters.FirstOrDefault()?.Name.Equals("scope") == true) ?? RestClient.Methods.OrderBy(m => m.Name.Length).FirstOrDefault(m => IsCreateResourceMethod(m));
        }

        private bool IsPutMethod(RestClientMethod method)
        {
            return method.Request.HttpMethod.Equals(RequestMethod.Put);
        }

        private bool IsCreateResourceMethod(RestClientMethod method)
        {
            return method.Request.HttpMethod.Equals(RequestMethod.Put) &&
                (method.Name.StartsWith("CreateOrUpdate") || method.Name.StartsWith("Create") || method.Name.StartsWith("Put"));
        }

        protected override string SuffixValue => _suffixValue;

        protected override IEnumerable<ClientMethod> GetMethodsInScope()
        {
            var resultList = new List<ClientMethod>();
            foreach (var method in base.GetMethodsInScope())
            {
                if (method.Name.StartsWith("GetAll") ||
                    IsPutMethod(method))
                    resultList.Add(method);
            }
            return resultList;
        }

        private bool IsPutMethod(ClientMethod method)
        {
            return method.RestClientMethod.Request.HttpMethod.Equals(RequestMethod.Put);
        }

        protected override string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing collection of {clientPrefix} and their operations over a {GetParentResourceName()}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        private string GetParentResourceName()
        {
            var parentResourceType = OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);

            switch (parentResourceType)
            {
                case ResourceTypeBuilder.ResourceGroups:
                    return ResourceGroupCommentName;
                case ResourceTypeBuilder.Subscriptions:
                    return SubscriptionCommentName;
                case ResourceTypeBuilder.ManagementGroups:
                    return ManagementGroupCommentName;
                case ResourceTypeBuilder.Tenant:
                    return TenantCommentName;
                default:
                    OperationGroup? opGroup = FindParentOperationGroup(parentResourceType);
                    if (opGroup != null)
                    {
                        return opGroup.Resource(Context.Configuration.MgmtConfiguration);
                    }
                    return "Parent";
            }
        }

        public string GetValidResourceValue()
        {
            var parentResourceType = OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);

            switch (parentResourceType)
            {
                case ResourceTypeBuilder.ResourceGroups:
                    return ResourceGroupOperationsResourceType;
                case ResourceTypeBuilder.Subscriptions:
                    return SubscriptionOperationsResourceType;
                case ResourceTypeBuilder.Tenant:
                    return TenantResourceType;
                default:
                    return FindParentFromRp(parentResourceType);
            }
        }

        private OperationGroup? FindParentOperationGroup(string parentResourceType)
        {
            OperationGroup? parentOperationGroup = null;
            foreach (var operationGroup in _context.CodeModel.OperationGroups)
            {
                if (operationGroup.ResourceType(_context.Configuration.MgmtConfiguration).Equals(parentResourceType))
                {
                    parentOperationGroup = operationGroup;
                    break;
                }
            }
            return parentOperationGroup;
        }

        private string FindParentFromRp(string parentResourceType)
        {
            OperationGroup? parentOperationGroup = FindParentOperationGroup(parentResourceType);

            if (parentOperationGroup is null)
                return parentResourceType;
            // TODO: Throw the below exception after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            // throw new Exception($"Could not find ResourceType for {parentResourceType}. Please update the swagger");

            Resource parentResource = _context.Library.GetArmResource(parentOperationGroup);
            return $"{parentResource.Type.ToString().Trim('\r', '\n')}.ResourceType";
        }
    }
}
