// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the origin group override action. </summary>
    public partial class OriginGroupOverrideActionParameters
    {
        /// <summary> Initializes a new instance of OriginGroupOverrideActionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="originGroup"> defines the OriginGroup that would override the DefaultOriginGroup. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="originGroup"/> is null. </exception>
        public OriginGroupOverrideActionParameters(OriginGroupOverrideActionParametersTypeName typeName, WritableSubResource originGroup)
        {
            Argument.AssertNotNull(originGroup, nameof(originGroup));

            TypeName = typeName;
            OriginGroup = originGroup;
        }

        /// <summary> Gets or sets the type name. </summary>
        public OriginGroupOverrideActionParametersTypeName TypeName { get; set; }
        /// <summary> defines the OriginGroup that would override the DefaultOriginGroup. </summary>
        internal WritableSubResource OriginGroup { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier OriginGroupId
        {
            get => OriginGroup is null ? default : OriginGroup.Id;
            set
            {
                if (OriginGroup is null)
                    OriginGroup = new WritableSubResource();
                OriginGroup.Id = value;
            }
        }
    }
}
