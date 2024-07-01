// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputListType(string Name, InputType ValueType) : InputType(Name)
{
    public InputListType(string name, InputType valueType, bool isEmbeddingsVector) : this(name, valueType)
    {
        IsEmbeddingsVector = isEmbeddingsVector;
    }

    public bool IsEmbeddingsVector { get; }
}
