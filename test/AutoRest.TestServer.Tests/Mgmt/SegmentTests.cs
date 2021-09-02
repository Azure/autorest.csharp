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
    internal class SegmentTests
    {
        [TestCase("something", "something")]
        public void TestConstantSegment(string value, string expected)
        {
            Segment result = value;
            Assert.IsTrue(result.IsConstant);
            Assert.AreEqual(expected, result.Constant);
        }

        [TestCase("{something}", "something")]
        public void TestParseAsReference(string value, string expected)
        {
            Segment result = value;
            Assert.IsFalse(result.IsConstant);
            Assert.AreEqual(expected, result.ReferenceName);
        }

        [TestCase("/subscriptions/{subscriptionId}")]
        [TestCase("/subscriptions")]
        public void TestParseInvalid(string value)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Segment result = value;
            });
        }
    }
}
