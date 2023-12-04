// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    // TODO -- eventually we should be able to move this class to a more common place, or just combine everything in this class into TypeProvider
    internal abstract class ExpressionTypeProvider : TypeProvider
    {
        protected ExpressionTypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
        }

        private IEnumerable<string>? _usings;
        public IEnumerable<string> Usings => _usings ??= BuildUsings();

        protected virtual IEnumerable<string> BuildUsings()
        {
            yield break;
        }

        public virtual CSharpType? Inherits => null;

        private IEnumerable<CSharpType>? _implements;
        public virtual IEnumerable<CSharpType> Implements => _implements ??= BuildImplements();

        private IEnumerable<Method>? _methods;
        public IEnumerable<Method> Methods => _methods ??= BuildMethods();

        private IEnumerable<Method>? _constructors;
        public IEnumerable<Method> Constructors => _constructors ??= BuildConstructors();

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
