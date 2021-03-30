// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal abstract class LongRunningOperation: TypeProvider
    {
        public LongRunningOperation(Input.Operation operation, BuildContext context) : base(context)
        {
            Debug.Assert(operation.IsLongRunning);

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
                    PagingResponse = new PagingResponseInfo(paging, ResultType);
                    ResultType = new CSharpType(typeof(AsyncPageable<>), PagingResponse.ItemType);
                }
            }
            else
            {
                ResultType = typeof(Response);
            }

            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
        }

        public CSharpType ResultType { get; }
        public OperationFinalStateVia FinalStateVia { get; }
        public Diagnostic Diagnostics => new Diagnostic(Declaration.Name);
        public ObjectSerialization? ResultSerialization { get; }
        public abstract RestClientMethod? NextPageMethod { get; }
        public PagingResponseInfo? PagingResponse { get; }
        public string Description { get; }
    }
}