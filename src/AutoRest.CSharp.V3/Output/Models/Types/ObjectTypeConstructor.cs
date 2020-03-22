// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.V3.Output.Models.Shared;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeConstructor
    {
        public ObjectTypeConstructor(MemberDeclarationOptions declaration, Parameter[] parameters, ObjectPropertyInitializer[] initializers, ObjectTypeConstructor? baseConstructor = null)
        {
            Declaration = declaration;
            Parameters = parameters;
            Initializers = initializers;
            BaseConstructor = baseConstructor;
        }

        public MemberDeclarationOptions Declaration { get; }
        public Parameter[] Parameters { get; }
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
    }
}