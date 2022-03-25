// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AutoRest.CSharp.MgmtTest.TestCommon;

namespace AutoRest.TestServer.Tests.MgmtTest
{
    public class StringExtensionsTests
    {
        [Test]
        public void TestRefScenarioDefinedVariablesToString()
        {
            var scenarioDefinedVariables = new List<string> {
                "variable1",
                "variable2",
            };
            Assert.AreEqual("".RefScenarioDefinedVariablesToString(scenarioDefinedVariables), "");
            Assert.AreEqual("{'abc': '$(variable1)'}".RefScenarioDefinedVariablesToString(scenarioDefinedVariables), "{{'abc': '{variable1}'}}");
            Assert.AreEqual("..$(variable1).$(variable2).$(variable3).$variable2).${variable2}".RefScenarioDefinedVariablesToString(scenarioDefinedVariables), "..{variable1}.{variable2}.$(variable3).$variable2).${{variable2}}");
            Assert.AreEqual("..$(variable1).$(variable2).$(variable3).$variable2).${variable2}".RefScenarioDefinedVariablesToString(Enumerable.Empty<string>()), "..$(variable1).$(variable2).$(variable3).$variable2).${{variable2}}");
        }

        [Test]
        public void TestRefScenarioDefinedVariables()
        {
            var scenarioDefinedVariables = new List<string> {
                "variable1",
                "variable2",
            };
            Assert.AreEqual("".RefScenarioDefinedVariables(scenarioDefinedVariables).ToString(), "");
            Assert.AreEqual("{'abc': '$(variable1)'}".RefScenarioDefinedVariables(scenarioDefinedVariables).ToString(), "${{'abc': '{variable1}'}}");
            Assert.AreEqual("{'abc': '$(variable3)'}".RefScenarioDefinedVariables(scenarioDefinedVariables).ToString(), "{'abc': '$(variable3)'}");
            Assert.AreEqual("{'abc': '$(variable3)'}".RefScenarioDefinedVariables(null).ToString(), "{'abc': '$(variable3)'}");
        }

        [Test]
        public void TestToSnakeCase()
        {
            Assert.AreEqual("".ToSnakeCase(), "");
            Assert.AreEqual("I".ToSnakeCase(), "i");
            Assert.AreEqual("IAmHere".ToSnakeCase(), "i_am_here");
            Assert.AreEqual("iAmHere".ToSnakeCase(), "i_am_here");
        }
    }
}
