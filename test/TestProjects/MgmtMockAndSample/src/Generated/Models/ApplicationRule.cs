// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Rule of type application. </summary>
    public partial class ApplicationRule : FirewallPolicyRule
    {
        /// <summary> Initializes a new instance of ApplicationRule. </summary>
        public ApplicationRule()
        {
            SourceAddresses = new ChangeTrackingList<string>();
            DestinationAddresses = new ChangeTrackingList<string>();
            Protocols = new ChangeTrackingList<FirewallPolicyRuleApplicationProtocol>();
            TargetFqdns = new ChangeTrackingList<string>();
            TargetUrls = new ChangeTrackingList<string>();
            FqdnTags = new ChangeTrackingList<string>();
            SourceIpGroups = new ChangeTrackingList<string>();
            WebCategories = new ChangeTrackingList<string>();
            RuleType = FirewallPolicyRuleType.ApplicationRule;
        }

        /// <summary> Initializes a new instance of ApplicationRule. </summary>
        /// <param name="name"> Name of the rule. </param>
        /// <param name="description"> Description of the rule. </param>
        /// <param name="ruleType"> Rule Type. </param>
        /// <param name="sourceAddresses"> List of source IP addresses for this rule. </param>
        /// <param name="destinationAddresses"> List of destination IP addresses or Service Tags. </param>
        /// <param name="protocols"> Array of Application Protocols. </param>
        /// <param name="targetFqdns"> List of FQDNs for this rule. </param>
        /// <param name="targetUrls"> List of Urls for this rule condition. </param>
        /// <param name="fqdnTags"> List of FQDN Tags for this rule. </param>
        /// <param name="sourceIpGroups"> List of source IpGroups for this rule. </param>
        /// <param name="terminateTLS"> Terminate TLS connections for this rule. </param>
        /// <param name="webCategories"> List of destination azure web categories. </param>
        internal ApplicationRule(string name, string description, FirewallPolicyRuleType ruleType, IList<string> sourceAddresses, IList<string> destinationAddresses, IList<FirewallPolicyRuleApplicationProtocol> protocols, IList<string> targetFqdns, IList<string> targetUrls, IList<string> fqdnTags, IList<string> sourceIpGroups, bool? terminateTLS, IList<string> webCategories) : base(name, description, ruleType)
        {
            SourceAddresses = sourceAddresses;
            DestinationAddresses = destinationAddresses;
            Protocols = protocols;
            TargetFqdns = targetFqdns;
            TargetUrls = targetUrls;
            FqdnTags = fqdnTags;
            SourceIpGroups = sourceIpGroups;
            TerminateTLS = terminateTLS;
            WebCategories = webCategories;
            RuleType = ruleType;
        }

        /// <summary> List of source IP addresses for this rule. </summary>
        public IList<string> SourceAddresses { get; }
        /// <summary> List of destination IP addresses or Service Tags. </summary>
        public IList<string> DestinationAddresses { get; }
        /// <summary> Array of Application Protocols. </summary>
        public IList<FirewallPolicyRuleApplicationProtocol> Protocols { get; }
        /// <summary> List of FQDNs for this rule. </summary>
        public IList<string> TargetFqdns { get; }
        /// <summary> List of Urls for this rule condition. </summary>
        public IList<string> TargetUrls { get; }
        /// <summary> List of FQDN Tags for this rule. </summary>
        public IList<string> FqdnTags { get; }
        /// <summary> List of source IpGroups for this rule. </summary>
        public IList<string> SourceIpGroups { get; }
        /// <summary> Terminate TLS connections for this rule. </summary>
        public bool? TerminateTLS { get; set; }
        /// <summary> List of destination azure web categories. </summary>
        public IList<string> WebCategories { get; }
    }
}
