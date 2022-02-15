// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtLongRunningOperation : TypeProvider
    {
        public bool IsGeneric { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "internal";

        public MgmtLongRunningOperation(bool isGeneric) : base(MgmtContext.Context)
        {
            IsGeneric = isGeneric;
            DefaultName = $"{MgmtContext.Context.DefaultNamespace.Split('.').Last()}ArmOperation";
            BaseType = isGeneric ? typeof(ArmOperation<>) : typeof(ArmOperation);
            WaitMethod = isGeneric ? "WaitForCompletionAsync" : "WaitForCompletionResponseAsync";
            OperationType = isGeneric ? typeof(ArmOperation<>) : typeof(ArmOperation);
            ResponseType = isGeneric ? typeof(Response<>) : typeof(Response);
            OperationOrResponseType = isGeneric ? typeof(OperationOrResponseInternals<>) : typeof(OperationOrResponseInternals);
            OperationSourceString = isGeneric ? (FormattableString)$"{typeof(IOperationSource<>)} source, " : (FormattableString)$"";
            SourceString = isGeneric ? "source, " : string.Empty;
        }

        public Type BaseType { get; }
        public string WaitMethod { get; }
        public Type OperationType { get; }
        public Type ResponseType { get; }
        public Type OperationOrResponseType { get; }
        public FormattableString OperationSourceString { get; }
        public string SourceString { get; }

        private ConstructorSignature? _mockingCtor;
        public ConstructorSignature? MockingCtor => _mockingCtor ??= EnsureMockingCtor();
        private ConstructorSignature? EnsureMockingCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class for mocking.",
                Modifiers: "protected",
                Parameters: new Parameter[0]);
        }

        private ConstructorSignature? _responseCtor;
        public ConstructorSignature? ResponseCtor => _responseCtor ??= EnsureResponseCtor();
        private ConstructorSignature? EnsureResponseCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                Description: null,
                Modifiers: "internal",
                Parameters: new[] { GenericResponseParameter });
        }

        private ConstructorSignature? _requestCtor;
        public ConstructorSignature? RequestCtor => _requestCtor ??= EnsureRequestCtor();
        private ConstructorSignature? EnsureRequestCtor()
        {
            var parameters = new List<Parameter> { ClientDiagnosticParameter, PipelineParameter, RequestParameter, ResponseParameter, FinalStateParameter };
            if (SourceParameter is not null)
                parameters.Insert(0, SourceParameter);
            return new ConstructorSignature(
                Name: Type.Name,
                Description: null,
                Modifiers: "internal",
                Parameters: parameters.ToArray());
        }

        protected Parameter GenericResponseParameter => new Parameter("response", null, ResponseType, null, false);

        protected Parameter? SourceParameter => IsGeneric ? new Parameter("source", null, typeof(IOperationSource<>), null, false) : null;
        protected Parameter ClientDiagnosticParameter => new Parameter("clientDiagnostics", null, typeof(ClientDiagnostics), null, false);
        protected Parameter PipelineParameter => new Parameter("pipeline", null, typeof(HttpPipeline), null, false);
        protected Parameter RequestParameter => new Parameter("request", null, typeof(Request), null, false);
        protected Parameter ResponseParameter => new Parameter("response", null, typeof(Response), null, false);
        protected Parameter FinalStateParameter => new Parameter("finalStateVia", null, typeof(OperationFinalStateVia), null, false);
    }
}
