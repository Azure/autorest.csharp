using AnotherCustomNamespace;
using Azure.Core;

namespace CustomNamespace
{
    internal class BaseClassForCustomizedModel
    {
        [CodeGenSchemaMember("Fruit")]
        internal CustomFruitEnum CustomizedFancyField;
    }
}