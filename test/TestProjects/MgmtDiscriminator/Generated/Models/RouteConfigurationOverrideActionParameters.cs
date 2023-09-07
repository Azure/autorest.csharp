// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the route configuration override action. </summary>
    public partial class RouteConfigurationOverrideActionParameters
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="RouteConfigurationOverrideActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        public RouteConfigurationOverrideActionParameters(RouteConfigurationOverrideActionParametersTypeName typeName)
        {
            TypeName = typeName;
        }

        /// <summary> Initializes a new instance of <see cref="RouteConfigurationOverrideActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="originGroupOverride"> A reference to the origin group override configuration. Leave empty to use the default origin group on route. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RouteConfigurationOverrideActionParameters(RouteConfigurationOverrideActionParametersTypeName typeName, OriginGroupOverride originGroupOverride, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TypeName = typeName;
            OriginGroupOverride = originGroupOverride;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RouteConfigurationOverrideActionParameters"/> for deserialization. </summary>
        internal RouteConfigurationOverrideActionParameters()
        {
        }

        /// <summary> Gets or sets the type name. </summary>
        public RouteConfigurationOverrideActionParametersTypeName TypeName { get; set; }
        /// <summary> A reference to the origin group override configuration. Leave empty to use the default origin group on route. </summary>
        public OriginGroupOverride OriginGroupOverride { get; set; }
    }
}
