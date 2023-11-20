// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Common.Output.Models
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal record PropertyDeclaration(FormattableString? Description, MethodSignatureModifiers Modifiers, CSharpType PropertyType, CodeWriterDeclaration Declaration, PropertyAccessorMethod Get, PropertyAccessorMethod? Set = null, ValueExpression? InitializationValue = null)
    {
        public PropertyDeclaration(FormattableString? description, MethodSignatureModifiers modifiers, CSharpType propertyType, string name, PropertyAccessorMethod get, PropertyAccessorMethod? set = null, ValueExpression? initializationValue = null) : this(description, modifiers, propertyType, new CodeWriterDeclaration(name), get, set, initializationValue)
        {
            Declaration.SetActualName(name);
        }

        private string GetDebuggerDisplay()
        {
            using var writer = new DebuggerCodeWriter();
            writer.WriteProperty(this);
            return writer.ToString();
        }
    }
}
