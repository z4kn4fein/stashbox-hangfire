using System;
using Hangfire;
using Hangfire.Server;

namespace Stashbox.Hangfire
{
    public class StashboxJobActivator : JobActivator
    {
        private readonly IDependencyResolver container;

        public StashboxJobActivator(IDependencyResolver container)
        {
            this.container = container;
        }

        public override object ActivateJob(Type jobType) =>
            this.container.Resolve(jobType);

        public override JobActivatorScope BeginScope(JobActivatorContext context) =>
            new StashboxJobActivatorScope(this.container.BeginScope());

        public override JobActivatorScope BeginScope(PerformContext context) =>
            new StashboxJobActivatorScope(this.container.BeginScope());
    }
}
