// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectTypeConstructor
    {
        public ObjectTypeConstructor(ConstructorSignature signature, ObjectPropertyInitializer[] initializers, ObjectTypeConstructor? baseConstructor = null)
        {
            Signature = signature;
            Initializers = initializers;
            BaseConstructor = baseConstructor;
        }

        public ObjectTypeConstructor(CSharpType type, MethodSignatureModifiers modifiers, Parameter[] parameters, ObjectPropertyInitializer[] initializers, ObjectTypeConstructor? baseConstructor = null)
            : this(
                 new ConstructorSignature(
                     type,
                     $"Initializes a new instance of {type.Name}",
                     null,
                     modifiers,
                     parameters,
                     Initializer: new(isBase: true, baseConstructor?.Signature.Parameters ?? Array.Empty<Parameter>())),
                 initializers,
                 baseConstructor)
        {
        }

        public ConstructorSignature Signature { get; }
        public ObjectPropertyInitializer[] Initializers { get; }
        public ObjectTypeConstructor? BaseConstructor { get; }

        public ObjectTypeProperty? FindPropertyInitializedByParameter(Parameter constructorParameter)
        {
            foreach (var propertyInitializer in Initializers)
            {
                if (propertyInitializer.Value is ParameterReference pe && pe.Parameter.Name == constructorParameter.Name)
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
                    if (propertyInitializer.Value is not ParameterReference parameterReference)
                    {
                        continue;
                    }

                    return Signature.Parameters.Single(p => p.Name == parameterReference.Parameter.Name);
                }
            }

            return BaseConstructor?.FindParameterByInitializedProperty(property);
        }
    }
}
