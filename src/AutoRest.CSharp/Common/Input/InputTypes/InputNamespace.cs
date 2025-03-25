// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputNamespace(string Name, IReadOnlyList<string> ApiVersions, IReadOnlyList<InputEnumType> Enums, IReadOnlyList<InputModelType> Models, IReadOnlyList<InputClient> Clients, InputAuth Auth)
{
    public InputNamespace() : this(Name: string.Empty, ApiVersions: Array.Empty<string>(), Enums: Array.Empty<InputEnumType>(), Models: Array.Empty<InputModelType>(), Clients: Array.Empty<InputClient>(), Auth: new InputAuth()) { }

    public IEnumerable<InputClient> EnumerateClients()
    {
        var queue = new Queue<InputClient>(Clients);
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
