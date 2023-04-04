// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Statements;

namespace AutoRest.CSharp.Output.Models
{
    internal record Method(MethodSignature Signature, IReadOnlyList<MethodBodyStatement> Body);
}
