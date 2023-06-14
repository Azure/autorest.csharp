// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Account.Samples
{
    internal class Samples_PurviewAccountResourceSetRules
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetResourceSetRule()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = client.GetResourceSetRule();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetResourceSetRule_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = client.GetResourceSetRule();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("modifiedAt").ToString());
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("resourceSetProcessing").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("typeName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("enableDefaultPatterns").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("dynamicReplacement").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("entityTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("version").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("condition").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("bindingUrl").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("isResourceSet").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("qualifiedName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("storeType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("version").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetResourceSetRule_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.GetResourceSetRuleAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetResourceSetRule_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.GetResourceSetRuleAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("modifiedAt").ToString());
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("resourceSetProcessing").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("typeName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("enableDefaultPatterns").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("dynamicReplacement").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("entityTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("version").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("condition").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("bindingUrl").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("isResourceSet").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("qualifiedName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("storeType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("version").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdateResourceSetRule()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            var data = new { };

            Response response = client.CreateOrUpdateResourceSetRule(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdateResourceSetRule_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            var data = new
            {
                advancedResourceSet = new
                {
                    modifiedAt = "2022-05-10T18:57:31.2311892Z",
                    resourceSetProcessing = "Default",
                },
                pathPatternConfig = new
                {
                    acceptedPatterns = new[] {
            new {
                createdBy = "<createdBy>",
                filterType = "Pattern",
                lastUpdatedTimestamp = 1234L,
                modifiedBy = "<modifiedBy>",
                name = "<name>",
                path = "<path>",
            }
        },
                    complexReplacers = new[] {
            new {
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
                    normalizationRules = new[] {
            new {
                description = "<description>",
                disabled = true,
                dynamicReplacement = true,
                entityTypes = new[] {
                    "<String>"
                },
                lastUpdatedTimestamp = 1234L,
                name = "<name>",
                regex = new {
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
                version = 123.45d,
            }
        },
                    regexReplacers = new[] {
            new {
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
                    rejectedPatterns = new[] {
            new {
                createdBy = "<createdBy>",
                filterType = "Pattern",
                lastUpdatedTimestamp = 1234L,
                modifiedBy = "<modifiedBy>",
                name = "<name>",
                path = "<path>",
            }
        },
                    scopedRules = new[] {
            new {
                bindingUrl = "<bindingUrl>",
                rules = new[] {
                    new {
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
            };

            Response response = client.CreateOrUpdateResourceSetRule(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("modifiedAt").ToString());
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("resourceSetProcessing").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("typeName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("enableDefaultPatterns").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("dynamicReplacement").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("entityTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("version").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("condition").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("bindingUrl").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("isResourceSet").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("qualifiedName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("storeType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("version").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdateResourceSetRule_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            var data = new { };

            Response response = await client.CreateOrUpdateResourceSetRuleAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdateResourceSetRule_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            var data = new
            {
                advancedResourceSet = new
                {
                    modifiedAt = "2022-05-10T18:57:31.2311892Z",
                    resourceSetProcessing = "Default",
                },
                pathPatternConfig = new
                {
                    acceptedPatterns = new[] {
            new {
                createdBy = "<createdBy>",
                filterType = "Pattern",
                lastUpdatedTimestamp = 1234L,
                modifiedBy = "<modifiedBy>",
                name = "<name>",
                path = "<path>",
            }
        },
                    complexReplacers = new[] {
            new {
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
                    normalizationRules = new[] {
            new {
                description = "<description>",
                disabled = true,
                dynamicReplacement = true,
                entityTypes = new[] {
                    "<String>"
                },
                lastUpdatedTimestamp = 1234L,
                name = "<name>",
                regex = new {
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
                version = 123.45d,
            }
        },
                    regexReplacers = new[] {
            new {
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
                    rejectedPatterns = new[] {
            new {
                createdBy = "<createdBy>",
                filterType = "Pattern",
                lastUpdatedTimestamp = 1234L,
                modifiedBy = "<modifiedBy>",
                name = "<name>",
                path = "<path>",
            }
        },
                    scopedRules = new[] {
            new {
                bindingUrl = "<bindingUrl>",
                rules = new[] {
                    new {
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
            };

            Response response = await client.CreateOrUpdateResourceSetRuleAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("modifiedAt").ToString());
            Console.WriteLine(result.GetProperty("advancedResourceSet").GetProperty("resourceSetProcessing").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("acceptedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("complexReplacers")[0].GetProperty("typeName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("enableDefaultPatterns").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("dynamicReplacement").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("entityTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("normalizationRules")[0].GetProperty("version").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("condition").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disabled").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("disableRecursiveReplacerApplication").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("doNotReplaceRegex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("maxLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDashes").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigits").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDigitsOrLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minDots").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minHex").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minLetters").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("minUnderscores").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("options").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("regex").GetProperty("regexStr").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("regexReplacers")[0].GetProperty("replaceWith").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("filterType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("modifiedBy").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("rejectedPatterns")[0].GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("bindingUrl").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("isResourceSet").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("lastUpdatedTimestamp").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("rules")[0].GetProperty("qualifiedName").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("scopedRules")[0].GetProperty("storeType").ToString());
            Console.WriteLine(result.GetProperty("pathPatternConfig").GetProperty("version").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteResourceSetRule()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = client.DeleteResourceSetRule();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteResourceSetRule_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = client.DeleteResourceSetRule();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteResourceSetRule_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.DeleteResourceSetRuleAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteResourceSetRule_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new PurviewAccountsClient(endpoint, credential).GetResourceSetRulesClient();

            Response response = await client.DeleteResourceSetRuleAsync();
            Console.WriteLine(response.Status);
        }
    }
}
