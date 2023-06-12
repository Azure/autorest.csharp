// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

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

        public virtual bool IsPropertyBag => false;

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

        private ConstructorSignature? _publicConstructor;
        private ConstructorSignature? _serializationConstructor;
        protected ConstructorSignature InitializationConstructorSignature => _publicConstructor ??= EnsurePublicConstructorSignature();
        protected ConstructorSignature SerializationConstructorSignature => _serializationConstructor ??= EnsureSerializationConstructorSignature();

        /// <summary>
        /// A flag to control if we need to skip the initialization constructor to support forward compatibility in polymorphism
        /// </summary>
        protected virtual bool SkipInitializerConstructor => false;

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            // Skip initialization ctor if this instance is used to support forward compatibility in polymorphism.
            if (!SkipInitializerConstructor)
                yield return InitializationConstructor;

            // Skip serialization ctor if they are the same
            if (InitializationConstructor != SerializationConstructor)
                yield return SerializationConstructor;
        }

        protected abstract ConstructorSignature EnsurePublicConstructorSignature();
        protected abstract ConstructorSignature EnsureSerializationConstructorSignature();

        protected abstract ObjectPropertyInitializer[] GetPropertyInitializers(IReadOnlyList<Parameter> parameters, bool includeDiscriminator);

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.InitializationConstructor;

            return new ObjectTypeConstructor(InitializationConstructorSignature, GetPropertyInitializers(InitializationConstructorSignature.Parameters, true), baseCtor);
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor()
        {
            if (IsPropertyBag)
                return InitializationConstructor;

            // verifies the serialization ctor has the same parameter list as the public one, we return the initialization ctor
            if (!SerializationConstructorSignature.Parameters.Any(p => TypeFactory.IsList(p.Type)) && InitializationConstructorSignature.Parameters.SequenceEqual(SerializationConstructorSignature.Parameters, Parameter.EqualityComparerByType))
                return InitializationConstructor;

            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.SerializationConstructor;

            return new ObjectTypeConstructor(SerializationConstructorSignature, GetPropertyInitializers(SerializationConstructorSignature.Parameters, false), baseCtor);
        }

        protected abstract void GetConstructorParameters(IEnumerable<Parameter> parameters, out List<Parameter> fullParameterList, out IEnumerable<Parameter> parametersToPassToBase, bool isInitializer, Func<Parameter, Parameter> creator);
    }
}
