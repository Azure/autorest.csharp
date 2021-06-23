using NUnit.Framework;

namespace AutoRest.CSharp.Utilities
{
    public class StringExtensionsTests
    {
        [TestCase("container", "containers")]
        [TestCase("operation", "operations")]
        [TestCase("containers", "containers", false)]
        [TestCase("operations", "operations", false)]
        [TestCase("test", "tests")]
        [TestCase("boy", "boys")]
        [TestCase("policy", "policies")]
        [TestCase("life", "lives")]
        [TestCase("shoe", "shoes")]
        [TestCase("bus", "buses")]
        [TestCase("bush", "bushes")]
        [TestCase("information", "information")]
        [TestCase("person", "people")]
        [TestCase("sheep", "sheep")]
        [TestCase("people", "people", false)]
        public void ValidatePluralize(string noun, string expected, bool inputIsKnownToBeSingle = true)
        {
            var plural = noun.ToPlural(inputIsKnownToBeSingle);
            Assert.AreEqual(expected, plural);
        }

        [TestCase("containers", "container")]
        [TestCase("operations", "operation")]
        [TestCase("container", "container", false)]
        [TestCase("operations", "operation", false)]
        [TestCase("tests", "test")]
        [TestCase("boys", "boy")]
        [TestCase("policies", "policy")]
        [TestCase("lives", "life")]
        [TestCase("shoes", "shoe")]
        [TestCase("buses", "bus")]
        [TestCase("bushes", "bush")]
        [TestCase("information", "information")]
        [TestCase("person", "person", false)]
        [TestCase("sheep", "sheep")]
        [TestCase("people", "person")]
        public void ValidateSingularize(string noun, string expected, bool inputIsKnownToBePlural = true)
        {
            var plural = noun.ToSingular(inputIsKnownToBePlural);
            Assert.AreEqual(expected, plural);
        }
    }
}
