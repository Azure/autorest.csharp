// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using NUnit.Framework;
using RenameGetList;

namespace AutoRest.TestServer.Tests
{
    public class RenameGetListClientTests
    {
        [Test]
        public void RenameGetMethod()
        {
            var methods = typeof(RenameGetListClient).GetMethods();
            var getMethod = typeof(RenameGetListClient).GetMethod("Get");
            Assert.AreEqual(null, getMethod);

            var projectGetMethod = typeof(RenameGetListClient).GetMethod("GetProject");
            Assert.AreNotEqual(null, projectGetMethod);

            var deploymentGetMethod = typeof(RenameGetListClient).GetMethod("GetDeployment");
            Assert.AreNotEqual(null, deploymentGetMethod);
        }

        [Test]
        public void RenameListMethod()
        {
            var listMethod = typeof(RenameGetListClient).GetMethod("List");
            Assert.AreEqual(null, listMethod);

            var projectListMethod = typeof(RenameGetListClient).GetMethod("GetProjects");
            Assert.AreNotEqual(null, projectListMethod);

            var deploymentListMethod = typeof(RenameGetListClient).GetMethod("GetDeployments");
            Assert.AreNotEqual(null, deploymentListMethod);
        }

    }
}
