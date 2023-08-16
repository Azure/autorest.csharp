// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class ObjectTypeConstructor
    {
        public ObjectTypeConstructor(ConstructorSignature signature, ObjectPropertyInitializer[] initializers, CSharpType type, ObjectTypeConstructor? baseConstructor = null, bool createInternal = false)
        {
            Signature = signature;
            Initializers = initializers;
            BaseConstructor = baseConstructor;
            if (createInternal)
            {

                ConstructorInitializer? newCtorInitializer = signature.Initializer;
                bool hasAdditionalProperties = signature.Parameters.Any(p => p.IsAdditionalProperties);

                if (baseConstructor is not null && baseConstructor.InternalCtor is not null)
                {
                    IEnumerable<FormattableString> currentArguments = ConstructorInitializer.ParametersToFormattableString(baseConstructor.InternalCtor.Signature.Parameters);
                    bool baseHasRawData = baseConstructor.InternalCtor.Signature.Parameters.Contains(Parameter.RawData);

                    if (hasAdditionalProperties && baseHasRawData)
                    {
                        currentArguments = currentArguments.Take(currentArguments.Count() - 1);
                        currentArguments = currentArguments.Concat(new FormattableString[] { $"default" });
                    }

                    newCtorInitializer = new ConstructorInitializer(true, currentArguments.ToArray());
                }

                IReadOnlyList<Parameter> newParameters = signature.Parameters;
                if (!hasAdditionalProperties)
                {
                    newParameters = signature.Parameters.Append(Parameter.RawData).ToArray();
                }

                ConstructorSignature newSig = new ConstructorSignature(
                    signature.Name,
                    signature.Summary,
                    signature.Description,
                    signature.Modifiers,
                    newParameters,
                    signature.Attributes,
                    newCtorInitializer);

                ObjectPropertyInitializer[] newInitializers = (baseConstructor is not null && !IsBaseSystemObjectType(type)) || hasAdditionalProperties ? initializers : initializers.Append(ObjectPropertyInitializer.RawData).ToArray();

                InternalCtor = new ObjectTypeConstructor(newSig, newInitializers, type, baseConstructor?.InternalCtor);
            }
        }

        private bool IsBaseSystemObjectType(CSharpType type)
        {
            if (!type.IsFrameworkType && type.Implementation is ObjectType objectType)
            {
                return objectType.Inherits is not null && !objectType.Inherits.IsFrameworkType && objectType.Inherits.Implementation is SystemObjectType;
            }

            return false;
        }

        public ObjectTypeConstructor(CSharpType type, MethodSignatureModifiers modifiers, Parameter[] parameters, ObjectPropertyInitializer[] initializers, ObjectTypeConstructor? baseConstructor = null, bool createInternal = false)
            : this(
                 new ConstructorSignature(
                     type.Name,
                     $"Initializes a new instance of {type}",
                     null,
                     modifiers,
                     parameters,
                     Initializer: new(isBase: true, baseConstructor?.Signature.Parameters ?? Array.Empty<Parameter>())),
                 initializers,
                 type,
                 baseConstructor,
                 createInternal)
        {
        }

        public ObjectTypeConstructor? InternalCtor { get; }
        public ConstructorSignature Signature { get; }
        public ObjectPropertyInitializer[] Initializers { get; }
        public ObjectTypeConstructor? BaseConstructor { get; }

        public ObjectTypeProperty? FindPropertyInitializedByParameter(Parameter constructorParameter)
        {
            foreach (var propertyInitializer in Initializers)
            {
                var value = propertyInitializer.Value;
                if (value.IsConstant)
                    continue;

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
