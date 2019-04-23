using System;
using Hangfire;

namespace Stashbox.Hangfire
{
    internal class StashboxJobActivatorScope : JobActivatorScope
    {
        private readonly IDependencyResolver scope;

        public StashboxJobActivatorScope(IDependencyResolver scope)
        {
            this.scope = scope;
        }

        public override object Resolve(Type type) => this.scope.Resolve(type);

        public override void DisposeScope() => this.scope.Dispose();
    }
}
