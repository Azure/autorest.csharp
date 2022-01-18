﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// MgmtTypeProvider represents the information that corresponds to the generated class in the SDK that contains operations in it.
    /// This includes <see cref="Resource"/>, <see cref="ResourceCollection"/>, <see cref="ArmClientExtensions"/>, <see cref="TenantExtensions"/>,
    /// <see cref="SubscriptionExtensions"/>, <see cref="ResourceGroupExtensions"/> and <see cref="ManagementGroupExtensions"/>
    /// </summary>
    internal abstract class MgmtTypeProvider : TypeProvider
    {
        protected BuildContext<MgmtOutputLibrary> _context;

        protected MgmtTypeProvider(BuildContext<MgmtOutputLibrary> context, string resourceName) : base(context)
        {
            _context = context;
            ResourceName = resourceName;
        }

        /// <summary>
        /// This is the display name for this TypeProvider.
        /// If this TypeProvider generates an extension class, this will be the resource name of whatever it extends from.
        /// </summary>
        public string ResourceName { get; }

        /// <summary>
        /// The collection of <see cref="MgmtRestClient"/> of all the operations that will be included in this generated class
        /// </summary>
        public abstract IEnumerable<MgmtRestClient> RestClients { get; }

        /// <summary>
        /// The collection of operations that will be included in this generated class.
        /// </summary>
        public abstract IEnumerable<MgmtClientOperation> ClientOperations { get; }

        private IEnumerable<Resource>? _childResources;
        /// <summary>
        /// The collection of <see cref="Resource"/> that is a child of this generated class.
        /// </summary>
        public virtual IEnumerable<Resource> ChildResources => _childResources ??= _context.Library.ArmResources.Where(resource => resource.Parent(_context).Contains(this));

        protected string GetOperationName(Operation operation, string clientResourceName)
        {
            // search the configuration for a override of this operation
            if (operation.TryGetConfigOperationName(_context, out var name))
                return name;

            return CalculateOperationName(operation, clientResourceName);
        }

        /// <summary>
        /// If the operationGroup of this operation is the same as the resource operation group, we just use operation.CSharpName()
        /// If it is not, we append the operation group key after operation.CSharpName() to make sure this operation has an unique name.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="clientResourceName">For extension classes, use the ResourceName. For resources, use its operation group name</param>
        /// <returns></returns>
        protected virtual string CalculateOperationName(Operation operation, string clientResourceName)
        {
            // search the configuration for a override of this operation
            if (operation.TryGetConfigOperationName(_context, out var name))
                return name;

            var operationGroup = _context.Library.GetRestClient(operation).OperationGroup;
            if (operationGroup.Key == clientResourceName)
            {
                return operation.MgmtCSharpName(false);
            }

            var resourceName = string.Empty;
            if (_context.Library.GetRestClientMethod(operation).IsListMethod(out _))
            {
                resourceName = operationGroup.Key.IsNullOrEmpty() ? string.Empty : operationGroup.Key.ResourceNameToPlural();
                var opName = operation.MgmtCSharpName(!resourceName.IsNullOrEmpty());
                // Remove 'By[Resource]' if the method is put in the [Resource] class. For instance, GetByDatabaseDatabaseColumns now becomes GetDatabaseColumns under Database resource class.
                if (opName.EndsWith($"By{clientResourceName.LastWordToSingular()}"))
                {
                    opName = opName.Substring(0, opName.IndexOf($"By{clientResourceName.LastWordToSingular()}"));
                }
                // For other variants, move By[Resource] to the end. For instance, GetByInstanceServerTrustGroups becomes GetServerTrustGroupsByInstance.
                else if (opName.StartsWith("GetBy") && opName.SplitByCamelCase().ToList()[1] == "By")
                {
                    return $"Get{resourceName}{opName.Substring(opName.IndexOf("By"))}";
                }
                return $"{opName}{resourceName}";
            }
            resourceName = operationGroup.Key.IsNullOrEmpty() ? string.Empty : operationGroup.Key.LastWordToSingular();
            return $"{operation.MgmtCSharpName(!resourceName.IsNullOrEmpty())}{resourceName}";
        }
    }
}
