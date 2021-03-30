// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Operation = AutoRest.CSharp.Input.Operation;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class MgmtLongRunningOperation: LongRunningOperation
    {
        private readonly Operation _operation;
        private readonly MgmtClient _clientClass;

        public MgmtLongRunningOperation(OperationGroup operationGroup, Operation operation, BuildContext<MgmtOutputLibrary> context) : base(operation, context)
        {
            _operation = operation;
            _clientClass = context.Library.FindClient(operationGroup)!;

            Debug.Assert(_clientClass != null, "clientClass != null, LROs should be disabled when public clients are disables");
        }

        protected override string DefaultName => _clientClass.RestClient.ClientPrefix + _operation.CSharpName() + "Operation";
        protected override string DefaultAccessibility => _clientClass.Declaration.Accessibility;
        public override RestClientMethod? NextPageMethod => _clientClass.RestClient.GetNextOperationMethod(_operation.Requests.First());
    }
}
