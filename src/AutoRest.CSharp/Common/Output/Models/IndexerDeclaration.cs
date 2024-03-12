// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal record IndexerDeclaration(FormattableString? Description, MethodSignatureModifiers Modifiers, CSharpType PropertyType, string Name, Parameter IndexerParameter, PropertyBody PropertyBody, IReadOnlyDictionary<CSharpType, FormattableString>? Exceptions = null)
        : PropertyDeclaration(Description, Modifiers, PropertyType, Name, PropertyBody, Exceptions);
}
