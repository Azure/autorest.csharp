// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class LongRunningOperation: TypeProvider
    {
        public LongRunningOperation(OperationGroup operationGroup, Operation operation, BuildContext context) : base(context)
        {
            Debug.Assert(operation.IsLongRunning);

            var clientClass = context.Library.FindClient(operationGroup);

            Debug.Assert(clientClass != null, "clientClass != null, LROs should be disabled when public clients are disables");

            Client = clientClass;
            DefaultName = clientClass.RestClient.ClientPrefix + operation.CSharpName() + "Operation";
            FinalStateVia = operation.LongRunningFinalStateVia switch
            {
                "azure-async-operation" => OperationFinalStateVia.AzureAsyncOperation,
                "location" => OperationFinalStateVia.Location,
                "original-uri" => OperationFinalStateVia.OriginalUri,
                null => OperationFinalStateVia.Location,
                _ => throw new ArgumentException($"Unknown final-state-via value: {operation.LongRunningFinalStateVia}")
            };

            var finalResponse = operation.LongRunningFinalResponse;
            Schema? finalResponseSchema = finalResponse.ResponseSchema;

            if (finalResponseSchema != null)
            {
                ResultType = TypeFactory.GetOutputType(context.TypeFactory.CreateType(finalResponseSchema, false));
                ResultSerialization = new SerializationBuilder().Build(finalResponse.HttpResponse.KnownMediaType, finalResponseSchema, ResultType);

                Paging? paging = operation.Language.Default.Paging;
                if (paging != null)
                {
                    NextPageMethod = Client.RestClient.GetNextOperationMethod(operation.Requests.Single());
                    PagingResponse = new PagingResponseInfo(paging, ResultType);
                    ResultType = new CSharpType(typeof(AsyncPageable<>), PagingResponse.ItemType);
                }
            }
            else
            {
                ResultType = typeof(Response);
            }

            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DefaultAccessibility = clientClass.Declaration.Accessibility;
        }

        public CSharpType ResultType { get; }
        public Client Client { get; }
        public OperationFinalStateVia FinalStateVia { get; }
        public Diagnostic Diagnostics => new Diagnostic(Declaration.Name);
        public ObjectSerialization? ResultSerialization { get; }
        public RestClientMethod? NextPageMethod { get; }
        public PagingResponseInfo? PagingResponse { get; }
        public string Description { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
    }
}
