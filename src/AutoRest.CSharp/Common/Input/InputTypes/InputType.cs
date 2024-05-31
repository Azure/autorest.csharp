// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input.InputTypes;

namespace AutoRest.CSharp.Common.Input;

internal abstract record InputType
{
    protected InputType(string name)
    {
        Name = name;
        SpecName = name;
        //IsNullable = isNullable;
    }

    public InputTypeSerialization Serialization { get; init; } = InputTypeSerialization.Default;

    internal InputType GetCollectionEquivalent(InputType inputType)
    {
        switch (this)
        {
            case InputListType listType:
                return new InputListType(
                    listType.Name,
                    listType.ElementType.GetCollectionEquivalent(inputType),
                    listType.IsEmbeddingsVector);
            case InputDictionaryType dictionaryType:
                return new InputDictionaryType(
                    dictionaryType.Name,
                    dictionaryType.KeyType,
                    dictionaryType.ValueType.GetCollectionEquivalent(inputType));
            default:
                return inputType;
        }
    }

    //public bool IsNullable { get; init; }
    public string Name { get; internal set; }
    //TODO: Remove this until the SDK nullable is enabled, traking in https://github.com/Azure/autorest.csharp/issues/4780
    internal string? SpecName { get; init; }

    public InputType WithNullable(bool isNullable)
    {
        if (isNullable)
            return new InputNullableType(this);
        return this;
    }
}
