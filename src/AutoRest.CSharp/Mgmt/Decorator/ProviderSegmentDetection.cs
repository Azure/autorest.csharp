// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models.Type.Decorate
{
    internal static class ProviderSegmentDetection
    {
        //Extensions algo will use same tokens ADO #5523
        public static List<ProviderSegment> GetProviderSegments(string path)
        {
            if (path == String.Empty)
            {
                return new List<ProviderSegment>();
            }
            var offset = path.IndexOf(ProviderSegment.Providers);
            ProviderSegment currentToken;
            var tokens = new List<ProviderSegment>();
            int pathLen = path.Length;
            int nextReference;
            currentToken = new ProviderSegment();
            currentToken.HadSpecialReference = path[0] == '/' && path[1] == '{';
            currentToken.NoPredecessor = offset == 0;
            do
            {
                currentToken.IndexFoundAt = offset;
                offset += ProviderSegment.Providers.Length;
                nextReference = path.IndexOf('{', offset);
                currentToken.HasReferenceSuccessor = nextReference > -1;
                currentToken.IsFullProvider = offset != nextReference;
                var tokenLength = nextReference > -1 ? nextReference - offset : pathLen - offset;
                currentToken.TokenValue = path.Substring(offset, Math.Max(0, tokenLength - 1));
                tokens.Add(currentToken);
                offset = path.IndexOf(ProviderSegment.Providers, offset + tokenLength);
                currentToken = new ProviderSegment();
            } while (offset > -1);
            return tokens;
        }
    }
}
