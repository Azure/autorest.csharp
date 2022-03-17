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
    /// MgmtExtensionsWrapper is a wrapper of all the <see cref="MgmtExtensions"/>, despite the <see cref="MgmtExtensions"/> is inheriting from <see cref="MgmtTypeProvider"/>, currently it will not produce a class in the generated code.
    /// Instead, this class will take all the things that are used to be produces into the individual extension classes, producing a big extension class
    /// </summary>
    internal class MgmtExtensionsWrapper : MgmtTypeProvider
    {
        public IEnumerable<MgmtExtensions> Extensions { get; }

        public MgmtExtensionsWrapper(IEnumerable<MgmtExtensions> extensions) : base(MgmtContext.Context.DefaultNamespace.Split('.').Last())
        {
            DefaultName = $"{ResourceName}Extensions";
            Description = Configuration.MgmtConfiguration.IsArmCore ? string.Empty : $"A class to add extension methods to {MgmtContext.Context.DefaultNamespace}.";
            Extensions = extensions;
        }

        public override CSharpType? BaseType => null;

        public override string Description { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            throw new NotImplementedException();
        }
    }
}
