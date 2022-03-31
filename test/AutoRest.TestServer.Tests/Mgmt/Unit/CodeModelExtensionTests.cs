// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.Unit
{
    internal class CodeModelExtensionTests
    {
        private static readonly List<string> EnumValuesShouldBePrompted = new()
        {
            "None",
            "NotSet",
            "Unknown",
            "NotSpecified",
            "Unspecified",
            "Undefined"
        };

        [TestCase]
        public void ValidateRearrangeChoicesWithNoneMatch()
        {
            var input = new[] { "A", "B", "C", "D" };
            var expected = new[] { "A", "B", "C", "D" };
            ValidateRearrangeChoices(expected, input);
        }

        [TestCase]
        public void ValidateRearrangeChoicesWithOneMatch()
        {
            var input = new[] { "A", "B", "C", "None" };
            var expected = new[] { "None", "A", "B", "C" };
            ValidateRearrangeChoices(expected, input);
        }

        [TestCase("ManagedServiceIdentity", "ManagedServiceIdentityType", "IdentityType")]
        [TestCase("ManagedServiceIdentity", "ManagedServiceIdentity7Type", "Identity7Type")]
        [TestCase("ResourceTypeAliasPathMetadata", "ResourceTypeAliasPathTokenType", "TokenType")]
        [TestCase("JitApproverDefinition", "JitApproverType", "ApproverType")]
        [TestCase("JitSchedulingPolicy", "JitSchedulingType", "SchedulingType")]
        [TestCase("JitScheduling", "JitSchedulingType", "SchedulingType")]
        [TestCase("JitSchedulingPolicy", "JitScheduling", "JitScheduling")]
        [TestCase("JitSchedulingPolicy", "JitSchedulingPolicy", "SchedulingPolicy")]
        [TestCase("JitSchedulingPolicy", "Scheduling7Policy", "Scheduling7Policy")]
        [TestCase("Jit7SchedulingPolicy", "Jit7Scheduling", "Jit7Scheduling")]
        [TestCase("JitSchedulingPolicy", "Jit", "Jit")]
        [TestCase("JitSchedulingPolicy", "ManagedServiceIdentityType", "IdentityType")]
        [TestCase("JitSchedulingPolicy", "JitApproverType", "ApproverType")]
        [TestCase("JitSchedulingPolicy", "JitApprover7Type", "Approver7Type")]
        [TestCase("ManagedServiceIdentity", "JitApproverType", "ApproverType")]
        [TestCase("Identity", "JitApproverType", "ApproverType")]
        [TestCase("Identity", "JitApprover7Type", "Approver7Type")]
        public void ValidateGetTypePropertyName(string parentName, string propertyTypeName, string expected)
        {
            var typePropertyName = CodeModelExtension.GetEnclosingTypeName(parentName, propertyTypeName);
            Assert.AreEqual(expected, typePropertyName);
        }

        [TestCase]
        public void ValidateRearrangeChoicesWithMultipleMatches()
        {
            var input = new[] { "A", "B", "NotSet", "C", "None" };
            var expected = new[] { "None", "NotSet", "A", "B", "C" };
            ValidateRearrangeChoices(expected, input);
        }

        private static void ValidateRearrangeChoices(IEnumerable<string> expected, IEnumerable<string> input)
        {
            var choiceValues = input.Select(v => GetChoiceValue(v)).ToList();
            var results = CodeModelExtension.RearrangeChoices(choiceValues, EnumValuesShouldBePrompted);
            CollectionAssert.AreEquivalent(expected, results.Select(c => c.CSharpName()));
        }

        private static ChoiceValue GetChoiceValue(string value)
        {
            return new ChoiceValue
            {
                Language = new Languages
                {
                    Default = new Language
                    {
                        Name = value
                    }
                }
            };
        }
    }
}
