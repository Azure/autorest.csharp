// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AnomalyDetector.Models;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace AnomalyDetector.Samples
{
    public class Samples_AnomalyDetectorClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectUnivariateEntireSeries()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            value = 123.45f,
        }
    },
            };

            Response response = client.DetectUnivariateEntireSeries(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("expectedValues")[0].ToString());
            Console.WriteLine(result.GetProperty("upperMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("lowerMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("isAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectUnivariateEntireSeries_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            timestamp = "2022-05-10T14:57:31.2311892-04:00",
            value = 123.45f,
        }
    },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                maxAnomalyRatio = 123.45f,
                sensitivity = 1234,
                imputeMode = "auto",
                imputeFixedValue = 123.45f,
            };

            Response response = client.DetectUnivariateEntireSeries(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("expectedValues")[0].ToString());
            Console.WriteLine(result.GetProperty("upperMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("lowerMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("isAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("severity")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateEntireSeries_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            value = 123.45f,
        }
    },
            };

            Response response = await client.DetectUnivariateEntireSeriesAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("expectedValues")[0].ToString());
            Console.WriteLine(result.GetProperty("upperMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("lowerMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("isAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateEntireSeries_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            timestamp = "2022-05-10T14:57:31.2311892-04:00",
            value = 123.45f,
        }
    },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                maxAnomalyRatio = 123.45f,
                sensitivity = 1234,
                imputeMode = "auto",
                imputeFixedValue = 123.45f,
            };

            Response response = await client.DetectUnivariateEntireSeriesAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("expectedValues")[0].ToString());
            Console.WriteLine(result.GetProperty("upperMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("lowerMargins")[0].ToString());
            Console.WriteLine(result.GetProperty("isAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly")[0].ToString());
            Console.WriteLine(result.GetProperty("severity")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateEntireSeries_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var options = new UnivariateDetectionOptions(new TimeSeriesPoint[]
            {
    new TimeSeriesPoint(3.14f)
{
        Timestamp = DateTimeOffset.UtcNow,
    }
            })
            {
                Granularity = TimeGranularity.Yearly,
                CustomInterval = 1234,
                Period = 1234,
                MaxAnomalyRatio = 3.14f,
                Sensitivity = 1234,
                ImputeMode = ImputeMode.Auto,
                ImputeFixedValue = 3.14f,
            };
            var result = await client.DetectUnivariateEntireSeriesAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectUnivariateLastPoint()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            value = 123.45f,
        }
    },
            };

            Response response = client.DetectUnivariateLastPoint(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("suggestedWindow").ToString());
            Console.WriteLine(result.GetProperty("expectedValue").ToString());
            Console.WriteLine(result.GetProperty("upperMargin").ToString());
            Console.WriteLine(result.GetProperty("lowerMargin").ToString());
            Console.WriteLine(result.GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectUnivariateLastPoint_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            timestamp = "2022-05-10T14:57:31.2311892-04:00",
            value = 123.45f,
        }
    },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                maxAnomalyRatio = 123.45f,
                sensitivity = 1234,
                imputeMode = "auto",
                imputeFixedValue = 123.45f,
            };

            Response response = client.DetectUnivariateLastPoint(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("suggestedWindow").ToString());
            Console.WriteLine(result.GetProperty("expectedValue").ToString());
            Console.WriteLine(result.GetProperty("upperMargin").ToString());
            Console.WriteLine(result.GetProperty("lowerMargin").ToString());
            Console.WriteLine(result.GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly").ToString());
            Console.WriteLine(result.GetProperty("severity").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateLastPoint_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            value = 123.45f,
        }
    },
            };

            Response response = await client.DetectUnivariateLastPointAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("suggestedWindow").ToString());
            Console.WriteLine(result.GetProperty("expectedValue").ToString());
            Console.WriteLine(result.GetProperty("upperMargin").ToString());
            Console.WriteLine(result.GetProperty("lowerMargin").ToString());
            Console.WriteLine(result.GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateLastPoint_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            timestamp = "2022-05-10T14:57:31.2311892-04:00",
            value = 123.45f,
        }
    },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                maxAnomalyRatio = 123.45f,
                sensitivity = 1234,
                imputeMode = "auto",
                imputeFixedValue = 123.45f,
            };

            Response response = await client.DetectUnivariateLastPointAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("suggestedWindow").ToString());
            Console.WriteLine(result.GetProperty("expectedValue").ToString());
            Console.WriteLine(result.GetProperty("upperMargin").ToString());
            Console.WriteLine(result.GetProperty("lowerMargin").ToString());
            Console.WriteLine(result.GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isNegativeAnomaly").ToString());
            Console.WriteLine(result.GetProperty("isPositiveAnomaly").ToString());
            Console.WriteLine(result.GetProperty("severity").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateLastPoint_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var options = new UnivariateDetectionOptions(new TimeSeriesPoint[]
            {
    new TimeSeriesPoint(3.14f)
{
        Timestamp = DateTimeOffset.UtcNow,
    }
            })
            {
                Granularity = TimeGranularity.Yearly,
                CustomInterval = 1234,
                Period = 1234,
                MaxAnomalyRatio = 3.14f,
                Sensitivity = 1234,
                ImputeMode = ImputeMode.Auto,
                ImputeFixedValue = 3.14f,
            };
            var result = await client.DetectUnivariateLastPointAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectUnivariateChangePoint()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            value = 123.45f,
        }
    },
                granularity = "yearly",
            };

            Response response = client.DetectUnivariateChangePoint(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectUnivariateChangePoint_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            timestamp = "2022-05-10T14:57:31.2311892-04:00",
            value = 123.45f,
        }
    },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                stableTrendWindow = 1234,
                threshold = 123.45f,
            };

            Response response = client.DetectUnivariateChangePoint(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("isChangePoint")[0].ToString());
            Console.WriteLine(result.GetProperty("confidenceScores")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateChangePoint_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            value = 123.45f,
        }
    },
                granularity = "yearly",
            };

            Response response = await client.DetectUnivariateChangePointAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateChangePoint_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                series = new[] {
        new {
            timestamp = "2022-05-10T14:57:31.2311892-04:00",
            value = 123.45f,
        }
    },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                stableTrendWindow = 1234,
                threshold = 123.45f,
            };

            Response response = await client.DetectUnivariateChangePointAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("period").ToString());
            Console.WriteLine(result.GetProperty("isChangePoint")[0].ToString());
            Console.WriteLine(result.GetProperty("confidenceScores")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectUnivariateChangePoint_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var options = new UnivariateChangePointDetectionOptions(new TimeSeriesPoint[]
            {
    new TimeSeriesPoint(3.14f)
{
        Timestamp = DateTimeOffset.UtcNow,
    }
            }, TimeGranularity.Yearly)
            {
                CustomInterval = 1234,
                Period = 1234,
                StableTrendWindow = 1234,
                Threshold = 3.14f,
            };
            var result = await client.DetectUnivariateChangePointAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultivariateBatchDetectionResult()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = client.GetMultivariateBatchDetectionResult(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultivariateBatchDetectionResult_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = client.GetMultivariateBatchDetectionResult(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("severity").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("score").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("contributionScore").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("correlationChanges").GetProperty("changedVariables")[0].ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateBatchDetectionResult_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateBatchDetectionResultAsync(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateBatchDetectionResult_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateBatchDetectionResultAsync(Guid.NewGuid(), new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("severity").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("score").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("contributionScore").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("correlationChanges").GetProperty("changedVariables")[0].ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateBatchDetectionResult_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var result = await client.GetMultivariateBatchDetectionResultAsync(Guid.NewGuid());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TrainMultivariateModel()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "<dataSource>",
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = client.TrainMultivariateModel(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_TrainMultivariateModel_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "<dataSource>",
                dataSchema = "OneTable",
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
                displayName = "<displayName>",
                slidingWindow = 1234,
                alignPolicy = new
                {
                    alignMode = "Inner",
                    fillNAMethod = "Previous",
                    paddingValue = 123.45f,
                },
                status = "CREATED",
                diagnosticsInfo = new
                {
                    modelState = new
                    {
                        epochIds = new[] {
                1234
            },
                        trainLosses = new[] {
                123.45f
            },
                        validationLosses = new[] {
                123.45f
            },
                        latenciesInSeconds = new[] {
                123.45f
            },
                    },
                    variableStates = new[] {
            new {
                variable = "<variable>",
                filledNARatio = 123.45f,
                effectiveCount = 1234,
                firstTimestamp = "2022-05-10T14:57:31.2311892-04:00",
                lastTimestamp = "2022-05-10T14:57:31.2311892-04:00",
            }
        },
                },
            };

            Response response = client.TrainMultivariateModel(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSchema").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("slidingWindow").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("alignMode").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("fillNAMethod").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("paddingValue").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("epochIds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("trainLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("validationLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("latenciesInSeconds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TrainMultivariateModel_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "<dataSource>",
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = await client.TrainMultivariateModelAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TrainMultivariateModel_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "<dataSource>",
                dataSchema = "OneTable",
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
                displayName = "<displayName>",
                slidingWindow = 1234,
                alignPolicy = new
                {
                    alignMode = "Inner",
                    fillNAMethod = "Previous",
                    paddingValue = 123.45f,
                },
                status = "CREATED",
                diagnosticsInfo = new
                {
                    modelState = new
                    {
                        epochIds = new[] {
                1234
            },
                        trainLosses = new[] {
                123.45f
            },
                        validationLosses = new[] {
                123.45f
            },
                        latenciesInSeconds = new[] {
                123.45f
            },
                    },
                    variableStates = new[] {
            new {
                variable = "<variable>",
                filledNARatio = 123.45f,
                effectiveCount = 1234,
                firstTimestamp = "2022-05-10T14:57:31.2311892-04:00",
                lastTimestamp = "2022-05-10T14:57:31.2311892-04:00",
            }
        },
                },
            };

            Response response = await client.TrainMultivariateModelAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSchema").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("slidingWindow").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("alignMode").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("fillNAMethod").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("paddingValue").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("epochIds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("trainLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("validationLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("latenciesInSeconds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_TrainMultivariateModel_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var modelInfo = new ModelInfo("<dataSource>", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow)
            {
                DataSchema = DataSchema.OneTable,
                DisplayName = "<DisplayName>",
                SlidingWindow = 1234,
                AlignPolicy = new AlignPolicy()
                {
                    AlignMode = AlignMode.Inner,
                    FillNAMethod = FillNAMethod.Previous,
                    PaddingValue = 3.14f,
                },
                Status = ModelStatus.Created,
                DiagnosticsInfo = new DiagnosticsInfo()
                {
                    ModelState = new ModelState()
                    {
                        EpochIds =
{
                1234
            },
                        TrainLosses =
{
                3.14f
            },
                        ValidationLosses =
{
                3.14f
            },
                        LatenciesInSeconds =
{
                3.14f
            },
                    },
                    VariableStates =
{
            new VariableState()
{
                Variable = "<Variable>",
                FilledNARatio = 3.14f,
                EffectiveCount = 1234,
                FirstTimestamp = DateTimeOffset.UtcNow,
                LastTimestamp = DateTimeOffset.UtcNow,
            }
        },
                },
            };
            var result = await client.TrainMultivariateModelAsync(modelInfo);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteMultivariateModel()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = client.DeleteMultivariateModel("<modelId>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteMultivariateModel_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = client.DeleteMultivariateModel("<modelId>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteMultivariateModel_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = await client.DeleteMultivariateModelAsync("<modelId>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteMultivariateModel_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = await client.DeleteMultivariateModelAsync("<modelId>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultivariateModel()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = client.GetMultivariateModel("<modelId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultivariateModel_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = client.GetMultivariateModel("<modelId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSchema").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("slidingWindow").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("alignMode").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("fillNAMethod").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("paddingValue").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("epochIds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("trainLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("validationLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("latenciesInSeconds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateModel_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateModelAsync("<modelId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateModel_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateModelAsync("<modelId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("modelId").ToString());
            Console.WriteLine(result.GetProperty("createdTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSchema").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("displayName").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("slidingWindow").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("alignMode").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("fillNAMethod").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("paddingValue").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("epochIds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("trainLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("validationLosses")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("latenciesInSeconds")[0].ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateModel_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var result = await client.GetMultivariateModelAsync("<modelId>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectMultivariateBatchAnomaly()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "http://localhost:3000",
                topContributorCount = 1234,
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = client.DetectMultivariateBatchAnomaly("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectMultivariateBatchAnomaly_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "http://localhost:3000",
                topContributorCount = 1234,
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = client.DetectMultivariateBatchAnomaly("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("severity").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("score").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("contributionScore").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("correlationChanges").GetProperty("changedVariables")[0].ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectMultivariateBatchAnomaly_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "http://localhost:3000",
                topContributorCount = 1234,
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = await client.DetectMultivariateBatchAnomalyAsync("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectMultivariateBatchAnomaly_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                dataSource = "http://localhost:3000",
                topContributorCount = 1234,
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = await client.DetectMultivariateBatchAnomalyAsync("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("resultId").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("errors")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("dataSource").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("topContributorCount").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("startTime").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("setupInfo").GetProperty("endTime").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("severity").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("score").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("contributionScore").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("correlationChanges").GetProperty("changedVariables")[0].ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectMultivariateBatchAnomaly_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var options = new MultivariateBatchDetectionOptions(new Uri("http://localhost:3000"), 1234, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
            var result = await client.DetectMultivariateBatchAnomalyAsync("<modelId>", options);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectMultivariateLastAnomaly()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                variables = new[] {
        new {
            variable = "<variable>",
            timestamps = new[] {
                "<String>"
            },
            values = new[] {
                123.45f
            },
        }
    },
                topContributorCount = 1234,
            };

            Response response = client.DetectMultivariateLastAnomaly("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DetectMultivariateLastAnomaly_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                variables = new[] {
        new {
            variable = "<variable>",
            timestamps = new[] {
                "<String>"
            },
            values = new[] {
                123.45f
            },
        }
    },
                topContributorCount = 1234,
            };

            Response response = client.DetectMultivariateLastAnomaly("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("severity").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("score").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("contributionScore").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("correlationChanges").GetProperty("changedVariables")[0].ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectMultivariateLastAnomaly_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                variables = new[] {
        new {
            variable = "<variable>",
            timestamps = new[] {
                "<String>"
            },
            values = new[] {
                123.45f
            },
        }
    },
                topContributorCount = 1234,
            };

            Response response = await client.DetectMultivariateLastAnomalyAsync("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectMultivariateLastAnomaly_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var data = new
            {
                variables = new[] {
        new {
            variable = "<variable>",
            timestamps = new[] {
                "<String>"
            },
            values = new[] {
                123.45f
            },
        }
    },
                topContributorCount = 1234,
            };

            Response response = await client.DetectMultivariateLastAnomalyAsync("<modelId>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
            Console.WriteLine(result.GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("timestamp").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("isAnomaly").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("severity").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("score").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("variable").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("contributionScore").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("value").GetProperty("interpretation")[0].GetProperty("correlationChanges").GetProperty("changedVariables")[0].ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("results")[0].GetProperty("errors")[0].GetProperty("message").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DetectMultivariateLastAnomaly_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            var options = new MultivariateLastDetectionOptions(new VariableValues[]
            {
    new VariableValues("<variable>", new string[]
{
        "<null>"
    }, new float[]
{
        3.14f
    })
            }, 1234);
            var result = await client.DetectMultivariateLastAnomalyAsync("<modelId>", options);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultivariateModels()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            foreach (var item in client.GetMultivariateModels(1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("modelId").ToString());
                Console.WriteLine(result.GetProperty("createdTime").ToString());
                Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultivariateModels_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            foreach (var item in client.GetMultivariateModels(1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("modelId").ToString());
                Console.WriteLine(result.GetProperty("createdTime").ToString());
                Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSource").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSchema").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("startTime").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("endTime").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("displayName").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("slidingWindow").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("alignMode").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("fillNAMethod").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("paddingValue").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("epochIds")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("trainLosses")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("validationLosses")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("latenciesInSeconds")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("variable").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateModels_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            await foreach (var item in client.GetMultivariateModelsAsync(1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("modelId").ToString());
                Console.WriteLine(result.GetProperty("createdTime").ToString());
                Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateModels_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            await foreach (var item in client.GetMultivariateModelsAsync(1234, 1234, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("modelId").ToString());
                Console.WriteLine(result.GetProperty("createdTime").ToString());
                Console.WriteLine(result.GetProperty("lastUpdatedTime").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSource").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("dataSchema").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("startTime").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("endTime").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("displayName").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("slidingWindow").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("alignMode").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("fillNAMethod").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("alignPolicy").GetProperty("paddingValue").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("errors")[0].GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("epochIds")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("trainLosses")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("validationLosses")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("modelState").GetProperty("latenciesInSeconds")[0].ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("variable").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("filledNARatio").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("effectiveCount").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("firstTimestamp").ToString());
                Console.WriteLine(result.GetProperty("modelInfo").GetProperty("diagnosticsInfo").GetProperty("variableStates")[0].GetProperty("lastTimestamp").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultivariateModels_Convenience_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AnomalyDetectorClient(endpoint, credential);

            await foreach (var item in client.GetMultivariateModelsAsync(1234, 1234))
            {
            }
        }
    }
}
