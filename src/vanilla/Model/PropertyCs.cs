// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.Extensions;
using Newtonsoft.Json;
using static AutoRest.Core.Utilities.DependencyInjection;

namespace AutoRest.CSharp.Model
{
    public class PropertyCs : Property
    {
        [JsonIgnore]
        public override string ModelTypeName => ModelType.AsNullableType(this.IsNullable());

        [JsonIgnore]
        public string HeaderCollectionPrefix => Extensions.GetValue<string>(SwaggerExtensions.HeaderCollectionPrefix);
        [JsonIgnore]
        public bool IsHeaderCollection => !string.IsNullOrEmpty(HeaderCollectionPrefix);

        // not spec compliant
        [JsonProperty("useDefaultInConstructor")]
        public bool UseDefaultInConstructor { get; set; } = Singleton<GeneratorSettingsCs>.Instance.UseDefaultInConstructor;

        [JsonIgnore]
        /// <summary>
        /// Whether the property is required from a code(r) point of view.
        /// </summary>
        public bool IsEffectivelyRequired => IsRequired && (!UseDefaultInConstructor || DefaultValue == null) && !IsConstant;

        [JsonIgnore]
        public IEnumerable<string> JsonConverters
        {
            get
            {
                switch ((ModelType as PrimaryType)?.KnownPrimaryType)
                {
                    case KnownPrimaryType.Date:
                        yield return "Microsoft.Rest.Serialization.DateJsonConverter";
                        break;
                    case KnownPrimaryType.DateTimeRfc1123:
                        yield return "Microsoft.Rest.Serialization.DateTimeRfc1123JsonConverter";
                        break;
                    case KnownPrimaryType.Base64Url:
                        yield return "Microsoft.Rest.Serialization.Base64UrlJsonConverter";
                        break;
                    case KnownPrimaryType.UnixTime:
                        yield return "Microsoft.Rest.Serialization.UnixTimeJsonConverter";
                        break;
                }
            }
        }
    }
}