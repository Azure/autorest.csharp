// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.Extensions;
using Newtonsoft.Json;
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp.Model
{
    public class ParameterCs : Parameter
    {
        public ParameterCs()
        {
            Name.OnGet += value => IsClientProperty ? true == Method?.Group.IsNullOrEmpty() ? $"this.{ClientProperty.Name}" : $"this.Client.{ClientProperty.Name}" : CodeNamer.Instance.GetParameterName(value);
        }
        /// <summary>
        /// Gets True if parameter can call .Validate method
        /// </summary>
        [JsonIgnore]
        public virtual bool CanBeValidated => Singleton<GeneratorSettingsCs>.Instance.ClientSideValidation;

        [JsonIgnore]
        public override string ModelTypeName => ModelType.AsNullableType(this.IsNullable());

        [JsonIgnore]
        public string HeaderCollectionPrefix => Extensions.GetValue<string>(SwaggerExtensions.HeaderCollectionPrefix);
        [JsonIgnore]
        public bool IsHeaderCollection => !string.IsNullOrEmpty(HeaderCollectionPrefix);

        /// <summary>
        /// Gets or sets the model type.
        /// </summary>
        public override IModelType ModelType
        {
            get
            {
                if (base.ModelType == null || !this.IsHeaderCollection)
                {
                    return base.ModelType;
                }
                return new DictionaryTypeCs { ValueType = base.ModelType, CodeModel = base.ModelType.CodeModel, SupportsAdditionalProperties = false };
            }
            set
            {
                base.ModelType = value;
            }
        }
    }
}