// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Application gateway resource. </summary>
    public partial class ApplicationGateway : Resource
    {
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; internal set; }
        /// <summary> A list of availability zones denoting where the resource needs to come from. </summary>
        public ICollection<string> Zones { get; set; }
        /// <summary> The identity of the application gateway, if configured. </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary> SKU of the application gateway resource. </summary>
        public ApplicationGatewaySku Sku { get; set; }
        /// <summary> SSL policy of the application gateway resource. </summary>
        public ApplicationGatewaySslPolicy SslPolicy { get; set; }
        /// <summary> Operational state of the application gateway resource. </summary>
        public ApplicationGatewayOperationalState? OperationalState { get; internal set; }
        /// <summary> Subnets of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayIPConfiguration> GatewayIPConfigurations { get; set; }
        /// <summary> Authentication certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayAuthenticationCertificate> AuthenticationCertificates { get; set; }
        /// <summary> Trusted Root certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayTrustedRootCertificate> TrustedRootCertificates { get; set; }
        /// <summary> SSL certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewaySslCertificate> SslCertificates { get; set; }
        /// <summary> Frontend IP addresses of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayFrontendIPConfiguration> FrontendIPConfigurations { get; set; }
        /// <summary> Frontend ports of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayFrontendPort> FrontendPorts { get; set; }
        /// <summary> Probes of the application gateway resource. </summary>
        public ICollection<ApplicationGatewayProbe> Probes { get; set; }
        /// <summary> Backend address pool of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayBackendAddressPool> BackendAddressPools { get; set; }
        /// <summary> Backend http settings of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayBackendHttpSettings> BackendHttpSettingsCollection { get; set; }
        /// <summary> Http listeners of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayHttpListener> HttpListeners { get; set; }
        /// <summary> URL path map of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayUrlPathMap> UrlPathMaps { get; set; }
        /// <summary> Request routing rules of the application gateway resource. </summary>
        public ICollection<ApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; set; }
        /// <summary> Rewrite rules for the application gateway resource. </summary>
        public ICollection<ApplicationGatewayRewriteRuleSet> RewriteRuleSets { get; set; }
        /// <summary> Redirect configurations of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits). </summary>
        public ICollection<ApplicationGatewayRedirectConfiguration> RedirectConfigurations { get; set; }
        /// <summary> Web application firewall configuration. </summary>
        public ApplicationGatewayWebApplicationFirewallConfiguration WebApplicationFirewallConfiguration { get; set; }
        /// <summary> Reference to the FirewallPolicy resource. </summary>
        public SubResource FirewallPolicy { get; set; }
        /// <summary> Whether HTTP2 is enabled on the application gateway resource. </summary>
        public bool? EnableHttp2 { get; set; }
        /// <summary> Whether FIPS is enabled on the application gateway resource. </summary>
        public bool? EnableFips { get; set; }
        /// <summary> Autoscale Configuration. </summary>
        public ApplicationGatewayAutoscaleConfiguration AutoscaleConfiguration { get; set; }
        /// <summary> The resource GUID property of the application gateway resource. </summary>
        public string ResourceGuid { get; internal set; }
        /// <summary> The provisioning state of the application gateway resource. </summary>
        public ProvisioningState? ProvisioningState { get; internal set; }
        /// <summary> Custom error configurations of the application gateway resource. </summary>
        public ICollection<ApplicationGatewayCustomError> CustomErrorConfigurations { get; set; }
    }
}
