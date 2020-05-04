// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class LongRunningOperation: ITypeProvider
    {
        private readonly BuildContext _context;

        public LongRunningOperation(OperationGroup operationGroup, Operation operation, BuildContext context)
        {
            Debug.Assert(operation.IsLongRunning);
            _context = context;

            var clientClass = _context.Library.FindClient(operationGroup);

            Name = clientClass.RestClient.ClientPrefix + operation.CSharpName() + "Operation";
            Diagnostics = new Diagnostic(Name);
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
                ResultType = context.TypeFactory.CreateType(finalResponseSchema, false);
                ResultSerialization = new SerializationBuilder().Build(finalResponse.HttpResponse.KnownMediaType, finalResponseSchema, ResultType);
            }
            else
            {
                ResultType = typeof(Response);
            }

            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);

            // Inherit accessibility from the client
            DeclaredType = BuilderHelpers.CreateTypeAttributes(Name, _context.DefaultNamespace, clientClass.Declaration.Accessibility);
        }

        public string Name { get; }
        public CSharpType ResultType { get; }
        public OperationFinalStateVia FinalStateVia { get; }
        public Diagnostic Diagnostics { get; }
        public CSharpType Type => new CSharpType(this,DeclaredType.Namespace, DeclaredType.Name);
        public TypeDeclarationOptions DeclaredType { get;  }
        public ObjectSerialization? ResultSerialization { get;  }
        public string Description { get; }
    }
}
