using Azure.Core;

namespace NamespaceForEnums
{
    [CodeGenModel("Fruit")]
    internal enum CustomFruitEnum
    {
        [CodeGenMember("apple")]
        Apple2,
        Pear
    }
}