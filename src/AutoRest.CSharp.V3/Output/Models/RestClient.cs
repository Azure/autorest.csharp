// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class RestClient: ITypeProvider
    {
        public RestClient(TypeDeclarationOptions declaredType, string description, Parameter[] parameters, RestClientMethod[] methods)
        {
            DeclaredType = declaredType;
            Parameters = parameters;
            Methods = methods;
            Description = description;
        }

        public string Description { get; }
        public RestClientMethod[] Methods { get; }
        public TypeDeclarationOptions DeclaredType { get; }
        public Parameter[] Parameters { get; }
        public CSharpType Type => new CSharpType(this, DeclaredType.Namespace, DeclaredType.Name);
    }
}
