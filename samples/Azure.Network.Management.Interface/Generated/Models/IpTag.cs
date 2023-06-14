// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Contains the IpTag associated with the object. </summary>
    public partial class IpTag
    {
        /// <summary> Initializes a new instance of IpTag. </summary>
        public IpTag()
        {
        }

        /// <summary> Initializes a new instance of IpTag. </summary>
        /// <param name="ipTagType"> The IP tag type. Example: FirstPartyUsage. </param>
        /// <param name="tag"> The value of the IP tag associated with the public IP. Example: SQL. </param>
        internal IpTag(string ipTagType, string tag)
        {
            IpTagType = ipTagType;
            Tag = tag;
        }

        /// <summary> The IP tag type. Example: FirstPartyUsage. </summary>
        public string IpTagType { get; set; }
        /// <summary> The value of the IP tag associated with the public IP. Example: SQL. </summary>
        public string Tag { get; set; }
    }
}
