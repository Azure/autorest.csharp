using NUnit.Framework;

namespace AutoRest.CSharp.Utilities
{
    public class StringExtensionsTests
    {
        [TestCase("container", "containers")]
        [TestCase("operation", "operations")]
        [TestCase("test", "tests")]
        [TestCase("boy", "boys")]
        [TestCase("policy", "policies")]
        [TestCase("life", "lives")]
        [TestCase("toe", "toes")]
        [TestCase("shoe", "shoes")]
        [TestCase("bus", "buses")]
        [TestCase("bush", "bushes")]
        public void ValidatePluralForm(string noun, string expected)
        {
            var plural = noun.ToPlural();
            Assert.AreEqual(expected, plural);
        }
    }
}
