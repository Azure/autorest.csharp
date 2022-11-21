// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

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
                _writer.WriteXmlDocumentationSummary($"Model factory for read-only models.");
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
            var model = method.ReturnType?.Implementation as SerializableObjectType;
            Debug.Assert(model != null);

            var ctor = model.SerializationConstructor;
            var initializes = new List<PropertyInitializer>();
            foreach (var parameter in method.Parameters)
            {
                (var property, var assignment) = This.GetPropertyAssignment(model, parameter);
                initializes.Add(new PropertyInitializer(property.Declaration.Name, property.Declaration.Type, property.IsReadOnly, assignment, parameter.Type));
            }

            _writer.WriteMethodDocumentation(method);
            using (_writer.WriteMethodDeclaration(method))
            {
                _writer.WriteParameterNullChecks(method.Parameters);
                _writer.WriteInitialization(v => _writer.Line($"return {v};"), model, ctor, initializes);
            }
        }
    }
}
