// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class ModelTypeMapping: TypeMapping
    {
        public SourceMemberMapping[] PropertyMappings { get; }

        public ModelTypeMapping(INamedTypeSymbol memberAttribute, string originalName, INamedTypeSymbol existingType): base(originalName, existingType)
        {
            List<SourceMemberMapping> memberMappings = new List<SourceMemberMapping>();
            foreach (ISymbol member in GetMembers(existingType))
            {
                if (SourceInputModel.TryGetName(member, memberAttribute, out var schemaMemberName))
                {
                    memberMappings.Add(new SourceMemberMapping(schemaMemberName, member));
                }
            }

            PropertyMappings = memberMappings.ToArray();
        }

        public SourceMemberMapping? GetForMember(string name)
        {
            var memberMapping = PropertyMappings.SingleOrDefault(p => string.Equals(p.OriginalName, name, StringComparison.InvariantCultureIgnoreCase));
            if (memberMapping == null)
            {
                var memberSymbol = ExistingType.GetMembers(name).FirstOrDefault();
                if (memberSymbol != null)
                {
                    memberMapping = new SourceMemberMapping(memberSymbol.Name, memberSymbol);
                }
            }

            return memberMapping;
        }

        private IEnumerable<ISymbol> GetMembers(INamedTypeSymbol? typeSymbol)
        {
            while (typeSymbol != null)
            {
                foreach (var symbol in typeSymbol.GetMembers())
                {
                    yield return symbol;
                }

                typeSymbol = typeSymbol.BaseType;
            }
        }
    }
}
