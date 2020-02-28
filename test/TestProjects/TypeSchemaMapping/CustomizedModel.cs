using AnotherCustomNamespace;
using Azure.Core;

namespace CustomNamespace
{
    [CodeGenSchema("Model")]
    internal partial class CustomizedModel
    {
        [CodeGenSchemaMember("ModelProperty")]
        internal string CustomizedStringProperty { get; set; }

        [CodeGenSchemaMember("Fruit")]
        internal CustomFruitEnum CustomizedFancyField;
    }
}
