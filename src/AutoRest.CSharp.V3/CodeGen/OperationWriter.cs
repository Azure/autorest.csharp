using AutoRest.CSharp.V3.Pipeline.Generated;

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
                using (Class(null, "static", cs?.Name)) { }
            }
            return true;
        }
    }
}
