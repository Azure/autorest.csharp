// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.Unit
{
    internal class CodeModelExtensionTests
    {
        [TestCase("OsType", "OSType", false)]
        [TestCase("OsType", "osType", true)]
        [TestCase("DnsIp", "DnsIP", false)]
        [TestCase("DnsIp", "dnsIP", true)]
        [TestCase("OsProfile", "OSProfile", false)]
        [TestCase("OsProfile", "osProfile", true)]
        public void EnsureNameCaseTest(string name, string expected, bool lowerFirst)
        {
            var result = name.EnsureNameCase(lowerFirst);
            Assert.AreEqual(expected, result);
        }
    }
}
