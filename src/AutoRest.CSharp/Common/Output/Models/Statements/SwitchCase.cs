// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Output.Models.Statements
{
    internal record SwitchCase(string Case, MethodBodyStatement Statement, bool Inline = false);
}
