// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputDictionaryType(IType KeyType, IType ValueType, bool IsNullable) : InputType("Dictionary", IsNullable), IDictionaryType
{
    public IType KeyType { get; set; } = KeyType;
    public IType ValueType { get; set; } = ValueType;
}
