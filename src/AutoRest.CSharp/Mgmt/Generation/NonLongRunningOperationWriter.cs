// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class NonLongRunningOperationWriter
    {
        /// <summary>
        /// Write a management plane non-LRO as a LRO for the consistency of API surface.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="operation"></param>
        public static void Write(CodeWriter writer, NonLongRunningOperation operation)
        {
            var responseVariable = "response";

            var cs = operation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(operation.Description);
                var baseType = operation.ResultType != null ? new CSharpType(typeof(Operation<>), operation.ResultType) : new CSharpType(typeof(Azure.Operation));
                var valueTaskType = operation.ResultType != null ? new CSharpType(typeof(Response<>), operation.ResultType) : new CSharpType(typeof(Response));
                var waitForCompletionType = new CSharpType(typeof(ValueTask<>), valueTaskType);
                var helperType = operation.ResultType != null ? new CSharpType(typeof(OperationOrResponseInternals<>), operation.ResultType) : new CSharpType(typeof(OperationOrResponseInternals));
                var waitForCompleteMethodName = operation.ResultType != null ? "WaitForCompletionAsync" : "WaitForCompletionResponseAsync";

                using (writer.Scope($"{operation.Declaration.Accessibility} partial class {cs.Name}: {baseType}"))
                {
                    writer.Line($"private readonly {helperType} _operation;");

                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name} for mocking.");
                    using (writer.Scope($"protected {cs.Name:D}()"))
                    {
                    }

                    writer.Line();
                    writer.Append($"internal {cs.Name}(");
                    if (operation.ResultType != null)
                    {
                        if (operation.ResultDataType != null)
                        {
                            // todo: programmatically get the type of operationBase from the definition of [Resource]
                            writer.Append($"{typeof(OperationsBase)} operationsBase, ");
                            writer.Append($"{typeof(Response)}<{operation.ResultDataType}> {responseVariable}");
                        }
                        else
                        {
                            writer.Append($"{typeof(Response)}<{operation.ResultType}> {responseVariable}");
                        }
                    }
                    else
                    {
                        writer.Append($"{typeof(Response)} {responseVariable}");
                    }
                    writer.Line($")");

                    using (writer.Scope())
                    {
                        writer.Append($"_operation = new {helperType}(");
                        if (operation.ResultType != null && operation.ResultDataType != null)
                        {
                            writer.Append($"{typeof(Response)}.FromValue(");
                            writer.Append($"new {operation.ResultType}(operationsBase, {responseVariable}.Value),");
                            writer.Append($"{responseVariable}.GetRawResponse()");
                            writer.Append($")");
                        }
                        else
                        {
                            writer.Append($"{responseVariable}");
                        }
                        writer.Line($");");

                    }

                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override string Id => _operation.Id;");
                    writer.Line();

                    if (operation.ResultType != null)
                    {
                        writer.WriteXmlDocumentationInheritDoc();
                        writer.Line($"public override {operation.ResultType} Value => _operation.Value;");
                        writer.Line();
                    }

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override bool HasCompleted => _operation.HasCompleted;");
                    writer.Line();

                    if (operation.ResultType != null)
                    {
                        writer.WriteXmlDocumentationInheritDoc();
                        writer.Line($"public override bool HasValue => _operation.HasValue;");
                        writer.Line();
                    }

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} GetRawResponse() => _operation.GetRawResponse();");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} UpdateStatus({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(ValueTask<Response>)} UpdateStatusAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {waitForCompletionType} {waitForCompleteMethodName}({typeof(CancellationToken)} cancellationToken = default) => _operation.{waitForCompleteMethodName}(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {waitForCompletionType} {waitForCompleteMethodName}({typeof(TimeSpan)} pollingInterval, {typeof(CancellationToken)} cancellationToken = default) => _operation.{waitForCompleteMethodName}(pollingInterval, cancellationToken);");
                    writer.Line();
                }
            }
        }
    }
}
