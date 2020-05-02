// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class LongRunningOperation: ITypeProvider
    {
        private readonly BuildContext _context;

        public LongRunningOperation(Operation operation, BuildContext context)
        {
            Debug.Assert(operation.IsLongRunning);
            _context = context;

            Operation = operation;
            Name = operation.CSharpName();
            Diagnostics = new Diagnostic(Name);
            FinalStateVia = operation.LongRunningFinalStateVia switch
            {
                "azure-async-operation" => OperationFinalStateVia.AzureAsyncOperation,
                "location" => OperationFinalStateVia.Location,
                "original-uri" => OperationFinalStateVia.OriginalUri,
                null => OperationFinalStateVia.Location,
                _ => throw new ArgumentException($"Unknown final-state-via value: {operation.LongRunningFinalStateVia}")
            };

            Schema? finalResponse = operation.LongRunningFinalResponse.ResponseSchema;
            ResultType = finalResponse != null ? context.TypeFactory.CreateType(finalResponse, false) : null;
            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DeclaredType = BuilderHelpers.CreateTypeAttributes(Name, _context.DefaultNamespace, "public");
        }

        public string Name { get; }
        public CSharpType? ResultType { get; }
        public OperationFinalStateVia FinalStateVia { get; }
        public Diagnostic Diagnostics { get; set; }
        public Operation Operation { get; set; }
        public CSharpType Type => new CSharpType(this,DeclaredType.Namespace, DeclaredType.Name);
        public TypeDeclarationOptions DeclaredType { get; set; }
        public string Description { get; set; }
    }
}
