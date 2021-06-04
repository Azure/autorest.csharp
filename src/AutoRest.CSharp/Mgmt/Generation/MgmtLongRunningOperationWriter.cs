// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Request = Azure.Core.Request;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtLongRunningOperationWriter : LongRunningOperationWriter
    {
        private const string _operationBaseField = "_operationBase";

        protected override CSharpType GetBaseType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperType != null ? new CSharpType(typeof(Operation<>), mgmtOperation.WrapperType) : base.GetBaseType(operation);
        }

        protected override CSharpType? GetInterfaceType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperType != null ? new CSharpType(typeof(IOperationSource<>), mgmtOperation.WrapperType) : base.GetInterfaceType(operation);
        }

        protected override CSharpType GetHelperType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperType != null ? new CSharpType(typeof(OperationInternals<>), mgmtOperation.WrapperType) : base.GetHelperType(operation);
        }

        protected override CSharpType GetValueTaskType(LongRunningOperation operation)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);
            return mgmtOperation.WrapperType != null ? new CSharpType(typeof(Response<>), mgmtOperation.WrapperType) : base.GetValueTaskType(operation);
        }

        protected override void WriteFields(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType helperType)
        {
            base.WriteFields(writer, operation, pagingResponse, helperType);

            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);

            if (mgmtOperation.WrapperType != null)
            {
                writer.Line();
                writer.Line($"private readonly {typeof(ResourceOperationsBase)} {_operationBaseField};");
            }
        }

        protected override void WriteConstructor(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType cs, CSharpType helperType)
        {
            MgmtLongRunningOperation mgmtOperation = AsMgmtOperation(operation);

            if (mgmtOperation.WrapperType != null)
            {
                // pass operationsBase in so that the construction of [Resource] is possible
                writer.Append($"internal {cs.Name}({typeof(ResourceOperationsBase)} operationsBase, {typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, {typeof(Request)} request, {typeof(Response)} response");

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
                    writer.Line($"clientDiagnostics, pipeline, request, response, { typeof(OperationFinalStateVia)}.{ operation.FinalStateVia}, { operation.Diagnostics.ScopeName:L});");

                    if (pagingResponse != null)
                    {
                        writer.Line($"_nextPageFunc = nextPageFunc;");
                    }

                    writer.Line($"{_operationBaseField} = operationsBase;");
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

            if (mgmtOperation.WrapperType != null)
            {
                writer.WriteXmlDocumentationInheritDoc();
                writer.Line($"public override {mgmtOperation.WrapperType} Value => _operation.Value;");
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

            if (mgmtOperation.WrapperType != null)
            {
                Action<CodeWriter, CodeWriterDelegate> valueCallback = (w, v) => w.Line($"return new {mgmtOperation.WrapperType}({_operationBaseField}, {v});");

                using (writer.Scope($"{mgmtOperation.WrapperType} {interfaceType}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
                {
                    WriteCreateResultImpl(false, writer, operation, responseVariable, pagingResponse, valueCallback);
                }
                writer.Line();

                using (writer.Scope($"async {new CSharpType(typeof(ValueTask<>), mgmtOperation.WrapperType)} {interfaceType}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
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
