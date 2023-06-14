// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> A CAA record. </summary>
    public partial class CaaRecord
    {
        /// <summary> Initializes a new instance of CaaRecord. </summary>
        public CaaRecord()
        {
        }

        /// <summary> Initializes a new instance of CaaRecord. </summary>
        /// <param name="flags"> The flags for this CAA record as an integer between 0 and 255. </param>
        /// <param name="tag"> The tag for this CAA record. </param>
        /// <param name="value"> The value for this CAA record. </param>
        internal CaaRecord(int? flags, string tag, string value)
        {
            Flags = flags;
            Tag = tag;
            Value = value;
        }

        /// <summary> The flags for this CAA record as an integer between 0 and 255. </summary>
        public int? Flags { get; set; }
        /// <summary> The tag for this CAA record. </summary>
        public string Tag { get; set; }
        /// <summary> The value for this CAA record. </summary>
        public string Value { get; set; }
    }
}
