// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> An MX record. </summary>
    public partial class MxRecord
    {
        /// <summary> Initializes a new instance of MxRecord. </summary>
        public MxRecord()
        {
        }

        /// <summary> Initializes a new instance of MxRecord. </summary>
        /// <param name="preference"> The preference value for this MX record. </param>
        /// <param name="exchange"> The domain name of the mail host for this MX record. </param>
        internal MxRecord(int? preference, string exchange)
        {
            Preference = preference;
            Exchange = exchange;
        }

        /// <summary> The preference value for this MX record. </summary>
        public int? Preference { get; set; }
        /// <summary> The domain name of the mail host for this MX record. </summary>
        public string Exchange { get; set; }
    }
}
