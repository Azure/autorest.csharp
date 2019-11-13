using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using Azure;
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
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class(null, "static", cs?.Name))
                {
                    var exceptionText = Type(typeof(Exception));
                    var stringType = new CSharpType { FrameworkType = typeof(string) };
                    foreach (var operation in operationGroup.Operations)
                    {
                        var operationCs = operation.Language.CSharp;
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

                        var pipelineType = typeof(HttpPipeline);
                        //var clientDiagnostics = new CSharpType { FrameworkType = pipelineType, Name = "ClientDiagnostics" };
                        var parameters = new [] { /*Pair(clientDiagnostics, "clientDiagnostics"),*/ Pair(pipelineType, "pipeline") }
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

                        using (Method("public static async", Type(returnType), operationCs?.Name ?? "[NO NAME]", parameters))
                        {
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
