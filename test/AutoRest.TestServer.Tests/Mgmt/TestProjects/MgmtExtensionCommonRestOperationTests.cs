// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.Core.Pipeline;
using MgmtExtensionCommonRestOperation;
using MgmtExtensionCommonRestOperation.Mock;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class MgmtExtensionCommonRestOperationTests : TestProjectTests
    {
        public MgmtExtensionCommonRestOperationTests()
            : base("MgmtExtensionCommonRestOperation")
        {
        }

        [Test]
        public void ValidateSingleField()
        {
            ValidateFields(typeof(TypeOneResource), "typetwo");
            ValidateFields(typeof(TypeOneCollection), "typetwo");
            ValidateFields(typeof(TypeTwoResource), "typeone");
            ValidateFields(typeof(TypeTwoCollection), "typeone");
        }

        private static void ValidateFields(Type type, string name)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                Assert.IsFalse(field.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }
        }

        [TestCase(typeof(TypeOneResourceExtension), "_typeOneCommonRestClient", typeof(CommonRestOperations), "_typeOneCommonClientDiagnostics")]
        [TestCase(typeof(TypeTwoResourceExtension), "_typeTwoCommonRestClient", typeof(CommonRestOperations), "_typeTwoCommonClientDiagnostics")]
        public void ValidateFieldsInExtensionClients(Type extensionClient, string restOperationName, Type restOperationType, string clientDiagnosticName)
        {
            var fields = extensionClient.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var field = fields.FirstOrDefault(f => f.Name.Contains(restOperationName, StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(field);
            Assert.AreEqual(field.FieldType, restOperationType);
            field = fields.FirstOrDefault(f => f.Name.Contains(clientDiagnosticName, StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(field);
            Assert.AreEqual(field.FieldType, typeof(ClientDiagnostics));
        }
    }
}
