// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CustomizationsInTsp.Models;

public partial class OutputModelWithReadWriteProperty
{
    /// <summary> Read-write property that is changed to readonly. </summary>
    public string PropertyReadWriteToReadOnly { get; }
}
