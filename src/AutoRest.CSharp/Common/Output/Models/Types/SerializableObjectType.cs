﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

        private bool? _includeSerializer;
        public bool IncludeSerializer => _includeSerializer ??= EnsureIncludeSerializer();

        private bool? _includeDeserializer;
        public bool IncludeDeserializer => _includeDeserializer ??= EnsureIncludeDeserializer();

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
        protected abstract bool EnsureIncludeSerializer();
        protected abstract bool EnsureIncludeDeserializer();
        protected abstract JsonObjectSerialization? EnsureJsonSerialization();
        protected abstract XmlObjectSerialization? EnsureXmlSerialization();
    }
}
