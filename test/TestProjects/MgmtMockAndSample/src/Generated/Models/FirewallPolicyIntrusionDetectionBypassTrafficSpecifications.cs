// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Intrusion detection bypass traffic specification. </summary>
    public partial class FirewallPolicyIntrusionDetectionBypassTrafficSpecifications
    {
        /// <summary> Initializes a new instance of FirewallPolicyIntrusionDetectionBypassTrafficSpecifications. </summary>
        public FirewallPolicyIntrusionDetectionBypassTrafficSpecifications()
        {
            SourceAddresses = new ChangeTrackingList<string>();
            DestinationAddresses = new ChangeTrackingList<string>();
            DestinationPorts = new ChangeTrackingList<string>();
            SourceIpGroups = new ChangeTrackingList<string>();
            DestinationIpGroups = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of FirewallPolicyIntrusionDetectionBypassTrafficSpecifications. </summary>
        /// <param name="name"> Name of the bypass traffic rule. </param>
        /// <param name="description"> Description of the bypass traffic rule. </param>
        /// <param name="protocol"> The rule bypass protocol. </param>
        /// <param name="sourceAddresses"> List of source IP addresses or ranges for this rule. </param>
        /// <param name="destinationAddresses"> List of destination IP addresses or ranges for this rule. </param>
        /// <param name="destinationPorts"> List of destination ports or ranges. </param>
        /// <param name="sourceIpGroups"> List of source IpGroups for this rule. </param>
        /// <param name="destinationIpGroups"> List of destination IpGroups for this rule. </param>
        internal FirewallPolicyIntrusionDetectionBypassTrafficSpecifications(string name, string description, FirewallPolicyIntrusionDetectionProtocol? protocol, IList<string> sourceAddresses, IList<string> destinationAddresses, IList<string> destinationPorts, IList<string> sourceIpGroups, IList<string> destinationIpGroups)
        {
            Name = name;
            Description = description;
            Protocol = protocol;
            SourceAddresses = sourceAddresses;
            DestinationAddresses = destinationAddresses;
            DestinationPorts = destinationPorts;
            SourceIpGroups = sourceIpGroups;
            DestinationIpGroups = destinationIpGroups;
        }

        /// <summary> Name of the bypass traffic rule. </summary>
        public string Name { get; set; }
        /// <summary> Description of the bypass traffic rule. </summary>
        public string Description { get; set; }
        /// <summary> The rule bypass protocol. </summary>
        public FirewallPolicyIntrusionDetectionProtocol? Protocol { get; set; }
        /// <summary> List of source IP addresses or ranges for this rule. </summary>
        public IList<string> SourceAddresses { get; }
        /// <summary> List of destination IP addresses or ranges for this rule. </summary>
        public IList<string> DestinationAddresses { get; }
        /// <summary> List of destination ports or ranges. </summary>
        public IList<string> DestinationPorts { get; }
        /// <summary> List of source IpGroups for this rule. </summary>
        public IList<string> SourceIpGroups { get; }
        /// <summary> List of destination IpGroups for this rule. </summary>
        public IList<string> DestinationIpGroups { get; }
    }
}
