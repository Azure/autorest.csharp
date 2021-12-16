// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// Represents a management plane long-running-operation.
    /// </summary>
    internal class MgmtLongRunningOperation : LongRunningOperation
    {
        public MgmtLongRunningOperation(Input.Operation operation, OperationGroup operationGroup, LongRunningOperationInfo lroInfo, BuildContext<MgmtOutputLibrary> context)
            : base(operation, context, lroInfo, lroInfo.ClientPrefix.LastWordToSingular() + operation.CSharpName() + "Operation")
        {
            DefaultNamespace = $"{context.DefaultNamespace}.Models";
            if (operation.ShouldWrapResultType(ResultType, context))
            {
                WrapperType = context.Library.GetArmResources(operation.GetHttpPath()).First().Type;
            }
        }

        /// <summary>
        /// Type of the [Resource] class to replace whatever response type in the LRO.
        /// Only valid for PUT operations.
        /// </summary>
        /// <value></value>
        public CSharpType? WrapperType { get; }

        protected override string DefaultNamespace { get; }
    }
}
