// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    // TODO -- eventually we should combine everything in this class into TypeProvider
    internal abstract class ExpressionTypeProvider : TypeProvider
    {
        protected ExpressionTypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
        }

        private IReadOnlyList<string>? _usings;
        public IReadOnlyList<string> Usings => _usings ??= BuildUsings().ToArray();

        protected virtual IEnumerable<string> BuildUsings()
        {
            yield break;
        }

        public virtual CSharpType? Inherits { get; protected init; }

        private IReadOnlyList<CSharpType>? _implements;
        public virtual IReadOnlyList<CSharpType> Implements => _implements ??= BuildImplements().ToArray();

        private IReadOnlyList<PropertyDeclaration>? _properties;
        public virtual IReadOnlyList<PropertyDeclaration> Properties => _properties ??= BuildProperties().ToArray();

        private IReadOnlyList<Method>? _methods;
        public IReadOnlyList<Method> Methods => _methods ??= BuildMethods().ToArray();

        private IReadOnlyList<Method>? _constructors;
        public IReadOnlyList<Method> Constructors => _constructors ??= BuildConstructors().ToArray();

        private IReadOnlyList<MethodBodyStatement>? _fields;
        public IReadOnlyList<MethodBodyStatement> Fields => _fields ??= BuildFields().ToArray();

        protected virtual IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield break;
        }

        protected virtual IEnumerable<MethodBodyStatement> BuildFields()
        {
            yield break;
        }

        protected virtual IEnumerable<CSharpType> BuildImplements()
        {
            yield break;
        }

        protected virtual IEnumerable<Method> BuildMethods()
        {
            yield break;
        }

        protected virtual IEnumerable<Method> BuildConstructors()
        {
            yield break;
        }
    }
}
