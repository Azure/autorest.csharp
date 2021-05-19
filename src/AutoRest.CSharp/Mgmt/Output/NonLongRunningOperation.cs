// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// Represents a management plane non-long-running-operation.
    /// </summary>
    internal class NonLongRunningOperation : LongRunningOperation
    {
        public NonLongRunningOperation(OperationGroup operationGroup, Input.Operation operation, BuildContext<MgmtOutputLibrary> context, LongRunningOperationInfo lroInfo) : base(context)
        {
            Debug.Assert(!operation.IsLongRunning);
            DefaultName = lroInfo.ClientPrefix + operation.CSharpName() + "Operation";

            var response = GetOperationResponse(operation);
            Schema? responseSchema = response.ResponseSchema;

            if (responseSchema != null)
            {
                ResultType = TypeFactory.GetOutputType(context.TypeFactory.CreateType(responseSchema, false));
                ResultSerialization = new SerializationBuilder().Build(response.HttpResponse.KnownMediaType, responseSchema, ResultType);

                Paging? paging = operation.Language.Default.Paging;
                if (paging != null)
                {
                    NextPageMethod = lroInfo.NextOperationMethod;
                    PagingResponse = new PagingResponseInfo(paging, ResultType);
                    ResultType = new CSharpType(typeof(AsyncPageable<>), PagingResponse.ItemType);
                }
            }

            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DefaultAccessibility = lroInfo.Accessibility;

            if (ShouldWrapResultType(context, operationGroup, operation))
            {
                WrapperType = context.Library.GetArmResource(operationGroup).Type;
            }
        }

        public CSharpType? WrapperType { get; protected set; }
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

        private bool ShouldWrapResultType(BuildContext<MgmtOutputLibrary> context, OperationGroup operationGroup, Input.Operation operation)
        {
            if (ResultType != null
                && operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest
                && httpRequest.Method == HttpMethod.Put)
            {
                // need to check result type is [Resource]Data because
                // some PUT operation returns differently and we don't want to wrap that with [Resource]
                var resourceDataType = context.Library.GetResourceData(operationGroup).Type;
                if (ResultType.Name.Equals(resourceDataType.Name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
