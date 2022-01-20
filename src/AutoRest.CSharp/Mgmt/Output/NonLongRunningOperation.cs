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
        public NonLongRunningOperation(Operation operation, LongRunningOperationInfo lroInfo, Resource? resource, string defaultName, BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            Debug.Assert(!operation.IsLongRunning);

            var response = GetOperationResponse(operation);

            Schema? responseSchema = response.ResponseSchema;

            if (responseSchema != null)
            {
                ResultType = TypeFactory.GetOutputType(context.TypeFactory.CreateType(responseSchema, false));
            }

            if (operation.ShouldWrapResultType(ResultType, resource))
            {
                WrapperResource = resource;
                ResultType = resource?.Type;
            }

            DefaultName = defaultName;
            DefaultNamespace = $"{context.DefaultNamespace}.Models";
            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DefaultAccessibility = lroInfo.Accessibility;
        }

        public Resource? WrapperResource { get; }

        /// <summary>
        /// Type of the result of the operation.
        /// </summary>
        /// <value></value>
        public CSharpType? ResultType { get; }

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
