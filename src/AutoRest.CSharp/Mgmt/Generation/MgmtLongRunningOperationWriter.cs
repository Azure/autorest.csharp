// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
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
            _responseType = isGeneric ? Configuration.ApiTypes.ResponseOfTType : Configuration.ApiTypes.ResponseType;
            _operationInternalType = isGeneric ? typeof(OperationInternal<>) : typeof(OperationInternal);
            _operationSourceString = isGeneric ? (FormattableString)$"{typeof(IOperationSource<>)} source, " : (FormattableString)$"";
            _responseString = isGeneric ? $"{Configuration.ApiTypes.ResponseParameterName}.{Configuration.ApiTypes.GetRawResponseName}(), {Configuration.ApiTypes.ResponseParameterName}.Value" : $"{Configuration.ApiTypes.ResponseParameterName}";
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
                    _writer.Line($"private readonly {typeof(RehydrationToken?)} _completeRehydrationToken;");
                    _writer.Line($"private readonly {typeof(NextLinkOperationImplementation)}? _nextLinkOperation;");
                    _writer.Line($"private readonly {typeof(string)} _operationId;");
                    _writer.Line();

                    _writer.WriteXmlDocumentationSummary($"Initializes a new instance of {_name} for mocking.");
                    using (_writer.Scope($"protected {_name}()"))
                    {
                    }
                    _writer.Line();

                    using (_writer.Scope($"internal {_name}({_responseType} {Configuration.ApiTypes.ResponseParameterName}, {typeof(RehydrationToken?)} rehydrationToken = null)"))
                    {
                        _writer.Line($"_operation = {_operationInternalType}.Succeeded({_responseString});");
                        _writer.Line($"_completeRehydrationToken = rehydrationToken;");
                        _writer.Line($"_operationId = GetOperationId(rehydrationToken);");
                    }
                    _writer.Line();

                    using (_writer.Scope($"internal {_name}({_operationSourceString}{typeof(ClientDiagnostics)} clientDiagnostics, {Configuration.ApiTypes.HttpPipelineType} pipeline, {typeof(Request)} request, {Configuration.ApiTypes.ResponseType} {Configuration.ApiTypes.ResponseParameterName}, {typeof(OperationFinalStateVia)} finalStateVia, bool skipApiVersionOverride = false, string apiVersionOverrideValue = null)"))
                    {
                        var nextLinkOperation = new CodeWriterDeclaration("nextLinkOperation");
                        _writer.Line($"var {nextLinkOperation:D} = {typeof(NextLinkOperationImplementation)}.{nameof(NextLinkOperationImplementation.Create)}(pipeline, request.Method, request.Uri.ToUri(), {Configuration.ApiTypes.ResponseParameterName}, finalStateVia, skipApiVersionOverride, apiVersionOverrideValue);");
                        using (_writer.Scope($"if (nextLinkOperation is NextLinkOperationImplementation nextLinkOperationValue)"))
                        {
                            // If nextLinkOperation is NextLinkOperationImplementation, this implies that the operation is not complete
                            // we need to store the nextLinkOperation to get lateset rehydration token
                            _writer.Line($"_nextLinkOperation = nextLinkOperationValue;");
                            _writer.Line($"_operationId = _nextLinkOperation.OperationId;");
                        }
                        using (_writer.Scope($"else"))
                        {
                            // This implies the operation is complete and we can cache the rehydration token since it won't change anymore
                            _writer.Line($"_completeRehydrationToken = {typeof(NextLinkOperationImplementation)}.{nameof(NextLinkOperationImplementation.GetRehydrationToken)}(request.Method, request.Uri.ToUri(), {Configuration.ApiTypes.ResponseParameterName}, finalStateVia);");
                            _writer.Line($"_operationId = GetOperationId(_completeRehydrationToken);");
                        }
                        if (_isGeneric)
                        {
                            _writer.Line($"_operation = new {_operationInternalType}({typeof(NextLinkOperationImplementation)}.{nameof(NextLinkOperationImplementation.Create)}({_sourceString}nextLinkOperation), clientDiagnostics, {Configuration.ApiTypes.ResponseParameterName}, {_name:L}, fallbackStrategy: new {typeof(SequentialDelayStrategy)}());");
                        }
                        else
                        {
                            _writer.Line($"_operation = new {_operationInternalType}({nextLinkOperation}, clientDiagnostics, {Configuration.ApiTypes.ResponseParameterName}, {_name:L}, fallbackStrategy: new {typeof(SequentialDelayStrategy)}());");
                        }
                        }
                    _writer.Line();

                    using (_writer.Scope($"private string GetOperationId(RehydrationToken? rehydrationToken)"))
                    {
                        using (_writer.Scope($"if (rehydrationToken is null)"))
                        {
                            _writer.Line($"return null;");
                        }
                        _writer.Line($"var lroDetails = {typeof(ModelReaderWriter)}.{nameof(ModelReaderWriter.Write)}(rehydrationToken, ModelReaderWriterOptions.Json).ToObjectFromJson<{typeof(Dictionary<string, string>)}>();");
                        _writer.Line($"return lroDetails[\"id\"];");
                    }

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer
                        .LineRaw("public override string Id => _operationId ?? NextLinkOperationImplementation.NotSet;")
                        .Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer
                        .LineRaw("public override RehydrationToken? GetRehydrationToken() => _nextLinkOperation?.GetRehydrationToken() ?? _completeRehydrationToken;")
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
                    _writer.Line($"public override {Configuration.ApiTypes.ResponseType} {Configuration.ApiTypes.GetRawResponseName}() => _operation.RawResponse;");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {Configuration.ApiTypes.ResponseType} UpdateStatus({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(ValueTask<>).MakeGenericType(Configuration.ApiTypes.ResponseType)} UpdateStatusAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
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
