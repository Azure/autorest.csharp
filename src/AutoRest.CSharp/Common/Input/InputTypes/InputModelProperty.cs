// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputModelProperty(string Name, string? SerializedName, string Description, InputType Type, bool IsRequired, bool IsReadOnly, bool IsDiscriminator)
{
    public InputConstant? DefaultValue { get; init; }
}
