﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : TypeProvider
    {
        public Resource(OperationGroup operationGroup, BuildContext context)
            : base(context)
        {
            OperationGroup = operationGroup;
            // check if this is an extension resource, if so, we need to append the name of its parent to this resource name
            var isExtension = operationGroup.IsExtensionResource(context.Configuration.MgmtConfiguration);
            string parentValue = "";
            if (isExtension)
            {
                var parentOperationGroup = operationGroup.ParentOperationGroup(context);
                parentValue = parentOperationGroup?.Key.ToSingular(false) ?? string.Empty;
            }
            DefaultName = operationGroup.Resource(context.Configuration.MgmtConfiguration) + parentValue;
            Description = BuilderHelpers.EscapeXmlDescription(
                $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.");
        }

        internal OperationGroup OperationGroup { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public string Description { get; }

        private static string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };
    }
}
