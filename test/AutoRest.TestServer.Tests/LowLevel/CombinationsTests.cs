// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.LowLevel.Helpers;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.LowLevel
{
    public class CombinationsTests
    {
        [Test]
        public void ValidateCombinations()
        {
            IEnumerable<IEnumerable<int>> input = new[] { new int[] { 1, 2 }, new int[] { 3, 4, 5 } };
            IEnumerable<IEnumerable<int>> expected = new[] { new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 2, 5 } };

            var result = CollectionHelpers.GetCombinations(input);
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
