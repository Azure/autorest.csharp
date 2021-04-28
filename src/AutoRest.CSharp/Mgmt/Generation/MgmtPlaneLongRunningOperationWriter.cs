// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    /// <summary>
    /// This is a very naive version of long running operation writer.
    /// It's written to support generating containers,
    /// and should be rewritten later.
    /// </summary>
    internal class MgmtPlaneLongRunningOperationWriter
    {
        internal void Write(CodeWriter writer, OperationGroup operationGroup, Input.Operation operation, Output.Models.Types.BuildContext<Mgmt.AutoRest.MgmtOutputLibrary> context)
        {
            writer.UseNamespace("System");
            writer.UseNamespace("System.Text.Json");
            writer.UseNamespace("System.Threading");
            writer.UseNamespace("System.Threading.Tasks");
            writer.UseNamespace("Azure.Core");
            writer.UseNamespace("Azure.Core.Pipeline");
            writer.UseNamespace("Azure.ResourceManager.Core");

            var typeName = $"{operationGroup.Resource(context.Configuration.MgmtConfiguration)}{operation.Language.Default.Name}Operation";
            var resourceData = context.Library.GetResourceData(operationGroup);
            using var _ = writer.Namespace(context.DefaultNamespace);
            using (writer.Scope(
                $"public partial class {typeName} : ArmOperation<{resourceData.Type}>, IOperationSource<{resourceData.Type}>"
            ))
            {
                writer.Line($"private readonly OperationInternals<{resourceData.Type}> _operation;");
                using (writer.Scope($"protected {typeName}()"))
                { };
                using (writer.Scope($"internal {typeName}(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)"))
                {
                    writer.Line($"_operation = new OperationInternals<{resourceData.Type}>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, \"{typeName}\");");
                }

                writer.Line($"public override string Id => _operation.Id;");
                writer.Line($"public override {resourceData.Type} Value => _operation.Value;");
                writer.Line($"public override bool HasCompleted => _operation.HasCompleted;");
                writer.Line($"public override bool HasValue => _operation.HasValue;");
                writer.Line($"public override {typeof(Response)} GetRawResponse() => _operation.GetRawResponse();");
                writer.Line($"public override {typeof(Response)} UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                writer.Line($"public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
                writer.Line($"public override ValueTask<Response<{resourceData.Type}>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);");
                writer.Line($"public override ValueTask<Response<{resourceData.Type}>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);");

                using (writer.Scope($"{resourceData.Type} IOperationSource<{resourceData.Type}>.CreateResult(Response response, CancellationToken cancellationToken)"))
                {
                    writer.Line($"using var document = JsonDocument.Parse(response.ContentStream);");
                    writer.Line($"return {resourceData.Type}.Deserialize{resourceData.Type.Name}(document.RootElement);");
                }
                using (writer.Scope($"async ValueTask<{resourceData.Type}> IOperationSource<{resourceData.Type}>.CreateResultAsync(Response response, CancellationToken cancellationToken)"))
                {
                    writer.Line($"using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);");
                    writer.Line($"return {resourceData.Type}.Deserialize{resourceData.Type.Name}(document.RootElement);");
                }
            }
        }
    }
}