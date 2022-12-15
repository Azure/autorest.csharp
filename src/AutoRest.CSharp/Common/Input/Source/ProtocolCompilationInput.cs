// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ProtocolCompilationInput: CompilationInput
    {
        public ProtocolCompilationInput(Compilation compilation)
            : base(compilation, type => type.Name.EndsWith("Client"), method => method.Parameters.Length > 0 && method.Parameters.Last().Name == "context") { }
    }
}
