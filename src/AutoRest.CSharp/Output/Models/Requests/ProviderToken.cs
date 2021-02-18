// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class ProviderToken
    {
        internal bool noPred;
        internal bool hasReferenceSuccessor;
        internal bool isFullProvider;
        internal string tokenValue;
        internal bool hadSpecialReference;
        internal bool isLastProvider;
        internal ProviderToken()
        {
            noPred = false;
            hasReferenceSuccessor = false;
            tokenValue = "";
            isFullProvider = false;
            isLastProvider = false;
            hadSpecialReference = false;
        }
    }
}