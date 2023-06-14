// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel11. </summary>
    public partial class ExactMatchModel11
    {
        /// <summary> Initializes a new instance of ExactMatchModel11. </summary>
        public ExactMatchModel11()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel11. </summary>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        internal ExactMatchModel11(string name, ResourceType? resourceType)
        {
            Name = name;
            ResourceType = resourceType;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
        /// <summary> Gets the resource type. </summary>
        public ResourceType? ResourceType { get; }
    }
}
