// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

public interface IDictionaryType : IType
{
    IType KeyType { get; }
    IType ValueType { get; }
}
