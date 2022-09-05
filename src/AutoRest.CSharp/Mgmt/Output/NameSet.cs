// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Pipeline;
using static Azure.Core.HttpHeader;

internal readonly struct NameSet
{
    //public string DiagnosticField { get; }
    public FieldDeclaration DiagnosticFieldDeclaration { get; }
    public string DiagnosticProperty { get; }
    //public string RestField { get; }
    public FieldDeclaration RestFieldDeclaration { get; }
    public string RestProperty { get; }
    public string ApiVersionVariable { get; }

    public NameSet(string diagField, string diagProperty, string restField, string restProperty, string apiVariable, FieldModifiers fieldModifiers, CSharpType restClientType)
    {
        //DiagnosticField = diagField;
        DiagnosticFieldDeclaration = new FieldDeclaration(fieldModifiers, typeof(ClientDiagnostics), diagField);
        DiagnosticProperty = diagProperty;
        //RestField = restField;
        RestFieldDeclaration = new FieldDeclaration(fieldModifiers, restClientType, restField);
        RestProperty = restProperty;
        ApiVersionVariable = apiVariable;
    }
}
