// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : TypeProvider
    {
        private readonly TypeFactory _typeFactory;

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        public IReadOnlyList<FieldDeclaration> Fields { get; }
        public ConstructorSignature PublicConstructor { get; }
        public JsonSerialization Serialization { get; }

        public ModelTypeProvider(InputModelType inputModel, TypeFactory typeFactory, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory;

            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            Fields = CreateFields(inputModel, typeFactory).ToArray();
            PublicConstructor = BuildPublicConstructor(inputModel);
            Serialization = new JsonObjectSerialization(new CSharpType(this), CreateProperties(inputModel, Fields).ToArray(), null, false);
        }

        private IEnumerable<JsonPropertySerialization> CreateProperties(InputModelType inputModel, IReadOnlyList<FieldDeclaration> fields)
        {
            for (var index = 0; index < inputModel.Properties.Count; index++)
            {
                var property = inputModel.Properties[index];
                var field = fields[index];
                var optionalViaNullability = !property.IsRequired && !field.Type.IsNullable && !TypeFactory.IsCollectionType(field.Type);
                var valueSerialization = new JsonValueSerialization(field.Type, SerializationFormat.Default, field.Type.IsNullable);

                yield return new JsonPropertySerialization(field.Declaration.RequestedName, property.SerializedName ?? property.Name, field.Type, field.Type, valueSerialization, property.IsRequired, property.IsReadOnly, optionalViaNullability);
            }
        }

        private static IEnumerable<FieldDeclaration> CreateFields(InputModelType inputModel, TypeFactory typeFactory)
        {
            foreach (var property in inputModel.Properties)
            {
                var fieldModifiers = property.IsReadOnly || property.Type is InputDictionaryType or InputListType
                    ? Public | ReadOnly
                    : Public;

                yield return new FieldDeclaration($"{property.Description}", fieldModifiers, typeFactory.CreateType(property.Type), property.Name.FirstCharToUpperCase(), writeAsProperty: true);
            }
        }

        private ConstructorSignature BuildPublicConstructor(InputModelType inputModel)
        {
            var parameters = inputModel.Properties
                .Where(p => p.IsReadOnly || p.Type is InputDictionaryType or InputListType)
                .Select(p => Parameter.FromModelProperty(p, _typeFactory))
                .ToList();

            return new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, MethodSignatureModifiers.Public, parameters);
        }
    }
}
