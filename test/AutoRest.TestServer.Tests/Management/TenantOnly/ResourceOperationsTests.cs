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
        //[TestCase (typeof(AgreementsOperations))]
        public void ValidateBaseClass(Type type)
        {
            Assert.AreEqual(typeof(ResourceOperationsBase), type.BaseType);
        }

        //[TestCase(typeof(AgreementsOperations))]
        public void ValiateListAvailableLocations(Type type)
        {
            var method = type.GetMethod("ListAvailableLocations");
            Assert.NotNull(method);
        }
    }
}
