using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class OperationWriter : StringWriter
    {
        public bool WriteOperationGroup(OperationGroup operationGroup) =>
            operationGroup switch
            {
                _ => WriteDefaultOperationGroup(operationGroup)
            };

        private bool WriteDefaultOperationGroup(OperationGroup operationGroup)
        {
            Header();
            using var _ = UsingStatements();
            var cs = operationGroup.Language.CSharp;
            var @namespace = cs?.Type?.Namespace;
            using (Namespace(@namespace))
            {
                using (Class(null, "static", cs?.Name))
                {
                    //var exceptionText = Type(typeof(Exception));
                    //var stringType = new CSharpType { FrameworkType = typeof(string) };
                    operationGroup.Operations.ForEachLast(o => WriteOperation(o, @namespace), o => WriteOperation(o, @namespace, false));
                }
            }
            return true;
        }

        private static string? ParameterMethodCall(ParameterLocation? location) => location switch
        {
            ParameterLocation.Body => (string?)null,
            ParameterLocation.Cookie => null,
            ParameterLocation.Header => "request.Headers.SetValue",
            ParameterLocation.Path => null,
            ParameterLocation.Query => "request.Uri.AppendQuery",
            ParameterLocation.Uri => null,
            _ => null
        };

        private void WriteOperation(Operation operation, CSharpNamespace? @namespace, bool includeBlankLine = true)
        {
            var operationCs = operation.Language.CSharp;
            //TODO: Do not default to string type
            var responseType = (operation.Responses?.FirstOrDefault() as SchemaResponse)?.Schema.Language.CSharp?.Type ?? new CSharpType { FrameworkType = typeof(string) };
            Type(responseType);
            var returnType = new CSharpType
            {
                FrameworkType = typeof(ValueTask<>),
                SubType1 = new CSharpType
                {
                    FrameworkType = typeof(Response<>),
                    SubType1 = responseType
                }
            };

            var httpRequest = operation.Request.Protocol.Http as HttpRequest;
            var httpServer = httpRequest?.Servers.FirstOrDefault();
            var serverParameters = (httpServer?.Variables ?? Enumerable.Empty<ServerVariable>()).ToArray();
            var serverParametersText = serverParameters.Select(sv => Pair(sv.Language.CSharp?.Type, sv.Language.CSharp?.Name));

            var pipelineType = typeof(HttpPipeline);
            var clientDiagnostics = new CSharpType { FrameworkType = pipelineType, Name = "ClientDiagnostics" };

            var parameters = (operation.Request.Parameters ?? Enumerable.Empty<Parameter>())
                .Select(p => (Parameter: p, ParameterCs: p.Language.CSharp, ParameterSchemaCs: p.Schema.Language.CSharp))
                .Where(p => !(p.Parameter.Schema is ConstantSchema) && !(p.Parameter.Schema is BinarySchema) && !((p.Parameter.Schema as ArraySchema)?.ElementType is ConstantSchema))
                .ToArray();

            var parametersText = new[] { /*Pair(clientDiagnostics, "clientDiagnostics"),*/ Pair(pipelineType, "pipeline") }
                .Concat(serverParametersText)
                .Concat(parameters.OrderBy(p => p.ParameterCs?.IsNullable ?? false).Select(p =>
                    {
                        var (_, parameterCs, parameterSchemaCs) = p;
                        var pair = Pair(parameterSchemaCs?.InputType ?? parameterSchemaCs?.Type, parameterCs?.Name, parameterCs?.IsNullable);
                        return (parameterCs?.IsNullable ?? false) ? $"{pair} = default" : pair;
                    }))
                .Append($"{Pair(typeof(CancellationToken), "cancellationToken")} = default").ToArray();

            var methodName = operationCs?.Name ?? "[NO NAME]";
            using (Method("public static async", Type(returnType), $"{methodName}Async", parametersText))
            {
                Line($"//using {Type(clientDiagnostics)} scope = pipeline.CreateScope(\"{@namespace?.FullName ?? "[NO NAMESPACE]"}.{methodName}\");");
                //TODO: Implement attribute logic
                Line("//scope.AddAttribute(\"key\", name)");
                Line("//scope.Start()");

                using (Try())
                {
                    Line("var request = pipeline.CreateRequest();");
                    var method = httpRequest?.Method.ToCoreRequestMethod() ?? RequestMethod.Get;
                    Line($"request.Method = {Type(typeof(RequestMethod))}.{method.ToRequestMethodName()};");
                    Line($"//request.Uri.Reset();");

                    var addParameters = parameters.Select(p => (p.Parameter, p.ParameterCs, p.ParameterSchemaCs, Location: (p.Parameter.Protocol.Http as HttpParameter)?.In)).OrderBy(p => p.Location);
                    foreach (var (parameter, parameterCs, parameterSchemaCs, location) in addParameters)
                    {
                        //body: add model serialization code

                        var methodCall = ParameterMethodCall(location);
                        var isNullable = parameterCs?.IsNullable ?? false;
                        var ifCondition = isNullable ? $"if ({parameterCs?.Name} != null) {{ " : String.Empty;
                        var endPart = isNullable ? " }" : String.Empty;
                        if (methodCall != null)
                        {
                            Line($"{ifCondition}{methodCall}(\"{parameter.Language.Default.Name}\", {parameterCs?.Name}.ToString() ?? {Type(typeof(string))}.Empty);{endPart}");
                        }
                    }
                }

                var exceptionParameter = Pair(typeof(Exception), "e");
                using (Catch())
                {
                    Line("//scope.Failed(e);");
                    Line("throw;");
                }
                Line($"throw new {Type(typeof(Exception))}();");
            }

            if(includeBlankLine) Line();
        }
    }
}
