﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class LongRunningOperation : TypeProvider
    {
        public LongRunningOperation(Input.Operation operation, BuildContext context, LongRunningOperationInfo lroInfo) : this(operation, context, lroInfo, lroInfo.ClientPrefix + operation.CSharpName() + "Operation")
        {
        }

        protected LongRunningOperation(Input.Operation operation, BuildContext context, LongRunningOperationInfo lroInfo, string defaultName) : base(context)
        {
            Debug.Assert(operation.IsLongRunning);

            FinalStateVia = operation.LongRunningFinalStateVia;

            var finalResponse = operation.LongRunningFinalResponse;
            Schema? finalResponseSchema = finalResponse.ResponseSchema;

            if (finalResponseSchema != null)
            {
                ResultType = TypeFactory.GetOutputType(context.TypeFactory.CreateType(finalResponseSchema, false));
                ResultSerialization = new SerializationBuilder().Build(finalResponse.HttpResponse.KnownMediaType, finalResponseSchema, ResultType);

                Paging? paging = operation.Language.Default.Paging;
                if (paging != null)
                {
                    NextPageMethod = lroInfo.NextOperationMethod;
                    PagingResponse = new PagingResponseInfo(paging, ResultType);
                    ResultType = new CSharpType(typeof(AsyncPageable<>), PagingResponse.ItemType);
                }
            }

            DefaultName = defaultName;
            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DefaultAccessibility = lroInfo.Accessibility;
        }

        public CSharpType? ResultType { get; }
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
