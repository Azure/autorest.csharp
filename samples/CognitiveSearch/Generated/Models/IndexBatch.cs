// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveSearch.Models
{
    /// <summary> Contains a batch of document write actions to send to the index. </summary>
    public partial class IndexBatch
    {
        /// <summary> Initializes a new instance of <see cref="IndexBatch"/>. </summary>
        /// <param name="actions"> The actions in the batch. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="actions"/> is null. </exception>
        public IndexBatch(IEnumerable<IndexAction> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }

            Actions = actions.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="IndexBatch"/>. </summary>
        /// <param name="actions"> The actions in the batch. </param>
        internal IndexBatch(IList<IndexAction> actions)
        {
            Actions = actions;
        }

        /// <summary> The actions in the batch. </summary>
        public IList<IndexAction> Actions { get; }
    }
}
