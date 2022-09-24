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
        public OperationSource(CSharpType returnType, Resource? resource, Schema schema)
        {
            ReturnType = returnType;
            TypeName = $"{(resource != null ? resource.ResourceName : returnType.Name)}OperationSource";
            Interface = new CSharpType(typeof(IOperationSource<>), returnType);
            Resource = resource;
            ResourceData = resource?.ResourceData;
            ArmClientField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ArmClient), "_client");
            ArmClientCtor = new ConstructorSignature(TypeName, null, null, Internal, new[] { MgmtTypeProvider.ArmClientParameter });
            ResponseSerialization = new SerializationBuilder().Build(KnownMediaType.Json, schema, GetSerializationType(returnType, resource));
        }

        public bool IsReturningResource => !ReturnType.IsFrameworkType && ReturnType.Implementation is Resource;

        /// <summary>
        /// Because our serialization only support a limited list of TypeProviders (Resource is not supported), we need to ensure the CSharpType we returned here has an implementation of a valid type provider
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        private static CSharpType GetSerializationType(CSharpType returnType, Resource? resource)
        {
            if (resource != null)
                return resource.ResourceData.Type;

            return returnType;
        }

        public CSharpType ReturnType { get; }
        public CSharpType Interface { get; }
        public Resource? Resource { get; }
        public ResourceData? ResourceData { get; }
        public FieldDeclaration ArmClientField { get; }
        public ConstructorSignature ArmClientCtor { get; }
        public string TypeName { get; }
        public ObjectSerialization ResponseSerialization { get; }
    }
}
