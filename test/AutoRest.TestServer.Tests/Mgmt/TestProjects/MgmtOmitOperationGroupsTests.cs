using System;
using System.Reflection;
using MgmtOmitOperationGroups;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtOmitOperationGroupTests : TestProjectTests
    {
        public MgmtOmitOperationGroupTests()
            : base("MgmtOmitOperationGroups")
        {
        }

        private protected override Assembly GetAssembly() => typeof(Model2Data).Assembly;

        [TestCase("Model1Data", false)]
        [TestCase("Model1Update", false)]
        [TestCase("Model1ListResult", false)]
        [TestCase("Model2Data", true)]
        [TestCase("ModelX", true)]
        [TestCase("ModelY", true)]
        [TestCase("Model4Data", false)]
        [TestCase("Model5Data", false)]
        [TestCase("ModelZ", true)]
        [TestCase("ModelQ", true)]
        [TestCase("ModelP", false)]
        public void ValidateOperationGroupExistence(string className, bool isExist)
        {
            Assert.AreEqual(isExist, CheckExistence(className));
        }

        private bool CheckExistence(string className)
        {
            return GetType(className) is not null;
        }
    }
}
