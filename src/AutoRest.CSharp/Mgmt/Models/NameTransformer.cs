// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Input.MgmtConfiguration;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class NameTransformer
    {
        private IReadOnlyDictionary<string, RenameRuleTarget> _renameRules;
        private Regex _regex;

        /// <summary>
        /// Instanciate a NameTranformer which usign the dictionary to tranform the abbreviations in this word to correct casing
        /// </summary>
        /// <param name="renameRules"></param>
        public NameTransformer(IReadOnlyDictionary<string, RenameRuleTarget> renameRules)
        {
            _renameRules = renameRules;
            _regex = BuildRegex(renameRules.Keys);
        }

        private static Regex BuildRegex(IEnumerable<string> renameItems)
        {
            var regexRawString = string.Join("|", renameItems);
            // we are building the regex that matches
            // 1. it starts with a lower case letter or a digit which is considered as the end of its previous word
            //    or it is at the beginning of this string
            //    or we hit a word separator including \W, _, ., @, -, spaces
            // 2. it either should match one of the candidates in the rename rules dictionary
            // 3. it should followed by a upper case letter which is considered as the beginning of next word
            //    or it is the end of this string
            //    or we hit a word separator including \W, _, ., @, -, spaces
            return new Regex(@$"([\W|_|\.|@|-|\s|\$\da-z]|^)({regexRawString})([\W|_|\.|@|-|\s|\$A-Z]|$)");
        }

        /// <summary>
        /// Parse the input name and produce a name with correct casing
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string EnsureNameCase(string name)
        {
            var builder = new StringBuilder();
            var strToMatch = name.FirstCharToUpperCase();
            var match = _regex.Match(strToMatch);
            while (match.Success)
            {
                // in our regular expression, the content we want to find is in the second group
                var matchGroup = match.Groups[2];
                var replaceValue = _renameRules[matchGroup.Value];
                // append everything between the beginning and the index of this match
                builder.Append(strToMatch.Substring(0, matchGroup.Index));
                // append the replaced value
                builder.Append(replaceValue.Value);
                // move to whatever is left unmatched
                strToMatch = strToMatch.Substring(matchGroup.Index + matchGroup.Length);
                match = _regex.Match(strToMatch);
            }
            if (strToMatch.Length > 0)
                builder.Append(strToMatch);

            return builder.ToString();
        }
    }
}
