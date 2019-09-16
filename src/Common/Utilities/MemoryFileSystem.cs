// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRest.Core.Utilities
{
    public class MemoryFileSystem : IDisposable
    {
        private readonly Dictionary<string, StringBuilder> _virtualStore = new Dictionary<string, StringBuilder>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _virtualStore?.Clear();
            }
        }
    }
}
