using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class OmitOperationGroupTests : TestProjectTests
    {
        public OmitOperationGroupTests()
            : base("OmitOperationGroups")
        {
        }

        [TestCase(new string[] { "Model1Data", "Model1Update", "Model1ListResult" }, new string[] { "Model2Data", "ModelX", "ModelY", "Model3" })]
        public void ValidateOperationGroupExistence(string[] notExist, string[] doesExist)
        {
            string @namespace = "OmitOperationGroups";
            for (int i = 0; i < notExist.Length; i++)
            {
                Assert.IsNull(Type.GetType(String.Format("{0}.{1}", @namespace, notExist[i])));
            }
            for (int i = 0; i < doesExist.Length; i++)
            {
                Assert.IsNotNull(Type.GetType(String.Format("{0}.{1}", @namespace, doesExist[i])));
            }
        }
    }
}
