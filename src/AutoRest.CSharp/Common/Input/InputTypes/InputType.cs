// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.X509Certificates;

namespace AutoRest.CSharp.Common.Input;

internal abstract record InputType(string Name, bool IsNullable, string? OriginalName = default)
{
    internal InputType GetCollectionEquivalent(InputType inputType)
    {
        switch (this)
        {
            case InputListType listType:
                return new InputListType(
                    listType.Name,
                    listType.ElementType.GetCollectionEquivalent(inputType),
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

    public string Name { get; internal set; } = Name;

    public string? OriginalName { get; internal set; } = OriginalName;
}
