// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace subscriptionId_apiVersion.Models
{
    /// <summary> The SampleResourceGroup. </summary>
    public partial class SampleResourceGroup
    {
        /// <summary> Initializes a new instance of SampleResourceGroup. </summary>
        internal SampleResourceGroup()
        {
        }

        /// <summary> Initializes a new instance of SampleResourceGroup. </summary>
        /// <param name="name"> resource group name 'testgroup101'. </param>
        /// <param name="location"> resource group location 'West US'. </param>
        internal SampleResourceGroup(string name, string location)
        {
            Name = name;
            Location = location;
        }

        /// <summary> resource group name 'testgroup101'. </summary>
        public string Name { get; }
        /// <summary> resource group location 'West US'. </summary>
        public string Location { get; }
    }
}
