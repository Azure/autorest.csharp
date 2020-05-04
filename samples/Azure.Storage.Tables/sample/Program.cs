// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Tables;

namespace sample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceClient = new TableServiceClient(
                new Uri("https://pakrym0test0storage.table.core.windows.net"),
                new StorageSharedKeyCredential("pakrym0test0storage", args[0]));

            await foreach (var table in serviceClient.GetTablesAsync())
            {
                Console.WriteLine(table.TableName);
            }

            var tableClient = serviceClient.GetTableClient("mytesttable2");

            var currentTime = DateTimeOffset.Now;
            var timestamp = currentTime.Ticks.ToString();

            Console.WriteLine("Type in a message:");

            var message = Console.ReadLine();

            Console.WriteLine("Type in a number:");

            var number = int.Parse(Console.ReadLine());

            await tableClient.InsertAsync(new Dictionary<string, object>()
            {
                {"Number", number},
                {"Time", currentTime},
                {"Message", message},
                {"PartitionKey", timestamp},
                {"RowKey", timestamp}
            });

            Console.WriteLine("What number do you want?");

            var filter = int.Parse(Console.ReadLine());

            await foreach (var entity in tableClient.QueryAsync(select: "Time,Message", filter: $"Number eq {filter}"))
            {
                Console.WriteLine($"{entity["Time"]} {entity["Message"]}");
            }
        }
    }
}
