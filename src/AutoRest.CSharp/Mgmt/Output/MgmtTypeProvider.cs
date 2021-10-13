// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// MgmtTypeProvider represents the information that corresponds to the generated class in the SDK that contains operations in it.
    /// This includes <see cref="Resource"/>, <see cref="ResourceContainer"/>, <see cref="ArmClientExtensions"/>, <see cref="TenantExtensions"/>,
    /// <see cref="SubscriptionExtensions"/>, <see cref="ResourceGroupExtensions"/> and <see cref="ManagementGroupExtensions"/>
    /// </summary>
    internal abstract class MgmtTypeProvider : TypeProvider
    {
        protected BuildContext<MgmtOutputLibrary> _context;

        protected MgmtTypeProvider(BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// This is the display name for this TypeProvider.
        /// If this TypeProvider generates an extension class, this will be the resource name of whatever it extends from.
        /// </summary>
        public abstract string ResourceName { get; }

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
    }
}
