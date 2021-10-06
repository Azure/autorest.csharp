// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal static class ParameterExtensions
    {
        public static FormattableString GetNamesForMethodCall(this Parameter[] parameters)
            => parameters.Length switch
            {
                0 => $"",
                1 => $"{parameters[0].Name:I}",
                _ => $"{parameters.Skip(1).Select(p => (FormattableString)$", {p.Name:I}").Prepend((FormattableString)$"{parameters[0].Name:I}")}"
            };
    }
}
