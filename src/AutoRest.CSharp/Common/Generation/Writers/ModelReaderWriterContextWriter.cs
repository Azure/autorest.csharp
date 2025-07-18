// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
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

        public void Write(CodeWriter writer, IEnumerable<TypeProvider>? models = null)
        {
            IReadOnlyList<CSharpType>? buildableTypes = null;

            // Collect buildable types if using ModelReaderWriter and models are provided
            if (Configuration.UseModelReaderWriter && models != null)
            {
                buildableTypes = CollectBuildableTypes(models);
            }

            // Write using statements if buildable types are provided
            if (buildableTypes != null && buildableTypes.Any())
            {
                writer.Line($"using System.ClientModel.Primitives;");
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
        /// Collects all IPersistableModel types and their properties recursively.
        /// Algorithm similar to ModelReaderWriterContextDefinition.CollectBuildableTypes from TypeSpec.
        /// </summary>
        /// <param name="models">All models in the library</param>
        /// <returns>List of types that need ModelReaderWriterBuildableAttribute</returns>
        private IReadOnlyList<CSharpType> CollectBuildableTypes(IEnumerable<TypeProvider> models)
        {
            _processedTypes.Clear();
            _buildableTypes.Clear();

            foreach (var model in models.OfType<SerializableObjectType>())
            {
                ProcessModel(model);
            }

            return _buildableTypes.Distinct().OrderBy(t => t.Name).ToList();
        }

        private void ProcessModel(SerializableObjectType model)
        {
            var modelType = model.Type;

            // Skip if already processed
            if (_processedTypes.Contains(modelType))
                return;

            _processedTypes.Add(modelType);

            // Check if this model implements IPersistableModel
            if (HasIPersistableModel(model))
            {
                _buildableTypes.Add(modelType);
            }

            // Process properties recursively to find their types
            foreach (var property in model.Properties)
            {
                ProcessPropertyType(property.Declaration.Type);
            }
        }

        private void ProcessPropertyType(CSharpType propertyType)
        {
            // Handle nullable types - get the underlying type
            var actualType = propertyType.IsNullable && propertyType.IsValueType ? propertyType.Arguments[0] : propertyType;

            // Handle generic types (collections, lists, dictionaries, etc.)
            if (actualType.IsGenericType)
            {
                // Process all generic type arguments recursively
                foreach (var argument in actualType.Arguments)
                {
                    ProcessPropertyType(argument);
                }
            }

            // Process the type itself if it's in our namespace (could be a generated model)
            if (IsGeneratedType(actualType))
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

            // For generated types that support IPersistableModel
            if (ImplementsIPersistableModel(type))
            {
                _buildableTypes.Add(type);
            }
        }

        private bool HasIPersistableModel(SerializableObjectType model)
        {
            var interfaces = model.Serialization?.Interfaces;
            if (interfaces == null)
                return false;

            // Check if the model has IPersistableModel<T> or IPersistableModel<object> interfaces
            return interfaces.IPersistableModelTInterface != null || interfaces.IPersistableModelObjectInterface != null;
        }

        private bool IsGeneratedType(CSharpType type)
        {
            // Types in our namespace are typically generated models
            return type.Namespace == Configuration.Namespace;
        }

        private bool ImplementsIPersistableModel(CSharpType type)
        {
            // Skip built-in types and system types
            if (type.Namespace == "System" || type.Namespace?.StartsWith("System.") == true)
                return false;

            // Skip types not in our namespace (they're not our generated models)
            if (type.Namespace != Configuration.Namespace)
                return false;

            // For types in our namespace, if UseModelReaderWriter is enabled,
            // they likely implement IPersistableModel (this is a reasonable heuristic)
            return Configuration.UseModelReaderWriter;
        }

        public static string Name => $"{Configuration.Namespace.RemovePeriods()}Context";
    }
}
