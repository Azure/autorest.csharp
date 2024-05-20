// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal abstract record InputType
{
    protected InputType(string name, bool isNullable)
    {
        Name = name;
        SpecName = name;
        IsNullable = isNullable;
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
                    listType.IsEmbeddingsVector,
                    listType.IsNullable);
            case InputDictionaryType dictionaryType:
                return new InputDictionaryType(
                    dictionaryType.Name,
                    dictionaryType.KeyType,
                    dictionaryType.ValueType.GetCollectionEquivalent(inputType),
                    dictionaryType.IsNullable);
            default:
                return inputType;
        }
    }

    public bool IsNullable { get; init; }
    public string Name { get; internal set; }
    public string? SpecName { get; init; }
}
