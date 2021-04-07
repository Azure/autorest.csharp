using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ResourceRename;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class ResourceRenameTests
    {
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
