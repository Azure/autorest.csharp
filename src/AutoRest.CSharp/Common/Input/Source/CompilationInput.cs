// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public abstract class CompilationInput
    {
        protected Compilation _compilation;

        public CompilationInput(Compilation compilation)
        {
            _compilation= compilation;
        }

        public abstract void FilterSymbols();
    }
}
