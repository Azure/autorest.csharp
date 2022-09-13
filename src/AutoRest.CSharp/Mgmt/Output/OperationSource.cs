// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using Azure.Core;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class OperationSource
    {
        public OperationSource(CSharpType returnType, MgmtTypeProvider? provider, Schema schema)
        {
            ReturnType = returnType;
            TypeName = $"{(provider != null ? provider.ResourceName : returnType.Name)}OperationSource";
            Interface = new CSharpType(typeof(IOperationSource<>), returnType);
            Resource = provider;
            ResourceData = GetResourceData(provider);
            ArmClientField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ArmClient), "_client");
            ArmClientCtor = new ConstructorSignature(TypeName, null, null, Internal, new[] { MgmtTypeProvider.ArmClientParameter });
            ResponseSerialization = new SerializationBuilder().Build(KnownMediaType.Json, schema, GetSerializationType(ReturnType, provider));
        }

        public bool IsReturningResource => !ReturnType.IsFrameworkType && (ReturnType.Implementation is Resource || ReturnType.Implementation is BaseResource);

        private static ResourceData? GetResourceData(MgmtTypeProvider? provider)
        {
            if (provider is Resource resource)
                return resource.ResourceData;

            if (provider is BaseResource baseResource)
                return baseResource.ResourceData;

            return null;
        }

        private static CSharpType GetSerializationType(CSharpType returnType, MgmtTypeProvider? provider)
        {
            if (provider == null)
                return returnType;

            if (provider is Resource resource && resource.Type.Equals(returnType))
                return resource.ResourceData.Type;

            if (provider is BaseResource baseResource && baseResource.Type.Equals(returnType))
                return baseResource.ResourceData.Type;

            return returnType;
        }

        public CSharpType ReturnType { get; }
        public CSharpType Interface { get; }
        public MgmtTypeProvider? Resource { get; }
        public ResourceData? ResourceData { get; }
        public FieldDeclaration ArmClientField { get; }
        public ConstructorSignature ArmClientCtor { get; }
        public string TypeName { get; }
        public ObjectSerialization ResponseSerialization { get; }
    }
}
