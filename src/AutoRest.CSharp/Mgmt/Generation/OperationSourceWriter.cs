﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class OperationSourceWriter
    {
        private readonly OperationSource _opSource;
        private readonly CodeWriter _writer;
        private readonly bool _isReturningResource;
        private readonly IReadOnlyDictionary<string, string>? _operationIdMappings;

        public OperationSourceWriter(OperationSource opSource)
        {
            _writer = new CodeWriter();
            _opSource = opSource;
            _isReturningResource = MgmtContext.Library.CsharpTypeToResource.ContainsKey(_opSource.ReturnType);
            if (_opSource.Resource is not null && Configuration.MgmtConfiguration.OperationIdMappings.TryGetValue(_opSource.Resource.Type.Name, out var mappings))
                _operationIdMappings = mappings;
        }

        public void Write()
        {
            using (_writer.Namespace($"{MgmtContext.Context.DefaultNamespace}"))
            {
                using (_writer.Scope($"internal class {_opSource.TypeName} : {_opSource.Interface}"))
                {
                    if (_isReturningResource)
                    {
                        _writer.WriteFieldDeclaration(_opSource.ArmClientField);

                        if (_operationIdMappings is not null)
                        {
                            using (_writer.Scope($"private readonly {typeof(Dictionary<string, string>)} _idMappings = new {typeof(Dictionary<string, string>)}()", start: "\t\t{", end: "\t\t};"))
                            {
                                _writer.Line($"\t\t\t{{ \"subscriptionId\", \"Microsoft.Resources/subscriptions\" }},");
                                _writer.Line($"\t\t\t{{ \"resourceGroupName\", \"Microsoft.Resources/resourceGroups\" }},");
                                foreach (var mapping in _operationIdMappings)
                                {
                                    _writer.Line($"\t\t\t{{ \"{mapping.Key}\", \"{mapping.Value}\" }},");
                                }
                            }
                        }

                        _writer.Line();
                        using (_writer.WriteMethodDeclaration(_opSource.ArmClientCtor))
                        {
                            _writer.Line($"{_opSource.ArmClientField.Name} = {MgmtTypeProvider.ArmClientParameter.Name};");
                        }
                    }

                    _writer.Line();
                    WriteCreateResult("response");

                    if (_operationIdMappings is not null)
                    {
                        var resource = _opSource.Resource!;
                        var resourceType = resource.Type;
                        var dataType = resource.ResourceData.Type;
                        _writer.Line();
                        using (_writer.Scope($"private {dataType} ScrubId({dataType} data)"))
                        {
                            _writer.Line($"if (data.Id.ResourceType == {resourceType}.ResourceType)");
                            _writer.Line($"return data;");
                            _writer.Line();
                            _writer.Append($"var newId = {resourceType}.CreateResourceIdentifier(");
                            var createIdMethods = resource.CreateResourceIdentifierMethodSignature();
                            if (createIdMethods.Count != 1)
                                throw new InvalidOperationException($"In order to write mappings we need to have exactly 1 CreateResourceIdentifierMethodSignature.  We found {createIdMethods.Count} for {resource.Type.Name}.");
                            var createIdMethod = createIdMethods.Values.First();
                            foreach (var param in createIdMethod.Parameters)
                            {
                                _writer.Line();
                                _writer.Append($"\tGetName(\"{param.Name}\", data.Id),");
                            }
                            _writer.RemoveTrailingComma();
                            _writer.Line($");");
                            _writer.Line();
                            _writer.Line($"return new {dataType}(");
                            _writer.Line($"\tnewId,");
                            _writer.Line($"\tnewId.Name,");
                            _writer.Append($"\tnewId.ResourceType,");
                            foreach (var param in resource.ResourceData.SerializationConstructor.Signature.Parameters.Skip(3))
                            {
                                _writer.Line();
                                _writer.Append($"\tdata.{param.Name.FirstCharToUpperCase()},");
                            }
                            _writer.RemoveTrailingComma();
                            _writer.Line($");");
                        }

                        _writer.Line();
                        using (_writer.Scope($"private string GetName(string param, {typeof(ResourceIdentifier)} id)"))
                        {
                            _writer.Line($"while (id.ResourceType != _idMappings[param])");
                            _writer.Line($"id = id.Parent;");
                            _writer.Line($"return id.Name;");
                        }
                    }
                }
            }
        }

        public void WriteCreateResult(string responseVariable)
        {
            Action<CodeWriter, CodeWriterDelegate> valueCallback = (w, v) => w.Line($"return {v};");
            if (_isReturningResource)
            {
                valueCallback = (w, v) =>
                {
                    var data = new CodeWriterDeclaration("data");
                    FormattableString dataString = _operationIdMappings is null ? (FormattableString)$"var {data:D} = {v};" : (FormattableString)$"var {data:D} = ScrubId({v});";
                    w.Line(dataString);
                    if (_opSource.Resource!.ResourceData.ShouldSetResourceIdentifier)
                    {
                        w.Line($"{data}.Id = {_opSource.ArmClientField.Name}.Id;");
                    }
                    w.Line($"return new {_opSource.Resource.Type}({_opSource.ArmClientField.Name}, {data});");
                };
            }

            using (_writer.Scope($"{_opSource.ReturnType} {_opSource.Interface}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
            {
                _writer.WriteDeserializationForMethods(_opSource.ResponseSerialization, false, valueCallback, responseVariable, _opSource.ReturnType);
            }
            _writer.Line();

            using (_writer.Scope($"async {new CSharpType(typeof(ValueTask<>), _opSource.ReturnType)} {_opSource.Interface}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
            {
                _writer.WriteDeserializationForMethods(_opSource.ResponseSerialization, true, valueCallback, responseVariable, _opSource.ReturnType);
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
