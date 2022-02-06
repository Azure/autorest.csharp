// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class OperationSourceWriter
    {
        private readonly BuildContext<MgmtOutputLibrary> _context;
        private readonly OperationSource _opSource;
        private readonly CodeWriter _writer;

        public OperationSourceWriter(OperationSource opSource, BuildContext<MgmtOutputLibrary> context)
        {
            _writer = new CodeWriter();
            _context = context;
            _opSource = opSource;
        }

        public void Write()
        {
            using (_writer.Namespace($"{_context.DefaultNamespace}"))
            {
                using (_writer.Scope($"internal class {_opSource.TypeName} : {_opSource.Interface}"))
                {
                    if (_opSource.Resource is not null)
                    {
                        _writer.WriteFieldDeclaration(_opSource.ArmClientField);
                        _writer.Line();
                        using (_writer.WriteMethodDeclaration(_opSource.ArmClientCtor))
                        {
                            _writer.Line($"{_opSource.ArmClientField.Name} = {MgmtTypeProvider.ArmClientParameter.Name};");
                        }
                        _writer.Line();
                    }
                    WriteCreateResult("response");
                }
            }
        }

        public void WriteCreateResult(string responseVariable)
        {
            Action<CodeWriter, CodeWriterDelegate> valueCallback = (w, v) => w.Line($"return {v};");
            if (_opSource.Resource is not null && _opSource.Resource.Type.Equals(_opSource.ReturnType))
            {
                valueCallback = (w, v) =>
                {
                    var data = new CodeWriterDeclaration("data");
                    w.Line($"var {data:D} = {v};");
                    if (_opSource.Resource.ResourceData.ShouldSetResourceIdentifier)
                    {
                        w.Line($"{data}.Id = {_opSource.ArmClientField.Name}.Id;");
                    }
                    w.Line($"return new {_opSource.Resource.Type}({_opSource.ArmClientField.Name}, {data});");
                };
            }

            using (_writer.Scope($"{_opSource.ReturnType} {_opSource.Interface}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
            {
                _writer.WriteDeserializationForMethods(_opSource.ResponseSerialization, false, valueCallback, responseVariable);
            }
            _writer.Line();

            using (_writer.Scope($"async {new CSharpType(typeof(ValueTask<>), _opSource.ReturnType)} {_opSource.Interface}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
            {
                _writer.WriteDeserializationForMethods(_opSource.ResponseSerialization, true, valueCallback, responseVariable);
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
