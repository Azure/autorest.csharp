using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ResourceRename;
using ResourceRename.Models;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ResourceRenameTests : TestProjectTests
    {
        public ResourceRenameTests() : base("ResourceRename") { }

        [Test]
        public void RenamedModelExists()
        {
            var modelType = typeof(SshPublicKeyInfo);
            Assert.NotNull(modelType);
        }

        [Test]
        public void OldModelDoesNotExist()
        {
            var modelType = typeof(SshPublicKeyInfo);
            Assert.Null(modelType.Assembly.GetType("SshPublicKeyResource"));
        }
    }
}
