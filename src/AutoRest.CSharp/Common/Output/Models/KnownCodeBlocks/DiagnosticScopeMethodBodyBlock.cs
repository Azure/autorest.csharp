// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks
{
    internal record DiagnosticScopeMethodBodyBlock(Diagnostic Diagnostic, Reference ClientDiagnosticsReference, MethodBodyStatement InnerStatement) : MethodBodyStatement;
}
