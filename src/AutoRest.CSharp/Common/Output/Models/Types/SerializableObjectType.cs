// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Bicep;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal abstract class SerializableObjectType : ObjectType
    {
        private readonly Lazy<ModelTypeMapping?> _modelTypeMapping;

        protected SerializableObjectType(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            _modelTypeMapping = new Lazy<ModelTypeMapping?>(() => _sourceInputModel?.CreateForModel(ExistingType));
        }

        public INamedTypeSymbol? GetExistingType() => ExistingType;

        private protected ModelTypeMapping? ModelTypeMapping => _modelTypeMapping.Value;

        private bool? _includeSerializer;
        public bool IncludeSerializer => _includeSerializer ??= EnsureIncludeSerializer();

        private bool? _includeDeserializer;
        public bool IncludeDeserializer => _includeDeserializer ??= EnsureIncludeDeserializer();

        private ObjectTypeSerialization? _modelSerialization;
        public ObjectTypeSerialization Serialization => _modelSerialization ??= BuildSerialization();

        protected virtual ObjectTypeSerialization BuildSerialization()
        {
            var json = BuildJsonSerialization();
            var xml = BuildXmlSerialization();
            var bicep = BuildBicepSerialization(json);
            var multipart = BuildMultipartSerialization();
            // select interface model type here
            var modelType = IsUnknownDerivedType && Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : Type;
            var interfaces = new SerializationInterfaces(IncludeSerializer, IsStruct, modelType, json is not null, xml is not null);
            return new ObjectTypeSerialization(this, json, xml, bicep, multipart, interfaces);
        }

        protected abstract JsonObjectSerialization? BuildJsonSerialization();
        protected abstract XmlObjectSerialization? BuildXmlSerialization();
        protected abstract BicepObjectSerialization? BuildBicepSerialization(JsonObjectSerialization? json);
        protected abstract MultipartObjectSerialization? BuildMultipartSerialization();

        protected abstract bool EnsureIncludeSerializer();
        protected abstract bool EnsureIncludeDeserializer();

        public JsonConverterProvider? JsonConverter { get; protected init; }
        protected internal abstract InputModelTypeUsage GetUsage();

        // TODO -- despite this is actually a field if present, we have to make it a property to work properly with other functionalities in the generator, such as the `CodeWriter.WriteInitialization` method
        public virtual ObjectTypeProperty? RawDataField => null;

        private bool? _shouldHaveRawData;
        protected bool ShouldHaveRawData => _shouldHaveRawData ??= EnsureShouldHaveRawData();

        private bool EnsureShouldHaveRawData()
        {
            if (!Configuration.UseModelReaderWriter)
                return false;

            if (IsPropertyBag)
                return false;

            if (Inherits != null && Inherits is not { IsFrameworkType: false, Implementation: SystemObjectType })
                return false;

            return true;
        }

        protected const string PrivateAdditionalPropertiesPropertyDescription = "Keeps track of any properties unknown to the library.";
        protected const string PrivateAdditionalPropertiesPropertyName = "_serializedAdditionalRawData";
        protected const string InternalAdditionalPropertiesPropertyName = "SerializedAdditionalRawData";
        protected static readonly CSharpType _privateAdditionalPropertiesPropertyType = typeof(IDictionary<string, BinaryData>);

        protected internal SourcePropertySerializationMapping? GetForMemberSerialization(string propertyDeclaredName)
        {
            foreach (var obj in EnumerateHierarchy())
            {
                if (obj is not SerializableObjectType so)
                    continue;

                var serialization = so.ModelTypeMapping?.GetForMemberSerialization(propertyDeclaredName);
                if (serialization is not null)
                    return serialization;
            }

            return null;
        }
    }
}
