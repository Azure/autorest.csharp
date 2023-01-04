﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output.Models
{
    internal class MgmtPropertyBag : PropertyBag
    {
        public MgmtPropertyBag(string name, InputOperation operation)
            : base(name)
        {
            _operation = operation;
            _paramsToKeep = Array.Empty<Parameter>();
        }

        private MgmtPropertyBag(string name, InputOperation operation, IEnumerable<Parameter> paramsToKeep)
            : this(name, operation)
        {
            _paramsToKeep = paramsToKeep;
        }

        public MgmtPropertyBag WithUpdatedInfo(string name, IEnumerable<Parameter> paramsToKeep) =>
            new MgmtPropertyBag(name, _operation, paramsToKeep);

        private InputOperation _operation;

        private IEnumerable<Parameter> _paramsToKeep;

        protected override TypeProvider EnsurePackModel()
        {
            var packModelName = string.IsNullOrEmpty(Name) ?
            throw new InvalidOperationException("Not enough information is provided for constructing management plane property bag, please make sure you first call the WithUpdatedInfo method of MgmtPropertyBag to update the property bag before using it.") :
            $"{Name}Options";
            var properties = new List<InputModelProperty>();
            foreach (var parameter in _paramsToKeep)
            {
                var inputParameter = _operation.Parameters.FirstOrDefault(p => string.Equals(p.Name, parameter.Name, StringComparison.OrdinalIgnoreCase));
                string? description = parameter.Description;
                if (description == null)
                    description = $"The {parameter.Name}";
                var property = new InputModelProperty(parameter.Name, null, description, inputParameter.Type, parameter.DefaultValue == null, IsReadOnly(parameter), false, GetDefaultValue(parameter));
                properties.Add(property);
            }
            var defaultNamespace = $"{MgmtContext.Context.DefaultNamespace}.Models";
            var propertyBagModel = new InputModelType(
                packModelName,
                defaultNamespace,
                "public",
                $"The {packModelName}.",
                InputModelTypeUsage.None,
                properties,
                null,
                Array.Empty<InputModelType>(),
                null,
                null,
                false,
                true);
            return new ModelTypeProvider(propertyBagModel, defaultNamespace, MgmtContext.Context.SourceInputModel, MgmtContext.Context.TypeFactory);
            ;
        }

        protected override bool EnsureShouldValidateParameter()
        {
            if (PackModel is ModelTypeProvider mgmtPackModel)
            {
                return mgmtPackModel.Properties.Any(p => p.IsRequired);
            }
            return false;
        }

        private bool IsReadOnly(Parameter parameter)
        {
            if (TypeFactory.IsCollectionType(parameter.Type))
            {
                return true;
            }
            return false;
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
