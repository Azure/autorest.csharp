﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public OperationSource(CSharpType returnType, Resource? resource, Schema schema)
        {
            ReturnType = returnType;
            TypeName = $"{(resource != null ? resource.ResourceName : returnType.Name)}OperationSource";
            Interface = new CSharpType(typeof(IOperationSource<>), returnType);
            Resource = resource;
            ArmClientField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ArmClient), "_client");
            ArmClientCtor = new ConstructorSignature(TypeName, null, Internal, new[] { MgmtTypeProvider.ArmClientParameter });
            var serializationType = resource is null ? ReturnType : resource.Type.Equals(returnType) ? resource.ResourceData.Type : ReturnType;
            ResponseSerialization = new SerializationBuilder().Build(KnownMediaType.Json, schema, serializationType);
        }

        public CSharpType ReturnType { get; }
        public CSharpType Interface { get; }
        public Resource? Resource { get; }
        public FieldDeclaration ArmClientField { get; }
        public ConstructorSignature ArmClientCtor { get; }
        public string TypeName { get; }
        public ObjectSerialization ResponseSerialization { get; }
    }
}
