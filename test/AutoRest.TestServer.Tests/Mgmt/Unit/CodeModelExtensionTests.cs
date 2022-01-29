// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.Unit
{
    internal class CodeModelExtensionTests
    {
        [OneTimeSetUp]
        public static void ApplyRenameRules()
        {
            var renameRules = new Dictionary<string, string>
            {
                { "Os", "OS" },
                { "Ip", "IP" },
                { "Ips", "IPs" },
                { "ID", "Id" },
                { "IDs", "Ids" },
                { "VPN", "Vpn" },
                { "WAN", "Wan" },
                { "WANs", "Wans" },
            };
            CodeModelExtension.ApplyRenameRules(renameRules);
        }

        [TestCase("OsType", "OSType")]
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
        [TestCase("something_IDs_Ip_Os", "Something_Ids_Ip_OS")]
        [TestCase("Dynamic365IDs", "Dynamic365Ids")]
        [TestCase("VirtualWAN", "VirtualWan")]
        [TestCase("VirtualWANs", "VirtualWans")]
        public void EnsureNameCaseTest(string name, string expected)
        {
            var result = name.EnsureNameCase();
            Assert.AreEqual(expected, result);
        }
    }
}
