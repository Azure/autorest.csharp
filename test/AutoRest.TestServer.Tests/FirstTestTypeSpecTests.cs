// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class FirstTestTypeSpecTests
    {
        [Test]
        public void ModelForUnionShouldBePublic()
        {
            // ModelForUnion is not used anywhere in the public API, as a property type or parameter type or field type or any other approach of being part of public API.
            // but this model is used in description of `RoundTripModel.UnionList` property, as part of the xml doc
            // for the purpose of documentation, and for the convenience of our generated library users to use the BinaryData type, we need to keep this type public despite it is not publicly used on APIs.
            Assert.IsTrue(typeof(ModelForUnion).IsPublic);
        }

        [TestCase("a", "A", true)]
        [TestCase("A", "A", true)]
        [TestCase("A", "B", false)]
        public void ExtensibleEnumIgnoreCasing(string v1, string v2, bool expected)
        {
            var e1 = new StringExtensibleEnum(v1);
            var e2 = new StringExtensibleEnum(v2);
            Assert.AreEqual(expected, e1.Equals(e2));
        }

        [TestCaseSource(nameof(ExtensibleEnumData))]
        public void ExtensibleEnumInHashSet(string[] values, int expectedCount)
        {
            var enums = values.Select(v => new StringExtensibleEnum(v));
            var set = new HashSet<StringExtensibleEnum>(enums);
            foreach (var e in enums)
            {
                Assert.IsTrue(set.Contains(e));
            }

            Assert.AreEqual(expectedCount, set.Count);
        }

        [Test]
        public void ExtensibleEnumCanHandleNullValue()
        {
            StringExtensibleEnum e = default;
            var field = typeof(StringExtensibleEnum).GetField("_value", BindingFlags.NonPublic | BindingFlags.Instance);
            var value = field.GetValue(e);

            Assert.IsNull(value);
            Assert.AreEqual(0, e.GetHashCode());
        }

        private static object[] ExtensibleEnumData = new object[] {
            new object[] {
                new string[]
                {
                    "a", "A", "foo", "fOO"
                },
                2
            }
        };
    }
}
