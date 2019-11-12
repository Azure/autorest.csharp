using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Pipeline.Generated;
using Azure;

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
                    foreach (var operation in operationGroup.Operations)
                    {
                        var opcs = operation.Language.CSharp;
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
                        using (Method("public static async", Type(returnType), opcs?.Name ?? "[NO NAME]"))
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
