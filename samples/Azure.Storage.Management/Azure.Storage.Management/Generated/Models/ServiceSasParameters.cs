// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Storage.Management.Models
{
    /// <summary> The parameters to list service SAS credentials of a specific resource. </summary>
    public partial class ServiceSasParameters
    {
        /// <summary> Initializes a new instance of ServiceSasParameters. </summary>
        public ServiceSasParameters()
        {
        }

        /// <summary> Initializes a new instance of ServiceSasParameters. </summary>
        /// <param name="canonicalizedResource"> The canonical path to the signed resource. </param>
        /// <param name="resource"> The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share (s). </param>
        /// <param name="permissions"> The signed permissions for the service SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p). </param>
        /// <param name="iPAddressOrRange"> An IP address or a range of IP addresses from which to accept requests. </param>
        /// <param name="protocols"> The protocol permitted for a request made with the account SAS. </param>
        /// <param name="sharedAccessStartTime"> The time at which the SAS becomes valid. </param>
        /// <param name="sharedAccessExpiryTime"> The time at which the shared access signature becomes invalid. </param>
        /// <param name="identifier"> A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or table. </param>
        /// <param name="partitionKeyStart"> The start of partition key. </param>
        /// <param name="partitionKeyEnd"> The end of partition key. </param>
        /// <param name="rowKeyStart"> The start of row key. </param>
        /// <param name="rowKeyEnd"> The end of row key. </param>
        /// <param name="keyToSign"> The key to sign the account SAS token with. </param>
        /// <param name="cacheControl"> The response header override for cache control. </param>
        /// <param name="contentDisposition"> The response header override for content disposition. </param>
        /// <param name="contentEncoding"> The response header override for content encoding. </param>
        /// <param name="contentLanguage"> The response header override for content language. </param>
        /// <param name="contentType"> The response header override for content type. </param>
        internal ServiceSasParameters(string canonicalizedResource, SignedResource? resource, Permissions? permissions, string iPAddressOrRange, HttpProtocol? protocols, DateTimeOffset? sharedAccessStartTime, DateTimeOffset? sharedAccessExpiryTime, string identifier, string partitionKeyStart, string partitionKeyEnd, string rowKeyStart, string rowKeyEnd, string keyToSign, string cacheControl, string contentDisposition, string contentEncoding, string contentLanguage, string contentType)
        {
            CanonicalizedResource = canonicalizedResource;
            Resource = resource;
            Permissions = permissions;
            IPAddressOrRange = iPAddressOrRange;
            Protocols = protocols;
            SharedAccessStartTime = sharedAccessStartTime;
            SharedAccessExpiryTime = sharedAccessExpiryTime;
            Identifier = identifier;
            PartitionKeyStart = partitionKeyStart;
            PartitionKeyEnd = partitionKeyEnd;
            RowKeyStart = rowKeyStart;
            RowKeyEnd = rowKeyEnd;
            KeyToSign = keyToSign;
            CacheControl = cacheControl;
            ContentDisposition = contentDisposition;
            ContentEncoding = contentEncoding;
            ContentLanguage = contentLanguage;
            ContentType = contentType;
        }

        /// <summary> The canonical path to the signed resource. </summary>
        public string CanonicalizedResource { get; set; }
        /// <summary> The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share (s). </summary>
        public SignedResource? Resource { get; set; }
        /// <summary> The signed permissions for the service SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p). </summary>
        public Permissions? Permissions { get; set; }
        /// <summary> An IP address or a range of IP addresses from which to accept requests. </summary>
        public string IPAddressOrRange { get; set; }
        /// <summary> The protocol permitted for a request made with the account SAS. </summary>
        public HttpProtocol? Protocols { get; set; }
        /// <summary> The time at which the SAS becomes valid. </summary>
        public DateTimeOffset? SharedAccessStartTime { get; set; }
        /// <summary> The time at which the shared access signature becomes invalid. </summary>
        public DateTimeOffset? SharedAccessExpiryTime { get; set; }
        /// <summary> A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or table. </summary>
        public string Identifier { get; set; }
        /// <summary> The start of partition key. </summary>
        public string PartitionKeyStart { get; set; }
        /// <summary> The end of partition key. </summary>
        public string PartitionKeyEnd { get; set; }
        /// <summary> The start of row key. </summary>
        public string RowKeyStart { get; set; }
        /// <summary> The end of row key. </summary>
        public string RowKeyEnd { get; set; }
        /// <summary> The key to sign the account SAS token with. </summary>
        public string KeyToSign { get; set; }
        /// <summary> The response header override for cache control. </summary>
        public string CacheControl { get; set; }
        /// <summary> The response header override for content disposition. </summary>
        public string ContentDisposition { get; set; }
        /// <summary> The response header override for content encoding. </summary>
        public string ContentEncoding { get; set; }
        /// <summary> The response header override for content language. </summary>
        public string ContentLanguage { get; set; }
        /// <summary> The response header override for content type. </summary>
        public string ContentType { get; set; }
    }
}
