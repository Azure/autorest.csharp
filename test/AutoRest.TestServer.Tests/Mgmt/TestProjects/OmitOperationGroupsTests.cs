using System;
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
            for (int i = 0; i < notExist.Length; i++)
            {
                Assert.IsNull(Type.GetType(GetTypeName(notExist[i])));
            }
            for (int i = 0; i < doesExist.Length; i++)
            {
                string name = GetTypeName(doesExist[i]);
                Assert.IsNotNull(Type.GetType(name));
            }
        }

        private string GetTypeName(string className)
        {
            string @namespace = "OmitOperationGroups";

            return className.EndsWith("Data") ? String.Format("{0}.{1}", @namespace, className) : String.Format("{0}.{1}.{2}", @namespace, "Models", className);
        }
    }
}
