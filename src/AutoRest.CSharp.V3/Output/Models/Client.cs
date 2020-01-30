// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class Client: ITypeProvider
    {
        public Client(TypeDeclarationOptions declaredType, string description, Parameter[] parameters, Method[] methods, Paging[] pagingMethods)
        {
            DeclaredType = declaredType;
            Parameters = parameters;
            Methods = methods;
            PagingMethods = pagingMethods;
            Description = description;
        }

        public string Description { get; }
        public Method[] Methods { get; }
        public Paging[] PagingMethods { get; }
        public TypeDeclarationOptions DeclaredType { get; }
        public Parameter[] Parameters { get; }
        public CSharpType Type => new CSharpType(this, DeclaredType.Namespace, DeclaredType.Name);
    }
}
