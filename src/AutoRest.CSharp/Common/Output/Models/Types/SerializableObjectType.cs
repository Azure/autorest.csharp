// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal abstract class SerializableObjectType : ObjectType
    {
        protected SerializableObjectType(BuildContext context) : base(context)
        {
        }
        protected SerializableObjectType(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
        }

        public INamedTypeSymbol? GetExistingType() => ExistingType;

        private bool _jsonSerializationInitialized = false;
        private JsonObjectSerialization? _jsonSerialization;
        public JsonObjectSerialization? JsonSerialization => EnsureJsonSerialization();

        private bool _xmlSerializationInitialized = false;
        private XmlObjectSerialization? _xmlSerialization;
        public XmlObjectSerialization? XmlSerialization => EnsureXmlSerialization();

        private JsonObjectSerialization? EnsureJsonSerialization()
        {
            if (_jsonSerializationInitialized)
                return _jsonSerialization;

            _jsonSerializationInitialized = true;
            _jsonSerialization = BuildJsonSerialization();
            return _jsonSerialization;
        }

        private XmlObjectSerialization? EnsureXmlSerialization()
        {
            if (_xmlSerializationInitialized)
                return _xmlSerialization;

            _xmlSerializationInitialized = true;
            _xmlSerialization = BuildXmlSerialization();
            return _xmlSerialization;
        }

        protected abstract JsonObjectSerialization? BuildJsonSerialization();
        protected abstract XmlObjectSerialization? BuildXmlSerialization();

        // TODO -- despite this is actually a field if present, we have to make it a property to work properly with other functionalities in the generator, such as the `CodeWriter.WriteInitialization` method
        public virtual ObjectTypeProperty? RawDataField => null;

        private bool? _shouldHaveRawData;
        protected bool ShouldHaveRawData => _shouldHaveRawData ??= EnsureShouldHaveRawData();

        private bool EnsureShouldHaveRawData()
        {
            if (IsPropertyBag)
                return false;

            if (Inherits != null && Inherits is not { IsFrameworkType: false, Implementation: SystemObjectType })
                return false;

            return true;
        }

        protected readonly string _privateAdditionalPropertiesPropertyDescription = "Keeps track of any properties unknown to the library.";
        protected readonly string _privateAdditionalPropertiesPropertyName = "_serializedAdditionalRawData";
        protected readonly CSharpType _privateAdditionalPropertiesPropertyType = new CSharpType(typeof(IDictionary<,>), typeof(string), typeof(BinaryData));
    }
}
