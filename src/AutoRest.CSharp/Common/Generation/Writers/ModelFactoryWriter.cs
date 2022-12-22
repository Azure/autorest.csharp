// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ModelFactoryWriter
    {
        protected CodeWriter _writer;
        private ModelFactoryTypeProvider This { get; }

        public ModelFactoryWriter(ModelFactoryTypeProvider modelFactoryProvider) : this(new CodeWriter(), modelFactoryProvider)
        {
        }

        public ModelFactoryWriter(CodeWriter writer, ModelFactoryTypeProvider modelFactoryProvider)
        {
            _writer = writer;
            This = modelFactoryProvider;
        }

        public void Write()
        {
            using (_writer.Namespace(This.Type.Namespace))
            {
                _writer.WriteXmlDocumentationSummary(This.Description);
                using (_writer.Scope($"{This.Declaration.Accessibility} static partial class {This.Type:D}"))
                {
                    foreach (var method in This.Methods)
                    {
                        WriteFactoryMethod(method);
                        _writer.Line();
                    }
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }

        public void WriteModelFactory()
        {
            using (_writer.Namespace(This.Type.Namespace))
            {
                _writer.WriteXmlDocumentationSummary($"Model factory for read-only models.");
                using (_writer.Scope($"{This.Declaration.Accessibility} static partial class {This.Type.Name}"))
                {
                    foreach (var method in This.Methods)
                    {
                        WriteFactoryMethod(method);
                        _writer.Line();
                    }
                }
            }
        }

        private void WriteFactoryMethod(MethodSignature method)
        {
            if (!method.ReturnType!.TryCast<SerializableObjectType>(out var model))
            {
                // this should be impossible
                throw new InvalidOperationException($"The return type {method.ReturnType} of method {method.Name} is not a SerializableObjectType, this should never happen");
            }

            var ctor = model.SerializationConstructor;
            var initializes = new List<PropertyInitializer>();
            foreach (var parameter in method.Parameters)
            {
                (var property, var assignment) = This.GetPropertyAssignment(_writer, model, parameter);
                initializes.Add(new PropertyInitializer(property.Declaration.Name, property.Declaration.Type, property.IsReadOnly, assignment, parameter.Type));
            }

            if (!Configuration.ModelFactoryForHlc && model.Discriminator is ObjectTypeDiscriminator discriminator)
            {
                if (discriminator.Value is Constant discriminatorValue)
                {
                    var property = discriminator.Property;
                    initializes.Add(new PropertyInitializer(property.Declaration.Name, property.Declaration.Type, property.IsReadOnly, $"{GetRawEnumValue(discriminatorValue):L}"));
                }
                else if (model.Declaration.IsAbstract)
                {
                    model = (SerializableObjectType)discriminator.DefaultObjectType!;
                    ctor = model.SerializationConstructor;
                }
            }

            _writer.WriteMethodDocumentation(method);
            using (_writer.WriteMethodDeclaration(method))
            {
                _writer.WriteParameterNullChecks(method.Parameters);
                _writer.WriteInitialization(v => _writer.Line($"return {v};"), model, ctor, initializes);
            }
        }

        private static object? GetRawEnumValue(Constant constant) => constant.Value switch
        {
            Constant anotherConstant => GetRawEnumValue(anotherConstant),
            EnumTypeValue enumValue => GetRawEnumValue(enumValue.Value),
            _ => constant.Value
        };
    }
}
