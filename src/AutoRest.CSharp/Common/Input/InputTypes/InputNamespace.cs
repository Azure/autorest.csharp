// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputNamespace
{
    public string Name { get; init; }
    public IReadOnlyList<string> ApiVersions { get; init; }
    public IReadOnlyList<InputEnumType> Enums { get; init; }
    public IReadOnlyList<InputModelType> Models { get; init; }
    private IReadOnlyList<InputClient> Clients { get; init; } // we should not be using this because this only contains the top level clients
    public InputAuth Auth { get; init; }
    public IReadOnlyList<InputClient> AllClients { get; init; }

    public InputNamespace(string name, IReadOnlyList<string> apiVersions, IReadOnlyList<InputEnumType> enums, IReadOnlyList<InputModelType> models, IReadOnlyList<InputClient> clients, InputAuth auth)
    {
        Name = name;
        ApiVersions = apiVersions;
        Enums = enums;
        Models = models;
        Clients = clients;
        Auth = auth;
        AllClients = EnumerateClients(clients);
    }

    public InputNamespace() : this(name: string.Empty, apiVersions: Array.Empty<string>(), enums: Array.Empty<InputEnumType>(), models: Array.Empty<InputModelType>(), clients: Array.Empty<InputClient>(), auth: new InputAuth()) { }

    private static IReadOnlyList<InputClient> EnumerateClients(IEnumerable<InputClient> clients)
    {
        var queue = new Queue<InputClient>(clients);
        var allClients = new List<InputClient>();

        while (queue.Count > 0)
        {
            var currentClient = queue.Dequeue();
            allClients.Add(currentClient);

            foreach (var childClient in currentClient.Children)
            {
                queue.Enqueue(childClient);
            }
        }

        return allClients;
    }
}
