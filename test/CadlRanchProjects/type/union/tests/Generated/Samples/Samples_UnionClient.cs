// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Union;
using _Type.Union.Models;

namespace _Type.Union.Samples
{
    public partial class Samples_UnionClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt_ShortVersion()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendInt(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = client.SendInt(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = await client.SendIntAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendInt(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendInt_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = client.SendInt(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendInt_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = await client.SendIntAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray_ShortVersion()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendIntArray(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntArrayAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = client.SendIntArray(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = await client.SendIntArrayAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = client.SendIntArray(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                simpleUnion = 1234,
            });
            Response response = await client.SendIntArrayAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendIntArray_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = client.SendIntArray(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendIntArray_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithSimpleUnionProperty input = new ModelWithSimpleUnionProperty(BinaryData.FromObjectAsJson(1234));
            Response response = await client.SendIntArrayAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue_ShortVersion()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendFirstNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendFirstNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = client.SendFirstNamedUnionValue(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = await client.SendFirstNamedUnionValueAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendFirstNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendFirstNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendFirstNamedUnionValue_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = client.SendFirstNamedUnionValue(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendFirstNamedUnionValue_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = await client.SendFirstNamedUnionValueAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue_ShortVersion()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendSecondNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendSecondNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = client.SendSecondNamedUnionValue(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = await client.SendSecondNamedUnionValueAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = client.SendSecondNamedUnionValue(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            RequestContent content = RequestContent.Create(new
            {
                namedUnion = new
                {
                    prop1 = 1234,
                    name = "<name>",
                },
            });
            Response response = await client.SendSecondNamedUnionValueAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SendSecondNamedUnionValue_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = client.SendSecondNamedUnionValue(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SendSecondNamedUnionValue_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            ModelWithNamedUnionProperty input = new ModelWithNamedUnionProperty(BinaryData.FromObjectAsJson(new
            {
                prop1 = 1234,
                name = "<name>",
            }));
            Response response = await client.SendSecondNamedUnionValueAsync(input);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveString_ShortVersion()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveString(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveString_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveStringAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveString_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = client.ReceiveString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveString_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = await client.ReceiveStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveString_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveString(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveString_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveStringAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveString_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = client.ReceiveString();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveString_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = await client.ReceiveStringAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveIntArray_ShortVersion()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveIntArray(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveIntArray_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveIntArrayAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveIntArray_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = client.ReceiveIntArray();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveIntArray_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = await client.ReceiveIntArrayAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveIntArray_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveIntArray(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveIntArray_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveIntArrayAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("simpleUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveIntArray_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = client.ReceiveIntArray();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveIntArray_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithSimpleUnionPropertyInResponse> response = await client.ReceiveIntArrayAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveFirstNamedUnionValue_ShortVersion()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveFirstNamedUnionValue(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveFirstNamedUnionValue_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveFirstNamedUnionValueAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveFirstNamedUnionValue_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = client.ReceiveFirstNamedUnionValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveFirstNamedUnionValue_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = await client.ReceiveFirstNamedUnionValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveFirstNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveFirstNamedUnionValue(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveFirstNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveFirstNamedUnionValueAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveFirstNamedUnionValue_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = client.ReceiveFirstNamedUnionValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveFirstNamedUnionValue_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = await client.ReceiveFirstNamedUnionValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveSecondNamedUnionValue_ShortVersion()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveSecondNamedUnionValue(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveSecondNamedUnionValue_ShortVersion_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveSecondNamedUnionValueAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveSecondNamedUnionValue_ShortVersion_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = client.ReceiveSecondNamedUnionValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveSecondNamedUnionValue_ShortVersion_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = await client.ReceiveSecondNamedUnionValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveSecondNamedUnionValue_AllParameters()
        {
            UnionClient client = new UnionClient();

            Response response = client.ReceiveSecondNamedUnionValue(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveSecondNamedUnionValue_AllParameters_Async()
        {
            UnionClient client = new UnionClient();

            Response response = await client.ReceiveSecondNamedUnionValueAsync(null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("namedUnion").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ReceiveSecondNamedUnionValue_AllParameters_Convenience()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = client.ReceiveSecondNamedUnionValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ReceiveSecondNamedUnionValue_AllParameters_Convenience_Async()
        {
            UnionClient client = new UnionClient();

            Response<ModelWithNamedUnionPropertyInResponse> response = await client.ReceiveSecondNamedUnionValueAsync();
        }
    }
}
