// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input;

internal interface IModelProperty
{
    string Name { get; }
    string SerializedName { get; }
    string Description { get; }
    IType Type { get; }
    bool IsRequired { get; }
    bool IsReadOnly { get; }
    bool IsDiscriminator { get; }
    FormattableString? DefaultValue { get; }
}
