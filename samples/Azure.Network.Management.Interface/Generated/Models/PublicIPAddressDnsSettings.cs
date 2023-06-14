// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Contains FQDN of the DNS record associated with the public IP address. </summary>
    public partial class PublicIPAddressDnsSettings
    {
        /// <summary> Initializes a new instance of PublicIPAddressDnsSettings. </summary>
        public PublicIPAddressDnsSettings()
        {
        }

        /// <summary> Initializes a new instance of PublicIPAddressDnsSettings. </summary>
        /// <param name="domainNameLabel"> The domain name label. The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system. </param>
        /// <param name="fqdn"> The Fully Qualified Domain Name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone. </param>
        /// <param name="reverseFqdn"> The reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. </param>
        internal PublicIPAddressDnsSettings(string domainNameLabel, string fqdn, string reverseFqdn)
        {
            DomainNameLabel = domainNameLabel;
            Fqdn = fqdn;
            ReverseFqdn = reverseFqdn;
        }

        /// <summary> The domain name label. The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system. </summary>
        public string DomainNameLabel { get; set; }
        /// <summary> The Fully Qualified Domain Name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone. </summary>
        public string Fqdn { get; set; }
        /// <summary> The reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. </summary>
        public string ReverseFqdn { get; set; }
    }
}
