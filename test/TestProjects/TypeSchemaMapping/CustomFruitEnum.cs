using Azure.Core;

namespace AnotherCustomNamespace
{
    [CodeGenSchema("Fruit")]
    internal partial struct CustomFruitEnum
    {
        [CodeGenSchemaMember("Apple")]
        public static CustomFruitEnum WhatAnApple { get; } = new CustomFruitEnum(AppleValue);
    }
}