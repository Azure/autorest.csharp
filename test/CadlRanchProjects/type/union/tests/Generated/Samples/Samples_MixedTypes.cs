// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Union.Models;

namespace _Type.Union.Samples
{
    public partial class Samples_MixedTypes
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_GetMixedType_ShortVersion()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response response = client.GetMixedType(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("model").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("literal").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("int").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("boolean").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_GetMixedType_ShortVersion_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response response = await client.GetMixedTypeAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("model").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("literal").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("int").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("boolean").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_GetMixedType_ShortVersion_Convenience()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response<GetResponse> response = client.GetMixedType();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_GetMixedType_ShortVersion_Convenience_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response<GetResponse> response = await client.GetMixedTypeAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_GetMixedType_AllParameters()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response response = client.GetMixedType(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("model").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("literal").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("int").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("boolean").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_GetMixedType_AllParameters_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response response = await client.GetMixedTypeAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("model").GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("literal").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("int").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("boolean").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_GetMixedType_AllParameters_Convenience()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response<GetResponse> response = client.GetMixedType();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_GetMixedType_AllParameters_Convenience_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            Response<GetResponse> response = await client.GetMixedTypeAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_Send_ShortVersion()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["model"] = new
                    {
                        name = "<name>",
                    },
                    ["literal"] = null,
                    ["int"] = null,
                    ["boolean"] = null,
                    ["array"] = new object[]
            {
null
            }
                },
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_Send_ShortVersion_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["model"] = new
                    {
                        name = "<name>",
                    },
                    ["literal"] = null,
                    ["int"] = null,
                    ["boolean"] = null,
                    ["array"] = new object[]
            {
null
            }
                },
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_Send_ShortVersion_Convenience()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            MixedTypesCases prop = new MixedTypesCases(BinaryData.FromObjectAsJson(new
            {
                name = "<name>",
            }), null, null, null, new BinaryData[]
            {
null
            });
            Response response = client.Send(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_Send_ShortVersion_Convenience_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            MixedTypesCases prop = new MixedTypesCases(BinaryData.FromObjectAsJson(new
            {
                name = "<name>",
            }), null, null, null, new BinaryData[]
            {
null
            });
            Response response = await client.SendAsync(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_Send_AllParameters()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["model"] = new
                    {
                        name = "<name>",
                    },
                    ["literal"] = null,
                    ["int"] = null,
                    ["boolean"] = null,
                    ["array"] = new object[]
            {
null
            }
                },
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_Send_AllParameters_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["model"] = new
                    {
                        name = "<name>",
                    },
                    ["literal"] = null,
                    ["int"] = null,
                    ["boolean"] = null,
                    ["array"] = new object[]
            {
null
            }
                },
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedTypes_Send_AllParameters_Convenience()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            MixedTypesCases prop = new MixedTypesCases(BinaryData.FromObjectAsJson(new
            {
                name = "<name>",
            }), null, null, null, new BinaryData[]
            {
null
            });
            Response response = client.Send(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedTypes_Send_AllParameters_Convenience_Async()
        {
            MixedTypes client = new UnionClient().GetMixedTypesClient();

            MixedTypesCases prop = new MixedTypesCases(BinaryData.FromObjectAsJson(new
            {
                name = "<name>",
            }), null, null, null, new BinaryData[]
            {
null
            });
            Response response = await client.SendAsync(prop);
        }
    }
}
