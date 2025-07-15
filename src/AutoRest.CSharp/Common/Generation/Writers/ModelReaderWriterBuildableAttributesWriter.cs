// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ModelReaderWriterBuildableAttributesWriter
    {
        private readonly HashSet<CSharpType> _processedTypes = new();
        private readonly List<CSharpType> _buildableTypes = new();

        /// <summary>
        /// Collects all IPersistableModel types and their properties recursively
        /// </summary>
        /// <param name="models">All models in the library</param>
        /// <returns>List of types that need ModelReaderWriterBuildableAttribute</returns>
        public IReadOnlyList<CSharpType> CollectBuildableTypes(IEnumerable<TypeProvider> models)
        {
            _processedTypes.Clear();
            _buildableTypes.Clear();

            foreach (var model in models)
            {
                ProcessModel(model);
            }

            return _buildableTypes;
        }

        /// <summary>
        /// Writes the ModelReaderWriterBuildableAttributes for all collected types
        /// </summary>
        /// <param name="writer">The code writer</param>
        /// <param name="buildableTypes">Types that need the attribute</param>
        public void WriteModelReaderWriterBuildableAttributes(CodeWriter writer, IReadOnlyList<CSharpType> buildableTypes)
        {
            if (!buildableTypes.Any())
                return;

            // Write using statements
            writer.Line("using System.ClientModel.Primitives;");
            writer.Line();

            // Write assembly-level attributes
            foreach (var type in buildableTypes.OrderBy(t => t.Name))
            {
                writer.Line($"[assembly: ModelReaderWriterBuildableAttribute(typeof({type}))]");
            }
        }

        private void ProcessModel(TypeProvider model)
        {
            if (model is not SerializableObjectType serializableModel)
                return;

            var modelType = serializableModel.Type;
            
            // Skip if already processed
            if (_processedTypes.Contains(modelType))
                return;

            _processedTypes.Add(modelType);

            // Check if this model implements IPersistableModel
            if (HasIPersistableModel(serializableModel))
            {
                _buildableTypes.Add(modelType);
            }

            // Process properties recursively
            foreach (var property in serializableModel.Properties)
            {
                ProcessPropertyType(property.Declaration.Type);
            }
        }

        private void ProcessPropertyType(CSharpType propertyType)
        {
            // Handle nullable types
            var actualType = propertyType.IsNullable && propertyType.IsValueType ? propertyType.Arguments[0] : propertyType;
            
            // Handle generic types (collections, etc.)
            if (actualType.IsGenericType)
            {
                foreach (var argument in actualType.Arguments)
                {
                    ProcessPropertyType(argument);
                }
            }

            // Skip if already processed
            if (_processedTypes.Contains(actualType))
                return;

            _processedTypes.Add(actualType);

            // Check if this type implements IPersistableModel
            if (ImplementsIPersistableModel(actualType))
            {
                _buildableTypes.Add(actualType);
            }
        }

        private bool HasIPersistableModel(SerializableObjectType model)
        {
            if (model.Serialization?.Interfaces == null)
                return false;

            // Check if any interface is IPersistableModel<T>
            return model.Serialization.Interfaces.Any(i => 
                i.IsGenericType && 
                i.Name.StartsWith("IPersistableModel"));
        }

        private bool ImplementsIPersistableModel(CSharpType type)
        {
            // Skip built-in types
            if (type.Namespace == "System" || type.Namespace?.StartsWith("System.") == true)
                return false;

            // Skip if not in our namespace
            if (type.Namespace != Configuration.Namespace)
                return false;

            // For generated types, we assume they implement IPersistableModel if UseModelReaderWriter is enabled
            // This is a heuristic - ideally we'd have more type information
            return Configuration.UseModelReaderWriter;
        }
    }
}