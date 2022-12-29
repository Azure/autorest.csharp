// Copyright (c) Microsoft Corporation. All rights reserved.
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
using AutoRest.CSharp.Input;
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
            _paramNamesToKeep = Array.Empty<string>();
        }

        private MgmtPropertyBag(string name, InputOperation operation, IEnumerable<string> paramNamesToKeep)
            : this(name, operation)
        {
            _paramNamesToKeep = paramNamesToKeep;
        }

        public MgmtPropertyBag WithUpdatedInfo(string name, IEnumerable<string> paramNamesToKeep) =>
            new MgmtPropertyBag(name, _operation, paramNamesToKeep);

        private InputOperation _operation;

        private IEnumerable<string> _paramNamesToKeep;

        protected override TypeProvider EnsurePackModel()
        {
            var packModelName = string.IsNullOrEmpty(Name) ?
            throw new InvalidOperationException("Not enough information is provided for constructing management plane property bag, please make sure you first call the WithUpdatedInfo method of MgmtPropertyBag to update the property bag before using it.") :
            $"{Name}Options";
        var properties = new List<Property>();
            var parameters = _operation.Parameters.Where(p => _paramNamesToKeep.Contains(p.Name, StringComparer.OrdinalIgnoreCase));
            foreach (var parameter in parameters)
            {
                var propertySchema = parameter.Schema;
                var format = TypeFactory.GetXMsFormatType(parameter.Type);
                if (parameter.Schema is StringSchema s && format != null)
                {
                    // some parameters might share one string schema, but have different x-ms-format
                    // therefore we use deep clone here to avoid generating the wrong parameter type
                    propertySchema = DeepClone(s);
                    propertySchema.Extensions = new RecordOfStringAndAny { { "x-ms-format", format } };
                }
                var property = new Property
                {
                    Schema = propertySchema,
                    Language = new Languages
                    {
                        Default = new Language
                        {
                            Name = parameter.Name,
                            Description = parameter.Description
                        }
                    },
                    ReadOnly = false,
                    Required = parameter.DefaultValue == null
                };
                properties.Add(property);
            }
            var schema = new ObjectSchema
            {
                Extensions = new RecordOfStringAndAny { { "x-csharp-usage", "model,input" }, { "x-accessibility", "public" } },
                ApiVersions = new Collection<ApiVersion> { parameters.FirstOrDefault().Schema.ApiVersions.FirstOrDefault() },
                Properties = properties,
                Language = new Languages
                {
                    Default = new Language
                    {
                        Name = packModelName,
                        Description = $"The {packModelName}."
                    }
                }
            };
            return new MgmtObjectType(schema);
        }

        protected override bool EnsureShouldValidateParameter()
        {
            if (PackModel is MgmtObjectType mgmtPackModel)
            {
                return mgmtPackModel.Properties.Any(p => p.IsRequired);
            }
            return false;
        }

        private static T DeepClone<T>(T source)
        {
            return BinaryData.FromObjectAsJson<T>(source).ToObjectFromJson<T>();
        }
    }
}
