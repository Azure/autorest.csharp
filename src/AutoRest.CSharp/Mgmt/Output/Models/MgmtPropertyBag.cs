// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output.Models
{
    internal class MgmtPropertyBag : PropertyBag
    {
        public MgmtPropertyBag(string name, InputOperation operation, IEnumerable<Parameter> paramsToKeep)
            : base(name)
        {
            _operation = operation;
            _paramsToKeep = paramsToKeep;
        }

        private readonly InputOperation _operation;

        private readonly IEnumerable<Parameter> _paramsToKeep;

        protected override TypeProvider EnsurePackModel()
        {
            var packModelName = string.IsNullOrEmpty(Name)
                ? throw new InvalidOperationException("Not enough information is provided for constructing management plane property bag, please make sure you first call the WithUpdatedInfo method of MgmtPropertyBag to update the property bag before using it.") :
                $"{Name}Options";

            var properties = new List<InputModelProperty>();
            foreach (var parameter in _paramsToKeep)
            {
                var inputParameter = _operation.Parameters.FirstOrDefault(p => string.Equals(p.Name, parameter.Name, StringComparison.OrdinalIgnoreCase));
                var description = parameter.Description?.ToString() ?? $"The {parameter.Name}";
                var property = new InputModelProperty(parameter.Name, parameter.Name, description, inputParameter!.Type, parameter.DefaultValue == null ? null : inputParameter.DefaultValue, parameter.DefaultValue == null, false, false);
                properties.Add(property);
            }
            var defaultNamespace = $"{MgmtContext.Context.DefaultNamespace}.Models";
            var propertyBagModel = new InputModelType(
                packModelName,
                defaultNamespace,
                "public",
                null,
                $"The {packModelName}.",
                InputModelTypeUsage.Input,
                properties,
                null,
                Array.Empty<InputModelType>(),
                null,
                null,
                null,
                false)
            {
                IsPropertyBag = true
            };
            return new ModelTypeProvider(propertyBagModel, defaultNamespace, MgmtContext.Context.SourceInputModel, MgmtContext.Context.Library.TypeFactory);
        }

        protected override bool EnsureShouldValidateParameter()
        {
            if (PackModel is ModelTypeProvider mgmtPackModel)
            {
                return mgmtPackModel.Properties.Any(p => p.IsRequired);
            }
            return false;
        }
    }
}
