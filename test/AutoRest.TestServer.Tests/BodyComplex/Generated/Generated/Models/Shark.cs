// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace BodyComplex.Models.V20160229
{
    public partial class Shark
    {
        public int? Age { get; set; }
        public DateTime Birthday { get; private set; }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        private Shark()
        {
        }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        public Shark(DateTime birthday)
        {
            Birthday = birthday;
        }
    }
}
