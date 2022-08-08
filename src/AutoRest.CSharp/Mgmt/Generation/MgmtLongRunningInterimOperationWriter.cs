// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
    internal class MgmtLongRunningInterimOperationWriter
    {
        private readonly CodeWriter _writer;
        private readonly string _name;
        private readonly string _baseName;
        private readonly FormattableString _operationSourceType;
        private readonly FormattableString _responseType;
        private readonly FormattableString _stateLockType;

        public string Filename { get; }

        public MgmtLongRunningInterimOperationWriter()
        {
            _writer = new CodeWriter();
            _name = $"{MgmtContext.Context.DefaultNamespace.Split('.').Last()}ArmInterimOperation";
            _baseName = $"{MgmtContext.Context.DefaultNamespace.Split('.').Last()}ArmOperation<T>";
            _operationSourceType = (FormattableString)$"{typeof(IOperationSource<>)}";
            _responseType = (FormattableString)$"{typeof(Response)}";
            _stateLockType = (FormattableString)$"{typeof(AsyncLockWithValue<>)}";
            Filename = $"LongRunningOperation/{_name}OfT.cs";
        }

        public void Write()
        {
            using (_writer.Namespace(MgmtContext.Context.DefaultNamespace))
            {
                _writer.Line($"#pragma warning disable SA1649 // File name should match first type name");
                _writer.Line($"internal class {_name}<T> : {_baseName}");
                _writer.Line($"#pragma warning restore SA1649 // File name should match first type name");
                using (_writer.Scope())
                {
                    _writer.Line($"private readonly {_operationSourceType} _operationSource;");
                    _writer.Line();

                    _writer.Line($"private readonly {_responseType} _interimResponse;");
                    _writer.Line();

                    _writer.Line($"private readonly {_stateLockType} _stateLock;");
                    _writer.Line();

                    using (_writer.Scope($"internal {_name}({_operationSourceType} source, {typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, {typeof(Request)} request, {typeof(Response)} response, {typeof(OperationFinalStateVia)} finalStateVia) : base(source, clientDiagnostics, pipeline, request, response, finalStateVia)"))
                    {
                        _writer.Line($"_operationSource = source;");
                        _writer.Line($"_interimResponse = response;");
                        _writer.Line($"_stateLock = new {_stateLockType}();");
                    }
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override async {typeof(ValueTask)}<T> GetCurrentStatusAsync({typeof(CancellationToken)} cancellationToken = default) => await GetCurrentState(true, cancellationToken).ConfigureAwait(false);");

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override T GetCurrentStatus({typeof(CancellationToken)} cancellationToken = default) => GetCurrentState(false, cancellationToken).EnsureCompleted();");
                    _writer.Line();

                    using (_writer.Scope($"private async {typeof(ValueTask)}<T> GetCurrentState({typeof(bool)} async, {typeof(CancellationToken)} cancellationToken)"))
                    {
                        _writer.Line($"using var asyncLock = await _stateLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);");
                        using (_writer.Scope($"if (asyncLock.HasValue)"))
                        {
                            _writer.Line($"return asyncLock.Value;");
                        }
                        _writer.Line($"var val = async ? await _operationSource.CreateResultAsync(_interimResponse, cancellationToken).ConfigureAwait(false)");
                        _writer.Line($"\t\t: _operationSource.CreateResult(_interimResponse, cancellationToken);");
                        _writer.Line($"asyncLock.SetValue(val);");
                        _writer.Line($"return val;");
                    }
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
