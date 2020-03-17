using Azure.Core;

namespace CustomNamespace
{
    [CodeGenSchema("Model")]
    internal partial class CustomizedModel: BaseClassForCustomizedModel
    {
        // overrides auto-generated default ctor
        public CustomizedModel()
        {
        }

        [CodeGenSchemaMember("ModelProperty")]
        internal string CustomizedStringProperty { get; set; }
    }
}
