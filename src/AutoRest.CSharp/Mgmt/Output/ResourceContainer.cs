﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class ResourceContainer : ResourceOperation
    {
        private const string _suffixValue = "Container";
        private BuildContext<MgmtOutputLibrary> _context;
        private const string ResourceGroupOperationsResourceType = "ResourceGroupOperations.ResourceType";
        private const string SubscriptionOperationsResourceType = "SubscriptionOperations.ResourceType";
        private const string TenantResourceType = "ResourceIdentifier.RootResourceIdentifier.ResourceType";
        private const string ResourceGroupCommentName = "ResourceGroup";
        private const string SubscriptionCommentName = "Subscription";
        private const string TenantCommentName = "Tenant";

        private RestClientMethod? _putMethod;
        private PagingMethod? _listMethod;
        private ClientMethod? _getMethod;

        public ResourceContainer(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(operationGroup, context)
        {
            _context = context;
        }

        public IEnumerable<ClientMethod> RemainingMethods => Methods.Where(m => m.RestClientMethod != PutMethod && m.RestClientMethod != ListMethod?.Method);

        public RestClientMethod? PutMethod => _putMethod ??= GetPutMethod();

        public PagingMethod? ListMethod => _listMethod ??= FindListPagingMethod();

        public override ClientMethod? GetMethod => _getMethod ??= _context.Library.GetResourceOperation(OperationGroup).GetMethod;

        private PagingMethod? FindListPagingMethod()
        {
            return PagingMethods.FirstOrDefault(m => m.Name.Equals("ListByResourceGroup", StringComparison.InvariantCultureIgnoreCase))
                ?? PagingMethods.FirstOrDefault(m => m.Name.Equals("List", StringComparison.InvariantCultureIgnoreCase))
                ?? PagingMethods.FirstOrDefault(m => m.Name.StartsWith("List", StringComparison.InvariantCultureIgnoreCase));
        }

        private RestClientMethod? GetPutMethod()
        {
            return RestClient.Methods.FirstOrDefault(m => m.Request.HttpMethod.Equals(RequestMethod.Put));
        }

        protected override string SuffixValue => _suffixValue;

        protected override ClientMethod[] GetMethodsInScope()
        {
            var resultList = new List<ClientMethod>();
            foreach (var method in base.GetMethodsInScope())
            {
                if (method.Name.StartsWith("List") ||
                    IsPutMethod(method))
                    resultList.Add(method);
            }
            return resultList.ToArray();
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

            var parentOperations = _context.Library.GetResourceOperation(parentOperationGroup);
            return $"{parentOperations.Declaration.Name}.ResourceType";
        }
    }
}
