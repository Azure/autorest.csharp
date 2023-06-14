// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> A TXT record. </summary>
    public partial class TxtRecord
    {
        /// <summary> Initializes a new instance of TxtRecord. </summary>
        public TxtRecord()
        {
            Value = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of TxtRecord. </summary>
        /// <param name="value"> The text value of this TXT record. </param>
        internal TxtRecord(IList<string> value)
        {
            Value = value;
        }

        /// <summary> The text value of this TXT record. </summary>
        public IList<string> Value { get; }
    }
}
