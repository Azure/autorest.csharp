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
using _Specs_.Azure.Core.Basic.Models;

namespace _Specs_.Azure.Core.Basic.Samples
{
    public class Samples_BasicClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdate()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = client.CreateOrUpdate(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdate_AllParameters()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
                orders = new[] {
        new {
            userId = 1234,
            detail = "<detail>",
        }
    },
            };

            Response response = client.CreateOrUpdate(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdate_Async()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.CreateOrUpdateAsync(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdate_AllParameters_Async()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
                orders = new[] {
        new {
            userId = 1234,
            detail = "<detail>",
        }
    },
            };

            Response response = await client.CreateOrUpdateAsync(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrReplace()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = client.CreateOrReplace(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrReplace_AllParameters()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
                orders = new[] {
        new {
            userId = 1234,
            detail = "<detail>",
        }
    },
            };

            Response response = client.CreateOrReplace(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrReplace_Async()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
            };

            Response response = await client.CreateOrReplaceAsync(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrReplace_AllParameters_Async()
        {
            var client = new BasicClient();

            var data = new
            {
                name = "<name>",
                orders = new[] {
        new {
            userId = 1234,
            detail = "<detail>",
        }
    },
            };

            Response response = await client.CreateOrReplaceAsync(1234, RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrReplace_Convenience_Async()
        {
            var client = new BasicClient();

            var resource = new User("<name>")
            {
                Orders =
{
        new UserOrder(1234, "<detail>")
    },
            };
            var result = await client.CreateOrReplaceAsync(1234, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUser()
        {
            var client = new BasicClient();

            Response response = client.GetUser(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUser_AllParameters()
        {
            var client = new BasicClient();

            Response response = client.GetUser(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUser_Async()
        {
            var client = new BasicClient();

            Response response = await client.GetUserAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUser_AllParameters_Async()
        {
            var client = new BasicClient();

            Response response = await client.GetUserAsync(1234, new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUser_Convenience_Async()
        {
            var client = new BasicClient();

            var result = await client.GetUserAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete()
        {
            var client = new BasicClient();

            Response response = client.Delete(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete_AllParameters()
        {
            var client = new BasicClient();

            Response response = client.Delete(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete_Async()
        {
            var client = new BasicClient();

            Response response = await client.DeleteAsync(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete_AllParameters_Async()
        {
            var client = new BasicClient();

            Response response = await client.DeleteAsync(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Export()
        {
            var client = new BasicClient();

            Response response = client.Export(1234, "<format>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Export_AllParameters()
        {
            var client = new BasicClient();

            Response response = client.Export(1234, "<format>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_Async()
        {
            var client = new BasicClient();

            Response response = await client.ExportAsync(1234, "<format>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_AllParameters_Async()
        {
            var client = new BasicClient();

            Response response = await client.ExportAsync(1234, "<format>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
            Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_Convenience_Async()
        {
            var client = new BasicClient();

            var result = await client.ExportAsync(1234, "<format>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUsers()
        {
            var client = new BasicClient();

            foreach (var item in client.GetUsers(1234, 1234, 1234, new string[] { "<orderby>" }, "<filter>", new string[] { "<select>" }, new string[] { "<expand>" }, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUsers_AllParameters()
        {
            var client = new BasicClient();

            foreach (var item in client.GetUsers(1234, 1234, 1234, new string[] { "<orderby>" }, "<filter>", new string[] { "<select>" }, new string[] { "<expand>" }, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUsers_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetUsersAsync(1234, 1234, 1234, new string[] { "<orderby>" }, "<filter>", new string[] { "<select>" }, new string[] { "<expand>" }, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUsers_AllParameters_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetUsersAsync(1234, 1234, 1234, new string[] { "<orderby>" }, "<filter>", new string[] { "<select>" }, new string[] { "<expand>" }, new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUsers_Convenience_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetUsersAsync(1234, 1234, 1234, new string[] { "<orderby>" }, "<filter>", new string[] { "<select>" }, new string[] { "<expand>" }))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithPage()
        {
            var client = new BasicClient();

            foreach (var item in client.GetWithPage(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithPage_AllParameters()
        {
            var client = new BasicClient();

            foreach (var item in client.GetWithPage(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithPage_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetWithPageAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithPage_AllParameters_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetWithPageAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithPage_Convenience_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetWithPageAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithCustomPageModel()
        {
            var client = new BasicClient();

            foreach (var item in client.GetWithCustomPageModel(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithCustomPageModel_AllParameters()
        {
            var client = new BasicClient();

            foreach (var item in client.GetWithCustomPageModel(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithCustomPageModel_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetWithCustomPageModelAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithCustomPageModel_AllParameters_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetWithCustomPageModelAsync(new RequestContext()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result.GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result.GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithCustomPageModel_Convenience_Async()
        {
            var client = new BasicClient();

            await foreach (var item in client.GetWithCustomPageModelAsync())
            {
            }
        }
    }
}
