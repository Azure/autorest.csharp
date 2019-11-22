using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class OperationWriter : StringWriter
    {
        public bool WriteOperationGroup(OperationGroup operationGroup)
        {
            Header();
            using var _ = UsingStatements();
            var cs = operationGroup.Language.CSharp;
            var @namespace = cs?.Type?.Namespace;
            using (Namespace(@namespace))
            {
                using (Class(null, "static", cs?.Name))
                {
                    operationGroup.Operations.ForEachLast(o => WriteOperation(o, @namespace), o => WriteOperation(o, @namespace, false));
                }
            }
            return true;
        }

        //TODO: Implement Cookie (Body, Path, and Uri are handled differently)
        private static string? ParameterSetMethodCall(ParameterLocation? location) => location switch
        {
            ParameterLocation.Body => (string?)null,
            ParameterLocation.Cookie => null,
            ParameterLocation.Header => "request.Headers.SetValue",
            ParameterLocation.Path => null,
            ParameterLocation.Query => "request.Uri.AppendQuery",
            ParameterLocation.Uri => null,
            _ => null
        };

        //TODO: This is written very... code smelly. Clean up.
        private static IEnumerable<(string Text, bool IsLiteral)> GetPathParts(string path, (string Name, string SerializedName)?[] parameterInfos)
        {
            var index = 0;
            var currentPart = new List<char>();
            while (index < path.Length)
            {
                if (path[index] == '{')
                {
                    var innerPart = new List<char>();
                    var innerIndex = index + 1;
                    while (innerIndex < path.Length)
                    {
                        if (path[innerIndex] == '}')
                        {
                            var innerString = new string(innerPart.ToArray());
                            var pathParameter = parameterInfos.FirstOrDefault(pi => pi?.SerializedName == innerString);
                            if (pathParameter != null)
                            {
                                if (currentPart.Any())
                                {
                                    yield return (new string(currentPart.ToArray()), true);
                                }

                                var name = pathParameter.Value.Name;
                                yield return (name ?? "[NO NAME]", false);
                                currentPart.Clear();
                                innerPart.Clear();
                                break;
                            }
                        }
                        innerPart.Add(path[innerIndex]);
                        innerIndex++;
                    }

                    if (innerPart.Any())
                    {
                        currentPart.Add('{');
                        currentPart.AddRange(innerPart);
                    }
                    index = innerIndex + 1;
                    continue;
                }
                currentPart.Add(path[index]);
                index++;
            }

            if (currentPart.Any())
            {
                yield return (new string(currentPart.ToArray()), true);
            }
        }

        private static string GetWritableName(Parameter parameter, CSharpLanguage? parameterCs) => parameter.Schema is ConstantSchema constantSchema ? constantSchema.ToValueString() : parameterCs?.Name ?? "[NO NAME]";

        //TODO: Clean this up. It is written quickly and has a lot of parts that can be extracted from it.
        private void WriteOperation(Operation operation, CSharpNamespace? @namespace, bool includeBlankLine = true)
        {
            var operationCs = operation.Language.CSharp;
            //TODO: Handle multiple responses
            var schemaResponse = operation.Responses?.FirstOrDefault() as SchemaResponse;
            var responseType = schemaResponse?.Schema.Language.CSharp?.Type;
            var hasResponse = responseType != null;
            var returnType = hasResponse ?
                new CSharpType
                {
                    FrameworkType = typeof(ValueTask<>),
                    SubType1 = new CSharpType
                    {
                        FrameworkType = typeof(Response<>),
                        SubType1 = responseType
                    }
                } :
                new CSharpType
                {
                    FrameworkType = typeof(ValueTask<>),
                    SubType1 = new CSharpType
                    {
                        FrameworkType = typeof(Response)
                    }
                };

            var httpRequest = operation.Request.Protocol.Http as HttpRequest;
            var parameters = (operation.Request.Parameters ?? Enumerable.Empty<Parameter>())
                .Select(p => (Parameter: p, ParameterCs: p.Language.CSharp, ParameterSchemaCs: p.Schema.Language.CSharp, Location: (p.Protocol.Http as HttpParameter)?.In))
                //TODO: Handle BinarySchema properly
                .Where(p => !(p.Parameter.Schema is BinarySchema))
                .ToArray();

            var parametersText = new[] { Pair(Type(typeof(ClientDiagnostics)), "clientDiagnostics"), Pair(typeof(HttpPipeline), "pipeline") }
                .Concat(parameters
                    .Where(p => !(p.Parameter.Schema is ConstantSchema))
                    .OrderBy(p => (p.ParameterCs?.IsNullable ?? false) || (p.Parameter.ClientDefaultValue != null)).Select(p =>
                    {
                        var (parameter, parameterCs, parameterSchemaCs, _) = p;
                        var pair = Pair(parameterSchemaCs?.InputType ?? parameterSchemaCs?.Type, parameterCs?.Name, parameterCs?.IsNullable);
                        var shouldBeDefaulted = (parameterCs?.IsNullable ?? false) || (parameter.ClientDefaultValue != null);
                        //TODO: This will only work if the parameter is a string parameter
                        return shouldBeDefaulted ? $"{pair} = {(parameter.ClientDefaultValue != null ? $"\"{parameter.ClientDefaultValue}\"" : "default")}" : pair;
                    }))
                .Append($"{Pair(typeof(CancellationToken), "cancellationToken")} = default").ToArray();

            var methodName = operationCs?.Name ?? "[NO NAME]";
            using (Method("public static async", Type(returnType), $"{methodName}Async", parametersText))
            {
                Line($"using var scope = clientDiagnostics.CreateScope(\"{@namespace?.FullName ?? "[NO NAMESPACE]"}.{methodName}\");");
                //TODO: Implement attribute logic
                //Line("scope.AddAttribute(\"key\", name);");
                Line("scope.Start();");

                using (Try())
                {
                    Line("var request = pipeline.CreateRequest();");
                    var method = httpRequest?.Method.ToCoreRequestMethod() ?? RequestMethod.Get;
                    Line($"request.Method = {Type(typeof(RequestMethod))}.{method.ToRequestMethodName()};");

                    var uri = httpRequest?.Uri ?? String.Empty;
                    var path = httpRequest?.Path ?? String.Empty;
                    var pathParameters = parameters.Where(p => p.Location == ParameterLocation.Path || p.Location == ParameterLocation.Uri)
                        .Select(p => (Name: GetWritableName(p.Parameter, p.ParameterCs), SerializedName: p.Parameter.Language.Default.Name) as (string Name, string SerializedName)?).ToArray();
                    var pathParts = GetPathParts(uri + path, pathParameters);

                    //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                    //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                    var urlText = String.Join(String.Empty, pathParts.Select(p => p.IsLiteral ? p.Text : $"{{{p.Text}}}"));
                    Line($"request.Uri.Reset(new Uri($\"{urlText}\"));");

                    var settableParameters = parameters
                        .OrderBy(p => p.Location)
                        .Select(p => (Name: GetWritableName(p.Parameter, p.ParameterCs), SerializedName: p.Parameter.Language.Default.Name, MethodCall: ParameterSetMethodCall(p.Location), IsNullable: p.ParameterCs?.IsNullable ?? false))
                        .Where(p => p.MethodCall != null)
                        .ToArray();
                    foreach (var (name, serializedName, methodCall, isNullable) in settableParameters)
                    {
                        using (isNullable ? If($"{name} != null") : new DisposeAction())
                        {
                            //TODO: Determine conditions in which to ToString() or not
                            Line($"{methodCall}(\"{serializedName}\", {name}.ToString()!);");
                        }
                    }

                    var bodyParameter = parameters.Select(p => p.Parameter).FirstOrDefault(p => (p.Protocol.Http as HttpParameter)?.In == ParameterLocation.Body);
                    if (bodyParameter != null)
                    {
                        var bufferWriter = new CSharpType
                        {
                            FrameworkType = typeof(ArrayBufferWriter<>),
                            SubType1 = new CSharpType
                            {
                                FrameworkType = typeof(byte)
                            }
                        };

                        Line($"var buffer = new {Type(bufferWriter)}();");
                        Line($"await using var writer = new {Type(typeof(Utf8JsonWriter))}(buffer);");
                        var (parameter, parameterCs) = (bodyParameter, bodyParameter.Language.CSharp);
                        var name = GetWritableName(parameter, parameterCs);
                        var serializedName = parameter.Language.Default.Name;
                        var isNullable = parameterCs?.IsNullable ?? false;
                        Line(parameter.Schema.ToSerializeCall(name, serializedName, isNullable, includePropertyName: false) ?? $"// {parameter.Schema.GetType().Name} {name}: Not Implemented");
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
                            var statusCodes = (schemaResponse!.Protocol.Http as HttpResponse)?.StatusCodes ?? Enumerable.Empty<StatusCodes>().ToList();
                            foreach (var statusCode in statusCodes)
                            {
                                Line($"case {statusCode.GetEnumMemberValue()}:");
                            }
                            Line($"return {Type(typeof(Response))}.FromValue({schemaResponse.Schema.ToDeserializeCall("document.RootElement", Type(responseType), responseType?.Name ?? "[NO TYPE NAME]")}, response);");
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

            if(includeBlankLine) Line();
        }
    }
}
