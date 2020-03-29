using Azure.Core;

namespace CustomNamespace
{
    [CodeGenModel("Model")]
    internal partial class CustomizedModel: BaseClassForCustomizedModel
    {
        // overrides auto-generated default ctor
        public CustomizedModel()
        {
        }

        [CodeGenMember("ModelProperty")]
        internal int? CustomizedStringProperty { get; set; }
    }
}
