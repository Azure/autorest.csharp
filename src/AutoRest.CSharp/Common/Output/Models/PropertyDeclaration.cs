// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal record PropertyDeclaration(FormattableString? Description, FieldModifiers Modifiers, CSharpType PropertyType, string Name, ValueExpression? InitializationValue, FieldModifiers? Get = null, FieldModifiers? Set = null)
    {
    }
}
