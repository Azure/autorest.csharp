using System.Linq;
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
        [TestCase("child", "children")]
        [TestCase("data", "data", false)]
        [TestCase("dataTip", "dataTips")]
        [TestCase("tipData", "tipDatas")]
        [TestCase("da_ta", "da_tas")]
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
        [TestCase("children", "child")]
        [TestCase("data", "data", false)]
        [TestCase("datas", "data", false)]
        public void ValidateSingularize(string noun, string expected, bool inputIsKnownToBePlural = true)
        {
            var singular = noun.ToSingular(inputIsKnownToBePlural);
            Assert.AreEqual(expected, singular);
        }

        [TestCase("CamelCase", new[] { "Camel", "Case" })]
        [TestCase("IPAddress", new[] { "IP", "Address" })]
        [TestCase("HTTPIsURL", new[] { "HTTP", "Is", "URL" })]
        [TestCase("GetAllByLocation", new[] { "Get", "All", "By", "Location" })]
        [TestCase("snake_case", new[] { "Snake", "Case" })]
        [TestCase("single", new[] { "Single" })]
        [TestCase("", new[] { "" })]
        [TestCase("_", new[] { "", "" })]
        public void ValidateSplitByCamelCase(string camelCase, string[] expected)
        {
            var result = camelCase.SplitByCamelCase().ToArray();
            Assert.AreEqual(expected.Length, result.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCase("PropertyName", false, "propertyName")]
        [TestCase("PropertyName", true, "PropertyName")]
        [TestCase("_propertyName", false, "propertyName")]
        [TestCase("_propertyName", true, "PropertyName")]
        [TestCase("_property_name", false, "propertyName")]
        [TestCase("_property_name", true, "PropertyName")]
        public void ValidateToCleanName(string name, bool camelCase, string expected)
        {
            var result = name.ToCleanName(camelCase);
            Assert.AreEqual(expected, result);
        }

        [TestCase("MetadataRole", "MetadataRoles", true)]
        [TestCase("MetadataRole", "MetadataRoles", false)]
        [TestCase("MetadataRoles", "MetadataRoles", true)]
        [TestCase("MetadataRoles", "MetadataRoles", false)]
        [TestCase("KeyInformation", "KeyInformation", true)]
        [TestCase("KeyInformation", "KeyInformation", false)]
        [TestCase("RoleMetadata", "RoleMetadata", true)]
        [TestCase("RoleMetadata", "RoleMetadata", false)]
        [TestCase("MetadataPolicy", "MetadataPolicies", true)]
        [TestCase("MetadataPolicy", "MetadataPolicies", false)]
        [TestCase("MetadataPolicies", "MetadataPolicies", true)]
        [TestCase("MetadataPolicies", "MetadataPolicies", false)]
        [TestCase("TipData", "TipData", true)]
        [TestCase("TipData", "TipData", false)]
        public void ValidateLastWordToPlural(string resourceName, string expected, bool inputKnownToBeSingular = true)
        {
            var result = resourceName.LastWordToPlural(inputKnownToBeSingular);
            Assert.AreEqual(expected, result);
        }

        [TestCase("MetadataRoles", "MetadataRole", true)]
        [TestCase("MetadataRoles", "MetadataRole", false)]
        [TestCase("MetadataRoles", "MetadataRole", true)]
        [TestCase("MetadataRoles", "MetadataRole", false)]
        [TestCase("KeyInformation", "KeyInformation", true)]
        [TestCase("KeyInformation", "KeyInformation", false)]
        [TestCase("RoleMetadata", "RoleMetadata", true)]
        [TestCase("RoleMetadata", "RoleMetadata", false)]
        [TestCase("MetadataPolicy", "MetadataPolicy", true)]
        [TestCase("MetadataPolicy", "MetadataPolicy", false)]
        [TestCase("MetadataPolicies", "MetadataPolicy", true)]
        [TestCase("MetadataPolicies", "MetadataPolicy", false)]
        [TestCase("TipData", "TipData", true)]
        [TestCase("TipData", "TipData", false)]
        [TestCase("Extensions", "Extension", true)]
        [TestCase("Extensions", "Extension", false)]
        public void ValidateLastWordToSingular(string resourceName, string expected, bool inputKnownToBePlural = true)
        {
            var result = resourceName.LastWordToSingular(inputKnownToBePlural);
            Assert.AreEqual(expected, result);
        }

        [TestCase("List", "MetadataRoles", "GetMetadataRoles")]
        [TestCase("ListAll", "MetadataPolicy", "GetMetadataPolicies")]
        [TestCase("ListCollection", "Collections", "GetCollections")]
        [TestCase("ListChildCollectionNames", "Collections", "GetChildCollectionNames")]
        [TestCase("ListByGuids", "Entity", "GetEntitiesByGuids")]
        [TestCase("ListEntitiesAssignedWithTerm", "Glossary", "GetEntitiesAssignedWithTerm")]
        [TestCase("ListTermsByGlossaryName", "Glossary", "GetTermsByGlossaryName")]
        [TestCase("ListMyListings", "Glossary", "GetMyListings")]
        [TestCase("ListBlobContainerBlob", "StorageBlob", "GetBlobContainerBlobs")]
        [TestCase("List", "ApplicationData", "GetAllApplicationData")]
        [TestCase("ListByFarmerId", "ApplicationData", "GetAllApplicationDataByFarmerId")]
        [TestCase("ListDataTip", "", "GetDataTips")]
        [TestCase("ListTipData", "", "GetAllTipData")]
        public void ValidateRenameListToGet(string methodName, string resourceName, string expected)
        {
            var result = methodName.RenameListToGet(resourceName);
            Assert.AreEqual(expected, result);
        }

        [TestCase("Get", "ApplicationData", "GetApplicationData")]
        [TestCase("GetMyData", "ApplicationData", "GetMyData")]
        [TestCase("Get", "DataTips", "GetDataTip")]
        [TestCase("Get", "TipData", "GetTipData")]
        public void ValidateRenameGetMethod(string methodName, string resourceName, string expected)
        {
            var result = methodName.RenameGetMethod(resourceName);
            Assert.AreEqual(expected, result);
        }

        [TestCase("ListMyListings", "List", "Get", "GetMyListings")]
        [TestCase("ListEntity", "Entity", "Entities", "ListEntities")]
        [TestCase("CreateEntity", "List", "Get", "CreateEntity")]
        public void ValidateReplaceFirst(string text, string oldValue, string newValue, string expected)
        {
            var result = text.ReplaceFirst(oldValue, newValue);
            Assert.AreEqual(expected, result);
        }

        [TestCase("ListBlobContainerBlob", "Blob", "Blobs", "ListBlobContainerBlobs")]
        [TestCase("ListEntity", "Entity", "Entities", "ListEntities")]
        [TestCase("CreateEntity", "List", "Get", "CreateEntity")]
        public void ValidateReplaceLast(string text, string oldValue, string newValue, string expected)
        {
            var result = text.ReplaceLast(oldValue, newValue);
            Assert.AreEqual(expected, result);
        }
    }
}
