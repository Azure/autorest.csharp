// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Contains a batch of document write actions to send to the index. </summary>
    public partial class IndexBatch
    {
        /// <summary> Initializes a new instance of IndexBatch. </summary>
        /// <param name="actions"> The actions in the batch. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="actions"/> is null. </exception>
        public IndexBatch(IEnumerable<IndexAction> actions)
        {
            Argument.AssertNotNull(actions, nameof(actions));

            Actions = actions.ToList();
        }

        /// <summary> The actions in the batch. </summary>
        public IList<IndexAction> Actions { get; }
    }
}
