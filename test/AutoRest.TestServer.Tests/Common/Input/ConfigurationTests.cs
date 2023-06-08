using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using static AutoRest.CSharp.Input.Configuration;

namespace AutoRest.TestServer.Tests.Common.Input
{
    public class ConfigurationTests
    {
        [TestCase("TestOptions")]
        [TestCase("ClientOperationOptions")]
        public void PropertyBagNameForGroupParametersMethodOptions(string name)
        {
            var option = GroupParametersMethodOptions.Parse(JsonDocument.Parse($"{{\"Vm_Create\":\"{name}\"}}").RootElement);
            Assert.AreEqual(name, option.PropertyBagName);
        }

        [TestCase("Test")]
        [TestCase("ClientOperation")]
        public void InvalidPropertyBagNameForGroupParametersMethodOptions(string name)
        {
            try
            {
                var option = GroupParametersMethodOptions.Parse(JsonDocument.Parse($"{{\"Vm_Create\":\"{name}\"}}").RootElement);
                Assert.Fail($"Should fail the parsing for {name}");
            }
            catch (ArgumentException) { };
        }
    }
}
