// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class ObjectType : TypeProvider
    {
        private ObjectTypeConstructor[]? _constructors;
        private ObjectTypeProperty[]? _properties;
        private CSharpType? _inheritsType;
        private ObjectTypeConstructor? _serializationConstructor;
        private ObjectTypeConstructor? _initializationConstructor;

        protected ObjectType(BuildContext context) : base(context)
        {
        }

        public ObjectTypeConstructor[] Constructors => _constructors ??= BuildConstructors().ToArray();
        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();

        public CSharpType? Inherits => _inheritsType ??= CreateInheritedType();
        public ObjectTypeConstructor SerializationConstructor => _serializationConstructor ??= BuildSerializationConstructor();

        public ObjectTypeConstructor InitializationConstructor => _initializationConstructor ??= BuildInitializationConstructor();
        public string? Description { get; protected set; }
        public abstract ObjectTypeProperty? AdditionalPropertiesProperty { get; }
        protected abstract ObjectTypeConstructor BuildInitializationConstructor();
        protected abstract ObjectTypeConstructor BuildSerializationConstructor();
        protected abstract CSharpType? CreateInheritedType();
        protected abstract IEnumerable<ObjectTypeProperty> BuildProperties();

        public IEnumerable<ObjectType> EnumerateHierarchy()
        {
            ObjectType? type = this;
            while (type != null)
            {
                yield return type;

                if (type.Inherits?.IsFrameworkType == false && type.Inherits.Implementation is ObjectType o)
                {
                    type = o;
                }
                else
                {
                    type = null;
                }
            }
        }

        protected abstract IEnumerable<ObjectTypeConstructor> BuildConstructors();

        protected ObjectTypeConstructor? GetBaseCtor()
        {
            if (Inherits != null && !Inherits.IsFrameworkType && Inherits.Implementation is ObjectType objectType)
            {
                return objectType.Constructors.First();
            }
            return null;
        }
    }
}
