// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputListType(string Name, InputType ValueType, bool IsNullable) : InputType(Name, IsNullable)
{
    public InputListType(string name, InputType valueType, bool isEmbeddingsVector, bool isNullable) : this(name, valueType, isNullable)
    {
        IsEmbeddingsVector = isEmbeddingsVector;
    }

    public bool IsEmbeddingsVector { get; }
}
