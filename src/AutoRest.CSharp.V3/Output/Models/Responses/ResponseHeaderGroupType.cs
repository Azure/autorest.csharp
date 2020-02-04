// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class ResponseHeaderGroupType: ITypeProvider
    {
        public ResponseHeaderGroupType(TypeDeclarationOptions declaration, string description, ResponseHeader[] headers)
        {
            Declaration = declaration;
            Headers = headers;
            Description = description;
        }

        public string Description { get; }
        public TypeDeclarationOptions Declaration { get; }
        public ResponseHeader[] Headers { get; }
        public CSharpType Type => new CSharpType(this, Declaration.Namespace, Declaration.Name);
    }
}
