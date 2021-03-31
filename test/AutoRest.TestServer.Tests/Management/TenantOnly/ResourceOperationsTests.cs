using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TenantOnly;
using Azure.ResourceManager.Core;

namespace AutoRest.TestServer.Tests
{
    public class ResourceOperationsTests
    {
        [TestCase(typeof(AgreementOperations))]
        [TestCase(typeof(AvailableBalanceOperations))]
        [TestCase(typeof(BillingAccountOperations))]
        [TestCase(typeof(InstructionOperations))]
        public void ValidateBaseClass(Type type)
        {
            Assert.AreEqual(typeof(ResourceOperationsBase), type.BaseType.BaseType);
        }

        [TestCase(typeof(AgreementOperations))]
        [TestCase(typeof(AvailableBalanceOperations))]
        [TestCase(typeof(BillingAccountOperations))]
        [TestCase(typeof(InstructionOperations))]
        public void ValidateListAvailableLocations(Type type)
        {
            var method = type.GetMethod("ListAvailableLocations");
            Assert.NotNull(method);
        }

        [TestCase(typeof(AgreementOperations))]
        [TestCase(typeof(AvailableBalanceOperations))]
        [TestCase(typeof(BillingAccountOperations))]
        [TestCase(typeof(InstructionOperations))]
        public void ValidateListAvailableLocationsAsync(Type type)
        {
            var method = type.GetMethod("ListAvailableLocationsAsync");
            Assert.NotNull(method);
        }
    }
}
