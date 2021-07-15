using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtListMethods : TestProjectTests
    {
        public MgmtListMethods() : base("MgmtListMethods") { }

        [Ignore("Waiting for the fix for List functions not showing up")]
        [TestCase("TheExtensionContainer", "ListUsages", false)]
        [TestCase("TheExtensionContainer", "ListFeatures", false)]
        [TestCase("TheExtensionOperations", "ListUsages", true)]
        [TestCase("TheExtensionOperations", "ListFeatures", true)]
        [TestCase("TheExtensionFakeContainer", "ListUsages", false)]
        [TestCase("TheExtensionFakeContainer", "ListFeatures", false)]
        [TestCase("TheExtensionFakeOperations", "ListUsages", true)]
        [TestCase("TheExtensionFakeOperations", "ListFeatures", true)]
        public void ValidateListOfNonResourceMethod(string operationOrContainerName, string methodName, bool exist)
        {
            var classesToCheck = FindAllContainers().Concat(FindAllOperations());
            var classToCheck = classesToCheck.First(t => t.Name == operationOrContainerName);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {operationOrContainerName}.{methodName}");
        }
    }
}
