// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Shared;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt
{
    internal class FormattableResourceTypeTests
    {
        [TestCase("something")]
        public void TestParseStringAsConstant(string value)
        {
            var result = FormattableResourceType.ParseString(value);
            Assert.IsTrue(result.IsConstant);
            Assert.AreEqual(value, result.Constant.Value);
        }


    }
}
