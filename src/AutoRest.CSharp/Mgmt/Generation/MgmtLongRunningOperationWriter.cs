// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Request = Azure.Core.Request;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtLongRunningOperationWriter : LongRunningOperationWriter
    {
        private const string _armClientField = "_armClient";

        protected override CSharpType GetBaseType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperResource != null ? new CSharpType(typeof(Operation<>), mgmtOperation.WrapperResource.Type) : base.GetBaseType(operation);
        }

        protected override CSharpType? GetInterfaceType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperResource != null ? new CSharpType(typeof(IOperationSource<>), mgmtOperation.WrapperResource.Type) : base.GetInterfaceType(operation);
        }

        protected override CSharpType GetHelperType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperResource != null ? new CSharpType(typeof(OperationInternals<>), mgmtOperation.WrapperResource.Type) : base.GetHelperType(operation);
        }

        protected override CSharpType GetValueTaskType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperResource != null ? new CSharpType(typeof(Response<>), mgmtOperation.WrapperResource.Type) : base.GetValueTaskType(operation);
        }

        protected override void WriteFields(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType helperType)
        {
            base.WriteFields(writer, operation, pagingResponse, helperType);

            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);

            if (mgmtOperation.WrapperResource != null)
            {
                writer.Line();
                writer.Line($"private readonly {typeof(ArmClient)} {_armClientField};");
            }
        }

        protected override void WriteConstructor(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType cs, CSharpType helperType)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);

            if (mgmtOperation.WrapperResource != null)
            {
                // pass operationsBase in so that the construction of [Resource] is possible
                writer.Append($"internal {cs.Name}({typeof(ArmClient)} armClient, {typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, {typeof(Request)} request, {typeof(Response)} response");

                if (pagingResponse != null)
                {
                    writer.Append($", {typeof(Func<string, Task<Response>>)} nextPageFunc");
                }
                writer.Line($")");

                using (writer.Scope())
                {
                    writer.Append($"_operation = new {helperType}(");
                    if (operation.ResultType != null)
                    {
                        writer.Append($"this, ");
                    }
                    writer.Line($"clientDiagnostics, pipeline, request, response, {typeof(OperationFinalStateVia)}.{operation.FinalStateVia}, { operation.Diagnostics.ScopeName:L});");

                    if (pagingResponse != null)
                    {
                        writer.Line($"_nextPageFunc = nextPageFunc;");
                    }

                    writer.Line($"{_armClientField} = armClient;");
                }
            }
            else
            {
                base.WriteConstructor(writer, operation, pagingResponse, cs, helperType);
            }
        }

        protected override void WriteValueProperty(CodeWriter writer, LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);

            if (mgmtOperation.WrapperResource != null)
            {
                writer.WriteXmlDocumentationInheritDoc();
                writer.Line($"public override {mgmtOperation.WrapperResource.Type} Value => _operation.Value;");
                writer.Line();
            }
            else
            {
                base.WriteValueProperty(writer, operation);
            }
        }

        protected override void WriteCreateResult(CodeWriter writer, LongRunningOperation operation, string responseVariable, PagingResponseInfo? pagingResponse, CSharpType? interfaceType)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);

            if (mgmtOperation.WrapperResource != null)
            {
                Action<CodeWriter, CodeWriterDelegate> valueCallback = (w, v) =>
                {
                    var data = new CodeWriterDeclaration("data");
                    w.Line($"var {data:D} = {v};");
                    if (mgmtOperation.WrapperResource.ResourceData.ShouldSetResourceIdentifier)
                    {
                        w.Line($"{data}.Id = {_armClientField}.Id;");
                    }
                    w.Line($"return new {mgmtOperation.WrapperResource.Type}({_armClientField}, {data});");
                };

                using (writer.Scope($"{mgmtOperation.WrapperResource.Type} {interfaceType}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                {
                    WriteCreateResultImpl(false, writer, operation, responseVariable, pagingResponse, valueCallback);
                }
                writer.Line();

                using (writer.Scope($"async {new CSharpType(typeof(ValueTask<>), mgmtOperation.WrapperResource.Type)} {interfaceType}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                {
                    WriteCreateResultImpl(true, writer, operation, responseVariable, pagingResponse, valueCallback);
                }
            }
            else
            {
                base.WriteCreateResult(writer, operation, responseVariable, pagingResponse, interfaceType);
            }
        }

        private MgmtLongRunningOperation AsMgmtOperation(LongRunningOperation operation)
        {
            var mgmtOperation = operation as MgmtLongRunningOperation;
            Debug.Assert(mgmtOperation != null);
            return mgmtOperation;
        }
    }
}
