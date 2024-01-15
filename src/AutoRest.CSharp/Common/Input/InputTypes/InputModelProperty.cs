// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input;

internal record InputModelProperty(string Name, string SerializedName, string Description, IType Type, bool IsRequired, bool IsReadOnly, bool IsDiscriminator) : IModelProperty
{
    public IType Type { get; internal set; } = Type;
    public FormattableString? DefaultValue { get; init; }
}
