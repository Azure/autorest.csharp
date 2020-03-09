using Azure.Core;

namespace CustomNamespace
{
    [CodeGenSchema("Model")]
    internal partial class CustomizedModel: BaseClassForCustomizedModel
    {
        [CodeGenSchemaMember("ModelProperty")]
        internal string CustomizedStringProperty { get; set; }
    }
}
