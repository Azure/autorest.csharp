// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Request = Azure.Core.Request;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtLongRunningOperationWriter
    {
        private readonly CodeWriter _writer;
        private readonly string _name;
        private readonly string _genericString;
        private readonly bool _isGeneric;
        private readonly string _waitMethod;
        private readonly Type _operationType;
        private readonly Type _responseType;
        private readonly Type _operationInternalType;
        private readonly FormattableString _operationSourceString;
        private readonly string _responseString;
        private readonly string _sourceString;

        public string Filename { get; }

        public MgmtLongRunningOperationWriter(bool isGeneric)
        {
            _writer = new CodeWriter();
            _isGeneric = isGeneric;
            _name = $"{MgmtContext.Context.DefaultNamespace.Split('.').Last()}ArmOperation";
            _genericString = isGeneric ? "<T>" : string.Empty;
            Filename = isGeneric ? $"LongRunningOperation/{_name}OfT.cs" : $"LongRunningOperation/{_name}.cs";
            _waitMethod = isGeneric ? "WaitForCompletion" : "WaitForCompletionResponse";
            _operationType = isGeneric ? typeof(ArmOperation<>) : typeof(ArmOperation);
            _responseType = isGeneric ? typeof(Response<>) : typeof(Response);
            _operationInternalType = isGeneric ? typeof(OperationInternal<>) : typeof(OperationInternal);
            _operationSourceString = isGeneric ? (FormattableString)$"{typeof(IOperationSource<>)} source, " : (FormattableString)$"";
            _responseString = isGeneric ? "response.GetRawResponse(), response.Value" : "response";
            _sourceString = isGeneric ? "source, " : string.Empty;
        }

        public void Write()
        {
            using (_writer.Namespace(MgmtContext.Context.DefaultNamespace))
            {
                _writer.Line($"#pragma warning disable SA1649 // File name should match first type name");
                _writer.Line($"internal class {_name}{_genericString} : {_operationType}");
                _writer.Line($"#pragma warning restore SA1649 // File name should match first type name");
                using (_writer.Scope())
                {
                    _writer.Line($"private readonly {_operationInternalType} _operation;");
                    _writer.Line();

                    _writer.WriteXmlDocumentationSummary($"Initializes a new instance of {_name} for mocking.");
                    using (_writer.Scope($"protected {_name}()"))
                    {
                    }
                    _writer.Line();

                    using (_writer.Scope($"internal {_name}({_responseType} response)"))
                    {
                        _writer.Line($"_operation = {_operationInternalType}.Succeeded({_responseString});");
                    }
                    _writer.Line();

                    using (_writer.Scope($"internal {_name}({_operationSourceString}{typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, {typeof(Request)} request, {typeof(Response)} response, {typeof(OperationFinalStateVia)} finalStateVia)"))
                    {
                        var nextLinkOperation = new CodeWriterDeclaration("nextLinkOperation");
                        _writer.Line($"var {nextLinkOperation:D} = {typeof(NextLinkOperationImplementation)}.{nameof(NextLinkOperationImplementation.Create)}({_sourceString}pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);");
                        _writer.Line($"_operation = new {_operationInternalType}(clientDiagnostics, {nextLinkOperation}, response, {_name:L}, fallbackStrategy: new {typeof(SequentialDelayStrategy)}());");
                    }
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer
                        .LineRaw("#pragma warning disable CA1822")
                        .LineRaw($"[{typeof(EditorBrowsableAttribute)}({typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)})]")
                        .LineRaw("public override string Id => throw new NotImplementedException();")
                        .LineRaw("#pragma warning restore CA1822")
                        .Line();

                    if (_isGeneric)
                    {
                        _writer.WriteXmlDocumentationInheritDoc();
                        _writer.Line($"public override T Value => _operation.Value;");
                        _writer.Line();

                        _writer.WriteXmlDocumentationInheritDoc();
                        _writer.Line($"public override bool HasValue => _operation.HasValue;");
                        _writer.Line();
                    }

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override bool HasCompleted => _operation.HasCompleted;");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(Response)} GetRawResponse() => _operation.RawResponse;");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(Response)} UpdateStatus({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(ValueTask<>).MakeGenericType(typeof(Response))} UpdateStatusAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {_responseType} {_waitMethod}({typeof(CancellationToken)} cancellationToken = default) => _operation.{_waitMethod}(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {_responseType} {_waitMethod}({typeof(TimeSpan)} pollingInterval, {typeof(CancellationToken)} cancellationToken = default) => _operation.{_waitMethod}(pollingInterval, cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(ValueTask<>).MakeGenericType(_responseType)} {_waitMethod}Async({typeof(CancellationToken)} cancellationToken = default) => _operation.{_waitMethod}Async(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(ValueTask<>).MakeGenericType(_responseType)} {_waitMethod}Async({typeof(TimeSpan)} pollingInterval, {typeof(CancellationToken)} cancellationToken = default) => _operation.{_waitMethod}Async(pollingInterval, cancellationToken);");
                    _writer.Line();
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
