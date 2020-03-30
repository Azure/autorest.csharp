using NamespaceForEnums;
using Azure.Core;

namespace CustomNamespace
{
    internal class BaseClassForCustomizedModel
    {
        [CodeGenMember("Fruit")]
        internal CustomFruitEnum CustomizedFancyField;
    }
}