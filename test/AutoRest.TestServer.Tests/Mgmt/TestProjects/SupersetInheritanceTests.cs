// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using SupersetInheritance;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class SupersetInheritanceTests
    {
        [TestCase(typeof(Resource<TenantResourceIdentifier>), typeof(SupersetModel1Data))]
        [TestCase(typeof(Object), typeof(SupersetModel2))]
        [TestCase(typeof(Object), typeof(SupersetModel3))]
        [TestCase(typeof(TrackedResource<TenantResourceIdentifier>), typeof(SupersetModel4Data))]
        public void ValidateInheritanceType(Type expectedBaseType, Type generatedClass)
        {
            Assert.AreEqual(expectedBaseType, generatedClass.BaseType);
        }
    }
}
