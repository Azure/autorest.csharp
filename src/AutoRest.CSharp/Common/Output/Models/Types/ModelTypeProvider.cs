// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
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

        public ModelTypeProvider(InputModelType inputModel, TypeFactory typeFactory, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(inputModel.Namespace ?? defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory;

            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            Fields = CreateFields(inputModel).ToArray();
            PublicConstructor = BuildPublicConstructor(inputModel);
        }

        private IEnumerable<FieldDeclaration> CreateFields(InputModelType inputModel)
        {
            foreach (var property in inputModel.Properties)
            {
                var fieldModifiers = property.IsReadOnly || property.Type is InputDictionaryType or InputListType
                    ? Public | ReadOnly
                    : Public;

                yield return new FieldDeclaration($"{property.Description}", fieldModifiers, _typeFactory.CreateType(property.Type), property.Name.FirstCharToUpperCase(), writeAsProperty: true);
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
