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
        [TestCase("", "")]
        [TestCase("{'abc': '$(variable1)'}", "{{'abc': '{variable1}'}}")]
        [TestCase("..$(variable1).$(variable2).$(variable3).$variable2).${variable2}", "..{variable1}.{variable2}.$(variable3).$variable2).${{variable2}}")]
        public void TestRefScenarioDefinedVariablesToString(string input, string expected)
        {
            var scenarioDefinedVariables = new List<string> {
                "variable1",
                "variable2",
            };
            Assert.AreEqual(input.RefScenarioDefinedVariablesToString(scenarioDefinedVariables), expected);
        }

        [TestCase("", "")]
        [TestCase("{'abc': '$(variable1)'}", "${{'abc': '{variable1}'}}")]
        [TestCase("{'abc': '$(variable3)'}", "{'abc': '$(variable3)'}")]
        public void TestRefScenarioDefinedVariables(string input, string expected)
        {
            var scenarioDefinedVariables = new List<string> {
                "variable1",
                "variable2",
            };
            Assert.AreEqual(input.RefScenarioDefinedVariables(scenarioDefinedVariables).ToString(), expected);
            Assert.AreEqual(input.RefScenarioDefinedVariables(null).ToString(), input);
        }

        [TestCase("", "")]
        [TestCase("I", "i")]
        [TestCase("IAmHere", "i_am_here")]
        [TestCase("iAmHere", "i_am_here")]
        public void TestToSnakeCase(string input, string expected)
        {
            Assert.AreEqual(input.ToSnakeCase(), expected);

        }
    }
}
