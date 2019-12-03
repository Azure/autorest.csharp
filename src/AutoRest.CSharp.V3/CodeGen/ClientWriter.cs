// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModel;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ClientWriter : StringWriter
    {
        private readonly TypeFactory _typeFactory;

        public ClientWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public bool WriteClient(ServiceClient operationGroup)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(operationGroup);
            var @namespace = cs.Namespace;
            using (Namespace(@namespace))
            {
                using (Class(null, "static", operationGroup.Name))
                {
                    foreach (var method in operationGroup.Methods)
                    {
                        WriteOperation(method, cs.Namespace);
                    }
                }
            }
            return true;
        }

        private void WriteOperation(ClientMethod operation, CSharpNamespace? @namespace)
        {
            //TODO: Handle multiple responses
            var schemaResponse = operation.ResponseType;
            CSharpType returnType;
            CSharpType? responseType = null;
            bool hasResponse = false;

            if (schemaResponse != null)
            {
                hasResponse = true;
                responseType = _typeFactory.CreateType(schemaResponse);
                returnType = new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response<>), responseType));
            }
            else
            {
                returnType = new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response)));
            }

            var parametersText = new[] { Pair(Type(typeof(ClientDiagnostics)), "clientDiagnostics"), Pair(typeof(HttpPipeline), "pipeline") }
                .Concat(operation.Parameters
                    .OrderBy(p => p.DefaultValue != null)
                    .Select(parameter =>
                    {
                        Debug.Assert(parameter != null);
                        var pair = Pair(_typeFactory.CreateInputType(parameter.Type), parameter.Name);
                        var shouldBeDefaulted = parameter.DefaultValue != null;
                        //TODO: This will only work if the parameter is a string parameter
                        return shouldBeDefaulted ? $"{pair} = {(parameter.DefaultValue != null ? $"\"{parameter.DefaultValue.Value.Value}\"" : "default")}" : pair;
                    }))
                .Append($"{Pair(typeof(CancellationToken), "cancellationToken")} = default").ToArray();

            var methodName = operation.Name;
            using (Method("public static async", Type(returnType), $"{methodName}Async", parametersText))
            {
                Line($"using var scope = clientDiagnostics.CreateScope(\"{@namespace?.FullName ?? "[NO NAMESPACE]"}.{methodName}\");");
                //TODO: Implement attribute logic
                //Line("scope.AddAttribute(\"key\", name);");
                Line("scope.Start();");

                using (Try())
                {
                    Line("var request = pipeline.CreateRequest();");
                    var method = operation.Request.Method;
                    Line($"request.Method = {Type(typeof(RequestMethod))}.{method.ToRequestMethodName()};");

                    //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                    //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                    //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end up with multiple // together
                    var urlText = String.Join(String.Empty, operation.Request.HostSegments.Select(s=> s.IsConstant ? s.Constant.Value :"{" + s.Parameter.Name + "}"));
                    Line($"request.Uri.Reset(new Uri($\"{urlText}\"));");

                    foreach (var segment in operation.Request.PathSegments)
                    {
                        if (segment.IsConstant)
                        {
                            Line($"request.Uri.AppendPath(\"{segment.Constant.Value}\", false);");
                        }
                        else
                        {
                            Line($"request.Uri.AppendPath({segment.Parameter.Name}.ToString()!);");
                        }
                    }

                    foreach (var pair in operation.Request.Headers)
                    {
                        if (pair.Value.IsConstant)
                        {
                            Line($"request.Headers.Add(\"{pair.Key}\", \"{pair.Value.Constant.Value}\");");
                        }
                        else
                        {
                            var parameter = pair.Value.Parameter;

                            using (parameter.Type.IsNullable ? If($"{parameter.Name} != null") : new DisposeAction())
                            {
                                //TODO: Determine conditions in which to ToString() or not
                                Line($"request.Headers.Add(\"{pair.Key}\", {parameter.Name}.ToString()!);");
                            }
                        }
                    }

                    foreach (var pair in operation.Request.Query)
                    {
                        if (pair.Value.IsConstant)
                        {
                            Line($"request.Uri.AppendQuery(\"{pair.Key}\", \"{pair.Value.Constant.Value}\");");
                        }
                        else
                        {
                            var parameter = pair.Value.Parameter;

                            using (parameter.Type.IsNullable ? If($"{parameter.Name} != null") : new DisposeAction())
                            {
                                //TODO: Determine conditions in which to ToString() or not
                                Line($"request.Uri.AppendQuery(\"{pair.Key}\", {parameter.Name}.ToString()!);");
                            }
                        }
                    }


                    if (operation.Request.Body is ConstantOrParameter body)
                    {
                        var bufferWriter = new CSharpType(typeof(ArrayBufferWriter<>), new CSharpType(typeof(byte)));

                        Line($"var buffer = new {Type(bufferWriter)}();");
                        Line($"await using var writer = new {Type(typeof(Utf8JsonWriter))}(buffer);");

                        if (body.IsConstant)
                        {
                            this.ToSerializeCall(body.Constant.Type, _typeFactory, body.Constant.ToValueString(), "", includePropertyName: false);
                        }
                        else
                        {
                            ServiceClientMethodParameter parameter = body.Parameter;
                            this.ToSerializeCall(parameter.Type, _typeFactory, parameter.Name, "", includePropertyName: false);
                        }

                        Line("writer.Flush();");
                        Line("request.Content = RequestContent.Create(buffer.WrittenMemory);");
                    }

                    Line("var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);");
                    Line("cancellationToken.ThrowIfCancellationRequested();");

                    //TODO: Do multiple status codes
                    if (hasResponse)
                    {
                        Line($"using var document = await {Type(typeof(JsonDocument))}.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);");

                        //TODO: Handle multiple exceptions
                        //var schemaException = operation.Exceptions?.FirstOrDefault() as SchemaResponse;

                        using (Switch("response.Status"))
                        {
                            var statusCodes = operation.Request.SuccessfulStatusCodes;
                            foreach (var statusCode in statusCodes)
                            {
                                Line($"case {statusCode}:");
                            }

                            Append($"return {Type(typeof(Response))}.FromValue(");
                            this.ToDeserializeCall(schemaResponse!, _typeFactory, "document.RootElement", Type(responseType!), responseType!.Name ?? "[NO TYPE NAME]");
                            Line(", response);");
                            Line("default:");
                            //TODO: Handle actual exception responses
                            Line($"throw new {Type(typeof(Exception))}();");
                        }
                    }
                    else
                    {
                        Line("return response;");
                    }
                }

                var exceptionParameter = Pair(typeof(Exception), "e");
                using (Catch(exceptionParameter))
                {
                    Line("scope.Failed(e);");
                    Line("throw;");
                }
            }
        }
    }
}
