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
        public NonLongRunningOperation(Operation operation, LongRunningOperationInfo lroInfo, BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            Debug.Assert(!operation.IsLongRunning);

            var response = GetOperationResponse(operation);

            Schema? responseSchema = response.ResponseSchema;

            if (responseSchema != null)
            {
                ResultType = TypeFactory.GetOutputType(context.TypeFactory.CreateType(responseSchema, false));
            }

            if (operation.ShouldWrapResultType(ResultType, context))
            {
                ResultType = context.Library.GetArmResource(operation.GetHttpPath()).Type;
                ResultDataType = context.Library.GetResourceData(operation.GetHttpPath()).Type;
            }

            DefaultName = lroInfo.ClientPrefix.LastWordToSingular() + operation.CSharpName() + "Operation";
            DefaultNamespace = $"{context.DefaultNamespace}.Models";
            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DefaultAccessibility = lroInfo.Accessibility;
        }

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

        protected override string DefaultName { get; }

        protected override string DefaultNamespace { get; }

        public string Description { get; }

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
