// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> A PTR record. </summary>
    public partial class PtrRecord
    {
        /// <summary> Initializes a new instance of PtrRecord. </summary>
        public PtrRecord()
        {
        }

        /// <summary> Initializes a new instance of PtrRecord. </summary>
        /// <param name="ptrdname"> The PTR target domain name for this PTR record. </param>
        internal PtrRecord(string ptrdname)
        {
            Ptrdname = ptrdname;
        }

        /// <summary> The PTR target domain name for this PTR record. </summary>
        public string Ptrdname { get; set; }
    }
}
