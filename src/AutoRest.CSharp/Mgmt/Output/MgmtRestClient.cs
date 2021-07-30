// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
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

        protected override bool ShouldReturnNullOn404(Operation operation)
        {
            if (!_context.Library.TryGetResourceData(OperationGroup, out var resourceData))
                return false;

            if (!operation.Language.Default.Name.Equals("Get"))
                return false;

            return operation.Responses.Any(r => r.ResponseSchema == resourceData.ObjectSchema);
        }
    }
}
