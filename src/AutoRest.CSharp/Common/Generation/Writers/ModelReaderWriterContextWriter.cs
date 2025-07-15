// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class ModelReaderWriterContextWriter
    {
        private readonly HashSet<CSharpType> _processedTypes = new();
        private readonly List<CSharpType> _buildableTypes = new();

        public void Write(CodeWriter writer, IEnumerable<TypeProvider> models = null)
        {
            IReadOnlyList<CSharpType> buildableTypes = null;
            
            // Collect buildable types if using ModelReaderWriter and models are provided
            if (Configuration.UseModelReaderWriter && models != null)
            {
                buildableTypes = CollectBuildableTypes(models);
            }

            // Write using statements if buildable types are provided
            if (buildableTypes != null && buildableTypes.Any())
            {
                writer.Line("using System.ClientModel.Primitives;");
                writer.Line();
            }

            using (writer.Namespace($"{Configuration.Namespace}"))
            {
                writer.Line($"/// <summary>");
                writer.Line($"/// Context class which will be filled in by the System.ClientModel.SourceGeneration.");
                writer.Line($"/// For more information see 'https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md'");
                writer.Line($"/// </summary>");
                
                // Write class-level attributes if buildable types are provided
                if (buildableTypes != null && buildableTypes.Any())
                {
                    foreach (var type in buildableTypes.OrderBy(t => t.Name))
                    {
                        writer.Line($"[ModelReaderWriterBuildableAttribute(typeof({type}))]");
                    }
                }
                
                using (writer.Scope($"public partial class {Name} : {typeof(ModelReaderWriterContext)}"))
                {
                }
            }
        }

        /// <summary>
        /// Collects all IPersistableModel types and their properties recursively
        /// </summary>
        /// <param name="models">All models in the library</param>
        /// <returns>List of types that need ModelReaderWriterBuildableAttribute</returns>
        private IReadOnlyList<CSharpType> CollectBuildableTypes(IEnumerable<TypeProvider> models)
        {
            _processedTypes.Clear();
            _buildableTypes.Clear();

            foreach (var model in models)
            {
                ProcessModel(model);
            }

            return _buildableTypes;
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
                // Also process the generic type itself if it's in our namespace
                if (actualType.Namespace == Configuration.Namespace)
                {
                    ProcessSingleType(actualType);
                }
            }
            else
            {
                ProcessSingleType(actualType);
            }
        }

        private void ProcessSingleType(CSharpType type)
        {
            // Skip if already processed
            if (_processedTypes.Contains(type))
                return;

            _processedTypes.Add(type);

            // Check if this type implements IPersistableModel
            if (ImplementsIPersistableModel(type))
            {
                _buildableTypes.Add(type);
            }
        }

        private bool HasIPersistableModel(SerializableObjectType model)
        {
            if (model.Serialization?.Interfaces == null)
                return false;

            // Check if any interface is IPersistableModel<T>
            return model.Serialization.Interfaces.Any(i => 
                i.IsGenericType && 
                (i.Name.StartsWith("IPersistableModel") || 
                 i.ToString().Contains("IPersistableModel")));
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

        public static string Name => $"{Configuration.Namespace.RemovePeriods()}Context";
    }
}
