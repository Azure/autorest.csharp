// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.LowLevel.Output
{
    // TODO -- eventually we should be able to move this class to a more common place, or just combine everything in this class into TypeProvider
    internal abstract class ExpressionTypeProvider : TypeProvider
    {
        protected ExpressionTypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
        }

        private IEnumerable<string>? _usings;
        public IEnumerable<string> Usings => _usings ??= EnsureUsings();

        protected virtual IEnumerable<string> EnsureUsings()
        {
            yield break;
        }

        public virtual CSharpType? Inherits => null;

        private IEnumerable<CSharpType>? _implements;
        public virtual IEnumerable<CSharpType> Implements => _implements ??= EnsureImplements();

        private IEnumerable<Method>? _methods;
        public IEnumerable<Method> Methods => _methods ??= EnsureMethods();

        private IEnumerable<Method>? _constructors;
        public IEnumerable<Method> Constructors => _constructors ??= EnsureConstructors();

        protected virtual IEnumerable<CSharpType> EnsureImplements()
        {
            yield break;
        }

        protected virtual IEnumerable<Method> EnsureMethods()
        {
            yield break;
        }

        protected virtual IEnumerable<Method> EnsureConstructors()
        {
            yield break;
        }
    }
}
