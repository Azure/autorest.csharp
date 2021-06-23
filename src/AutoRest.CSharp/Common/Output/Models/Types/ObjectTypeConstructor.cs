// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectTypeConstructor
    {
        public ObjectTypeConstructor(string name, string modifiers, Parameter[] parameters, ObjectPropertyInitializer[] initializers, ObjectTypeConstructor? baseConstructor = null)
        {
            Signature = new MethodSignature(
                name,
                $"Initializes a new instance of {name}",
                modifiers,
                null,
                parameters,
                baseConstructor?.Signature);

            Initializers = initializers;
            BaseConstructor = baseConstructor;
        }

        public MethodSignature Signature { get; }
        public ObjectPropertyInitializer[] Initializers { get; }
        public ObjectTypeConstructor? BaseConstructor { get; }

        public ObjectTypeProperty? FindPropertyInitializedByParameter(Parameter constructorParameter)
        {
            foreach (var propertyInitializer in Initializers)
            {
                var value = propertyInitializer.Value;
                if (value.IsConstant) continue;

                if (value.Reference.Name == constructorParameter.Name)
                {
                    return propertyInitializer.Property;
                }
            }

            return BaseConstructor?.FindPropertyInitializedByParameter(constructorParameter);
        }

        public Parameter? FindParameterByInitializedProperty(ObjectTypeProperty property)
        {
            foreach (var propertyInitializer in Initializers)
            {
                if (propertyInitializer.Property == property)
                {
                    if (propertyInitializer.Value.IsConstant)
                    {
                        continue;
                    }

                    var parameterName = propertyInitializer.Value.Reference.Name;
                    return Signature.Parameters.Single(p => p.Name == parameterName);
                }
            }

            return BaseConstructor?.FindParameterByInitializedProperty(property);
        }
    }
}
