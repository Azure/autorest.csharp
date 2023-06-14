// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    /// <summary> The List of Fake Configuration operation response. </summary>
    public partial class FakeConfigurationListResult
    {
        /// <summary> Initializes a new instance of FakeConfigurationListResult. </summary>
        public FakeConfigurationListResult()
        {
            Value = new ChangeTrackingList<FakeConfigurationData>();
        }

        /// <summary> Initializes a new instance of FakeConfigurationListResult. </summary>
        /// <param name="value"> The list of Fake Configuration. </param>
        internal FakeConfigurationListResult(IList<FakeConfigurationData> value)
        {
            Value = value;
        }

        /// <summary> The list of Fake Configuration. </summary>
        public IList<FakeConfigurationData> Value { get; }
    }
}
