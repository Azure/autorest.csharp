// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal record InputOperationExample(string Name, string? Description, string FilePath, IReadOnlyList<InputParameterExample> Parameters, IReadOnlyList<OperationResponseExample> Responses);
}
