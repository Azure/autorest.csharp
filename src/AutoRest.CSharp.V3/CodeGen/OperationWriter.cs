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
                    var exceptionText = Type(typeof(Exception));
                    var stringType = new CSharpType { FrameworkType = typeof(string) };
                    foreach (var operation in operationGroup.Operations)
                    {
                        var operationCs = operation.Language.CSharp;
                        //TODO: Do not default to string type
                        var responseType = (operation.Responses?.FirstOrDefault() as SchemaResponse)?.Schema.Language.CSharp?.Type ?? stringType;
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
                        var serverParameters = (httpRequest?.Servers.Where(s => s.Variables != null).SelectMany(s => s.Variables) ?? Enumerable.Empty<ServerVariable>())
                            .Select(sv => Pair(sv.Language.CSharp?.Type, sv.Language.CSharp?.Name));
                        var pipelineType = typeof(HttpPipeline);
                        var clientDiagnostics = new CSharpType { FrameworkType = pipelineType, Name = "ClientDiagnostics" };
                        var parameters = new [] { /*Pair(clientDiagnostics, "clientDiagnostics"),*/ Pair(pipelineType, "pipeline") }
                            .Concat(serverParameters)
                            .Concat((operation.Request.Parameters ?? Enumerable.Empty<Parameter>())
                                .Select(p => (Property: p, PropertyCs: p.Language.CSharp, PropertySchemaCs: p.Schema.Language.CSharp))
                                .Where(p => !(p.Property.Schema is ConstantSchema) && !(p.Property.Schema is BinarySchema) && !((p.Property.Schema as ArraySchema)?.ElementType is ConstantSchema))
                                .OrderBy(p => p.PropertyCs?.IsNullable ?? false)
                                .Select(p =>
                                {
                                    var (_, propertyCs, propertySchemaCs) = p;
                                    var pair = Pair(propertySchemaCs?.InputType ?? propertySchemaCs?.Type, propertyCs?.Name.ToVariableName(), propertyCs?.IsNullable);
                                    return (propertyCs?.IsNullable ?? false) ? $"{pair} = default" : pair;
                                }))
                            .Append($"{Pair(typeof(CancellationToken), "cancellationToken")} = default").ToArray();

                        var methodName = operationCs?.Name ?? "[NO NAME]";
                        using (Method("public static async", Type(returnType), $"{methodName}Async", parameters))
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

                            }

                            var exceptionParameter = Pair(typeof(Exception), "e");
                            using (Catch())
                            {
                                Line("//scope.Failed(e);");
                                Line("throw;");
                            }
                            Line($"throw new {exceptionText}();");
                        }
                        Line();
                    }
                }
            }
            return true;
        }
    }
}
