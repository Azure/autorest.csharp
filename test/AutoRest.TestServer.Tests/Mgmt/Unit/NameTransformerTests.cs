// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using NUnit.Framework;
using static AutoRest.CSharp.Input.MgmtConfiguration;

namespace AutoRest.TestServer.Tests.Mgmt.Unit
{
    internal class NameTransformerTests
    {
        private Dictionary<string, RenameRuleTarget> renameRules;

        [OneTimeSetUp]
        public void SetRenameRules()
        {
            renameRules = new Dictionary<string, RenameRuleTarget>
            {
                { "Os", new RenameRuleTarget("OS", null) },
                { "Ip", new RenameRuleTarget("IP", null) },
                { "Ips", new RenameRuleTarget("IPs", "ips") },
                { "ID", new RenameRuleTarget("Id", null) },
                { "IDs", new RenameRuleTarget("Ids", null) },
                { "VM", new RenameRuleTarget("Vm", null) },
                { "VMs", new RenameRuleTarget("Vms", null) },
                { "VPN", new RenameRuleTarget("Vpn", null) },
                { "WAN", new RenameRuleTarget("Wan", null) },
                { "WANs", new RenameRuleTarget("Wans", null) },
                { "DNS", new RenameRuleTarget("Dns", null) },
                { "P2s", new RenameRuleTarget("P2S", "p2s") },
            };
        }

        [TestCase("OsType", "OSType", "osType")]
        [TestCase("DNSIp", "DnsIP", "dnsIP")]
        [TestCase("DnsIp", "DnsIP", "dnsIP")]
        [TestCase("OsProfile", "OSProfile", "osProfile")]
        [TestCase("ipAddress", "IPAddress", "ipAddress")]
        [TestCase("vipAddress", "VipAddress", "vipAddress")]
        [TestCase("publicIp", "PublicIP", "publicIP")]
        [TestCase("publicIps", "PublicIPs", "publicIPs")]
        [TestCase("resourceId", "ResourceId", "resourceId")]
        [TestCase("resourceIds", "ResourceIds", "resourceIds")]
        [TestCase("resourceIDs", "ResourceIds", "resourceIds")]
        [TestCase("resourceIdSuffix", "ResourceIdSuffix", "resourceIdSuffix")]
        [TestCase("IpsilateralDisablity", "IpsilateralDisablity", "ipsilateralDisablity")]
        [TestCase("HumanIpsilateralDisablity", "HumanIpsilateralDisablity", "humanIpsilateralDisablity")]
        [TestCase("DnsIpAddressIDsForWindowsOs", "DnsIPAddressIdsForWindowsOS", "dnsIPAddressIdsForWindowsOS")]
        [TestCase("DnsIpAddressIDsForWindowsOsPlatform", "DnsIPAddressIdsForWindowsOSPlatform", "dnsIPAddressIdsForWindowsOSPlatform")]
        [TestCase("something_IDs_Ip_Os", "Something_Ids_IP_OS", "somethingIdsIPOS")]
        [TestCase("Dynamic365IDs", "Dynamic365Ids", "dynamic365Ids")]
        [TestCase("VirtualWAN", "VirtualWan", "virtualWan")]
        [TestCase("VirtualWANs", "VirtualWans", "virtualWans")]
        [TestCase("VPNIp", "VpnIP", "vpnIP")]
        [TestCase("VMIp", "VmIP", "vmIP")]
        [TestCase("SomethingVPNIp", "SomethingVpnIP", "somethingVpnIP")]
        [TestCase("SomethingVPNIP", "SomethingVpnIP", "somethingVpnIP")]
        [TestCase("RestorePointSourceVMOSDisk", "RestorePointSourceVmOSDisk", "restorePointSourceVmOSDisk")]
        [TestCase("p2sServer", "P2SServer", "p2sServer")]
        [TestCase("P2sServer", "P2SServer", "p2sServer")]
        public void EnsureNameCaseTest(string name, string expectedPropertyName, string expectedVariableName)
        {
            var transformer = new NameTransformer(renameRules);
            var result = transformer.EnsureNameCase(name);
            Assert.AreEqual(expectedPropertyName, result.Name);
            Assert.AreEqual(expectedVariableName, result.VariableName.ToCleanName(false));
        }
    }
}
