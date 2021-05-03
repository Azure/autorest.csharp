using System;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using ResourceIdentifierChooser;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class ResourceIdentifierChooserTests : TestProjectTests
    {
        public ResourceIdentifierChooserTests() : base("ResourceIdentifierChooser") { }

        [TestCase(typeof(SubscriptionLevelResource), typeof(SubscriptionResourceIdentifier))]
        [TestCase(typeof(TenantLevelResource), typeof(TenantResourceIdentifier))]
        [TestCase(typeof(ResourceGroupResource), typeof(ResourceGroupResourceIdentifier))]
        [TestCase(typeof(ResourceLevel), typeof(ResourceIdentifier))]
        public void TestResourceIdentifierChooser(Type dataType, Type expectedIdType)
        {
            Assert.AreEqual(dataType.BaseType.BaseType.GenericTypeArguments[0], expectedIdType);
        }
    }
}
