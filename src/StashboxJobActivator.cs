using System;
using Hangfire;
using Hangfire.Server;

namespace Stashbox.Hangfire
{
    /// <summary>
    /// Used to resolve job dependencies with Stashbox.
    /// </summary>
    public class StashboxJobActivator : JobActivator
    {
        private readonly IDependencyResolver container;

        /// <summary>
        /// Constructs a new <see cref="StashboxJobActivator"/>.
        /// </summary>
        /// <param name="container">The nested Stashbox dependency resolver used to resolve job dependencies.</param>
        public StashboxJobActivator(IDependencyResolver container)
        {
            this.container = container;
        }

        /// <inheritdoc />
        public override object ActivateJob(Type jobType) =>
            this.container.Resolve(jobType);

        /// <inheritdoc />
        public override JobActivatorScope BeginScope(JobActivatorContext context) =>
            new StashboxJobActivatorScope(this.container.BeginScope());

        /// <inheritdoc />
        public override JobActivatorScope BeginScope(PerformContext context) =>
            new StashboxJobActivatorScope(this.container.BeginScope());
    }
}
