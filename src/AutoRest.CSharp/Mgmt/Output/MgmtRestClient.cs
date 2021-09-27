// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtRestClient : RestClient
    {
        private BuildContext<MgmtOutputLibrary> _context;

        public MgmtRestClient(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(operationGroup, context, operationGroup.Language.Default.Name)
        {
            _context = context;
        }

        protected override Func<string?, bool> ShouldReturnNullOn404(Operation operation)
        {
            Func<string?, bool> f = delegate (string? responseBodyType)
            {
                if (!_context.Library.TryGetResourceData(operation.GetHttpPath(), out var resourceData))
                    return false;
                if (!operation.IsGetResourceOperation(responseBodyType, resourceData, _context))
                    return false;
                // if we are a GET for a resource, we do not need to check whether this is a singleton. This condition is included above
                //if (OperationGroup.IsSingletonResource(_context.Configuration.MgmtConfiguration))
                //    return false;

                return operation.Responses.Any(r => r.ResponseSchema == resourceData.ObjectSchema);
            };
            return f;
        }
    }
}
