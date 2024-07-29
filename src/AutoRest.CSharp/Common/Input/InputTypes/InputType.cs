// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input.InputTypes;

namespace AutoRest.CSharp.Common.Input;

internal abstract record InputType: InputDecoratedType
{
    protected InputType(string name, IReadOnlyList<InputDecoratorInfo> decorators) : base(decorators)
    {
        Name = name;
        SpecName = name;
    }

    public InputTypeSerialization Serialization { get; init; } = InputTypeSerialization.Default;

    internal InputType GetCollectionEquivalent(InputType inputType)
    {
        switch (this)
        {
            case InputListType listType:
                return new InputListType(
                    listType.Name,
                    listType.CrossLanguageDefinitionId,
                    listType.ValueType.GetCollectionEquivalent(inputType),
                    listType.Decorators);
            case InputDictionaryType dictionaryType:
                return new InputDictionaryType(
                    dictionaryType.Name,
                    dictionaryType.KeyType,
                    dictionaryType.ValueType.GetCollectionEquivalent(inputType),
                    dictionaryType.Decorators);
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
            return new InputNullableType(this, this.Decorators);
        return this;
    }
    public InputType GetImplementType() => this switch
    {
        InputNullableType nullableType => nullableType.Type,
        _ => this
    };
}
