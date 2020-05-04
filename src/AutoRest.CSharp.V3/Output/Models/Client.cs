// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class Client: ITypeProvider
    {
        public Client(TypeDeclarationOptions declaredType, string description, RestClient restClient, ClientMethod[] methods, PagingMethod[] pagingMethods, LongRunningOperationMethod[] longRunningOperationMethods)
        {
            DeclaredType = declaredType;
            Description = description;
            RestClient = restClient;
            Methods = methods;
            PagingMethods = pagingMethods;
            LongRunningOperationMethods = longRunningOperationMethods;
        }

        public TypeDeclarationOptions DeclaredType { get; }
        public string Description { get; }
        public RestClient RestClient { get; }
        public ClientMethod[] Methods { get; }
        public PagingMethod[] PagingMethods { get; }
        public LongRunningOperationMethod[] LongRunningOperationMethods { get; }
        public CSharpType Type => new CSharpType(this, DeclaredType.Namespace, DeclaredType.Name);
    }
}