// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class NonLongRunningOperationWriter : LongRunningOperationWriter
    {
        protected override CSharpType GetBaseType(LongRunningOperation operation)
        {
            var nonLro = AsNonLongRunningOperation(operation);
            return nonLro.WrapperType != null ? new CSharpType(typeof(Operation<>), nonLro.WrapperType) : base.GetBaseType(operation);
        }

        protected override CSharpType GetValueTaskType(LongRunningOperation operation)
        {
            var nonLro = AsNonLongRunningOperation(operation);
            return nonLro.WrapperType != null ? new CSharpType(typeof(Response<>), nonLro.WrapperType) : base.GetValueTaskType(operation);
        }
        protected override CSharpType GetHelperType(LongRunningOperation operation)
        {
            var nonLro = AsNonLongRunningOperation(operation);
            if (nonLro.WrapperType != null)
            {
                return new CSharpType(typeof(OperationOrResponseInternals<>), nonLro.WrapperType);
            }
            else if (nonLro.ResultType != null)
            {
                return new CSharpType(typeof(OperationOrResponseInternals<>), nonLro.ResultType);
            }
            else
            {
                return new CSharpType(typeof(OperationOrResponseInternals));
            }
        }

        // no need to implement IOperationSource (CreateResult) in non-LROs
        protected override CSharpType? GetInterfaceType(LongRunningOperation operation) => null;

        protected override void WriteConstructor(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType cs, CSharpType helperType)
        {
            var nonLro = AsNonLongRunningOperation(operation);
            if (nonLro.ResultType != null)
            {
                var responseType = new CSharpType(typeof(Response), nonLro.ResultType);

                writer.Append($"internal {cs.Name}(");

                if (nonLro.WrapperType != null)
                {
                    // pass operationsBase in so that the construction of [Resource] is possible
                    writer.Append($"{typeof(ResourceOperationsBase)} operationsBase, ");
                }
                writer.Append($"{responseType} response");

                if (pagingResponse != null)
                {
                    writer.Append($", {typeof(Func<string, Task<Response>>)} nextPageFunc");
                }
                writer.Line($")");

                using (writer.Scope())
                {
                    writer.Append($"_operation = new {helperType}(");
                    if (nonLro.WrapperType != null)
                    {
                        writer.Append($"{typeof(Response)}.FromValue(");
                        writer.Append($"new {nonLro.WrapperType}(operationsBase, response.Value),");
                        writer.Append($"response.GetRawResponse()");
                        writer.Append($")");
                    }
                    else
                    {
                        writer.Append($"response");
                    }
                    writer.Line($");");
                    if (pagingResponse != null)
                    {
                        writer.Line($"_nextPageFunc = nextPageFunc;");
                    }
                }
            }
            else
            {
                writer.Append($"internal {cs.Name}({typeof(Response)} response");

                if (pagingResponse != null)
                {
                    writer.Append($", {typeof(Func<string, Task<Response>>)} nextPageFunc");
                }
                writer.Line($")");

                using (writer.Scope())
                {
                    writer.Line($"_operation = new {helperType}(response);");
                    if (pagingResponse != null)
                    {
                        writer.Line($"_nextPageFunc = nextPageFunc;");
                    }
                }
            }
        }

        protected override void WriteValueProperty(CodeWriter writer, LongRunningOperation operation)
        {
            var nonLro = AsNonLongRunningOperation(operation);

            if (nonLro.ResultType != null)
            {
                writer.WriteXmlDocumentationInheritDoc();
                writer.Line($"public override {nonLro.WrapperType ?? nonLro.ResultType} Value => _operation.Value;");
                writer.Line();
            }
        }

        protected NonLongRunningOperation AsNonLongRunningOperation(LongRunningOperation operation)
        {
            var nonLongRunningOperation = operation as NonLongRunningOperation;
            Debug.Assert(nonLongRunningOperation != null);
            return nonLongRunningOperation;
        }
    }
}
