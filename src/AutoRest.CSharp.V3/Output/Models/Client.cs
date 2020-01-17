﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Shared;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class Client
    {
        public Client(string name, string description, Parameter[] parameters, Method[] methods, Paging[] pagingMethods)
        {
            Name = name;
            Parameters = parameters;
            Methods = methods;
            PagingMethods = pagingMethods;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }

        public Method[] Methods { get; }
        public Paging[] PagingMethods { get; }
        public Parameter[] Parameters { get; }
    }
}
