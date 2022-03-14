// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.Unit
{
    internal class NameTransformerTests
    {
        private Dictionary<string, string> renameRules;

        [OneTimeSetUp]
        public void SetRenameRules()
        {
            renameRules = new Dictionary<string, string>
            {
                { "Os", "OS" },
                { "Ip", "IP" },
                { "Ips", "IPs" },
                { "ID", "Id" },
                { "IDs", "Ids" },
                { "VM", "Vm" },
                { "VMs", "Vms" },
                { "VPN", "Vpn" },
                { "WAN", "Wan" },
                { "WANs", "Wans" },
                { "DNS", "Dns" },
            };
        }

        [TestCase("OsType", "OSType")]
        [TestCase("DNSIp", "DnsIP")]
        [TestCase("DnsIp", "DnsIP")]
        [TestCase("OsProfile", "OSProfile")]
        [TestCase("ipAddress", "IPAddress")]
        [TestCase("vipAddress", "VipAddress")]
        [TestCase("publicIp", "PublicIP")]
        [TestCase("publicIps", "PublicIPs")]
        [TestCase("resourceId", "ResourceId")]
        [TestCase("resourceIds", "ResourceIds")]
        [TestCase("resourceIDs", "ResourceIds")]
        [TestCase("resourceIdSuffix", "ResourceIdSuffix")]
        [TestCase("IpsilateralDisablity", "IpsilateralDisablity")]
        [TestCase("HumanIpsilateralDisablity", "HumanIpsilateralDisablity")]
        [TestCase("DnsIpAddressIDsForWindowsOs", "DnsIPAddressIdsForWindowsOS")]
        [TestCase("DnsIpAddressIDsForWindowsOsPlatform", "DnsIPAddressIdsForWindowsOSPlatform")]
        [TestCase("something_IDs_Ip_Os", "Something_Ids_IP_OS")]
        [TestCase("Dynamic365IDs", "Dynamic365Ids")]
        [TestCase("VirtualWAN", "VirtualWan")]
        [TestCase("VirtualWANs", "VirtualWans")]
        [TestCase("VPNIp", "VpnIP")]
        [TestCase("VMIp", "VmIP")]
        [TestCase("SomethingVPNIp", "SomethingVpnIP")]
        [TestCase("SomethingVPNIP", "SomethingVpnIP")]
        [TestCase("RestorePointSourceVMOSDisk", "RestorePointSourceVmOSDisk")]
        public void EnsureNameCaseTest(string name, string expected)
        {
            var transformer = new NameTransformer(renameRules);
            var result = transformer.EnsureNameCase(name);
            Assert.AreEqual(expected, result);
        }
    }
}
