// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <param name="vCpus"> Describes the resource range. </param>
        /// <param name="memory"> Describes the resource range. </param>
        internal RecommendedMachineConfiguration(ResourceRange vCpus, ResourceRange memory)
        {
            VCpus = vCpus;
            Memory = memory;
        }

        /// <summary> Describes the resource range. </summary>
        public ResourceRange VCpus { get; }
        /// <summary> Describes the resource range. </summary>
        public ResourceRange Memory { get; }
    }
}
