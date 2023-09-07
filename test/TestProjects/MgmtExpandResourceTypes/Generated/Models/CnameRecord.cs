// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> A CNAME record. </summary>
    internal partial class CnameRecord
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CnameRecord"/>. </summary>
        public CnameRecord()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CnameRecord"/>. </summary>
        /// <param name="cname"> The canonical name for this CNAME record. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CnameRecord(string cname, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Cname = cname;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname { get; set; }
    }
}
