﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;
using AutoRest.CSharp.Output.Models;

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

        private JsonObjectSerialization? _jsonSerialization;
        public JsonObjectSerialization? JsonSerialization => HasJsonSerialization ? _jsonSerialization ??= EnsureJsonSerialization() : null;

        private XmlObjectSerialization? _xmlSerialization;
        public XmlObjectSerialization? XmlSerialization => HasXmlSerialization ? _xmlSerialization ??= EnsureXmlSerialization() : null;

        private bool? _hasJsonSerialization;
        private bool HasJsonSerialization => _hasJsonSerialization ??= EnsureHasJsonSerialization();

        private bool? _hasXmlSerialization;
        private bool HasXmlSerialization => _hasXmlSerialization ??= EnsureHasXmlSerialization();

        protected abstract bool EnsureHasJsonSerialization();
        protected abstract bool EnsureHasXmlSerialization();
        protected abstract JsonObjectSerialization? EnsureJsonSerialization();
        protected abstract XmlObjectSerialization? EnsureXmlSerialization();

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
