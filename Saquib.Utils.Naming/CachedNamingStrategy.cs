using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Saquib.Utils.Naming {
    /// <summary>
    /// Caches all calls to the underlying naming strategy.
    /// </summary>
    public sealed class CachedNamingStrategy : NamingStrategy {
        private readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();
        private readonly NamingStrategy _inner;

        public CachedNamingStrategy( NamingStrategy inner ) {
            _inner = inner ?? throw new ArgumentNullException( nameof( inner ) );
        }

        public override string Apply( string name ) => _cache.GetOrAdd( name, _inner.Apply );
    }
}