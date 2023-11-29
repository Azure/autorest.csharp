// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConstructorInitializer(bool IsBase, ValueExpression[] Arguments)
    {
        public ConstructorInitializer(bool isBase, IEnumerable<Parameter> arguments) : this(isBase, arguments.Select(p => (ValueExpression)p).ToArray()) { }

        public ConstructorInitializer(bool isBase, IEnumerable<Reference> arguments) : this(isBase, arguments.Select(r => (ValueExpression)r).ToArray()) { }
    }
}
