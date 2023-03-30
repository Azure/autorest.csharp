// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class OperationSourceWriter
    {
        private readonly OperationSource _opSource;
        private readonly CodeWriter _writer;
        private readonly IReadOnlyDictionary<string, string>? _operationIdMappings;

        public OperationSourceWriter(OperationSource opSource)
        {
            _writer = new CodeWriter();
            _opSource = opSource;
            if (_opSource.Resource is not null && Configuration.MgmtConfiguration.OperationIdMappings.TryGetValue(_opSource.Resource.ResourceName, out var mappings))
                _operationIdMappings = mappings;
        }

        public void Write()
        {
            using (_writer.Namespace($"{MgmtContext.Context.DefaultNamespace}"))
            {
                using (_writer.Scope($"internal class {_opSource.TypeName} : {_opSource.Interface}"))
                {
                    if (_opSource.IsReturningResource)
                    {
                        _writer.WriteField(_opSource.ArmClientField);

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
                    WriteCreateResult();

                    _writer.Line();
                    WriteCreateResultAsync();

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
                            var createIdMethod = resource.CreateResourceIdentifierMethodSignature;
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

        public override string ToString()
        {
            return _writer.ToString();
        }

        private void WriteCreateResult()
        {
            var responseVariable = new CodeWriterDeclaration("response");
            using (_writer.Scope($"{_opSource.ReturnType} {_opSource.Interface}.CreateResult({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
            {
                WriteCreateResultBody(responseVariable, false);
            }
        }

        private void WriteCreateResultAsync()
        {
            var responseVariable = new CodeWriterDeclaration("response");
            using (_writer.Scope($"async {new CSharpType(typeof(ValueTask<>), _opSource.ReturnType)} {_opSource.Interface}.CreateResultAsync({typeof(Response)} {responseVariable:D}, {typeof(CancellationToken)} cancellationToken)"))
            {
                WriteCreateResultBody(responseVariable, true);
            }
        }

        private void WriteCreateResultBody(CodeWriterDeclaration responseVariable, bool async)
        {
            if (_opSource.IsReturningResource)
            {
                var resourceData = _opSource.Resource!.ResourceData;
                Debug.Assert(resourceData.IncludeDeserializer);

                _writer.MethodBodyStatement(Snippets.UsingVar("document", JsonDocumentExpression.Parse(responseVariable, async), out var document));

                var dataVariable = new CodeWriterDeclaration("data");
                var deserializeExpression = JsonSerializationMethodsBuilder.GetDeserializeImplementation(resourceData, document.RootElement, null);
                if (_operationIdMappings is not null)
                {
                    deserializeExpression = ValueExpressions.Call.Instance(null, "ScrubId", deserializeExpression);
                }

                _writer.MethodBodyStatement(new DeclareVariable(null, dataVariable, deserializeExpression));
                if (resourceData.ShouldSetResourceIdentifier)
                {
                    _writer.Line($"{dataVariable}.Id = {_opSource.ArmClientField.Name}.Id;");
                }
                _writer.Line($"return new {_opSource.Resource.Type}({_opSource.ArmClientField.Name}, {dataVariable});");
            }
            else
            {
                _writer.WriteDeserializationForMethods(_opSource.ResponseSerialization, async, null, $"{responseVariable}", _opSource.ReturnType);
            }
        }
    }
}
