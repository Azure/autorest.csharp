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
using _Specs_.Azure.Core.Basic;
using _Specs_.Azure.Core.Basic.Models;

namespace _Specs_.Azure.Core.Basic.Samples
{
    public class Samples_BasicClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdate()
        {
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = client.CreateOrUpdate(1234, content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdate_AllParameters()
        {
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
                ["orders"] = new List<object>()
{
new Dictionary<string, object>()
{
["userId"] = 1234,
["detail"] = "<detail>",
}
},
            });
            Response response = client.CreateOrUpdate(1234, content);

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
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = await client.CreateOrUpdateAsync(1234, content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdate_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
                ["orders"] = new List<object>()
{
new Dictionary<string, object>()
{
["userId"] = 1234,
["detail"] = "<detail>",
}
},
            });
            Response response = await client.CreateOrUpdateAsync(1234, content);

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
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = client.CreateOrReplace(1234, content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrReplace_AllParameters()
        {
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
                ["orders"] = new List<object>()
{
new Dictionary<string, object>()
{
["userId"] = 1234,
["detail"] = "<detail>",
}
},
            });
            Response response = client.CreateOrReplace(1234, content);

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
        public void Example_CreateOrReplace_Convenience()
        {
            BasicClient client = new BasicClient();

            User resource = new User("<name>");
            Response<User> response = client.CreateOrReplace(1234, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrReplace_AllParameters_Convenience()
        {
            BasicClient client = new BasicClient();

            User resource = new User("<name>")
            {
                Orders =
{
new UserOrder(1234,"<detail>")
},
            };
            Response<User> response = client.CreateOrReplace(1234, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrReplace_Async()
        {
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Response response = await client.CreateOrReplaceAsync(1234, content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrReplace_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
                ["orders"] = new List<object>()
{
new Dictionary<string, object>()
{
["userId"] = 1234,
["detail"] = "<detail>",
}
},
            });
            Response response = await client.CreateOrReplaceAsync(1234, content);

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
            BasicClient client = new BasicClient();

            User resource = new User("<name>");
            Response<User> response = await client.CreateOrReplaceAsync(1234, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrReplace_AllParameters_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            User resource = new User("<name>")
            {
                Orders =
{
new UserOrder(1234,"<detail>")
},
            };
            Response<User> response = await client.CreateOrReplaceAsync(1234, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUser()
        {
            BasicClient client = new BasicClient();

            Response response = client.GetUser(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUser_AllParameters()
        {
            BasicClient client = new BasicClient();

            Response response = client.GetUser(1234, null);

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
        public void Example_GetUser_Convenience()
        {
            BasicClient client = new BasicClient();

            Response<User> response = client.GetUser(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUser_AllParameters_Convenience()
        {
            BasicClient client = new BasicClient();

            Response<User> response = client.GetUser(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUser_Async()
        {
            BasicClient client = new BasicClient();

            Response response = await client.GetUserAsync(1234, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUser_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            Response response = await client.GetUserAsync(1234, null);

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
            BasicClient client = new BasicClient();

            Response<User> response = await client.GetUserAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUser_AllParameters_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            Response<User> response = await client.GetUserAsync(1234);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete()
        {
            BasicClient client = new BasicClient();

            Response response = client.Delete(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete_AllParameters()
        {
            BasicClient client = new BasicClient();

            Response response = client.Delete(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete_Async()
        {
            BasicClient client = new BasicClient();

            Response response = await client.DeleteAsync(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            Response response = await client.DeleteAsync(1234);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Export()
        {
            BasicClient client = new BasicClient();

            Response response = client.Export(1234, "<format>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Export_AllParameters()
        {
            BasicClient client = new BasicClient();

            Response response = client.Export(1234, "<format>", null);

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
        public void Example_Export_Convenience()
        {
            BasicClient client = new BasicClient();

            Response<User> response = client.Export(1234, "<format>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Export_AllParameters_Convenience()
        {
            BasicClient client = new BasicClient();

            Response<User> response = client.Export(1234, "<format>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_Async()
        {
            BasicClient client = new BasicClient();

            Response response = await client.ExportAsync(1234, "<format>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("etag").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            Response response = await client.ExportAsync(1234, "<format>", null);

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
            BasicClient client = new BasicClient();

            Response<User> response = await client.ExportAsync(1234, "<format>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_AllParameters_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            Response<User> response = await client.ExportAsync(1234, "<format>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUsers()
        {
            BasicClient client = new BasicClient();

            foreach (BinaryData item in client.GetUsers(null, null, null, null, null, null, null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUsers_AllParameters()
        {
            BasicClient client = new BasicClient();

            foreach (BinaryData item in client.GetUsers(1234, 1234, 1234, new List<string>()
{
"<orderby>"
}, "<filter>", new List<string>()
{
"<select>"
}, new List<string>()
{
"<expand>"
}, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUsers_Convenience()
        {
            BasicClient client = new BasicClient();

            foreach (User item in client.GetUsers())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUsers_AllParameters_Convenience()
        {
            BasicClient client = new BasicClient();

            foreach (User item in client.GetUsers(maxCount: 1234, skip: 1234, maxpagesize: 1234, orderby: new List<string>()
{
"<orderby>"
}, filter: "<filter>", select: new List<string>()
{
"<select>"
}, expand: new List<string>()
{
"<expand>"
}))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUsers_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (BinaryData item in client.GetUsersAsync(null, null, null, null, null, null, null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUsers_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (BinaryData item in client.GetUsersAsync(1234, 1234, 1234, new List<string>()
{
"<orderby>"
}, "<filter>", new List<string>()
{
"<select>"
}, new List<string>()
{
"<expand>"
}, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUsers_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (User item in client.GetUsersAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUsers_AllParameters_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (User item in client.GetUsersAsync(maxCount: 1234, skip: 1234, maxpagesize: 1234, orderby: new List<string>()
{
"<orderby>"
}, filter: "<filter>", select: new List<string>()
{
"<select>"
}, expand: new List<string>()
{
"<expand>"
}))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithPage()
        {
            BasicClient client = new BasicClient();

            foreach (BinaryData item in client.GetWithPage(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithPage_AllParameters()
        {
            BasicClient client = new BasicClient();

            foreach (BinaryData item in client.GetWithPage(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithPage_Convenience()
        {
            BasicClient client = new BasicClient();

            foreach (User item in client.GetWithPage())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithPage_AllParameters_Convenience()
        {
            BasicClient client = new BasicClient();

            foreach (User item in client.GetWithPage())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithPage_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (BinaryData item in client.GetWithPageAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithPage_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (BinaryData item in client.GetWithPageAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithPage_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (User item in client.GetWithPageAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithPage_AllParameters_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (User item in client.GetWithPageAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithCustomPageModel()
        {
            BasicClient client = new BasicClient();

            foreach (BinaryData item in client.GetWithCustomPageModel(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithCustomPageModel_AllParameters()
        {
            BasicClient client = new BasicClient();

            foreach (BinaryData item in client.GetWithCustomPageModel(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithCustomPageModel_Convenience()
        {
            BasicClient client = new BasicClient();

            foreach (User item in client.GetWithCustomPageModel())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithCustomPageModel_AllParameters_Convenience()
        {
            BasicClient client = new BasicClient();

            foreach (User item in client.GetWithCustomPageModel())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithCustomPageModel_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (BinaryData item in client.GetWithCustomPageModelAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithCustomPageModel_AllParameters_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (BinaryData item in client.GetWithCustomPageModelAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("name").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("id").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("userId").ToString());
                Console.WriteLine(result[0].GetProperty("orders")[0].GetProperty("detail").ToString());
                Console.WriteLine(result[0].GetProperty("etag").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithCustomPageModel_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (User item in client.GetWithCustomPageModelAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithCustomPageModel_AllParameters_Convenience_Async()
        {
            BasicClient client = new BasicClient();

            await foreach (User item in client.GetWithCustomPageModelAsync())
            {
            }
        }
    }
}
