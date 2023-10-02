// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using AnomalyDetector;
using AnomalyDetector.Models;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace AnomalyDetector.Tests
{
    public partial class AnomalyDetectorClientTests : AnomalyDetectorTestBase
    {
        public AnomalyDetectorClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateEntireSeries_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                series = new object[]
            {
new
{
value = 123.45F,
}
            },
            });
            Response response = await client.DetectUnivariateEntireSeriesAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateEntireSeries_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            UnivariateDetectionOptions options = new UnivariateDetectionOptions(new TimeSeriesPoint[]
            {
new TimeSeriesPoint(123.45F)
            });
            Response<UnivariateEntireDetectionResult> response = await client.DetectUnivariateEntireSeriesAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateEntireSeries_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                series = new object[]
            {
new
{
timestamp = "2022-05-10T14:57:31.2311892-04:00",
value = 123.45F,
}
            },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                maxAnomalyRatio = 123.45F,
                sensitivity = 1234,
                imputeMode = "auto",
                imputeFixedValue = 123.45F,
            });
            Response response = await client.DetectUnivariateEntireSeriesAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateEntireSeries_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            UnivariateDetectionOptions options = new UnivariateDetectionOptions(new TimeSeriesPoint[]
            {
new TimeSeriesPoint(123.45F)
{
Timestamp = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
}
            })
            {
                Granularity = TimeGranularity.Yearly,
                CustomInterval = 1234,
                Period = 1234,
                MaxAnomalyRatio = 123.45F,
                Sensitivity = 1234,
                ImputeMode = ImputeMode.Auto,
                ImputeFixedValue = 123.45F,
            };
            Response<UnivariateEntireDetectionResult> response = await client.DetectUnivariateEntireSeriesAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateLastPoint_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                series = new object[]
            {
new
{
value = 123.45F,
}
            },
            });
            Response response = await client.DetectUnivariateLastPointAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateLastPoint_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            UnivariateDetectionOptions options = new UnivariateDetectionOptions(new TimeSeriesPoint[]
            {
new TimeSeriesPoint(123.45F)
            });
            Response<UnivariateLastDetectionResult> response = await client.DetectUnivariateLastPointAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateLastPoint_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                series = new object[]
            {
new
{
timestamp = "2022-05-10T14:57:31.2311892-04:00",
value = 123.45F,
}
            },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                maxAnomalyRatio = 123.45F,
                sensitivity = 1234,
                imputeMode = "auto",
                imputeFixedValue = 123.45F,
            });
            Response response = await client.DetectUnivariateLastPointAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateLastPoint_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            UnivariateDetectionOptions options = new UnivariateDetectionOptions(new TimeSeriesPoint[]
            {
new TimeSeriesPoint(123.45F)
{
Timestamp = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
}
            })
            {
                Granularity = TimeGranularity.Yearly,
                CustomInterval = 1234,
                Period = 1234,
                MaxAnomalyRatio = 123.45F,
                Sensitivity = 1234,
                ImputeMode = ImputeMode.Auto,
                ImputeFixedValue = 123.45F,
            };
            Response<UnivariateLastDetectionResult> response = await client.DetectUnivariateLastPointAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateChangePoint_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                series = new object[]
            {
new
{
value = 123.45F,
}
            },
                granularity = "yearly",
            });
            Response response = await client.DetectUnivariateChangePointAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateChangePoint_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            UnivariateChangePointDetectionOptions options = new UnivariateChangePointDetectionOptions(new TimeSeriesPoint[]
            {
new TimeSeriesPoint(123.45F)
            }, TimeGranularity.Yearly);
            Response<UnivariateChangePointDetectionResult> response = await client.DetectUnivariateChangePointAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateChangePoint_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                series = new object[]
            {
new
{
timestamp = "2022-05-10T14:57:31.2311892-04:00",
value = 123.45F,
}
            },
                granularity = "yearly",
                customInterval = 1234,
                period = 1234,
                stableTrendWindow = 1234,
                threshold = 123.45F,
            });
            Response response = await client.DetectUnivariateChangePointAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectUnivariateChangePoint_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            UnivariateChangePointDetectionOptions options = new UnivariateChangePointDetectionOptions(new TimeSeriesPoint[]
            {
new TimeSeriesPoint(123.45F)
{
Timestamp = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
}
            }, TimeGranularity.Yearly)
            {
                CustomInterval = 1234,
                Period = 1234,
                StableTrendWindow = 1234,
                Threshold = 123.45F,
            };
            Response<UnivariateChangePointDetectionResult> response = await client.DetectUnivariateChangePointAsync(options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateBatchDetectionResult_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateBatchDetectionResultAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateBatchDetectionResult_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response<MultivariateDetectionResult> response = await client.GetMultivariateBatchDetectionResultAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateBatchDetectionResult_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateBatchDetectionResultAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateBatchDetectionResult_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response<MultivariateDetectionResult> response = await client.GetMultivariateBatchDetectionResultAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task TrainMultivariateModel_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                dataSource = "<dataSource>",
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.TrainMultivariateModelAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task TrainMultivariateModel_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            ModelInfo modelInfo = new ModelInfo("<dataSource>", DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"), DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response<AnomalyDetectionModel> response = await client.TrainMultivariateModelAsync(modelInfo);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task TrainMultivariateModel_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
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
                    paddingValue = 123.45F,
                },
                status = "CREATED",
                diagnosticsInfo = new
                {
                    modelState = new
                    {
                        epochIds = new object[]
            {
1234
            },
                        trainLosses = new object[]
            {
123.45F
            },
                        validationLosses = new object[]
            {
123.45F
            },
                        latenciesInSeconds = new object[]
            {
123.45F
            },
                    },
                    variableStates = new object[]
            {
new
{
variable = "<variable>",
filledNARatio = 123.45F,
effectiveCount = 1234,
firstTimestamp = "2022-05-10T14:57:31.2311892-04:00",
lastTimestamp = "2022-05-10T14:57:31.2311892-04:00",
}
            },
                },
            });
            Response response = await client.TrainMultivariateModelAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task TrainMultivariateModel_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            ModelInfo modelInfo = new ModelInfo("<dataSource>", DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"), DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"))
            {
                DataSchema = DataSchema.OneTable,
                DisplayName = "<displayName>",
                SlidingWindow = 1234,
                AlignPolicy = new AlignPolicy
                {
                    AlignMode = AlignMode.Inner,
                    FillNAMethod = FillNAMethod.Previous,
                    PaddingValue = 123.45F,
                },
                Status = ModelStatus.Created,
                DiagnosticsInfo = new DiagnosticsInfo
                {
                    ModelState = new ModelState
                    {
                        EpochIds = { 1234 },
                        TrainLosses = { 123.45F },
                        ValidationLosses = { 123.45F },
                        LatenciesInSeconds = { 123.45F },
                    },
                    VariableStates = {new VariableState
{
Variable = "<variable>",
FilledNARatio = 123.45F,
EffectiveCount = 1234,
FirstTimestamp = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
LastTimestamp = DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"),
}},
                },
            };
            Response<AnomalyDetectionModel> response = await client.TrainMultivariateModelAsync(modelInfo);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DeleteMultivariateModel_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response response = await client.DeleteMultivariateModelAsync("<modelId>");
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DeleteMultivariateModel_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response response = await client.DeleteMultivariateModelAsync("<modelId>");
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModel_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateModelAsync("<modelId>", null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModel_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response<AnomalyDetectionModel> response = await client.GetMultivariateModelAsync("<modelId>");
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModel_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response response = await client.GetMultivariateModelAsync("<modelId>", null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModel_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            Response<AnomalyDetectionModel> response = await client.GetMultivariateModelAsync("<modelId>");
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateBatchAnomaly_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                dataSource = "http://localhost:3000",
                topContributorCount = 1234,
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.DetectMultivariateBatchAnomalyAsync("<modelId>", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateBatchAnomaly_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            MultivariateBatchDetectionOptions options = new MultivariateBatchDetectionOptions(new Uri("http://localhost:3000"), 1234, DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"), DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response<MultivariateDetectionResult> response = await client.DetectMultivariateBatchAnomalyAsync("<modelId>", options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateBatchAnomaly_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                dataSource = "http://localhost:3000",
                topContributorCount = 1234,
                startTime = "2022-05-10T14:57:31.2311892-04:00",
                endTime = "2022-05-10T14:57:31.2311892-04:00",
            });
            Response response = await client.DetectMultivariateBatchAnomalyAsync("<modelId>", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateBatchAnomaly_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            MultivariateBatchDetectionOptions options = new MultivariateBatchDetectionOptions(new Uri("http://localhost:3000"), 1234, DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"), DateTimeOffset.Parse("2022-05-10T14:57:31.2311892-04:00"));
            Response<MultivariateDetectionResult> response = await client.DetectMultivariateBatchAnomalyAsync("<modelId>", options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateLastAnomaly_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                variables = new object[]
            {
new
{
variable = "<variable>",
timestamps = new object[]
{
"<timestamps>"
},
values = new object[]
{
123.45F
},
}
            },
                topContributorCount = 1234,
            });
            Response response = await client.DetectMultivariateLastAnomalyAsync("<modelId>", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateLastAnomaly_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            MultivariateLastDetectionOptions options = new MultivariateLastDetectionOptions(new VariableValues[]
            {
new VariableValues("<variable>", new string[]{"<timestamps>"}, new float[]{123.45F})
            }, 1234);
            Response<MultivariateLastDetectionResult> response = await client.DetectMultivariateLastAnomalyAsync("<modelId>", options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateLastAnomaly_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                variables = new object[]
            {
new
{
variable = "<variable>",
timestamps = new object[]
{
"<timestamps>"
},
values = new object[]
{
123.45F
},
}
            },
                topContributorCount = 1234,
            });
            Response response = await client.DetectMultivariateLastAnomalyAsync("<modelId>", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task DetectMultivariateLastAnomaly_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            MultivariateLastDetectionOptions options = new MultivariateLastDetectionOptions(new VariableValues[]
            {
new VariableValues("<variable>", new string[]{"<timestamps>"}, new float[]{123.45F})
            }, 1234);
            Response<MultivariateLastDetectionResult> response = await client.DetectMultivariateLastAnomalyAsync("<modelId>", options);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModels_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            await foreach (BinaryData item in client.GetMultivariateModelsAsync(null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModels_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            await foreach (AnomalyDetectionModel item in client.GetMultivariateModelsAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModels_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            await foreach (BinaryData item in client.GetMultivariateModelsAsync(1234, 1234, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetMultivariateModels_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            AnomalyDetectorClient client = CreateAnomalyDetectorClient(endpoint, credential);

            await foreach (AnomalyDetectionModel item in client.GetMultivariateModelsAsync(skip: 1234, maxCount: 1234))
            {
            }
        }
    }
}
