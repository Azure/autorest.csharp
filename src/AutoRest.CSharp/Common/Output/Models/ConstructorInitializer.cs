// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConstructorInitializer(bool IsBase, FormattableString[] Arguments)
    {
        public ConstructorInitializer(bool isBase, IEnumerable<Parameter> arguments) : this(isBase, ParametersToFormattableString(arguments).ToArray()) { }

        public ConstructorInitializer(bool isBase, IEnumerable<Reference> arguments) : this(isBase, arguments.Select(r => FormattableStringFactory.Create("{0:I}", r.Name)).ToArray()) { }

        public static IEnumerable<FormattableString> ParametersToFormattableString(IEnumerable<Parameter> parameters) => parameters.Select(p => FormattableStringFactory.Create("{0:I}", p.Name));
    }
}
