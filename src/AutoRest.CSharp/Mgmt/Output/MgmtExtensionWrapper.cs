// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    /// <summary>
    /// MgmtExtensionsWrapper is a wrapper of all the <see cref="MgmtExtension"/>, despite the <see cref="OldMgmtExtensions"/> is inheriting from <see cref="MgmtTypeProvider"/>, currently it will not produce a class in the generated code.
    /// Instead, this class will take all the things that are used to be produces into the individual extension classes, producing a big extension class
    /// </summary>
    internal class MgmtExtensionWrapper : MgmtTypeProvider
    {
        public IEnumerable<MgmtExtension> Extensions { get; }

        public override bool IsStatic => true;

        public bool IsEmpty => Extensions.All(extension => extension.IsEmpty);

        public MgmtExtensionWrapper(IEnumerable<MgmtExtension> extensions) : base(MgmtContext.Context.DefaultNamespace.Split('.').Last())
        {
            DefaultName = $"{ResourceName}Extensions";
            Description = Configuration.MgmtConfiguration.IsArmCore ? (FormattableString)$"" : $"A class to add extension methods to {MgmtContext.Context.DefaultNamespace}.";
            Extensions = extensions;
        }

        public override CSharpType? BaseType => null;

        public override FormattableString Description { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            foreach (var extension in Extensions)
            {
                foreach (var operation in extension.ClientOperations)
                {
                    yield return operation;
                }
            }
        }
    }
}
