// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
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

        public ResourceContainer(IReadOnlyDictionary<OperationSet, IEnumerable<Operation>> operationSets, string resourceName, BuildContext<MgmtOutputLibrary> context)
            : base(operationSets, resourceName, context)
        {
            CreateOperation = GetOperationWithVerb(HttpMethod.Put);
        }

        public Resource Resource => _context.Library.GetArmResource(RequestPaths.First());

        public override string ResourceName => Resource.ResourceName;

        public MgmtClientOperation? CreateOperation { get; }

        protected override bool ShouldIncludeOperation(Operation operation)
        {
            return !base.ShouldIncludeOperation(operation);
        }

        /// <summary>
        /// This method returns the contextual path from one resource <see cref="OperationSet"/>
        /// In the <see cref="ResourceContainer"/> class, we need to use the parent RequestPath of the OperationSet as its contextual path
        /// </summary>
        /// <param name="operationSet"></param>
        /// <returns></returns>
        protected override RequestPath GetContextualPath(OperationSet operationSet)
        {
            return operationSet.ParentRequestPath(_context);
        }

        protected override string DefaultName => base.DefaultName + _suffixValue;

        protected override string CreateDescription(string clientPrefix)
        {
            // TODO -- add the parents here
            return $"A class representing collection of {clientPrefix} and their operations over its parent.";
        }
    }
}
