// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtRestClient : RestClient
    {
        private BuildContext<MgmtOutputLibrary> _context;
        private MgmtRestClientBuilder _builder;
        private Resource? _resource;
        private bool _evaluatedResource = false;

        public MgmtRestClient(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(operationGroup, context, operationGroup.Language.Default.Name, new MgmtRestClientBuilder(operationGroup, context))
        {
            _context = context;
            _builder = (MgmtRestClientBuilder)Builder;
        }

        protected override Func<string?, bool> ShouldReturnNullOn404(Operation operation)
        {
            Func<string?, bool> f = delegate (string? responseBodyType)
            {
                if (!_context.Library.TryGetResourceData(operation.GetHttpPath(), out var resourceData))
                    return false;
                if (!operation.IsGetResourceOperation(responseBodyType, resourceData, _context))
                    return false;

                return operation.Responses.Any(r => r.ResponseSchema == resourceData.ObjectSchema);
            };
            return f;
        }

        public Resource? Resource => _resource ??= GetResource();

        private Resource? GetResource()
        {
            if (_evaluatedResource)
                return _resource;

            Dictionary<string, Resource> candidates = new Dictionary<string, Resource>();
            _evaluatedResource = true;
            foreach (var operation in OperationGroup.Operations)
            {
                var resource = MgmtExtensions.GetResourceFromResourceType(operation, _context);
                if (resource is not null)
                {
                    candidates.TryAdd(resource.ResourceName, resource);
                }
            }
            if (candidates.Count == 1)
                return candidates.Values.First();

            return null;
        }
    }
}
