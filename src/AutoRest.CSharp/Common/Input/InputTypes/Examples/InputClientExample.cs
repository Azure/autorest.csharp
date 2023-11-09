// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.Examples
{
    /// <summary>
    /// Set of client parameter sample values of a specific type
    /// </summary>
    /// <param name="Key">Type of a sample. E.g.: short version sample, all parameters sample, etc.</param>
    /// <param name="ClientParameters">Sample values for client-level parameters</param>
    internal record InputClientExample(string Key, IReadOnlyList<InputParameterExample> ClientParameters, string? OriginalFile = default);
}
