// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using Azure;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtLongRunningOperationWriter
    {
        private readonly CodeWriter _writer;

        private MgmtLongRunningOperation _lro;
        public string Filename { get; }

        public MgmtLongRunningOperationWriter(MgmtLongRunningOperation longRunningOperations)
        {
            _writer = new CodeWriter();
            _lro = longRunningOperations;
            Filename = _lro.IsGeneric ? $"{_lro.Type.Name}OfT.cs" : $"{_lro.Type.Name}.cs";
        }

        public void Write()
        {
            using (_writer.Namespace(MgmtContext.Context.DefaultNamespace))
            {
                _writer.Line($"#pragma warning disable SA1649 // File name should match first type name");
                _writer.Line($"internal class {_lro.Type:D} : {_lro.BaseType}");
                _writer.Line($"#pragma warning restore SA1649 // File name should match first type name");
                using (_writer.Scope())
                {
                    _writer.Line($"private readonly {_lro.OperationOrResponseType} _operation;");
                    _writer.Line();

                    if (_lro.MockingCtor is not null)
                    {
                        _writer.WriteMethodDocumentation(_lro.MockingCtor);
                        using (_writer.WriteMethodDeclaration(_lro.MockingCtor))
                        { }
                    }
                    _writer.Line();

                    if (_lro.ResponseCtor is not null)
                    {
                        using (_writer.WriteMethodDeclaration(_lro.ResponseCtor))
                        {
                            _writer.Line($"_operation = new {_lro.OperationOrResponseType}(response);");
                        }
                    }
                    _writer.Line();

                    if (_lro.RequestCtor is not null)
                    {
                        using (_writer.WriteMethodDeclaration(_lro.RequestCtor))
                        {
                            _writer.Append($"_operation = new {_lro.OperationOrResponseType}(");
                            foreach (var parameter in _lro.RequestCtor.Parameters)
                            {
                                _writer.Append($"{parameter.Name}, ");
                            }
                            _writer.Line($"\"{_lro.Type.Name}\");");
                        }
                    }
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override string Id => _operation.Id;");
                    _writer.Line();

                    if (_lro.IsGeneric)
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
                    _writer.Line($"public override {typeof(Response)} GetRawResponse() => _operation.GetRawResponse();");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(Response)} UpdateStatus({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(ValueTask<>).MakeGenericType(typeof(Response))} UpdateStatusAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(ValueTask<>).MakeGenericType(_lro.ResponseType)} {_lro.WaitMethod}({typeof(CancellationToken)} cancellationToken = default) => _operation.{_lro.WaitMethod}(cancellationToken);");
                    _writer.Line();

                    _writer.WriteXmlDocumentationInheritDoc();
                    _writer.Line($"public override {typeof(ValueTask<>).MakeGenericType(_lro.ResponseType)} {_lro.WaitMethod}({typeof(TimeSpan)} pollingInterval, {typeof(CancellationToken)} cancellationToken = default) => _operation.{_lro.WaitMethod}(pollingInterval, cancellationToken);");
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
