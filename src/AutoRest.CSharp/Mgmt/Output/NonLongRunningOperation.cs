// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// Represents a management plane non-long-running-operation.
    /// </summary>
    internal class NonLongRunningOperation : TypeProvider
    {
        private string? _defaultNamespace;

        public NonLongRunningOperation(OperationGroup operationGroup, Operation operation, BuildContext<MgmtOutputLibrary> context, LongRunningOperationInfo lroInfo) : base(context)
        {
            Debug.Assert(!operation.IsLongRunning);

            var response = GetOperationResponse(operation);

            Schema? responseSchema = response.ResponseSchema;

            if (responseSchema != null)
            {
                ResultType = TypeFactory.GetOutputType(context.TypeFactory.CreateType(responseSchema, false));
            }

            if (LongRunningOperationHelper.ShouldWrapResultType(context, operationGroup, operation, ResultType))
            {
                ResultType = context.Library.GetArmResource(operationGroup).Type;
                ResultDataType = context.Library.GetResourceData(operationGroup).Type;
            }

            DefaultName = lroInfo.ClientPrefix.ToSingular() + operation.CSharpName() + "Operation";
            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DefaultAccessibility = lroInfo.Accessibility;
        }

        protected override string DefaultNamespace => _defaultNamespace ??= $"{base.DefaultNamespace}.Models";

        /// <summary>
        /// Type of the result of the operation.
        /// </summary>
        /// <value></value>
        public CSharpType? ResultType { get; }

        /// <summary>
        /// Type of the inner data of the operation.
        /// </summary>
        /// <value></value>
        public CSharpType? ResultDataType { get; }

        public string Description { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; }

        private ServiceResponse GetOperationResponse(Input.Operation operation)
        {
            foreach (var operationResponse in operation.Responses)
            {
                if (operationResponse.Protocol.Http is HttpResponse operationHttpResponse)
                {
                    return operationResponse;
                }
            }

            return operation.Responses.First();
        }

        public CSharpType? WrapperType { get; protected set; }
    }
}
