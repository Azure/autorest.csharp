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
    internal abstract class MgmtTypeProvider : TypeProvider
    {
        protected BuildContext<MgmtOutputLibrary> _context;

        protected MgmtTypeProvider(BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
        }

        public abstract IEnumerable<MgmtClientOperation> ClientOperations { get; }

        private IEnumerable<Resource>? _chileResources;
        public virtual IEnumerable<Resource> ChildResources => _chileResources ??= _context.Library.ArmResources.Where(resource => resource.Parent(_context).Contains(this));
    }
}
