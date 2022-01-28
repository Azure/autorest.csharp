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
            };
            CodeModelExtension.ApplyRenameRules(renameRules);
        }

        [TestCase("OsType", "OSType", false)]
        [TestCase("OsType", "osType", true)]
        [TestCase("DnsIp", "DnsIP", false)]
        [TestCase("DnsIp", "dnsIP", true)]
        [TestCase("OsProfile", "OSProfile", false)]
        [TestCase("OsProfile", "osProfile", true)]
        [TestCase("ipAddress", "IPAddress", false)]
        [TestCase("ipAddress", "ipAddress", true)]
        [TestCase("vipAddress", "VipAddress", false)]
        [TestCase("vipAddress", "vipAddress", true)]
        [TestCase("publicIp", "PublicIP", false)]
        [TestCase("publicIp", "publicIP", true)]
        [TestCase("publicIps", "PublicIPs", false)]
        [TestCase("publicIps", "publicIPs", true)]
        [TestCase("resourceId", "ResourceId", false)]
        [TestCase("resourceId", "resourceId", true)]
        [TestCase("resourceIds", "ResourceIds", false)]
        [TestCase("resourceIds", "resourceIds", true)]
        [TestCase("resourceIDs", "ResourceIds", false)]
        [TestCase("resourceIDs", "resourceIds", true)]
        [TestCase("resourceIdSuffix", "ResourceIdSuffix", false)]
        [TestCase("resourceIdSuffix", "resourceIdSuffix", true)]
        [TestCase("resourceIDSuffix", "ResourceIdSuffix", false)]
        [TestCase("resourceIDSuffix", "resourceIdSuffix", true)]
        public void EnsureNameCaseTest(string name, string expected, bool lowerFirst)
        {
            var result = name.EnsureNameCase(lowerFirst);
            Assert.AreEqual(expected, result);
        }
    }
}
