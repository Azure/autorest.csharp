// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Generation.Writers
{
    internal class ModelReaderWriterContextWriter
    {
        public void Write(CodeWriter writer, IEnumerable<TypeProvider>? models = null)
        {
            IEnumerable<CSharpType>? buildableTypes = null;

            // Collect buildable types if using ModelReaderWriter and models are provided
            if (Configuration.UseModelReaderWriter && models != null)
            {
                buildableTypes = CollectBuildableTypes(models);
            }

            using (writer.Namespace($"{Configuration.Namespace}"))
            {
                writer.Line($"/// <summary>");
                writer.Line($"/// Context class which will be filled in by the System.ClientModel.SourceGeneration.");
                writer.Line($"/// For more information see 'https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md'");
                writer.Line($"/// </summary>");

                // Write class-level attributes if buildable types are provided
                if (buildableTypes != null)
                {
                    foreach (var type in buildableTypes)
                    {
                        if (IsObsolete(type))
                        {
                            writer.Line($"#pragma warning disable CS0618 // Type or member is obsolete");
                            writer.Line($"[{typeof(ModelReaderWriterBuildableAttribute)}(typeof({type}))]");
                            writer.Line($"#pragma warning disable CS0618 // Type or member is obsolete");
                        }
                        else
                        {
                            writer.Line($"[{typeof(ModelReaderWriterBuildableAttribute)}(typeof({type}))]");
                        }
                    }
                }

                using (writer.Scope($"public partial class {Name} : {typeof(ModelReaderWriterContext)}"))
                {
                }
            }
        }

        private static bool IsObsolete(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                return type.FrameworkType.GetCustomAttributes().Any(a => a.GetType() == typeof(ObsoleteAttribute));
            }
            else
            {
                return type.Implementation.IsObsolete();
            }
        }

        /// <summary>
        /// Collects all IPersistableModel types and their properties recursively.
        /// Algorithm similar to ModelReaderWriterContextDefinition.CollectBuildableTypes from TypeSpec.
        /// </summary>
        /// <param name="models">All models in the library</param>
        /// <returns>List of types that need ModelReaderWriterBuildableAttribute</returns>
        private IEnumerable<CSharpType> CollectBuildableTypes(IEnumerable<TypeProvider> models)
        {
            var buildableTypes = new HashSet<CSharpType>(new CSharpTypeNameComparer());
            var visitedTypes = new HashSet<CSharpType>(new CSharpTypeNameComparer());

            // for all Resource types, just add them directly to buildableTypes
            foreach (var resource in models.OfType<Resource>())
            {
                buildableTypes.Add(resource.Type);
            }

            var modelDictionary = models.OfType<SerializableObjectType>().ToDictionary(m => m.Type, m => m);

            foreach (var model in modelDictionary.Values)
            {
                ProcessModel(model.Type, visitedTypes, buildableTypes, modelDictionary);
            }

            return buildableTypes.OrderBy(m => m.Name);
        }

        private void ProcessModel(CSharpType type, HashSet<CSharpType> visitedTypes, HashSet<CSharpType> buildableTypes, Dictionary<CSharpType, SerializableObjectType> modelDictionary)
        {
            // Skip if already processed
            if (visitedTypes.Contains(type))
                return;


            visitedTypes.Add(type);

            // Check if this model implements IJsonmodel or IPersistableModel
            if (ImplementsIPersistableModel(type, modelDictionary, out var model))
            {
                buildableTypes.Add(type);

                if (model is null)
                {
                    return;
                }

                // Process properties recursively to find their types
                foreach (var property in model.Properties)
                {
                    var propertyType = property.Declaration.Type.IsCollection ? GetInnerMostElement(property.Declaration.Type) : property.Declaration.Type;
                    ProcessModel(propertyType, visitedTypes, buildableTypes, modelDictionary);
                }

                var baseModels = model.EnumerateHierarchy().Skip(1).ToList();
                foreach (var baseModel in baseModels)
                {
                    // Process base model properties recursively
                    if (baseModel is SystemObjectType || baseModel is SerializableObjectType)
                    {
                        foreach (var baseProperty in baseModel.Properties)
                        {
                            var basePropertyType = baseProperty.Declaration.Type.IsCollection ? GetInnerMostElement(baseProperty.Declaration.Type) : baseProperty.Declaration.Type;
                            ProcessModel(basePropertyType, visitedTypes, buildableTypes, modelDictionary);
                        }
                    }
                }
            }
        }

        private CSharpType GetInnerMostElement(CSharpType type)
        {
            var result = type.ElementType;
            while (result.IsCollection)
            {
                result = result.ElementType;
            }
            return result;
        }

        private bool ImplementsIPersistableModel(CSharpType type, Dictionary<CSharpType, SerializableObjectType> modelDictionary, out SerializableObjectType? model)
        {
            if (modelDictionary.TryGetValue(type, out model))
            {
                return true;
            }

            // If the type is SystemObjectType, it should always implement IPersistableModel or IJsonModel
            if (!type.IsFrameworkType && type.Implementation is SystemObjectType)
            {
                return true;
            }

            if (!type.IsFrameworkType || type.IsEnum || type.IsLiteral)
                return false;

            return type.FrameworkType.GetInterfaces().Any(i => i.Name == "IPersistableModel`1" || i.Name == "IJsonModel`1");
        }

        public static string Name => $"{Configuration.Namespace.RemovePeriods()}Context";

        private class CSharpTypeNameComparer : IEqualityComparer<CSharpType>
        {
            public bool Equals(CSharpType? x, CSharpType? y)
            {
                if (x is null && y is null)
                {
                    return true;
                }
                if (x is null || y is null)
                {
                    return false;
                }
                return x.Namespace == y.Namespace && x.Name == y.Name;
            }

            public int GetHashCode(CSharpType obj)
            {
                HashCode hashCode = new HashCode();
                hashCode.Add(obj.Namespace);
                hashCode.Add(obj.Name);
                return hashCode.ToHashCode();
            }
        }
    }
}
