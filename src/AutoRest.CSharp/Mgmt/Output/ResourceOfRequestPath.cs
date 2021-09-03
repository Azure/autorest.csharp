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
    internal class ResourceOfRequestPath : TypeProvider
    {
        private BuildContext<MgmtOutputLibrary> _context;

        private IEnumerable<ResourceOfRequestPath>? _childResources;

        private IEnumerable<OperationSet>? _childOperaions;

        public ResourceOfRequestPath(RequestPath requestPath, string name, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
            RequestPath = requestPath;
            DefaultName = name;
        }
        public RequestPath RequestPath { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public IEnumerable<ResourceOfRequestPath> ChildResources => _childResources ??= EnsureChildResources();

        public IEnumerable<OperationSet> ChildOperations => _childOperaions ??= EnsureChildOperations();

        private IEnumerable<ResourceOfRequestPath> EnsureChildResources()
        {
            return _context.Library.ArmResourcesOfRequestPath
                .Where(resource => resource.RequestPath.ParentRequestPath(_context).Equals(RequestPath));
        }

        private IEnumerable<OperationSet> EnsureChildOperations()
        {
            // TODO -- usually the list function of the child resource is also listed in this condition
            // we need to refine this condition to make things right
            return _context.Library.OperationSets
                .Where(operationSet => !operationSet.IsResource(_context.Configuration.MgmtConfiguration)
                && operationSet.ParentRequestPath(_context).Equals(RequestPath));
        }

        public override string? ToString()
        {
            return $"{DefaultName}({RequestPath})";
        }
    }
}
