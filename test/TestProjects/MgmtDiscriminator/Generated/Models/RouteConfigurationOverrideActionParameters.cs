// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the route configuration override action. </summary>
    public partial class RouteConfigurationOverrideActionParameters
    {
        /// <summary> Initializes a new instance of RouteConfigurationOverrideActionParameters. </summary>
        /// <param name="typeName"></param>
        public RouteConfigurationOverrideActionParameters(RouteConfigurationOverrideActionParametersTypeName typeName)
        {
            TypeName = typeName;
        }

        /// <summary> Initializes a new instance of RouteConfigurationOverrideActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="originGroupOverride"> A reference to the origin group override configuration. Leave empty to use the default origin group on route. </param>
        internal RouteConfigurationOverrideActionParameters(RouteConfigurationOverrideActionParametersTypeName typeName, OriginGroupOverride originGroupOverride)
        {
            TypeName = typeName;
            OriginGroupOverride = originGroupOverride;
        }

        /// <summary> Gets or sets the type name. </summary>
        public RouteConfigurationOverrideActionParametersTypeName TypeName { get; set; }
        /// <summary> A reference to the origin group override configuration. Leave empty to use the default origin group on route. </summary>
        public OriginGroupOverride OriginGroupOverride { get; set; }
    }
}
