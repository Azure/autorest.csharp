using System;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using ResourceIdentifierChooser;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class ResourceIdentifierChooserTests : TestProjectTests
    {
        public ResourceIdentifierChooserTests() : base("ResourceIdentifierChooser") { }

        [TestCase(typeof(SubscriptionLevelIdentifier), typeof(SubscriptionResourceIdentifier))]
        [TestCase(typeof(TenantLevelIdentifier), typeof(TenantResourceIdentifier))]
        [TestCase(typeof(ResourceGroup), typeof(ResourceGroupResourceIdentifier))]
        [TestCase(typeof(ResourcesIdentifier), typeof(ResourceIdentifier))]
        public void TestResourceIdentifierChooser(Type dataType, Type expectedIdType)
        {
            Assert.AreEqual(dataType.BaseType.GenericTypeArguments, expectedIdType);
        }
    }
}
