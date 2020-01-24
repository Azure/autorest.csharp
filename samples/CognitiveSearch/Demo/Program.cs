// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.CognitiveSearch;
using CognitiveSearch.Models;

namespace Demo
{
    public static class Application
    {
        public static async Task Main()
        {
            // Get our settings
            string serviceName = GetVariable("Search Service Name: ", "SEARCH_SERVICE");
            string indexName = GetVariable("Search Index Name: ", "SEARCH_INDEX");
            string apiKey = GetVariable("Search Api Key: ", "SEARCH_APIKEY");
            Console.WriteLine();

            // Create the client to search an index
            CognitiveSearchClient search = new CognitiveSearchClient(serviceName, new CognitiveSearchCredential(apiKey));
            IndexClient index = search.GetIndexClient(indexName);

            // Start a REPL
            for (;;)
            {
                // Get the query
                Console.Write("Query: ");
                string query = Console.ReadLine();
                if (string.IsNullOrEmpty(query)) { break; }

                try
                {
                    // Try searching
                    SearchDocumentsResult response = await index.SearchAsync(query);
                    Console.WriteLine($"{response.Results.Count} results!");
                    Console.WriteLine();

                    // Print the result
                    int count = 0;
                    foreach (SearchResult result in response.Results)
                    {
                        Console.WriteLine($"Result #{count++} (score={result.Score}):");
                        foreach (KeyValuePair<string, object> field in (IDictionary<string, object>)result)
                        {
                            string value = field.Value?.ToString() ?? "";
                            if (value.Length > 70) { value = value.Substring(0, 70) + "..."; }
                            Console.WriteLine($"    {field.Key}: {value}");
                        }
                        Console.WriteLine();
                    }
                }
                catch (RequestFailedException ex)
                {
                    Console.WriteLine($"You're bad at searching: ${ex}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Goodbye!");
        }

        internal static string GetVariable(string prompt, string envName)
        {
            Console.Write(prompt);
            string value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                value = Console.ReadLine();
            }
            else
            {
                Console.WriteLine(value);
            }
            return value;
        }

    }
}
