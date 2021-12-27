// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> The properties describe the recommended machine configuration for this Image Definition. These properties are updatable. </summary>
    public partial class RecommendedMachineConfiguration
    {
        /// <summary> Initializes a new instance of RecommendedMachineConfiguration. </summary>
        internal RecommendedMachineConfiguration()
        {
        }

        /// <summary> Initializes a new instance of RecommendedMachineConfiguration. </summary>
        /// <param name="vCPUs"> Describes the resource range. </param>
        /// <param name="memory"> Describes the resource range. </param>
        internal RecommendedMachineConfiguration(ResourceRange vCPUs, ResourceRange memory)
        {
            VCPUs = vCPUs;
            Memory = memory;
        }

        /// <summary> Describes the resource range. </summary>
        public ResourceRange VCPUs { get; }
        /// <summary> Describes the resource range. </summary>
        public ResourceRange Memory { get; }
    }
}
