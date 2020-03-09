using Azure.Core;

namespace NamespaceForEnums
{
    [CodeGenSchema("Fruit")]
    internal enum CustomFruitEnum
    {
        [CodeGenSchemaMember("apple")]
        Apple2,
        Pear
    }
}