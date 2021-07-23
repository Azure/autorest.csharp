using System;
using Azure.ResourceManager;
using NUnit.Framework;
using ResourceIdentifierChooser;
using TenantOnly;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class ResourceIdentifierChooserTests : TestProjectTests
    {
        public ResourceIdentifierChooserTests() : base("ResourceIdentifierChooser") { }

        [TestCase(typeof(SubscriptionLevelResource), typeof(SubscriptionResourceIdentifier))]
        [TestCase(typeof(TenantLevelResource), typeof(TenantResourceIdentifier))]
        [TestCase(typeof(ResourceGroupResource), typeof(ResourceGroupResourceIdentifier))]
        [TestCase(typeof(ResourceLevel), typeof(ResourceGroupResourceIdentifier))]
        [TestCase(typeof(ModelData), typeof(ResourceGroupResourceIdentifier))]
        [TestCase(typeof(SubResResource), typeof(SubscriptionResourceIdentifier))]
        [TestCase(typeof(SubRes2Resource), typeof(TenantResourceIdentifier))]
        [TestCase(typeof(SubRes3Resource), typeof(ResourceGroupResourceIdentifier))]
        [TestCase(typeof(WritableSubResResource), typeof(SubscriptionResourceIdentifier))]
        [TestCase(typeof(WritableSubRes2Resource), typeof(TenantResourceIdentifier))]
        [TestCase(typeof(WritableSubRes3Resource), typeof(ResourceGroupResourceIdentifier))]
        [TestCase(typeof(Agreement), typeof(TenantResourceIdentifier))]
        public void TestResourceIdentifierChooser(Type dataType, Type expectedIdType)
        {
            Assert.AreEqual(dataType.BaseType.BaseType.GenericTypeArguments[0], expectedIdType);
        }
    }
}
