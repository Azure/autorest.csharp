// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPartialResource;

namespace MgmtPartialResource.Models
{
    /// <summary> The response of the list configuration profile assignment operation. </summary>
    internal partial class ConfigurationProfileAssignmentList
    {
        /// <summary> Initializes a new instance of <see cref="ConfigurationProfileAssignmentList"/>. </summary>
        internal ConfigurationProfileAssignmentList()
        {
            Value = new ChangeTrackingList<ConfigurationProfileAssignmentData>();
        }

        /// <summary> Initializes a new instance of <see cref="ConfigurationProfileAssignmentList"/>. </summary>
        /// <param name="value"> Result of the list configuration profile assignment operation. </param>
        internal ConfigurationProfileAssignmentList(IReadOnlyList<ConfigurationProfileAssignmentData> value)
        {
            Value = value;
        }

        /// <summary> Result of the list configuration profile assignment operation. </summary>
        public IReadOnlyList<ConfigurationProfileAssignmentData> Value { get; }
    }
}
