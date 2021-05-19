// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Builders;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        public IEnumerable<SchemaObjectType> Models { get; }
        public string DefaultClientName { get; }

        public ModelFactoryTypeProvider(BuildContext context, IEnumerable<SchemaObjectType> models) : base(context)
        {
            Models = models;

            DefaultClientName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            DefaultName = $"{DefaultClientName}ModelFactory";
            DefaultAccessibility = "public";
        }
    }
}
