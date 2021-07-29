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

        [TestCase("Model1Data", false)]
        [TestCase("Model1Update", false)]
        [TestCase("Model1ListResult", false)]
        [TestCase("Model2Data", true)]
        [TestCase("ModelX", true)]
        [TestCase("ModelY", true)]
        [TestCase("Model3", true)]
        public void ValidateOperationGroupExistence(string className, bool isExist)
        {
            Assert.AreEqual(isExist, CheckExistence(className));
        }

        private bool CheckExistence(string className)
        {
            if (Type.GetType(GetTypeName(className)) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string GetTypeName(string className)
        {
            string @namespace = "OmitOperationGroups";

            return className.EndsWith("Data") ? String.Format("{0}.{1}", @namespace, className) : String.Format("{0}.{1}.{2}", @namespace, "Models", className);
        }
    }
}
