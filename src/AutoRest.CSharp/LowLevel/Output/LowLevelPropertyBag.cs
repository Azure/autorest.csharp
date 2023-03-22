// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Output.Models
{
    /// <summary>
    /// Represent a property bag of convenience method parameters (excluding `WaitUntil` and `CancellationToken`).
    /// </summary>
    internal class LowLevelPropertyBag : PropertyBag
    {
        /// <summary>
        /// Constructor of the <see cref="LowLevelPropertyBag">LowLevelPropertyBag</see>.
        /// </summary>
        /// <param baseName="baseName">Base name to be used to generate the name of the property bag class</param>
        /// <param baseName="rootNamespace">Root namespace of the whole SDK</param>
        /// <param baseName="paramsToKeep">Parameters to be wrapped</param>
        /// <param baseName="typeFactory">A <see cref="TypeFactory">TypeFactory</see> instance</param>
        /// <param baseName="inputParameters">A list of <see cref="InputParameter">InputParameter</see> of the protocol method. Note that it does not contain spread parameters.</param>
        /// <param baseName="spreadBackingModel">Optional spread model if there is spread parameter.</param>
        /// <param baseName="sourceInputModel">Optional source input model for customization codes.</param>
        public LowLevelPropertyBag(string baseName, string rootNamespace, IEnumerable<Parameter> paramsToKeep, TypeFactory typeFactory, IEnumerable<InputParameter> inputParameters, ModelTypeProvider? spreadBackingModel, SourceInputModel? sourceInputModel)
            : base(baseName)
        {
            _rootNamespace = rootNamespace;
            _paramsToKeep = paramsToKeep;
            _typeFactory = typeFactory;
            _inputParameters = inputParameters;
            _spreadBackingModel = spreadBackingModel;
            _sourceInputModel = sourceInputModel;
        }

        private string _rootNamespace;
        private IEnumerable<InputParameter> _inputParameters;
        private IEnumerable<Parameter> _paramsToKeep;
        private readonly TypeFactory _typeFactory;
        private readonly ModelTypeProvider? _spreadBackingModel;
        private readonly SourceInputModel? _sourceInputModel;

        public IEnumerable<Parameter> Parameters => _paramsToKeep;

        protected override TypeProvider EnsurePackModel()
        {
            var packModelName = $"{Name}Options";

            var properties = new List<InputModelProperty>();
            foreach (var parameter in _paramsToKeep)
            {
                properties.Add(new InputModelProperty(
                    Name: parameter.Name,
                    SerializedName: null,
                    Description: parameter.Description ?? $"The {parameter.Name}",
                    Type: GetInputTypeForParameter(parameter),
                    IsRequired: parameter.DefaultValue == null,
                    IsReadOnly: false,
                    IsDiscriminator: false,
                    DefaultValue: GetDefaultValue(parameter)));
            }

            var propertyBagModel = new InputModelType(
                Name: packModelName,
                Namespace: _rootNamespace,
                Accessibility: "public",
                Deprecated: null,
                Description: $"The {packModelName}.",
                Usage: InputModelTypeUsage.Input,
                Properties: properties,
                BaseModel: null,
                DerivedModels: Array.Empty<InputModelType>(),
                DiscriminatorValue: null,
                DiscriminatorPropertyName: null,
                IsPropertyBag: true);;
            return new ModelTypeProvider(propertyBagModel, _rootNamespace, _sourceInputModel, _typeFactory);
        }

        protected override bool EnsureShouldValidateParameter()
        {
            return ((ModelTypeProvider)PackModel).Properties.Any(p => p.IsRequired);
        }

        protected override Parameter EnsurePackParameter()
        {
            return new Parameter(
                Name: "options",
                Description: "A property bag which contains all the parameters of this method except the LRO qualifier and cancellation token parameter.",
                Type: TypeFactory.GetInputType(PackModel.Type),
                DefaultValue: null,
                Validation: ShouldValidateParameter ? ValidationType.AssertNotNull : ValidationType.None,
                Initializer: ShouldValidateParameter ? (FormattableString?)null : $"new {PackModel.Type.Name}()",
                IsPropertyBag: true);
        }

        /// <summary>
        /// Try to get intput type for given parameter.
        /// First, try to get the type from input parameters.
        /// If not found, then try to get it from spread parameters.
        /// </summary>
        /// <param baseName="parameter"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private InputType GetInputTypeForParameter(Parameter parameter)
        {
            var inputParameter = _inputParameters.FirstOrDefault(p => string.Equals(p.Name, parameter.Name, StringComparison.OrdinalIgnoreCase));
            if (inputParameter != null)
            {
                return inputParameter.Type;
            }

            if (_spreadBackingModel != null)
            {
                var field = _spreadBackingModel.Fields.GetFieldByParameter(parameter);
                if (field != null)
                {
                    return _spreadBackingModel.Fields.GetInputByField(field).Type;
                }
            };

            throw new InvalidOperationException($"Cannot find input type for parameter {parameter.Name}");
        }

        private FormattableString? GetDefaultValue(Parameter parameter)
        {
            if (parameter.DefaultValue != null)
            {
                return parameter.DefaultValue?.GetConstantFormattable();
            }
            return null;
        }
    }
}
