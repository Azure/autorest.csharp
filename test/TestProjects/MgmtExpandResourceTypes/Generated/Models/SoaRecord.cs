// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> An SOA record. </summary>
    public partial class SoaRecord
    {
        /// <summary> Initializes a new instance of SoaRecord. </summary>
        public SoaRecord()
        {
        }

        /// <summary> Initializes a new instance of SoaRecord. </summary>
        /// <param name="host"> The domain name of the authoritative name server for this SOA record. </param>
        /// <param name="email"> The email contact for this SOA record. </param>
        /// <param name="serialNumber"> The serial number for this SOA record. </param>
        /// <param name="refreshTime"> The refresh value for this SOA record. </param>
        /// <param name="retryTime"> The retry time for this SOA record. </param>
        /// <param name="expireTime"> The expire time for this SOA record. </param>
        /// <param name="minimumTtl"> The minimum value for this SOA record. By convention this is used to determine the negative caching duration. </param>
        internal SoaRecord(string host, string email, long? serialNumber, long? refreshTime, long? retryTime, long? expireTime, long? minimumTtl)
        {
            Host = host;
            Email = email;
            SerialNumber = serialNumber;
            RefreshTime = refreshTime;
            RetryTime = retryTime;
            ExpireTime = expireTime;
            MinimumTtl = minimumTtl;
        }

        /// <summary> The domain name of the authoritative name server for this SOA record. </summary>
        public string Host { get; set; }
        /// <summary> The email contact for this SOA record. </summary>
        public string Email { get; set; }
        /// <summary> The serial number for this SOA record. </summary>
        public long? SerialNumber { get; set; }
        /// <summary> The refresh value for this SOA record. </summary>
        public long? RefreshTime { get; set; }
        /// <summary> The retry time for this SOA record. </summary>
        public long? RetryTime { get; set; }
        /// <summary> The expire time for this SOA record. </summary>
        public long? ExpireTime { get; set; }
        /// <summary> The minimum value for this SOA record. By convention this is used to determine the negative caching duration. </summary>
        public long? MinimumTtl { get; set; }
    }
}
