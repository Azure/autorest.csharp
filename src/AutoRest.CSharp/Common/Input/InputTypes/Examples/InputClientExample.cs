// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using System.Linq;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal record InputClientExample(InputClient Client, IReadOnlyList<InputOperationExample> Operations, IReadOnlyList<InputParameterExample> Parameters);
}
