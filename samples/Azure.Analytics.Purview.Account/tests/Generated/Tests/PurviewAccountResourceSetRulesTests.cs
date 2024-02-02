// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Analytics.Purview.Account;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Account.Tests
{
    public partial class PurviewAccountResourceSetRulesTests : AnalyticsPurviewAccountTestBase
    {
        public PurviewAccountResourceSetRulesTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetResourceSetRule_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountResourceSetRules client = CreatePurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.GetResourceSetRuleAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetResourceSetRule_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountResourceSetRules client = CreatePurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.GetResourceSetRuleAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CreateOrUpdateResourceSetRule_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountResourceSetRules client = CreatePurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.CreateOrUpdateResourceSetRuleAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CreateOrUpdateResourceSetRule_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountResourceSetRules client = CreatePurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            using RequestContent content = RequestContent.Create(new
            {
                advancedResourceSet = new
                {
                    modifiedAt = "2022-05-10T18:57:31.2311892Z",
                    resourceSetProcessing = "Default",
                },
                pathPatternConfig = new
                {
                    acceptedPatterns = new object[]
            {
new
{
createdBy = "<createdBy>",
filterType = "Pattern",
lastUpdatedTimestamp = 1234L,
modifiedBy = "<modifiedBy>",
name = "<name>",
path = "<path>",
}
            },
                    complexReplacers = new object[]
            {
new
{
createdBy = "<createdBy>",
description = "<description>",
disabled = true,
disableRecursiveReplacerApplication = true,
lastUpdatedTimestamp = 1234L,
modifiedBy = "<modifiedBy>",
name = "<name>",
typeName = "<typeName>",
}
            },
                    createdBy = "<createdBy>",
                    enableDefaultPatterns = true,
                    lastUpdatedTimestamp = 1234L,
                    modifiedBy = "<modifiedBy>",
                    normalizationRules = new object[]
            {
new
{
description = "<description>",
disabled = true,
dynamicReplacement = true,
entityTypes = new object[]
{
"<entityTypes>"
},
lastUpdatedTimestamp = 1234L,
name = "<name>",
regex = new
{
maxDigits = 1234,
maxLetters = 1234,
minDashes = 1234,
minDigits = 1234,
minDigitsOrLetters = 1234,
minDots = 1234,
minHex = 1234,
minLetters = 1234,
minUnderscores = 1234,
options = 1234,
regexStr = "<regexStr>",
},
replaceWith = "<replaceWith>",
version = 123.45,
}
            },
                    regexReplacers = new object[]
            {
new
{
condition = "<condition>",
createdBy = "<createdBy>",
description = "<description>",
disabled = true,
disableRecursiveReplacerApplication = true,
lastUpdatedTimestamp = 1234L,
modifiedBy = "<modifiedBy>",
name = "<name>",
replaceWith = "<replaceWith>",
}
            },
                    rejectedPatterns = new object[]
            {
null
            },
                    scopedRules = new object[]
            {
new
{
bindingUrl = "<bindingUrl>",
rules = new object[]
{
new
{
displayName = "<displayName>",
isResourceSet = true,
lastUpdatedTimestamp = 1234L,
name = "<name>",
qualifiedName = "<qualifiedName>",
}
},
storeType = "<storeType>",
}
            },
                    version = 1234,
                },
            });
            Response response = await client.CreateOrUpdateResourceSetRuleAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeleteResourceSetRule_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountResourceSetRules client = CreatePurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.DeleteResourceSetRuleAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DeleteResourceSetRule_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountResourceSetRules client = CreatePurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.DeleteResourceSetRuleAsync();
        }
    }
}
